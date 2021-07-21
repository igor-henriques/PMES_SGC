using Domain.Repository;
using Infra.Helpers;
using Infra.Model;
using Infra.Model.Data;
using Infra.Model.Enum;
using Microsoft.EntityFrameworkCore;
using PMES_SAM.Forms.UtilityForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMES_SAM.Forms
{
    public partial class NewCautelaForm : Form
    {
        ApplicationDbContext _context;

        ILogInterface _log;
        IMaterialInterface _material;
        ICautelaInterface _cautela;
        ICautelaMaterialInterface _cautelaMaterial;
        IUsuarioInterface _users;
        IUsuarioCredencialInterface _credentials;
        public NewCautelaForm(ApplicationDbContext context)
        {            
            InitializeComponent();

            _context = context;
            _material = new IMaterialRepository(context);
            _cautela = new ICautelaRepository(context);
            _cautelaMaterial = new ICautelaMaterialRepository(context);
            _log = new ILogRepository(_context);
            _users = new IUsuarioRepository(_context);
            _credentials = new IUsuarioCredencialRepository(_context);
        }
        private void pbBack_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await _credentials.CheckUserCredential(Credential.PerformCautela, await _users.GetLoggedUser()))
                {
                    MessageBox.Show("Você não possui permissão para realizar essa operação", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in dgvAvailableItems.SelectedRows)
                {
                    if (int.TryParse(row.Cells[0].Value.ToString(), out int id))
                    {
                        Material curMat = new Material
                        {
                            Id = id,
                            Code = row.Cells[2].Value.ToString(),
                            Nome = row.Cells[1].Value.ToString(),
                            Count = int.Parse(row.Cells[3].Value.ToString())
                        };

                        if (curMat.Count > 1)
                        {
                            AmountSelectForm selectCount = new AmountSelectForm(curMat);
                            selectCount.ShowDialog();

                            if (selectCount.Amount > 0)
                            {
                                int index = GetIndexMaterialOnGrid(dgvItemsCautelados, curMat);
                                if (index > -1)
                                {
                                    dgvItemsCautelados.Rows[index].Cells[3].Value = (int)dgvItemsCautelados.Rows[index].Cells[3].Value + selectCount.Amount;
                                }
                                else
                                {
                                    dgvItemsCautelados.Rows.Add(new object[] { curMat.Id, curMat.Nome, curMat.Code, selectCount.Amount });
                                }

                                row.Cells[3].Value = (int)row.Cells[3].Value - selectCount.Amount;

                                if ((int)row.Cells[3].Value <= 0)
                                    rowsToRemove.Add(row);
                            }                            
                        }
                        else if (curMat.Count.Equals(1) || curMat.IsUnique)
                        {
                            int index = GetIndexMaterialOnGrid(dgvItemsCautelados, curMat);
                            if (index > -1)
                            {
                                dgvItemsCautelados.Rows[index].Cells[3].Value = (int)dgvItemsCautelados.Rows[index].Cells[3].Value + 1;
                            }
                            else
                            {
                                dgvItemsCautelados.Rows.Add(new object[] { curMat.Id, curMat.Nome, curMat.Code, curMat.Count });
                            }
                            
                            rowsToRemove.Add(row);
                        }
                    }
                }

                rowsToRemove.ForEach(row => dgvAvailableItems.Rows.Remove(row));

                FormatFirstDGV();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in dgvItemsCautelados.SelectedRows)
                {
                    if (int.TryParse(row.Cells[0].Value.ToString(), out int id))
                    {
                        Material curMat = new Material
                        {
                            Id = id,
                            Code = row.Cells[2].Value.ToString(),
                            Nome = row.Cells[1].Value.ToString(),
                            Count = int.Parse(row.Cells[3].Value.ToString())
                        };

                        int index = GetIndexMaterialOnGrid(dgvAvailableItems, curMat);
                        if (index > -1)
                        {
                            dgvAvailableItems.Rows[index].Cells[3].Value = (int)dgvAvailableItems.Rows[index].Cells[3].Value + curMat.Count;
                        }
                        else
                        {
                            dgvAvailableItems.Rows.Add(new object[] { curMat.Id, curMat.Nome, curMat.Code, curMat.Count });
                        }
                        
                        rowsToRemove.Add(row);
                    }
                }

                rowsToRemove.ForEach(row => dgvItemsCautelados.Rows.Remove(row));

                FormatSecondDGV();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async void btnCautelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemsCautelados.RowCount <= 0)
                {
                    MessageBox.Show("Não há nenhum material sob cautela", "Selecione materiais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(tbNumFunc.Text.Trim()) || string.IsNullOrEmpty(tbPIN.Text.Trim()))
                {
                    MessageBox.Show("Há campos vazios.", "Preencha todos os campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Militar curMilitar = await _context.Militar.Where(x => x.Funcional.Equals(tbNumFunc.Text.Trim())).FirstOrDefaultAsync();
                if (curMilitar == null)
                {
                    MessageBox.Show($"Não há registro de militar com o Número Funcional {tbNumFunc.Text.Trim()}.", "Militar não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    tbNumFunc.Clear();
                    tbPIN.Clear();
                    tbNumFunc.Focus();

                    return;
                }

                if (curMilitar.PIN.Equals(Cryptography.GetMD5(tbPIN.Text.Trim())))
                {
                    if (MessageBox.Show(BuildTextMessage(curMilitar).ToUpper(), "Militar Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
                    {
                        List<string> logResult = new List<string>();

                        Cautela cautela = new Cautela
                        {
                            DataRetirada = DateTime.Now,
                            Militar = curMilitar,
                            IdMilitar = curMilitar.Id,
                            Materiais = BuildMaterials()
                        };

                        Cautela fromDbCautela = await _cautela.Add(cautela);
                        if (fromDbCautela != null)
                        {                            
                            await _cautelaMaterial.Add(fromDbCautela);
                            (await _cautelaMaterial.GetListMaterials(fromDbCautela.Id)).ForEach(curMat => logResult.Add($"{curMat.Material.Code} - {curMat.Material.Nome}({curMat.MaterialAmount}x)"));
                            await _log.Add($"O militar {curMilitar.Nome}({curMilitar.Funcional}) realizou CAUTELA dos materiais: {string.Join(", ", logResult)}");
                        }                                                

                        await LoadTable();
                        dgvItemsCautelados.Rows.Clear();

                        MessageBox.Show($"Materiais cautelados com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("PIN inválido. Tente novamente.", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    tbPIN.Clear();
                    tbPIN.Focus();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private string BuildTextMessage(Militar curMilitar)
        {
            try
            {
                return $"Militar encontrado: {EnumHelper.GetDescription(curMilitar.Posto)} {curMilitar.Nome} {(curMilitar.Numero > 0 ? $", Nº {curMilitar.Numero}" : $"FUNCIONAL Nº {curMilitar.Funcional}")} {(curMilitar.Pelotao != "0" ? $", {curMilitar.Pelotao}º PEL" : $"{string.Empty}")}. Confirma?";
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }
        private List<Material> BuildMaterials()
        {
            try
            {
                List<Material> mats = new List<Material>();

                foreach (DataGridViewRow row in dgvItemsCautelados.Rows)
                {
                    if (int.TryParse(row.Cells[0].Value.ToString(), out int id))
                    {
                        mats.Add(new Material
                        {
                            Id = id,
                            Code = row.Cells[2].Value.ToString(),
                            Nome = row.Cells[1].Value.ToString(),
                            Count = int.Parse(row.Cells[3].Value.ToString())
                        });
                    }
                }

                return mats;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }
        private async void NewCautelaForm_Load(object sender, EventArgs e)
        {
            await LoadTable();
            FormatSecondDGV();
        }
        private async Task LoadTable()
        {
            try
            {
                List<Material> availableMaterials = (await _material.Get()).Where(x => x.Count > 0).ToList();

                AutoCompleteStringCollection funcionalAutoComplete = new AutoCompleteStringCollection();
                (await _context.Militar.Select(x => x.Funcional).ToListAsync()).ForEach(funcional => funcionalAutoComplete.Add(funcional.ToString()));
                tbNumFunc.AutoCompleteCustomSource = funcionalAutoComplete;

                dgvAvailableItems.Rows.Clear();
                availableMaterials.ForEach(curMat => dgvAvailableItems.Rows.Add(new object[] { curMat.Id, curMat.Nome, curMat.Code, curMat.Count }));

                Clear();
                FormatFirstDGV();
            }
            catch (Exception ex)
            {
                LogWriter.Write(ex.ToString());
                MessageBox.Show($"Erro no método LoadTable -> MilitaryForm\n{ex.ToString()}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Clear()
        {
            tbNumFunc.Clear();
            tbPIN.Clear();

            dgvItemsCautelados.Rows.Clear();

            dgvItemsCautelados.ClearSelection();
            dgvAvailableItems.ClearSelection();
        }
        public void FormatFirstDGV()
        {
            dgvAvailableItems.Columns[0].Visible = false;

            dgvAvailableItems.Columns[1].HeaderText = "Nome";
            dgvAvailableItems.Columns[2].HeaderText = "Código";
            dgvAvailableItems.Columns[3].HeaderText = "Qnt";

            dgvAvailableItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAvailableItems.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAvailableItems.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            for (int i = 0; i < dgvAvailableItems.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvAvailableItems.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else
                {
                    dgvAvailableItems.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
        }
        public void FormatSecondDGV()
        {
            dgvItemsCautelados.Columns[0].Visible = false;

            dgvItemsCautelados.Columns[1].HeaderText = "Nome";
            dgvItemsCautelados.Columns[2].HeaderText = "Código";
            dgvItemsCautelados.Columns[3].HeaderText = "Qnt";

            dgvItemsCautelados.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvItemsCautelados.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvItemsCautelados.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            for (int i = 0; i < dgvItemsCautelados.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dgvItemsCautelados.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else
                {
                    dgvItemsCautelados.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                tbSearch.Clear();
                dgvAvailableItems.Rows.Clear();

                List<Material> availableMaterials = await GetWithoutLastro();
                List<Material> takenMaterials = GetItemsCauteladosOnGrid();

                for (int i = 0; i < availableMaterials.Count; i++)
                {
                    var curTakenMat = takenMaterials.Where(x => availableMaterials[i].Id.Equals(x.Id)).FirstOrDefault();

                    if (curTakenMat != null)
                    {
                        if (curTakenMat.Count > 1)
                        {
                            availableMaterials[i].Count -= curTakenMat.Count;

                            if (availableMaterials[i].Count <= 0)
                            {
                                availableMaterials[i] = null;
                            }
                        }
                        else
                        {
                            availableMaterials[i] = null;
                        }
                    }                    
                }

                availableMaterials = availableMaterials.Where(x => x != null).ToList();
                availableMaterials.ForEach(curMat => dgvAvailableItems.Rows.Add(new object[] { curMat.Id, curMat.Nome, curMat.Code, curMat.Count }));
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async Task<List<Material>> GetWithoutLastro()
        {
            List<Material> availableMaterials = (await _material.Get()).Where(x => x.Count > 0).ToList();
            List<Material> newObject = new List<Material>();

            foreach (var mat in availableMaterials)
            {
                newObject.Add(new Material
                {
                    Id = mat.Id,
                    Code = mat.Code,
                    Nome = mat.Nome,
                    Count = mat.Count
                });
            }

            return newObject;
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
        private void tbPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) || !int.TryParse(tbPIN.Text + ch, out int x))
            {
                e.Handled = true;
            }
        }
        private void tbNumFunc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                tbPIN.Focus();
            }
        }
        private void tbPIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnCautelar.PerformClick();
            }
        }
        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tbSearch.Text.Trim() != string.Empty)
                {
                    List<Material> availableMaterials = GetAvailableMaterialsOnGrid();

                    dgvAvailableItems.Rows.Clear();

                    var foundMaterials = from i in availableMaterials where i.Code.Contains(tbSearch.Text.Trim()) select i;

                    foreach (var material in foundMaterials.ToList())
                    {
                        dgvAvailableItems.Rows.Add(new object[] { material.Id, material.Nome, material.Code, material.Count });
                    }

                    if (dgvAvailableItems.Rows.Count > 0)
                    {
                        dgvAvailableItems.ClearSelection();
                        dgvAvailableItems.Rows[dgvAvailableItems.Rows.Count - 1].Selected = true;
                    }                        

                    FormatFirstDGV();
                }
                else
                {
                    btnUpdate.PerformClick();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private List<Material> GetAvailableMaterialsOnGrid()
        {
            try
            {
                List<Material> availableMaterials = new List<Material>();

                foreach (DataGridViewRow row in dgvAvailableItems.Rows)
                {
                    availableMaterials.Add(new Material
                    {
                        Id = int.Parse(row.Cells[0].Value.ToString()),
                        Code = row.Cells[2].Value.ToString(),
                        Nome = row.Cells[1].Value.ToString(),
                        Count = int.Parse(row.Cells[3].Value.ToString())
                    });
                }

                return availableMaterials;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }
        private List<Material> GetItemsCauteladosOnGrid()
        {
            try
            {
                List<Material> availableMaterials = new List<Material>();

                foreach (DataGridViewRow row in dgvItemsCautelados.Rows)
                {
                    availableMaterials.Add(new Material
                    {
                        Id = int.Parse(row.Cells[0].Value.ToString()),
                        Code = row.Cells[2].Value.ToString(),
                        Nome = row.Cells[1].Value.ToString(),
                        Count = int.Parse(row.Cells[3].Value.ToString())
                    });
                }

                return availableMaterials;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }
        private int GetIndexMaterialOnGrid(DataGridView dgv, Material curMat)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if ((int)dgv.Rows[i].Cells[0].Value == curMat.Id)
                    return i;
            }

            return -1;
        }
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnAdd.PerformClick();
            }
        }
        private void dgvAvailableItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnAdd.PerformClick();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                pbBack_Click(null, null);
                return true;
            }
            else if (keyData == Keys.F2)
            {
                btnRemove.PerformClick();
            }
            else if (keyData == Keys.F1)
            {
                btnAdd.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}