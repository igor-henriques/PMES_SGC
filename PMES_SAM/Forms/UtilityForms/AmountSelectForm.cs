using Infra.Model;
using System;
using System.Windows.Forms;

namespace PMES_SAM.Forms.UtilityForms
{
    public partial class AmountSelectForm : Form
    {
        public Material curMat { get; set; }
        public int Amount { get; set; } = 0;

        public AmountSelectForm(Material curMat)
        {
            InitializeComponent();

            this.curMat = curMat;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {            
            Amount = int.Parse(tbAmount.Text);

            if (Amount <= curMat.Count)
            {
                Close();
            }
            else
            {
                MessageBox.Show($"Não é possível cautelar quantidade maior que a disponível.\nQuantia disponível: {curMat.Count}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Amount = 0;
            }
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) || !int.TryParse(tbAmount.Text + ch, out int x))
            {
                e.Handled = true;
            }
        }

        private void tbAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnConfirm.PerformClick();
            }
        }
    }
}