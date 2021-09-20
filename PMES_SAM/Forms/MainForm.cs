using ClosedXML.Excel;
using Domain.Repository;
using Infra.Helpers;
using Infra.Model;
using Infra.Model.Data;
using Infra.Model.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMES_SAM.Forms
{
    public partial class MainForm : Form
    {
        private int currentRow;
        private Point lastLocation;
        
        private ApplicationDbContext _context;
        public ServiceProvider serviceProvider { get; set; }
        public Usuario loggedUser { get; set; }

        private IUsuarioCredencialInterface _credentials;
        private ILogInterface _log;
        private IUsuarioInterface _users;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private Form Menu(string tag)
        {
            Dictionary<string, Form> Menu = new Dictionary<string, Form>
            {
                { "Acesso", serviceProvider.GetRequiredService<ControlAccessForm>() },
                { "Militar", serviceProvider.GetRequiredService<MilitaryForm>() },
                { "Material", serviceProvider.GetRequiredService<MateriaisForm>() },
                { "Cautela", serviceProvider.GetRequiredService<CautelaForm>() },
                { "Nova Cautela", serviceProvider.GetRequiredService<NewCautelaForm>() }
            };

            return Menu.Where(x => x.Key.ToUpper().Trim().Equals(tag.ToUpper().Trim())).FirstOrDefault().Value;            
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            _context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            _log = new LogRepository(_context);
            _credentials = new UsuarioCredencialRepository(_context);
            _users = new UsuarioRepository(_context);

            loggedUser.Credentials = (await _credentials.GetUserCredentials(loggedUser.Id)).Select(x => x.Credential).ToList();

            BuildStatusBar();

            await LoadTable();
        }
        private async Task LoadTable()
        {
            try
            {
                List<Log> todayLogs = await _context.Log.
                    Where(x => x.IdUsuario.Equals(loggedUser.Id)).
                    Where(x => x.Date.Date.Equals(DateTime.Today.Date)).
                    ToListAsync();

                DateTime yesterday = DateTime.Today.Subtract(TimeSpan.FromDays(1));

                List<Log> yesterdayLogs = await _context.Log.
                    Where(x => x.IdUsuario.Equals(loggedUser.Id)).
                    Where(x => x.Date.Date.Equals(yesterday.Date)).
                    ToListAsync();

                todayLogs.AddRange(yesterdayLogs);

                dgvMain.DataSource = todayLogs;

                FormatColumns();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        public void FormatColumns()
        {
            try
            {
                dgvMain.Columns[0].Visible = false;
                dgvMain.Columns[3].Visible = false;
                dgvMain.Columns[4].Visible = false;

                dgvMain.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvMain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvMain.Columns[1].HeaderText = "Data";
                dgvMain.Columns[2].HeaderText = "Descrição";

                for (int i = 0; i < dgvMain.RowCount; i++)
                {
                
                    if (i % 2 == 0)
                    {
                        dgvMain.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        dgvMain.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }

                dgvMain.ClearSelection();
                logsCount.Text = dgvMain.RowCount.ToString();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                Form clickedMenuItem = Menu((string)e.ClickedItem.Tag);

                if (clickedMenuItem != null)
                {
                    Credential credType = EnumHelper.LikeGetEnum<Credential>(clickedMenuItem.AccessibleName);

                    if (await _credentials.CheckUserCredential(credType, loggedUser))
                    {
                        clickedMenuItem.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Você não possui permissão para acessar esse módulo.", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }                

                await LoadTable();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private void BuildStatusBar()
        {
            alblTitle.Text = $"Serviço do dia {DateTime.Today.ToString("dd/MM/yyyy")}";
            Date.Text = DateTime.Now.ToLongDateString();
            Time.Text = DateTime.Now.ToLongTimeString();
            Login.Text = loggedUser.User;
        }
        private void watchTimer_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair?", "Saindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
            {
                loggedUser = null;
                Login.Text = default;
                Close();
            }
        }
        private async void backupBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await _credentials.CheckUserCredential(Credential.BackupDatabase, await _users.GetLoggedUser()))
                {
                    MessageBox.Show("Você não possui permissão para realizar essa operação", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Deseja realizar backup da base de dados?", "Fazendo backup...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
                {
                    if (!Directory.Exists("./Backup/"))
                    {
                        Directory.CreateDirectory("./Backup/");
                    }

                    string newFileName = $"./Backup/sam_database_{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Hour}.{DateTime.Now.Minute}.sqlite";

                    if (File.Exists(newFileName))
                    {
                        File.Delete(newFileName);
                    }

                    File.Copy("./sam_database.sqlite", newFileName);
                    await _log.Add("Backup LOCAL realizado.");

                    if (MessageBox.Show("Backup LOCAL realizado com sucesso e salvo na pasta 'backup'. Deseja realizar backup externo?", "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) is DialogResult.Yes)
                    {
                        await UploadDatabase(GetLastDatabase(), $"sam_database_{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Hour}.{DateTime.Now.Minute}.sqlite");
                    }

                    await LoadTable();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "ERRO AO SALVAR BACKUP LOCAL", MessageBoxButtons.OK, MessageBoxIcon.Error); LogWriter.Write(ex.ToString()); }
        }
        private async Task UploadDatabase(string filePath, string fileName, string parentFolderId = "1fkpeSLoTEPd1jdncbuxNFhHE-RyG-LxC", string contentType = "application/zip")
        {
            try
            {
                GDrive driveConnection = new GDrive();

                var credentials = await driveConnection.GetUserCredentialAsync();
                var service = driveConnection.GetDriveService(credentials);

                var response = await driveConnection.Upload(service, filePath, fileName, parentFolderId, contentType);

                if (response != null)
                {
                    do
                    {
                        await Task.Delay(1000);
                    } while (!driveConnection.succesfullUploaded);

                    if (MessageBox.Show($"Backup EXTERNO realizado com sucesso e disponível em\nhttps://drive.google.com/file/d/{response}/\n\nDeseja copiar o link?", "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) is DialogResult.Yes)
                    {
                        Clipboard.SetText($"https://drive.google.com/file/d/{response}/");
                    }

                    await _log.Add($"Backup EXTERNO realizado: https://drive.google.com/file/d/{response}/");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "ERRO AO SALVAR BACKUP EXTERNO", MessageBoxButtons.OK, MessageBoxIcon.Error); LogWriter.Write(ex.ToString()); }
        }
        private string GetLastDatabase()
        {
            try
            {
                var database = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Backup").GetFiles().OrderByDescending(f => f.LastWriteTime).LastOrDefault();
                return database.FullName;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await LoadTable();
            tbSearch.Clear();
        }
        private void dgvMain_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dgvMain.HitTest(e.X, e.Y);
                    dgvMain.Rows[hti.RowIndex <= -1 ? 0 : hti.RowIndex].Selected = true;

                    dgvMain_CellClick(null, null);

                    Point here = new Point((dgvMain.Location.X - lastLocation.X) + e.X, (dgvMain.Location.Y - lastLocation.Y) + e.Y);
                    ctxMenu.Show(this, here);
                }
            }
            catch (Exception) { }
        }
        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.Rows.Count > 0)
            {
                currentRow = (int)dgvMain.SelectedRows[0].Cells[0].Value;
            }
        }
        private async void reportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await _credentials.CheckUserCredential(Credential.ExportReport, await _users.GetLoggedUser()))
                {
                    MessageBox.Show("Você não possui permissão para realizar essa operação", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Deseja emitir um novo relatório?", "Emitindo Relatório...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
                {
                    List<Log> source;

                    if (loggedUser.Credentials.Contains(Credential.ExportFullReport) || loggedUser.Credentials.Contains(Credential.Master) || loggedUser.Credentials.Contains(Credential.Total))
                    {
                        if (MessageBox.Show("Deseja emitir um relatório completo?", "Emitindo Relatório Completo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
                        {
                            source = await _log.Get();
                        }
                        else
                        {
                            source = await GetLogFromGrid(dgvMain.Rows);
                        }
                    }
                    else
                    {
                        source = await GetLogFromGrid(dgvMain.Rows);
                    }

                    ExportToSheet(source);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async void ctxExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await _credentials.CheckUserCredential(Credential.ExportReport, await _users.GetLoggedUser()))
                {
                    MessageBox.Show("Você não possui permissão para realizar essa operação", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Deseja emitir novo relatório?", "Emitindo Relatório...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
                {
                    if (dgvMain.SelectedRows.Count > 0)
                    {
                        ExportToSheet(await GetLogFromGrid(dgvMain.SelectedRows));
                    }
                    else
                    {
                        MessageBox.Show("Não há linhas selecionadas para exportar", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private void ExportToSheet(List<Log> logs)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add($"SAM - RELATÓRIO");

                    worksheet.Cell("A1").Value = "DATA";
                    worksheet.Cell("A1").Style.Font.Bold = true;
                    worksheet.Cell("A1").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    
                    worksheet.Cell("B1").Value = "DESCRIÇÃO";
                    worksheet.Cell("B1").Style.Font.Bold = true;
                    worksheet.Cell("B1").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("B1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    worksheet.Cell("C1").Value = "USUÁRIO";
                    worksheet.Cell("C1").Style.Font.Bold = true;
                    worksheet.Cell("C1").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("C1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    int rowIndex = 2;

                    for (int i = 0; i < logs.Count; i++)
                    {
                        worksheet.Cell(rowIndex, 1).Value = logs[i].Date;
                        worksheet.Cell(rowIndex, 2).Value = logs[i].Description;
                        worksheet.Cell(rowIndex, 3).Value = logs[i].Usuario.User;

                        worksheet.Cell(rowIndex, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(rowIndex, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        worksheet.Cell(rowIndex, 2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(rowIndex, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        worksheet.Cell(rowIndex, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(rowIndex, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        rowIndex++;
                    }                        
                    
                    worksheet.Columns("C").AdjustToContents();
                    worksheet.Columns("B").AdjustToContents();
                    worksheet.Columns("A").AdjustToContents();

                    worksheet.Columns("A").Width = 17;

                    worksheet.Protect("masterkey", XLProtectionAlgorithm.Algorithm.SHA512);

                    workbook.SaveAs(Directory.GetCurrentDirectory() + $"\\Relatórios\\SAM RELATÓRIO - {DateTime.Today.ToLongDateString().ToUpper()}.xlsx");

                    MessageBox.Show($"{logs.Count} linhas exportadas em relatório à pasta Relatórios", "Exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async Task<List<Log>> GetLogFromGrid(dynamic rows)
        {
            List<Log> logs = new List<Log>();

            foreach (DataGridViewRow row in rows)
            {
                Usuario curUser = await _context.Usuario.FindAsync((int)row.Cells[3].Value);

                if (curUser != null)
                {
                    logs.Add(new Log
                    {
                        Id = (int)row.Cells[0].Value,
                        IdUsuario = curUser.Id,
                        Usuario = curUser,
                        Date = (DateTime)row.Cells[1].Value,
                        Description = row.Cells[2].Value.ToString()
                    });
                }                
            }

            return logs;
        }
        private async void TbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tbSearch.Text.Trim() != string.Empty)
                {
                    DateTime yesterday = DateTime.Today.Subtract(TimeSpan.FromDays(1));

                    var foundLogs = from i in _context.Log
                                    where i.IdUsuario.Equals(loggedUser.Id)
                                    where i.Date.Date.Equals(DateTime.Today.Date) || i.Date.Date.Equals(yesterday.Date)
                                    where EF.Functions.Like(i.Description, $"%{tbSearch.Text.Trim()}%")
                                    select i;

                    dgvMain.DataSource = await foundLogs.ToListAsync();
                    dgvMain.Rows[dgvMain.Rows.Count - 1].Selected = true;

                    FormatColumns();
                }
                else
                {
                    btnUpdate.PerformClick();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loggedUser = null;
            Login.Text = default;
        }
        private async void btnDeleteLog_Click(object sender, EventArgs e)
        {
            try
            {
                #region VERIFIY
                if (!await _credentials.CheckUserCredential(Credential.DeleteLogs, await _users.GetLoggedUser()))
                {
                    MessageBox.Show("Você não possui permissão para realizar essa operação", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (dgvMain.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Selecione ao menos uma linha para excluir.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                #endregion

                if (MessageBox.Show($"Tem certeza que deseja remover {dgvMain.SelectedRows.Count} registro(s) de log?", "Removendo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
                {
                    await _log.Remove(await GetLogsFromGrid());
                    await LoadTable();
                }                
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async Task<List<Log>> GetLogsFromGrid()
        {
            List<Log> logs = new List<Log>();

            foreach (DataGridViewRow row in dgvMain.SelectedRows)
            {
                logs.Add(new Log
                {
                    Id = int.Parse(row.Cells[0].Value.ToString()),
                    Date = DateTime.Parse(row.Cells[1].Value.ToString()),
                    Description = row.Cells[2].Value.ToString(),
                    IdUsuario = int.Parse(row.Cells[3].Value.ToString()),
                    Usuario = await _users.Get(int.Parse(row.Cells[3].Value.ToString()))
                });
            }

            return logs;
        }
    }
}