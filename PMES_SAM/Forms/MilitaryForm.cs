using Domain.Repository;
using Infra.Model.Data;
using Infra.Model.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Infra.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infra.Helpers;

namespace PMES_SAM.Forms
{
    public partial class MilitaryForm : Form
    {
        private byte ableToEdit = 0;
        private int currentRow;
        private Point lastLocation;
        ApplicationDbContext _context;

        ILogInterface _log;
        IMilitaryInterface militaries;
        IUsuarioInterface users;

        public MilitaryForm(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;

            militaries = new IMilitarRepository(_context);
            users = new IUsuarioRepository(_context);
            _log = new ILogRepository(_context);
        }
        private void LoadComboBox()
        {
            for (int i = 0; i <= Enum.GetValues(typeof(Posto)).Length - 1; i++)
            {
                cbPostos.Items.Add(EnumHelper.GetDescription((Posto)i));
            }

            cbPostos.SelectedIndex = 0;

            for (int i = 0; i <= Enum.GetValues(typeof(Curso)).Length - 1; i++)
            {
                cbCurso.Items.Add((Curso)i);
            }

            cbCurso.SelectedIndex = 1;
        }
        private void pbBack_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private async void ctxDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region CHECKINGS
                if (dgvMilitaries.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Selecione ao menos uma linha para excluir!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(MessageBox.Show($"Tem certeza que deseja excluir {dgvMilitaries.SelectedRows.Count} registro(s)?", "Excluindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes))
                {
                    return;
                }
                #endregion

                for (int i = 0; i < dgvMilitaries.SelectedRows.Count; i++)
                {
                    if (int.TryParse(dgvMilitaries.SelectedRows[i].Cells[0].Value.ToString(), out int id))
                    {
                        if (await CheckCautelas(id))
                        {
                            MessageBox.Show("Impossível excluir registro de Militar enquanto houver cautelas pendentes no registro do mesmo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Usuario curUser = await _context.Usuario.Where(x => x.IdMilitar.Equals(id)).FirstOrDefaultAsync();
                        if (curUser != null)
                        {
                            if (MessageBox.Show($"O usuário {curUser.User} foi encontrado atrelado a esse registro de militar. Caso prossiga com a exclusão, o usuário também será excluído. Deseja prosseguir?", "Excluindo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
                            {
                                await users.Remove(curUser.Id);
                                await militaries.Remove(id);

                                await _log.Add($"O militar {curUser.Militar.Nome}({curUser.Militar.Funcional}) foi REMOVIDO do sistema.");
                                await _log.Add($"O usuário {curUser.User} foi REMOVIDO do sistema.");
                            }
                        }
                        else
                        {
                            await militaries.Remove(id);
                            await _log.Add($"O militar {curUser.Militar.Nome}({curUser.Militar.Funcional}) foi REMOVIDO do sistema.");
                        }
                    }

                    await LoadTable();
                    Clear();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async Task<bool> CheckCautelas(int id)
        {
            try
            {
                int count = await _context.Cautela.Where(x => x.DataDevolucao == default && x.IdMilitar.Equals(id)).CountAsync();

                if (count > 0)
                    return true;

                return false;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }
        private void Clear()
        {
            tbName.Clear();
            tbNum.Clear();
            tbNumFunc.Clear();
            tbPel.Clear();
            tbPin.Clear();
        }
        private async void MilitaryForm_Load(object sender, EventArgs e)
        {
            await LoadTable();
            LoadComboBox();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((await _context.Militar.Where(x => x.Funcional.Equals(tbNumFunc.Text.Trim())).ToListAsync()).Count > 0)
                {
                    MessageBox.Show("Já existe registro com este número funcional.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNumFunc.Focus();

                    return;
                }

                if (tbPin.Text.Length < 4)
                {
                    MessageBox.Show("O PIN precisa ter ao menos 4 dígitos.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Militar militar = new Militar();

                militar.Nome = tbName.Text.ToUpper().Trim();
                militar.Numero = int.Parse(string.IsNullOrEmpty(tbNum.Text.Trim()) ? "0" : tbNum.Text.Trim());
                militar.Pelotao = string.IsNullOrEmpty(tbPel.Text.Trim()) ? "0" : tbPel.Text.Trim();
                militar.Posto = EnumHelper.GetEnum<Posto>(cbPostos.SelectedItem.ToString());
                militar.PIN = Cryptography.GetMD5(tbPin.Text.Trim());
                militar.Funcional = tbNumFunc.Text.Trim();
                militar.Curso = (Curso)cbCurso.SelectedIndex;

                await militaries.Add(militar);
                await LoadTable();
                await _log.Add($"O militar {militar.Nome}({militar.Funcional}) foi ADICIONADO ao sistema.");


                Clear();
            }
            catch (Exception ex)
            {
                LogWriter.Write(ex.ToString());
                MessageBox.Show($"Erro no método Salvar -> MilitaryForm\n{ex.ToString()}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMilitaries.SelectedRows.Count > 0)
                {
                    if (ableToEdit <= 0)
                    {
                        btnUpdate.Enabled = false;
                        rbName.Enabled = false;
                        rbNumFunc.Enabled = false;
                        tbSearch.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnEdit.Text = "  Atualizar";

                        tbName.Text = dgvMilitaries.SelectedRows[0].Cells[3].Value.ToString();
                        tbNum.Text = dgvMilitaries.SelectedRows[0].Cells[4].Value.ToString();
                        tbNumFunc.Text = dgvMilitaries.SelectedRows[0].Cells[6].Value.ToString();
                        tbPel.Text = dgvMilitaries.SelectedRows[0].Cells[5].Value.ToString();
                        tbPin.Text = default;

                        cbCurso.SelectedIndex = (int)Enum.Parse(typeof(Curso), dgvMilitaries.SelectedRows[0].Cells[8].Value.ToString());
                        cbPostos.SelectedIndex = (int)Enum.Parse(typeof(Posto), dgvMilitaries.SelectedRows[0].Cells[2].Value.ToString());

                        tbPin.Focus();
                    }

                    ableToEdit++;

                    if (ableToEdit > 1)
                    {
                        await Update();

                        btnUpdate.Enabled = true;
                        rbName.Enabled = true;
                        rbNumFunc.Enabled = true;
                        tbSearch.Enabled = true;
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                        btnEdit.Text = "  Editar";
                        ableToEdit = 0;

                        Clear();
                        await LoadTable();
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma linha para editar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async new Task Update()
        {
            try
            {
                if (tbPin.Text.Length < 4)
                {
                    MessageBox.Show("O PIN precisa ter ao menos 4 dígitos.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = currentRow;

                Militar militar = await _context.Militar.FindAsync(id);

                if (militar != null)
                {
                    militar.Nome = tbName.Text.ToUpper().Trim();
                    militar.Numero = int.Parse(string.IsNullOrEmpty(tbNum.Text.Trim()) ? "0" : tbNum.Text.Trim());
                    militar.Pelotao = string.IsNullOrEmpty(tbPel.Text.Trim()) ? "0" : tbPel.Text.Trim();
                    militar.Posto = EnumHelper.GetEnum<Posto>(cbPostos.SelectedItem.ToString());
                    militar.PIN = Cryptography.GetMD5(tbPin.Text.Trim());
                    militar.Funcional = tbNumFunc.Text.Trim();
                    militar.Curso = (Curso)cbCurso.SelectedIndex;

                    await _context.SaveChangesAsync();
                    await _log.Add($"O militar {militar.Nome}({militar.Funcional}) foi ATUALIZADO no sistema.");
                }
                else
                {
                    MessageBox.Show("O atual militar não foi encontrado. Consulte a administração.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async Task LoadTable()
        {
            try
            {
                dgvMilitaries.DataSource = null;
                dgvMilitaries.Columns.Clear();
                dgvMilitaries.Refresh();
                dgvMilitaries.DataSource = await militaries.Get();

                FormatColumns();
            }
            catch (Exception ex)
            {
                LogWriter.Write(ex.ToString());
                MessageBox.Show($"Erro no método LoadTable -> MilitaryForm\n{ex.ToString()}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FormatColumns()
        {
            if (dgvMilitaries.Columns.Count <= 8)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = "Posto";
                column.HeaderText = "Posto";
                column.CellTemplate = dgvMilitaries.Columns[3].CellTemplate;

                dgvMilitaries.Columns.Insert(1, column);
            }

            dgvMilitaries.Columns[0].Visible = false;
            dgvMilitaries.Columns[2].Visible = false;
            dgvMilitaries.Columns[7].Visible = false;

            dgvMilitaries.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMilitaries.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMilitaries.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMilitaries.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMilitaries.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvMilitaries.Columns[1].HeaderText = "Posto/Graduação";
            dgvMilitaries.Columns[3].HeaderText = "Nome de Guerra";
            dgvMilitaries.Columns[4].HeaderText = "Nº de Curso";
            dgvMilitaries.Columns[5].HeaderText = "Pel Nº";
            dgvMilitaries.Columns[6].HeaderText = "Funcional Nº";

            for (int i = 0; i < dgvMilitaries.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvMilitaries.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else
                {
                    dgvMilitaries.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            foreach (DataGridViewRow row in dgvMilitaries.Rows)
            {
                Enum.TryParse(((Posto)row.Cells[2].Value).ToString(), out Posto posto);
                row.Cells[1].Value = EnumHelper.GetDescription(posto);
            }

            dgvMilitaries.ClearSelection();
        }
        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            tbPin.PasswordChar = tbPin.PasswordChar.Equals('*') ? '\0' : '*';
            tbPin.Update();
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await LoadTable();
            tbSearch.Clear();
        }
        private void tbPel_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) || !int.TryParse(tbPel.Text + ch, out int x))
            {
                e.Handled = true;
            }
        }
        private void tbNumFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) || !int.TryParse(tbNumFunc.Text + ch, out int x))
            {
                e.Handled = true;
            }
        }
        private void tbNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) || !int.TryParse(tbNum.Text + ch, out int x))
            {
                e.Handled = true;
            }
        }
        private void tbPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) || !int.TryParse(tbPin.Text + ch, out int x))
            {
                e.Handled = true;
            }
        }
        private void dgvMilitaries_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dgvMilitaries.HitTest(e.X, e.Y);
                    dgvMilitaries.ClearSelection();
                    dgvMilitaries.Rows[hti.RowIndex <= -1 ? 0 : hti.RowIndex].Selected = true;

                    dgvMilitaries_CellClick(null, null);

                    Point here = new Point((dgvMilitaries.Location.X - lastLocation.X) + e.X, (dgvMilitaries.Location.Y - lastLocation.Y) + e.Y);
                    ctxMenu.Show(this, here);
                }
            }
            catch (Exception) { }
        }
        private void dgvMilitaries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMilitaries.Rows.Count > 0)
            {
                currentRow = (int)dgvMilitaries.SelectedRows[0].Cells[0].Value;
            }
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
        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                tbNum.Focus();
            }
        }
        private void tbNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                tbPel.Focus();
            }
        }
        private void tbPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                tbNumFunc.Focus();
            }
        }
        private void tbPel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                tbPin.Focus();
            }
        }
        private void tbNumFunc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSave.PerformClick();
            }
        }

        private async void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tbSearch.Text.Trim() != string.Empty)
                {
                    var foundLogs = await (from i in _context.Militar where EF.Functions.Like(rbName.Checked ? i.Nome : i.Funcional, $"%{tbSearch.Text.Trim()}%") select i).ToListAsync();

                    if (foundLogs.Count > 0)
                    {
                        dgvMilitaries.Columns.Clear();
                        dgvMilitaries.DataSource = foundLogs;
                        dgvMilitaries.Rows[dgvMilitaries.Rows.Count - 1].Selected = true;
                        FormatColumns();
                    }
                }
                else
                {
                    btnUpdate.PerformClick();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }

        private void cbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurso.SelectedIndex > 0)
            {
                tbPel.Enabled = true;
                tbNum.Enabled = true;

                tbPel.BackColor = Color.WhiteSmoke;
                tbNum.BackColor = Color.WhiteSmoke;
            }
            else
            {
                tbPel.Enabled = false;
                tbNum.Enabled = false;

                tbPel.BackColor = Color.Gainsboro;
                tbNum.BackColor = Color.Gainsboro;

                tbPel.Clear();
                tbNum.Clear();
            }
        }
    }
}