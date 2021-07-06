using Domain.Repository;
using Infra.Helpers;
using Infra.Model;
using Infra.Model.Data;
using Infra.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMES_SAM.Forms
{
    public partial class MateriaisForm : Form
    {
        private byte ableToEdit = 0;
        private int currentRow;
        private Point lastLocation;
        ApplicationDbContext _context;

        ILogInterface _log;
        IMaterialInterface _material;
        IUsuarioInterface _users;
        IUsuarioCredencialInterface _credentials;

        public MateriaisForm(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;
            _material = new IMaterialRepository(context);
            _log = new ILogRepository(_context);
            _users = new IUsuarioRepository(_context);
            _credentials = new IUsuarioCredencialRepository(_context);
        }
        private void Clear()
        {
            tbName.Clear();
            tbID.Clear();
            tbSearch.Clear();
        }

        private async void MateriaisForm_Load(object sender, EventArgs e)
        {
            await LoadTable();
        }
        private async Task LoadTable()
        {
            try
            {
                dgvItems.DataSource = null;
                dgvItems.Columns.Clear();
                dgvItems.Refresh();
                dgvItems.DataSource = await _material.Get();

                Clear();
                FormatColumns();
            }
            catch (Exception ex)
            {
                LogWriter.Write(ex.ToString());
                MessageBox.Show($"Erro no método LoadTable -> MilitaryForm\n{ex.ToString()}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await _credentials.CheckUserCredential(Credential.CreateMaterial, await _users.GetLoggedUser()))
                {
                    MessageBox.Show("Você não possui permissão para realizar essa operação", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (!string.IsNullOrEmpty(tbName.Text.Trim()))
                {
                    if (cbNoID.Checked)
                    {
                        tbID.Text = default;
                    }

                    Material mat = new Material
                    {
                        Nome = tbName.Text.ToUpper().Trim(),
                        Code = tbID.Text.Trim(),
                        Status = Infra.Model.Enum.Status.Disponível
                    };

                    if (await _context.Material.Where(x => x.Code.Equals(mat.Code)).Where(y => y.Nome.Equals(mat.Nome)).FirstOrDefaultAsync() != null)
                    {
                        MessageBox.Show("Já existe um material cadastrado com esse nome e código.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbID.Focus();
                        return;                        
                    }

                    await _material.Add(mat);
                    await _log.Add($"O material {mat.Nome}({mat.Code}) foi ADICIONADO ao sistema.");
                    await LoadTable();
                }
                else
                {
                    MessageBox.Show("O nome do material não pode ser vazio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await _credentials.CheckUserCredential(Credential.AlterMaterial, await _users.GetLoggedUser()))
                {
                    MessageBox.Show("Você não possui permissão para realizar essa operação", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (dgvItems.SelectedRows.Count > 0)
                {
                    if (ableToEdit <= 0)
                    {
                        rbName.Enabled = false;
                        rbCode.Enabled = false;
                        tbSearch.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnEdit.Text = "  Atualizar";

                        tbName.Text = dgvItems.SelectedRows[0].Cells[1].Value.ToString();
                        tbID.Text = dgvItems.SelectedRows[0].Cells[2].Value.ToString();
                    }

                    ableToEdit++;

                    if (ableToEdit > 1)
                    {
                        await Update();

                        rbName.Enabled = true;
                        rbCode.Enabled = true;
                        btnUpdate.Enabled = true;
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
                if (string.IsNullOrEmpty(tbName.Text.Trim()))
                {
                    MessageBox.Show("O nome do material não pode ser vazio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = currentRow;

                Material mat = await _context.Material.FindAsync(id);

                string oldCode = mat.Code;

                if (mat != null)
                {
                    mat.Nome = tbName.Text.ToUpper().Trim();
                    mat.Code = tbID.Text.Trim();                    
                    
                    await _context.SaveChangesAsync();
                    
                    if (oldCode != mat.Code)
                    {
                        await _log.Add($"O material {mat.Nome}({oldCode} => {mat.Code}) foi ATUALIZADO no sistema.");
                    }
                    else
                    {
                        await _log.Add($"O material {mat.Nome}({mat.Code}) foi ATUALIZADO no sistema.");
                    }                    
                }
                else
                {
                    MessageBox.Show("O atual militar não foi encontrado. Consulte a administração.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async void ctxDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await _credentials.CheckUserCredential(Credential.DeleteMaterial, await _users.GetLoggedUser()))
                {
                    MessageBox.Show("Você não possui permissão para realizar essa operação", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (dgvItems.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show($"Tem certeza que deseja excluir {dgvItems.SelectedRows.Count} registro(s)?", "Excluindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
                    {
                        for (int i = 0; i < dgvItems.SelectedRows.Count; i++)
                        {
                            if (int.TryParse(dgvItems.SelectedRows[i].Cells[0].Value.ToString(), out int id))
                            {
                                if (await CheckCautelas(id))
                                {
                                    MessageBox.Show("Impossível excluir registro de Material enquanto houver cautelas pendentes no registro do mesmo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                Material curMat = await _context.Material.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
                                if (curMat != null)
                                {
                                    await _material.Remove(id);
                                    await _log.Add($"O material {curMat.Nome}({curMat.Code}) foi REMOVIDO do sistema");
                                }
                            }
                        }                        

                        Clear();
                        await LoadTable();
                    }
                }
                else
                {
                    MessageBox.Show("Selecione ao menos uma linha para excluir!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async Task<bool> CheckCautelas(int id)
        {
            try
            {
                int count = await _context.Material.Where(x => x.Id.Equals(id) && x.Status == Infra.Model.Enum.Status.Cautelado).CountAsync();

                if (count > 0)
                    return true;

                return false;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }
        public void FormatColumns()
        {
            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[3].Visible = false;

            dgvItems.Columns[1].HeaderText = "Nome do Material";
            dgvItems.Columns[2].HeaderText = "Identificador";

            dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvItems.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dgvItems.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvItems.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else
                {
                    dgvItems.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            dgvItems.ClearSelection();
        }
        private void dgvItems_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dgvItems.HitTest(e.X, e.Y);
                    dgvItems.ClearSelection();
                    dgvItems.Rows[hti.RowIndex <= -1 ? 0 : hti.RowIndex].Selected = true;

                    dgvItems_CellClick(null, null);

                    Point here = new Point((dgvItems.Location.X - lastLocation.X) + e.X, (dgvItems.Location.Y - lastLocation.Y) + e.Y);
                    ctxMenu.Show(this, here);
                }
            }
            catch (Exception) { }
        }
        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItems.Rows.Count > 0)
            {
                currentRow = (int)dgvItems.SelectedRows[0].Cells[0].Value;
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
                tbID.Focus();
            }
        }
        private void pbBack_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void tbID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSave.PerformClick();
            }
        }

        private void cbNoID_MouseDown(object sender, MouseEventArgs e)
        {
            tbID.Enabled = cbNoID.Checked;
            tbID.BackColor = cbNoID.Checked ? Color.WhiteSmoke : Color.LightGray;
            tbID.Text = default;
        }

        private async void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tbSearch.Text.Trim() != string.Empty)
                {
                    var foundMaterials = from i in _context.Material where EF.Functions.Like(rbName.Checked ? i.Nome : i.Code, $"%{tbSearch.Text.Trim()}%") select i;
                    dgvItems.DataSource = await foundMaterials.ToListAsync();
                    dgvItems.Rows[dgvItems.Rows.Count - 1].Selected = true;
                    FormatColumns();
                }
                else
                {
                    btnUpdate.PerformClick();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await LoadTable();
            tbSearch.Clear();
        }
    }
}
