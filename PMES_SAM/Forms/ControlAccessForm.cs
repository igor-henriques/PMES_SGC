using Domain.Repository;
using Infra.Helpers;
using Infra.Model;
using Infra.Model.Data;
using Infra.Model.Enum;
using Microsoft.EntityFrameworkCore;
using PMES_SAM.Forms.UtilityForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMES_SAM.Forms
{
    public partial class ControlAccessForm : Form
    {
        private byte ableToEdit = 0;
        private int currentRow;
        private Point lastLocation;

        ApplicationDbContext _context;
        CredentialSelectForm credentials;

        ILogInterface _log;
        IUsuarioInterface _users;
        IMilitaryInterface _militaries;
        IUsuarioCredencialInterface _credentials;
        public ControlAccessForm(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;

            _users = new UsuarioRepository(_context);
            _militaries = new MilitarRepository(_context);
            _log = new LogRepository(_context);
            _credentials = new UsuarioCredencialRepository(_context);
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private async void ControlAccessForm_Load(object sender, EventArgs e)
        {
            await LoadComboBox();
            FillGrid(await _users.Get());
        }
        private async Task LoadComboBox()
        {
            AutoCompleteStringCollection dadosMilitares = new AutoCompleteStringCollection();

            var militariesSource = await _militaries.Get();

            foreach (var militar in militariesSource.OrderBy(x => x.Nome).ThenBy(x => x.Funcional))
            {
                string item = militar.Funcional + " | " + militar.Nome;

                cbMilitar.Items.Add(item);
                dadosMilitares.Add(item);
            }

            cbMilitar.AutoCompleteCustomSource = dadosMilitares;
            cbMilitar.SelectedIndex = 0;
        }
        private void FillGrid(List<Usuario> users)
        {
            dgvUsers.Rows.Clear();

            users.ForEach(user => dgvUsers.Rows.Add(new object[]
            {
                user.Id,
                user.User,
                $"{EnumHelper.GetDescription(user.Militar.Posto).ToUpper()} {user.Militar.Nome}",
                user.Status,
                CreateGridButton()
            }));

            FormatColumns();
        }
        private DataGridViewButtonCell CreateGridButton()
        {
            try
            {
                DataGridViewButtonCell dgvButton = new DataGridViewButtonCell();

                dgvButton.Value = "Permissões";
                dgvButton.UseColumnTextForButtonValue = true;
                dgvButton.FlatStyle = FlatStyle.Flat;

                return dgvButton;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }
        public void FormatColumns()
        {            
            for (int i = 0; i < dgvUsers.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvUsers.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else
                {
                    dgvUsers.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            dgvUsers.ClearSelection();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = tbPassword.PasswordChar.Equals('*') ? '\0' : '*';
            tbPassword.Update();
        }        
        private async Task<Militar> GetMilitarByString(string info)
        {
            try
            {
                var splittedInfos = info.Split('|');

                string name = splittedInfos.Last().Trim();
                string funcional = splittedInfos.First().Trim();

                return await _context.Militar.Where(x => x.Nome.ToUpper().Trim().Equals(name.ToUpper().Trim())).Where(x => x.Funcional.Equals(funcional)).FirstOrDefaultAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return new Militar();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(tbUser.Text.Trim()) || string.IsNullOrEmpty(tbPassword.Text.Trim())))
                {
                    Militar selectedMilitar = await GetMilitarByString(cbMilitar.SelectedItem.ToString());

                    #region CHECKINGS
                    if (!await _credentials.CheckUserCredential(Credential.CreateUser, await _users.GetLoggedUser()))
                    {
                        MessageBox.Show("Você não possui permissão para realizar essa operação", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (_context.Usuario.Where(x => x.IdMilitar.Equals(selectedMilitar.Id)).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Já existe registro de usuário deste militar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbMilitar.Focus();
                        return;
                    }

                    if ((await _context.Usuario.Where(x => x.User.Equals(tbUser.Text.Trim())).ToListAsync()).Count > 0)
                    {
                        MessageBox.Show("Já existe registro com este usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbUser.Focus();
                        return;
                    }

                    if (tbPassword.Text.Length < 4)
                    {
                        MessageBox.Show("A senha precisa ter ao menos 4 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbPassword.Focus();
                        return;
                    }                    
                    #endregion

                    Usuario user = new Usuario();

                    user.User = tbUser.Text.Trim();
                    user.Password = Cryptography.GetMD5(tbPassword.Text);
                    user.Militar = selectedMilitar;
                    user.Status = UserLogin.Offline;

                    if (user.Militar != null)
                    {
                        user.IdMilitar = user.Militar.Id;

                        await _users.Add(user);
                        await _log.Add($"O usuário {user.User} foi ADICIONADO ao sistema.");

                        FillGrid(await _users.Get());
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Não há registro de militar com este posto/nome de guerra. Cheque o cadastro de militares.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Há campos vazios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        
        private async void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (dgvUsers.RowCount > 0)
                {
                    int userId = (int)dgvUsers.SelectedRows[0].Cells[0].Value;

                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        if (!await _credentials.CheckUserCredential(Credential.AccessCredential, await _users.GetLoggedUser()))
                        {
                            MessageBox.Show("Você não possui permissão para acessar esse módulo.", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        CredentialSelectForm credentialsForm = new CredentialSelectForm(userId, _context);
                        credentialsForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private void dgvMilitaries_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dgvUsers.HitTest(e.X, e.Y);
                    dgvUsers.ClearSelection();
                    dgvUsers.Rows[hti.RowIndex <= -1 ? 0 : hti.RowIndex].Selected = true;

                    dgvUsers_CellClick(null, null);

                    Point here = new Point((dgvUsers.Location.X - lastLocation.X) + e.X, (dgvUsers.Location.Y - lastLocation.Y) + e.Y);
                    ctxMenu.Show(this, here);
                }
            }
            catch (Exception)
            {

            }
        }
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.Rows.Count > 0)
            {
                currentRow = (int)dgvUsers.SelectedRows[0].Cells[0].Value;
            }
        }
        private void Clear()
        {
            tbUser.Clear();
            tbPassword.Clear();
            tbSearch.Clear();
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            FillGrid(await _users.Get());
            tbSearch.Clear();
        }
        private async void ctxDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await _credentials.CheckUserCredential(Credential.DeleteUser, await _users.GetLoggedUser()))
                {
                    MessageBox.Show("Você não possui permissão para realizar essa operação.", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (dgvUsers.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show($"Tem certeza que deseja excluir {dgvUsers.SelectedRows.Count} registro(s)?", "Excluindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
                    {
                        for (int i = 0; i < dgvUsers.SelectedRows.Count; i++)
                        {
                            if (int.TryParse(dgvUsers.SelectedRows[i].Cells[0].Value.ToString(), out int id))
                            {
                                if (await CheckCautelas(id))
                                {
                                    MessageBox.Show("Impossível excluir registro de Usuário enquanto houver cautelas pendentes no registro do mesmo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                Usuario curUser = await _users.Get(id);
                                if (curUser != null)
                                {
                                    if (!curUser.Status.Equals(UserLogin.Online))
                                    {
                                        await _credentials.RemoveAllFromUser(curUser.Id);
                                        await _users.Remove(curUser.Id);
                                        await _log.Add($"O usuário {curUser.User} foi REMOVIDO do sistema.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Impossível deletar registro do usuário enquanto estiver online", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }

                        FillGrid(await _users.Get());
                        Clear();
                    }
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async Task<bool> CheckCautelas(int id)
        {
            try
            {
                Usuario user = await _users.Get(id);
                int count = await _context.Cautela.Where(x => x.IdMilitar.Equals(user.IdMilitar) && x.DataDevolucao.Equals(default)).CountAsync();

                if (count > 0)
                    return true;

                return false;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                pbBack_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await _credentials.CheckUserCredential(Credential.AlterUser, await _users.GetLoggedUser()))
                {
                    MessageBox.Show("Você não possui permissão para realizar essa operação.", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (dgvUsers.SelectedRows.Count > 0)
                {
                    if (ableToEdit <= 0)
                    {
                        Militar curMilitar = (await _users.Get(GetRowId())).Militar;

                        tbUser.Enabled = false;
                        tbSearch.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnEdit.Text = "  Atualizar";

                        tbUser.Text = dgvUsers.SelectedRows[0].Cells[1].Value.ToString();
                        tbPassword.Text = default;                        
                        cbMilitar.SelectedItem = curMilitar.Funcional + " | " + curMilitar.Nome;

                        tbPassword.Focus();
                    }

                    ableToEdit++;

                    if (ableToEdit > 1)
                    {
                        if (tbPassword.Text.Length < 4)
                        {
                            MessageBox.Show("A senha precisa ter ao menos 4 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbPassword.Focus();
                            return;
                        }

                        if (!await CheckPrivilegedUsers())
                        {
                            return;
                        }

                        await Update();

                        tbUser.Enabled = true;
                        btnUpdate.Enabled = true;
                        tbSearch.Enabled = true;
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                        btnEdit.Text = "  Editar";
                        ableToEdit = 0;

                        Clear();
                        FillGrid(await _users.Get());
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma linha para editar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async Task<bool> CheckPrivilegedUsers()
        {
            try
            {
                
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return true;
        }
        private async new Task Update()
        {
            try
            {
                int id = currentRow;

                Usuario user = await _context.Usuario.FindAsync(id);

                if (user != null)
                {
                    user.User = tbUser.Text.Trim();
                    user.Password = Cryptography.GetMD5(tbPassword.Text);
                    user.Militar = await GetMilitarByString(cbMilitar.SelectedItem.ToString());
                    user.Status = user.Id.Equals((await _users.GetLoggedUser()).Id) ? UserLogin.Online : UserLogin.Offline;

                    await _context.SaveChangesAsync();
                    await _log.Add($"O usuário {user.User} foi ATUALIZADO no sistema.");
                }
                else
                {
                    MessageBox.Show("O atual militar não foi encontrado. Consulte a administração.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }

        private async void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tbSearch.Text.Trim() != string.Empty)
                {
                    var foundLogs = await (from i in _context.Usuario where EF.Functions.Like(i.User, $"%{tbSearch.Text.Trim()}%") select i).ToListAsync();

                    if (foundLogs.Count > 0)
                    {
                        FillGrid(foundLogs);
                        dgvUsers.Rows[dgvUsers.Rows.Count - 1].Selected = true;                        
                    }
                }
                else
                {
                    btnUpdate.PerformClick();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private int GetRowId() => (int)dgvUsers.SelectedRows[0].Cells[0].Value;
    }
}
