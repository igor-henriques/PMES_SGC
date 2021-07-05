
namespace PMES_SAM.Forms.UtilityForms
{
    partial class DevolucaoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevolucaoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbPIN = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnState = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbObservations = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "IDENTIFICAÇÃO VIA PIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbPIN
            // 
            this.tbPIN.BackColor = System.Drawing.Color.White;
            this.tbPIN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPIN.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPIN.Location = new System.Drawing.Point(12, 49);
            this.tbPIN.Name = "tbPIN";
            this.tbPIN.PasswordChar = '*';
            this.tbPIN.PlaceholderText = "PIN";
            this.tbPIN.Size = new System.Drawing.Size(256, 20);
            this.tbPIN.TabIndex = 1;
            this.tbPIN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPIN_KeyDown);
            this.tbPIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPIN_KeyPress);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(12, 71);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(256, 1);
            this.pictureBox3.TabIndex = 40;
            this.pictureBox3.TabStop = false;
            // 
            // btnState
            // 
            this.btnState.BackColor = System.Drawing.Color.White;
            this.btnState.FlatAppearance.BorderSize = 0;
            this.btnState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnState.Font = new System.Drawing.Font("Caviar Dreams", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnState.Image = ((System.Drawing.Image)(resources.GetObject("btnState.Image")));
            this.btnState.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnState.Location = new System.Drawing.Point(-3, 105);
            this.btnState.Name = "btnState";
            this.btnState.Size = new System.Drawing.Size(286, 55);
            this.btnState.TabIndex = 43;
            this.btnState.Text = "  Autenticar";
            this.btnState.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnState.UseVisualStyleBackColor = false;
            this.btnState.Click += new System.EventHandler(this.btnState_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(12, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 1);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // tbObservations
            // 
            this.tbObservations.BackColor = System.Drawing.Color.White;
            this.tbObservations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbObservations.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObservations.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbObservations.Location = new System.Drawing.Point(12, 81);
            this.tbObservations.Name = "tbObservations";
            this.tbObservations.PlaceholderText = "OBSERVAÇÕES";
            this.tbObservations.Size = new System.Drawing.Size(256, 20);
            this.tbObservations.TabIndex = 2;
            // 
            // DevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(280, 161);
            this.Controls.Add(this.tbObservations);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbPIN);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnState);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevolucaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução de Materiais";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPIN;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnState;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbObservations;
    }
}