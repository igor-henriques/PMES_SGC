using Domain.Repository;
using Infra.Helpers;
using Infra.Model;
using Infra.Model.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMES_SAM.Forms.UtilityForms
{
    public partial class DevolucaoForm : Form
    {
        private Cautela _cautela;
        private ApplicationDbContext _context;
        private IMaterialInterface _material;
        private ICautelaMaterialInterface _cautelaMaterial;
        private IMilitaryInterface _militar;
        private ILogInterface _logs;
        private string numFuncional;

        public DevolucaoForm(ApplicationDbContext _context, Cautela cautela, string numFuncional)
        {
            InitializeComponent();

            tbPIN.Focus();
            _cautela = cautela;

            this._context = _context;
            this._material = new IMaterialRepository(_context);
            this._cautelaMaterial = new ICautelaMaterialRepository(_context);
            this._militar = new IMilitarRepository(_context);
            this._logs = new ILogRepository(_context);
            this.numFuncional = numFuncional;
        }
        private async void DevolucaoForm_Load(object sender, EventArgs e)
        {
            (await _cautelaMaterial.GetListMaterials(_cautela.Id)).ForEach(curMat => dgvItems.Rows.Add(new object[] { curMat.Id, curMat.Material.Nome, curMat.Material.Code, curMat.MaterialAmount, string.Empty, curMat.Material.IsUnique }));
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
        private void tbPIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                tbObservations.Focus();
            }
        }
        private async void btnState_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma a quantia de devolução dos itens?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
                {
                    #region VERIFY
                    foreach (DataGridViewRow row in dgvItems.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Value is null)
                            {
                                MessageBox.Show("Preencha todos os campos da tabela.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }


                    }

                    for (int i = 0; i < dgvItems.RowCount; i++)
                    {
                        for (int j = 0; j < dgvItems.Rows[i].Cells.Count; j++)
                        {
                            if (dgvItems.Rows[i].Cells[j].Value is null)
                            {
                                MessageBox.Show("Preencha todos os campos da tabela.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        if (int.Parse(dgvItems.Rows[i].Cells[3].Value.ToString()) < int.Parse(dgvItems.Rows[i].Cells[4].Value.ToString()))
                        {
                            MessageBox.Show("A quantidade devolvida não pode ser maior que a quantidade cautelada.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (tbPIN.Text.Length < 4)
                    {
                        MessageBox.Show("É necessário, no mínimo, 4 caracteres.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!(await _militar.Authenticate(numFuncional, tbPIN.Text)))
                    {
                        MessageBox.Show("PIN incorreto. Tente novamente.", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    #endregion

                    await UpdateRecords(GetMaterialsOnGrid());
                    MessageBox.Show("Materiais devolvidos com sucesso.", "Descautela", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                }                
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async Task UpdateRecords(List<Material> curMats)
        {
            try
            {
                List<string> logResult = new List<string>();

                Cautela curCautela = await _context.Cautela.Include(x => x.Militar).Where(x => x.Id.Equals(_cautela.Id)).FirstOrDefaultAsync();
                if (curCautela != null)
                {
                    curCautela.DataDevolucao = DateTime.Now;
                    curCautela.Observations = tbObservations.Text.ToUpper();
                }

                foreach (var curMat in curMats)
                {
                    var updateMat = await _material.Get(curMat.Id);
                    logResult.Add($"{curMat.Code} - {curMat.Nome}({curMat.Count}x)");
                    updateMat.Count += curMat.Count;
                }                

                await _logs.Add($"{curCautela.Militar.Nome.ToUpper()} realizou DEVOLUÇÃO dos seguintes materiais: {string.Join(", ", logResult)}");
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }            
        }
        private List<Material> GetMaterialsOnGrid()
        {
            try
            {
                List<Material> materials = new List<Material>();

                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    materials.Add(new Material
                    {
                        Id = int.Parse(row.Cells[0].Value.ToString()),
                        Code = row.Cells[2].Value.ToString(),
                        Nome = row.Cells[1].Value.ToString(),
                        Count = int.Parse(row.Cells[4].Value.ToString())
                    });
                }

                return materials;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void dgvItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvItems.RowCount > 0)
            {
                char ch = e.KeyChar;

                if (ch == (char)Keys.Back)
                {
                    e.Handled = false;
                }
                else if (!char.IsDigit(ch) || !int.TryParse(dgvItems.SelectedRows[0].Cells[4].Value.ToString() + ch, out int x))
                {
                    e.Handled = true;
                }
            }            
        }
        private void tbObservations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnAuthenticate.PerformClick();
            }
        }
    }
}