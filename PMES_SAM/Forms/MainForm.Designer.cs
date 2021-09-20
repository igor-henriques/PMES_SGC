
namespace PMES_SAM.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.newCautelaBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.cautelaBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.materialBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.militarBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlAccessBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.backupBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.DateDesc = new System.Windows.Forms.ToolStripStatusLabel();
            this.Date = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparator = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeDesc = new System.Windows.Forms.ToolStripStatusLabel();
            this.Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparator2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LoginDesc = new System.Windows.Forms.ToolStripStatusLabel();
            this.Login = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparator3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LogsDesc = new System.Windows.Forms.ToolStripStatusLabel();
            this.logsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.alblTitle = new System.Windows.Forms.Label();
            this.watchTimer = new System.Windows.Forms.Timer(this.components);
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteLog = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.AllowItemReorder = true;
            this.MenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.MenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MenuStrip.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCautelaBtn,
            this.cautelaBtn,
            this.materialBtn,
            this.militarBtn,
            this.ctrlAccessBtn,
            this.reportBtn,
            this.backupBtn,
            this.exitBtn});
            this.MenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.ShowItemToolTips = true;
            this.MenuStrip.Size = new System.Drawing.Size(840, 28);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip_ItemClicked);
            // 
            // newCautelaBtn
            // 
            this.newCautelaBtn.Image = ((System.Drawing.Image)(resources.GetObject("newCautelaBtn.Image")));
            this.newCautelaBtn.Name = "newCautelaBtn";
            this.newCautelaBtn.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.newCautelaBtn.Size = new System.Drawing.Size(129, 24);
            this.newCautelaBtn.Tag = "Nova Cautela";
            this.newCautelaBtn.Text = "Nova Cautela";
            this.newCautelaBtn.ToolTipText = "Inicia Nova Cautela de Materiais";
            // 
            // cautelaBtn
            // 
            this.cautelaBtn.Image = ((System.Drawing.Image)(resources.GetObject("cautelaBtn.Image")));
            this.cautelaBtn.Name = "cautelaBtn";
            this.cautelaBtn.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.cautelaBtn.Size = new System.Drawing.Size(95, 24);
            this.cautelaBtn.Tag = "Cautela";
            this.cautelaBtn.Text = "Cautelas";
            this.cautelaBtn.ToolTipText = "Área de Gerenciamento de Cautelas";
            // 
            // materialBtn
            // 
            this.materialBtn.Image = ((System.Drawing.Image)(resources.GetObject("materialBtn.Image")));
            this.materialBtn.Name = "materialBtn";
            this.materialBtn.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.materialBtn.Size = new System.Drawing.Size(99, 24);
            this.materialBtn.Tag = "Material";
            this.materialBtn.Text = "Materiais";
            this.materialBtn.ToolTipText = "Área de Gerenciamento de Registro de Materiais";
            // 
            // militarBtn
            // 
            this.militarBtn.Image = ((System.Drawing.Image)(resources.GetObject("militarBtn.Image")));
            this.militarBtn.Name = "militarBtn";
            this.militarBtn.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.militarBtn.Size = new System.Drawing.Size(95, 24);
            this.militarBtn.Tag = "Militar";
            this.militarBtn.Text = "Militares";
            this.militarBtn.ToolTipText = "Área de Gerenciamento de Registro de Militares";
            // 
            // ctrlAccessBtn
            // 
            this.ctrlAccessBtn.Image = ((System.Drawing.Image)(resources.GetObject("ctrlAccessBtn.Image")));
            this.ctrlAccessBtn.Name = "ctrlAccessBtn";
            this.ctrlAccessBtn.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.ctrlAccessBtn.Size = new System.Drawing.Size(169, 24);
            this.ctrlAccessBtn.Tag = "Acesso";
            this.ctrlAccessBtn.Text = "Controle de Acesso";
            this.ctrlAccessBtn.ToolTipText = "Área de Gerenciamento de Controle de Acesso";
            // 
            // reportBtn
            // 
            this.reportBtn.Image = ((System.Drawing.Image)(resources.GetObject("reportBtn.Image")));
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.reportBtn.Size = new System.Drawing.Size(98, 24);
            this.reportBtn.Tag = "Relatorio";
            this.reportBtn.Text = "Relatório";
            this.reportBtn.ToolTipText = "Exportar Relatório";
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // backupBtn
            // 
            this.backupBtn.Image = ((System.Drawing.Image)(resources.GetObject("backupBtn.Image")));
            this.backupBtn.Name = "backupBtn";
            this.backupBtn.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.backupBtn.Size = new System.Drawing.Size(87, 24);
            this.backupBtn.Tag = "Backup";
            this.backupBtn.Text = "Backup";
            this.backupBtn.ToolTipText = "Realiza um backup da base de dados";
            this.backupBtn.Click += new System.EventHandler(this.backupBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.exitBtn.Size = new System.Drawing.Size(62, 24);
            this.exitBtn.Tag = "Sobre";
            this.exitBtn.Text = "Sair";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DateDesc,
            this.Date,
            this.lblSeparator,
            this.TimeDesc,
            this.Time,
            this.lblSeparator2,
            this.LoginDesc,
            this.Login,
            this.lblSeparator3,
            this.LogsDesc,
            this.logsCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(840, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // DateDesc
            // 
            this.DateDesc.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DateDesc.Name = "DateDesc";
            this.DateDesc.Size = new System.Drawing.Size(37, 17);
            this.DateDesc.Text = "Data";
            // 
            // Date
            // 
            this.Date.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(0, 17);
            // 
            // lblSeparator
            // 
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(16, 17);
            this.lblSeparator.Text = " | ";
            // 
            // TimeDesc
            // 
            this.TimeDesc.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimeDesc.Name = "TimeDesc";
            this.TimeDesc.Size = new System.Drawing.Size(38, 17);
            this.TimeDesc.Text = "Hora";
            // 
            // Time
            // 
            this.Time.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(0, 17);
            // 
            // lblSeparator2
            // 
            this.lblSeparator2.Name = "lblSeparator2";
            this.lblSeparator2.Size = new System.Drawing.Size(16, 17);
            this.lblSeparator2.Text = " | ";
            // 
            // LoginDesc
            // 
            this.LoginDesc.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoginDesc.Name = "LoginDesc";
            this.LoginDesc.Size = new System.Drawing.Size(88, 17);
            this.LoginDesc.Text = "Entrou como";
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(0, 17);
            // 
            // lblSeparator3
            // 
            this.lblSeparator3.Name = "lblSeparator3";
            this.lblSeparator3.Size = new System.Drawing.Size(10, 17);
            this.lblSeparator3.Text = "|";
            // 
            // LogsDesc
            // 
            this.LogsDesc.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LogsDesc.Name = "LogsDesc";
            this.LogsDesc.Size = new System.Drawing.Size(37, 17);
            this.LogsDesc.Text = "Logs";
            // 
            // logsCount
            // 
            this.logsCount.Name = "logsCount";
            this.logsCount.Size = new System.Drawing.Size(0, 17);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(803, 516);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(20, 20);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // alblTitle
            // 
            this.alblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.alblTitle.Font = new System.Drawing.Font("Caviar Dreams", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.alblTitle.Location = new System.Drawing.Point(0, 28);
            this.alblTitle.Name = "alblTitle";
            this.alblTitle.Size = new System.Drawing.Size(840, 74);
            this.alblTitle.TabIndex = 1;
            this.alblTitle.Text = "Serviço do dia 00/00/0000";
            this.alblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // watchTimer
            // 
            this.watchTimer.Enabled = true;
            this.watchTimer.Interval = 1000;
            this.watchTimer.Tick += new System.EventHandler(this.watchTimer_Tick);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.BackColor = System.Drawing.Color.White;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbSearch.Location = new System.Drawing.Point(38, 513);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceholderText = "Pesquisar";
            this.tbSearch.Size = new System.Drawing.Size(747, 20);
            this.tbSearch.TabIndex = 30;
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbSearch_KeyUp);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BackColor = System.Drawing.Color.Black;
            this.pictureBox6.Location = new System.Drawing.Point(38, 534);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(747, 1);
            this.pictureBox6.TabIndex = 31;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(12, 516);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 40;
            this.pictureBox3.TabStop = false;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeColumns = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMain.GridColor = System.Drawing.Color.White;
            this.dgvMain.Location = new System.Drawing.Point(0, 102);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMain.RowTemplate.Height = 25;
            this.dgvMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.ShowCellErrors = false;
            this.dgvMain.ShowEditingIcon = false;
            this.dgvMain.ShowRowErrors = false;
            this.dgvMain.Size = new System.Drawing.Size(840, 406);
            this.dgvMain.TabIndex = 41;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            this.dgvMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMain_MouseDown);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxExport,
            this.btnDeleteLog});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(128, 48);
            this.ctxMenu.Text = "Menu";
            // 
            // ctxExport
            // 
            this.ctxExport.Image = ((System.Drawing.Image)(resources.GetObject("ctxExport.Image")));
            this.ctxExport.Name = "ctxExport";
            this.ctxExport.ShowShortcutKeys = false;
            this.ctxExport.Size = new System.Drawing.Size(127, 22);
            this.ctxExport.Text = "Exportar";
            this.ctxExport.ToolTipText = "Exporta as linhas selecionadas em arquivo";
            this.ctxExport.Click += new System.EventHandler(this.ctxExport_Click);
            // 
            // btnDeleteLog
            // 
            this.btnDeleteLog.Image = global::PMES_SAM.Properties.Resources.close_button;
            this.btnDeleteLog.Name = "btnDeleteLog";
            this.btnDeleteLog.Size = new System.Drawing.Size(127, 22);
            this.btnDeleteLog.Text = "Excluir";
            this.btnDeleteLog.Click += new System.EventHandler(this.btnDeleteLog_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(840, 561);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.alblTitle);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(856, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle Administrativo - Principal - Seção de Armamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cautelaBtn;
        private System.Windows.Forms.ToolStripMenuItem militarBtn;
        private System.Windows.Forms.ToolStripMenuItem materialBtn;
        private System.Windows.Forms.ToolStripMenuItem ctrlAccessBtn;
        private System.Windows.Forms.ToolStripMenuItem backupBtn;
        private System.Windows.Forms.ToolStripMenuItem reportBtn;
        private System.Windows.Forms.ToolStripMenuItem exitBtn;
        private System.Windows.Forms.StatusStrip statusStripp;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem newCautelaBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label alblTitle;
        private System.Windows.Forms.Timer watchTimer;
        private System.Windows.Forms.ToolStripStatusLabel DateDesc;
        private System.Windows.Forms.ToolStripStatusLabel Date;
        private System.Windows.Forms.ToolStripStatusLabel TimeDesc;
        private System.Windows.Forms.ToolStripStatusLabel Time;
        private System.Windows.Forms.ToolStripStatusLabel LoginDesc;
        private System.Windows.Forms.ToolStripStatusLabel Login;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparator;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparator2;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxExport;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel LogsDesc;
        private System.Windows.Forms.ToolStripStatusLabel logsCount;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteLog;
    }
}

