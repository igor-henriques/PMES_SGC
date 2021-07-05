using Infra.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMES_SAM.Forms.UtilityForms
{
    public partial class DevolucaoForm : Form
    {
        public string PIN { get; set; }
        public string Observations { get; set; }
        public DevolucaoForm()
        {
            InitializeComponent();

            tbPIN.Focus();
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

        }

        private void btnState_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbPIN.Text))
                {
                    if (tbPIN.Text.Length >= 4)
                    {
                        PIN = tbPIN.Text.Trim();
                        Observations = tbObservations.Text.Trim();

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("É necessário, no mínimo, 4 caracteres.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("O campo PIN não pode ser vazio.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
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
    }
}
