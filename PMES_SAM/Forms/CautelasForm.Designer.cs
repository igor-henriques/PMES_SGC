
namespace PMES_SAM.Forms
{
    partial class CautelaForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CautelaForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtiPicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtfPicker = new System.Windows.Forms.DateTimePicker();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.rbMilitar = new System.Windows.Forms.RadioButton();
            this.tbNumFuncSearch = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbStatus = new System.Windows.Forms.RadioButton();
            this.rbMaterial = new System.Windows.Forms.RadioButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tbMaterialSearch = new System.Windows.Forms.TextBox();
            this.cbStatusSearch = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvCautelas = new System.Windows.Forms.DataGridView();
            this.tbGridId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbGridnumFunc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbGridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbGridRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbGridDevolucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGridItens = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnState = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCautelas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pbBack);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 71);
            this.panel1.TabIndex = 25;
            // 
            // pbBack
            // 
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(15, 19);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(37, 34);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 0;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Caviar Dreams", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(709, 34);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gerenciamento de Cautelas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Caviar Dreams", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(0, 210);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(665, 66);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "   Pesquisar";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtiPicker
            // 
            this.dtiPicker.CalendarFont = new System.Drawing.Font("Caviar Dreams", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtiPicker.Font = new System.Drawing.Font("Caviar Dreams", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtiPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtiPicker.Location = new System.Drawing.Point(67, 114);
            this.dtiPicker.Name = "dtiPicker";
            this.dtiPicker.Size = new System.Drawing.Size(130, 24);
            this.dtiPicker.TabIndex = 33;
            this.dtiPicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtiPicker_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(15, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 34;
            this.label2.Text = "Entre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(204, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 19);
            this.label4.TabIndex = 34;
            this.label4.Text = "e";
            // 
            // dtfPicker
            // 
            this.dtfPicker.CalendarFont = new System.Drawing.Font("Caviar Dreams", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtfPicker.Font = new System.Drawing.Font("Caviar Dreams", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtfPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfPicker.Location = new System.Drawing.Point(229, 114);
            this.dtfPicker.Name = "dtfPicker";
            this.dtfPicker.Size = new System.Drawing.Size(130, 24);
            this.dtfPicker.TabIndex = 33;
            this.dtfPicker.ValueChanged += new System.EventHandler(this.dtfPicker_ValueChanged);
            this.dtfPicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtiPicker_MouseDown);
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Font = new System.Drawing.Font("Caviar Dreams", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbDate.Location = new System.Drawing.Point(18, 80);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(108, 26);
            this.rbDate.TabIndex = 35;
            this.rbDate.Text = "Por data";
            this.toolTip1.SetToolTip(this.rbDate, "Configura a pesquisa por intervalo entre datas");
            this.rbDate.UseVisualStyleBackColor = true;
            // 
            // rbMilitar
            // 
            this.rbMilitar.AutoSize = true;
            this.rbMilitar.Font = new System.Drawing.Font("Caviar Dreams", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbMilitar.Location = new System.Drawing.Point(18, 156);
            this.rbMilitar.Name = "rbMilitar";
            this.rbMilitar.Size = new System.Drawing.Size(113, 26);
            this.rbMilitar.TabIndex = 35;
            this.rbMilitar.Text = "Por militar";
            this.toolTip1.SetToolTip(this.rbMilitar, "Configura a pesquisa por militar");
            this.rbMilitar.UseVisualStyleBackColor = true;
            // 
            // tbNumFuncSearch
            // 
            this.tbNumFuncSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNumFuncSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNumFuncSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNumFuncSearch.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbNumFuncSearch.Location = new System.Drawing.Point(18, 186);
            this.tbNumFuncSearch.Name = "tbNumFuncSearch";
            this.tbNumFuncSearch.PlaceholderText = "Número Funcional";
            this.tbNumFuncSearch.Size = new System.Drawing.Size(341, 20);
            this.tbNumFuncSearch.TabIndex = 37;
            this.tbNumFuncSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbNumFuncSearch_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(18, 208);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 1);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // rbStatus
            // 
            this.rbStatus.AutoSize = true;
            this.rbStatus.Font = new System.Drawing.Font("Caviar Dreams", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbStatus.Location = new System.Drawing.Point(425, 80);
            this.rbStatus.Name = "rbStatus";
            this.rbStatus.Size = new System.Drawing.Size(115, 26);
            this.rbStatus.TabIndex = 35;
            this.rbStatus.Text = "Por Status";
            this.toolTip1.SetToolTip(this.rbStatus, "Configura a pesquisa por status do material");
            this.rbStatus.UseVisualStyleBackColor = true;
            // 
            // rbMaterial
            // 
            this.rbMaterial.AutoSize = true;
            this.rbMaterial.Font = new System.Drawing.Font("Caviar Dreams", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbMaterial.Location = new System.Drawing.Point(425, 156);
            this.rbMaterial.Name = "rbMaterial";
            this.rbMaterial.Size = new System.Drawing.Size(133, 26);
            this.rbMaterial.TabIndex = 35;
            this.rbMaterial.Text = "Por material";
            this.toolTip1.SetToolTip(this.rbMaterial, "Configura a pesquisa por material");
            this.rbMaterial.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(425, 208);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(285, 1);
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // tbMaterialSearch
            // 
            this.tbMaterialSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMaterialSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMaterialSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbMaterialSearch.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbMaterialSearch.Location = new System.Drawing.Point(425, 186);
            this.tbMaterialSearch.Name = "tbMaterialSearch";
            this.tbMaterialSearch.PlaceholderText = "Código";
            this.tbMaterialSearch.Size = new System.Drawing.Size(285, 20);
            this.tbMaterialSearch.TabIndex = 37;
            this.tbMaterialSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbMaterialSearch_MouseDown);
            // 
            // cbStatusSearch
            // 
            this.cbStatusSearch.BackColor = System.Drawing.SystemColors.Window;
            this.cbStatusSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusSearch.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbStatusSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbStatusSearch.FormattingEnabled = true;
            this.cbStatusSearch.Items.AddRange(new object[] {
            "PENDENTE",
            "PROCESSADO"});
            this.cbStatusSearch.Location = new System.Drawing.Point(425, 109);
            this.cbStatusSearch.Name = "cbStatusSearch";
            this.cbStatusSearch.Size = new System.Drawing.Size(285, 28);
            this.cbStatusSearch.TabIndex = 39;
            this.cbStatusSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbStatusSearch_MouseDown);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(686, 232);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(24, 24);
            this.btnUpdate.TabIndex = 40;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvCautelas
            // 
            this.dgvCautelas.AllowUserToAddRows = false;
            this.dgvCautelas.AllowUserToDeleteRows = false;
            this.dgvCautelas.AllowUserToResizeColumns = false;
            this.dgvCautelas.AllowUserToResizeRows = false;
            this.dgvCautelas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCautelas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCautelas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCautelas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCautelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCautelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tbGridId,
            this.tbGridnumFunc,
            this.tbGridName,
            this.tbGridRetirada,
            this.tbGridDevolucao,
            this.btnGridItens});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCautelas.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCautelas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCautelas.GridColor = System.Drawing.Color.White;
            this.dgvCautelas.Location = new System.Drawing.Point(0, 274);
            this.dgvCautelas.MultiSelect = false;
            this.dgvCautelas.Name = "dgvCautelas";
            this.dgvCautelas.ReadOnly = true;
            this.dgvCautelas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvCautelas.RowHeadersVisible = false;
            this.dgvCautelas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCautelas.RowTemplate.Height = 25;
            this.dgvCautelas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCautelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCautelas.ShowCellErrors = false;
            this.dgvCautelas.ShowEditingIcon = false;
            this.dgvCautelas.ShowRowErrors = false;
            this.dgvCautelas.Size = new System.Drawing.Size(733, 287);
            this.dgvCautelas.TabIndex = 41;
            this.dgvCautelas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCautelas_CellContentClick);
            // 
            // tbGridId
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tbGridId.DefaultCellStyle = dataGridViewCellStyle2;
            this.tbGridId.HeaderText = "Id";
            this.tbGridId.Name = "tbGridId";
            this.tbGridId.ReadOnly = true;
            this.tbGridId.Visible = false;
            this.tbGridId.Width = 28;
            // 
            // tbGridnumFunc
            // 
            this.tbGridnumFunc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tbGridnumFunc.DefaultCellStyle = dataGridViewCellStyle3;
            this.tbGridnumFunc.HeaderText = "Funcional";
            this.tbGridnumFunc.Name = "tbGridnumFunc";
            this.tbGridnumFunc.ReadOnly = true;
            this.tbGridnumFunc.Width = 97;
            // 
            // tbGridName
            // 
            this.tbGridName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tbGridName.DefaultCellStyle = dataGridViewCellStyle4;
            this.tbGridName.HeaderText = "Nome";
            this.tbGridName.Name = "tbGridName";
            this.tbGridName.ReadOnly = true;
            this.tbGridName.Width = 75;
            // 
            // tbGridRetirada
            // 
            this.tbGridRetirada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tbGridRetirada.DefaultCellStyle = dataGridViewCellStyle5;
            this.tbGridRetirada.HeaderText = "Retirada";
            this.tbGridRetirada.Name = "tbGridRetirada";
            this.tbGridRetirada.ReadOnly = true;
            // 
            // tbGridDevolucao
            // 
            this.tbGridDevolucao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tbGridDevolucao.DefaultCellStyle = dataGridViewCellStyle6;
            this.tbGridDevolucao.HeaderText = "Devolução";
            this.tbGridDevolucao.Name = "tbGridDevolucao";
            this.tbGridDevolucao.ReadOnly = true;
            // 
            // btnGridItens
            // 
            this.btnGridItens.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.btnGridItens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGridItens.HeaderText = "Itens Cautelados";
            this.btnGridItens.Name = "btnGridItens";
            this.btnGridItens.ReadOnly = true;
            this.btnGridItens.Text = "Verificar";
            this.btnGridItens.UseColumnTextForButtonValue = true;
            // 
            // btnState
            // 
            this.btnState.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnState.FlatAppearance.BorderSize = 0;
            this.btnState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnState.Font = new System.Drawing.Font("Caviar Dreams", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnState.Image = ((System.Drawing.Image)(resources.GetObject("btnState.Image")));
            this.btnState.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnState.Location = new System.Drawing.Point(-1, 559);
            this.btnState.Name = "btnState";
            this.btnState.Size = new System.Drawing.Size(735, 64);
            this.btnState.TabIndex = 42;
            this.btnState.Text = "  Devolver Materiais";
            this.btnState.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnState.UseVisualStyleBackColor = false;
            this.btnState.Click += new System.EventHandler(this.btnState_Click);
            // 
            // CautelaForm
            // 
            this.AccessibleName = "Cautelas";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(733, 620);
            this.ControlBox = false;
            this.Controls.Add(this.dgvCautelas);
            this.Controls.Add(this.btnState);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cbStatusSearch);
            this.Controls.Add(this.tbMaterialSearch);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.tbNumFuncSearch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rbMilitar);
            this.Controls.Add(this.rbMaterial);
            this.Controls.Add(this.rbStatus);
            this.Controls.Add(this.rbDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtfPicker);
            this.Controls.Add(this.dtiPicker);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CautelaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle Administrativo - Gerenciamento de Cautelas - Seção de Armamento";
            this.Load += new System.EventHandler(this.CautelasForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCautelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtiPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtfPicker;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.RadioButton rbMilitar;
        private System.Windows.Forms.TextBox tbNumFuncSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbStatus;
        private System.Windows.Forms.RadioButton rbMaterial;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbMaterialSearch;
        private System.Windows.Forms.ComboBox cbStatusSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvCautelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbGridId;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbGridnumFunc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbGridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbGridRetirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbGridDevolucao;
        private System.Windows.Forms.DataGridViewButtonColumn btnGridItens;
        private System.Windows.Forms.Button btnState;
    }
}