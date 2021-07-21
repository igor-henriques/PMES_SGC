using Domain.Repository;
using Infra.Helpers;
using Infra.Model;
using Infra.Model.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PMES_SAM.Forms
{
    public partial class Material_Cautela_Form : Form
    {
        private int idCautela { get; set; }
        private ICautelaMaterialInterface _cautelaMaterial { get; set; }
        private ApplicationDbContext _context { get; set; }

        public Material_Cautela_Form(int idCautela, ApplicationDbContext _context)
        {
            InitializeComponent();

            this.idCautela = idCautela;
            this._context = _context;
            this._cautelaMaterial = new ICautelaMaterialRepository(_context);
        }

        private void Material_Cautela_Form_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
        private async void LoadTable()
        {
            try
            {
                dgvItems.Rows.Clear();

                (await _cautelaMaterial.GetListMaterials(idCautela)).ForEach(curMat => dgvItems.Rows.Add(new object[] { curMat.Id, curMat.Material.Nome, curMat.Material.Code, curMat.MaterialAmount }));                

                FormatColumns();
            }
            catch (Exception ex)
            {
                LogWriter.Write(ex.ToString());
                MessageBox.Show($"Erro no método LoadTable -> Material_Cautela_Form\n{ex.ToString()}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvItems.RowCount > 0)
                {
                    dgvItems.SelectedRows[0].DefaultCellStyle.BackColor = dgvItems.SelectedRows[0].DefaultCellStyle.BackColor.Equals(Color.AliceBlue) ? Color.LightCoral : Color.AliceBlue;
                    dgvItems.ClearSelection();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        public void FormatColumns()
        {         
            for (int i = 0; i < dgvItems.RowCount; i++)
            {
                dgvItems.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
            }

            dgvItems.ClearSelection();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
