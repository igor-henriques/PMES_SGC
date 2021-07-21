
namespace PMES_SAM.Forms
{
    partial class MilitaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MilitaryForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPin = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbPostos = new System.Windows.Forms.ComboBox();
            this.dgvMilitaries = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tbPel = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tbNum = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tbNumFunc = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.rbNumFunc = new System.Windows.Forms.RadioButton();
            this.cbCurso = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilitaries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowPassword.BackgroundImage")));
            this.btnShowPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowPassword.FlatAppearance.BorderSize = 0;
            this.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPassword.Location = new System.Drawing.Point(723, 150);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(23, 23);
            this.btnShowPassword.TabIndex = 23;
            this.btnShowPassword.UseVisualStyleBackColor = true;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbName.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbName.Location = new System.Drawing.Point(19, 150);
            this.tbName.Name = "tbName";
            this.tbName.PlaceholderText = "Nome de Guerra";
            this.tbName.Size = new System.Drawing.Size(151, 20);
            this.tbName.TabIndex = 3;
            this.toolTip.SetToolTip(this.tbName, "Nome de Guerra");
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            // 
            // tbPin
            // 
            this.tbPin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbPin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbPin.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPin.Location = new System.Drawing.Point(641, 150);
            this.tbPin.Name = "tbPin";
            this.tbPin.PasswordChar = '*';
            this.tbPin.PlaceholderText = "PIN";
            this.tbPin.Size = new System.Drawing.Size(75, 20);
            this.tbPin.TabIndex = 7;
            this.toolTip.SetToolTip(this.tbPin, "Código particular utilizado para cautelar itens na SAM");
            this.tbPin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPin_KeyDown);
            this.tbPin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPIN_KeyPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(641, 172);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(75, 1);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(19, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 1);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // cbPostos
            // 
            this.cbPostos.BackColor = System.Drawing.SystemColors.Window;
            this.cbPostos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPostos.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPostos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbPostos.FormattingEnabled = true;
            this.cbPostos.Location = new System.Drawing.Point(19, 104);
            this.cbPostos.Name = "cbPostos";
            this.cbPostos.Size = new System.Drawing.Size(332, 28);
            this.cbPostos.TabIndex = 1;
            // 
            // dgvMilitaries
            // 
            this.dgvMilitaries.AllowUserToAddRows = false;
            this.dgvMilitaries.AllowUserToDeleteRows = false;
            this.dgvMilitaries.AllowUserToResizeColumns = false;
            this.dgvMilitaries.AllowUserToResizeRows = false;
            this.dgvMilitaries.BackgroundColor = System.Drawing.Color.White;
            this.dgvMilitaries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMilitaries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMilitaries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMilitaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMilitaries.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMilitaries.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMilitaries.GridColor = System.Drawing.Color.White;
            this.dgvMilitaries.Location = new System.Drawing.Point(0, 225);
            this.dgvMilitaries.Name = "dgvMilitaries";
            this.dgvMilitaries.ReadOnly = true;
            this.dgvMilitaries.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvMilitaries.RowHeadersVisible = false;
            this.dgvMilitaries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMilitaries.RowTemplate.Height = 25;
            this.dgvMilitaries.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMilitaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMilitaries.ShowCellErrors = false;
            this.dgvMilitaries.ShowEditingIcon = false;
            this.dgvMilitaries.ShowRowErrors = false;
            this.dgvMilitaries.Size = new System.Drawing.Size(766, 294);
            this.dgvMilitaries.TabIndex = 10;
            this.dgvMilitaries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMilitaries_CellClick);
            this.dgvMilitaries.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMilitaries_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(16, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Graduação/Posto";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(309, 172);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(82, 1);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // tbPel
            // 
            this.tbPel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbPel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbPel.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPel.Location = new System.Drawing.Point(309, 150);
            this.tbPel.Name = "tbPel";
            this.tbPel.PlaceholderText = "Pelotão";
            this.tbPel.Size = new System.Drawing.Size(82, 20);
            this.tbPel.TabIndex = 5;
            this.toolTip.SetToolTip(this.tbPel, "Pelotão");
            this.tbPel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPel_KeyDown);
            this.tbPel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPel_KeyPress);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.Location = new System.Drawing.Point(189, 172);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(102, 1);
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // tbNum
            // 
            this.tbNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNum.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbNum.Location = new System.Drawing.Point(189, 150);
            this.tbNum.Name = "tbNum";
            this.tbNum.PlaceholderText = "Nº de Curso";
            this.tbNum.Size = new System.Drawing.Size(102, 20);
            this.tbNum.TabIndex = 4;
            this.toolTip.SetToolTip(this.tbNum, "Nº de Curso");
            this.tbNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNum_KeyDown);
            this.tbNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNum_KeyPress);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Black;
            this.pictureBox5.Location = new System.Drawing.Point(409, 172);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(214, 1);
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // tbNumFunc
            // 
            this.tbNumFunc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNumFunc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNumFunc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNumFunc.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbNumFunc.Location = new System.Drawing.Point(409, 150);
            this.tbNumFunc.Name = "tbNumFunc";
            this.tbNumFunc.PlaceholderText = "Número Funcional";
            this.tbNumFunc.Size = new System.Drawing.Size(214, 20);
            this.tbNumFunc.TabIndex = 6;
            this.toolTip.SetToolTip(this.tbNumFunc, "Número Funcional");
            this.tbNumFunc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNumFunc_KeyDown);
            this.tbNumFunc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumFunc_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pbBack);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 71);
            this.panel1.TabIndex = 24;
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
            this.toolTip.SetToolTip(this.pbBack, "Voltar à área inicial. Atalho: ESC");
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Caviar Dreams", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(17, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(732, 34);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gerenciamento de Militares";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Black;
            this.pictureBox6.Location = new System.Drawing.Point(280, 548);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(436, 1);
            this.pictureBox6.TabIndex = 16;
            this.pictureBox6.TabStop = false;
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbSearch.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbSearch.Location = new System.Drawing.Point(280, 526);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceholderText = "Pesquisar";
            this.tbSearch.Size = new System.Drawing.Size(436, 20);
            this.tbSearch.TabIndex = 10;
            this.toolTip.SetToolTip(this.tbSearch, "Marque a opção ao lado para realizar a pesquisa nesta modalidade");
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Checked = true;
            this.rbName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbName.Location = new System.Drawing.Point(19, 531);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(114, 19);
            this.rbName.TabIndex = 8;
            this.rbName.TabStop = true;
            this.rbName.Text = "Nome de Guerra";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // rbNumFunc
            // 
            this.rbNumFunc.AutoSize = true;
            this.rbNumFunc.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbNumFunc.Location = new System.Drawing.Point(154, 531);
            this.rbNumFunc.Name = "rbNumFunc";
            this.rbNumFunc.Size = new System.Drawing.Size(95, 19);
            this.rbNumFunc.TabIndex = 9;
            this.rbNumFunc.Text = "Nº Funcional";
            this.rbNumFunc.UseVisualStyleBackColor = true;
            // 
            // cbCurso
            // 
            this.cbCurso.BackColor = System.Drawing.SystemColors.Window;
            this.cbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurso.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbCurso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCurso.FormattingEnabled = true;
            this.cbCurso.Location = new System.Drawing.Point(374, 104);
            this.cbCurso.Name = "cbCurso";
            this.cbCurso.Size = new System.Drawing.Size(342, 28);
            this.cbCurso.TabIndex = 2;
            this.cbCurso.SelectedIndexChanged += new System.EventHandler(this.cbCurso_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(371, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Curso";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(731, 530);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(20, 20);
            this.btnUpdate.TabIndex = 11;
            this.toolTip.SetToolTip(this.btnUpdate, "Atualiza a tabela de registros");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxUpdate,
            this.ctxDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(129, 48);
            this.ctxMenu.Text = "Menu";
            // 
            // ctxUpdate
            // 
            this.ctxUpdate.Image = ((System.Drawing.Image)(resources.GetObject("ctxUpdate.Image")));
            this.ctxUpdate.Name = "ctxUpdate";
            this.ctxUpdate.ShowShortcutKeys = false;
            this.ctxUpdate.Size = new System.Drawing.Size(128, 22);
            this.ctxUpdate.Text = "Atualizar";
            this.ctxUpdate.ToolTipText = "Alterar o registro do militar selecionado";
            this.ctxUpdate.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ctxDelete
            // 
            this.ctxDelete.Image = ((System.Drawing.Image)(resources.GetObject("ctxDelete.Image")));
            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ctxDelete.ShowShortcutKeys = false;
            this.ctxDelete.Size = new System.Drawing.Size(128, 22);
            this.ctxDelete.Text = "Excluir";
            this.ctxDelete.ToolTipText = "Deleta permanentemente o registro selecionado";
            this.ctxDelete.Click += new System.EventHandler(this.ctxDelete_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(585, 173);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(181, 54);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = " Excluir";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.ctxDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(381, 173);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(204, 54);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "  Editar";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Caviar Dreams", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(-10, 173);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(391, 55);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "   Salvar";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(255, 529);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(20, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 40;
            this.pictureBox7.TabStop = false;
            // 
            // MilitaryForm
            // 
            this.AccessibleName = "Militares";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(766, 561);
            this.ControlBox = false;
            this.Controls.Add(this.dgvMilitaries);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rbNumFunc);
            this.Controls.Add(this.rbName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnShowPassword);
            this.Controls.Add(this.tbNum);
            this.Controls.Add(this.tbPel);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.tbNumFunc);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbPin);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbCurso);
            this.Controls.Add(this.cbPostos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MilitaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle Administrativo - Gerenciamento de Militares - Seção de Armamento";
            this.Load += new System.EventHandler(this.MilitaryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilitaries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbPin;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbPostos;
        private System.Windows.Forms.DataGridView dgvMilitaries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbPel;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox tbNumFunc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.RadioButton rbNumFunc;
        private System.Windows.Forms.ComboBox cbCurso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
        private System.Windows.Forms.ToolStripMenuItem ctxUpdate;
        private System.Windows.Forms.Button btnTeste;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}