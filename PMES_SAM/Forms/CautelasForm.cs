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
    public partial class CautelaForm : Form
    {
        int cautelaId;

        ILogInterface _log;
        ICautelaInterface _cautelas;
        IMilitaryInterface _militares;
        IMaterialInterface _materiais;
        IUsuarioInterface _users;
        IUsuarioCredencialRepository _credentials;
        ApplicationDbContext _context;
        public CautelaForm(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;
            _cautelas = new ICautelaRepository(_context);
            _militares = new IMilitarRepository(_context);
            _materiais = new IMaterialRepository(_context);
            _log = new ILogRepository(_context);
            _users = new IUsuarioRepository(_context);
            _credentials = new IUsuarioCredencialRepository(_context);
        }

        private async void CautelasForm_Load(object sender, EventArgs e)
        {
            dtiPicker.Value = DateTime.Today.Subtract(TimeSpan.FromDays(1));
            dtfPicker.Value = DateTime.Today;

            cbStatusSearch.SelectedIndex = 0;

            await LoadCautelas();
        }
        private async Task LoadCautelas()
        {
            try
            {
                FillGrid(await _cautelas.Get());
                FormatColumns();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private DataGridViewButtonCell CreateGridButton()
        {
            try
            {
                DataGridViewButtonCell dgvButton = new DataGridViewButtonCell();

                dgvButton.Value = "Verificar";
                dgvButton.UseColumnTextForButtonValue = true;
                dgvButton.FlatStyle = FlatStyle.Flat;

                return dgvButton;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }
        private void dgvCautelas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (dgvCautelas.RowCount > 0)
                {
                    cautelaId = (int)dgvCautelas.SelectedRows[0].Cells[0].Value;

                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        int cautelaId = (int)dgvCautelas.Rows[e.RowIndex].Cells[0].Value;
                        Material_Cautela_Form items = new Material_Cautela_Form(cautelaId, _context);
                        items.ShowDialog();
                    }
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }

        private void FormatColumns()
        {
            try
            {
                for (int i = 0; i < dgvCautelas.RowCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        dgvCautelas.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        dgvCautelas.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }

                dgvCautelas.ClearSelection();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }

        private void tbNumFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) || !int.TryParse(tbNumFuncSearch.Text + ch, out int x))
            {
                e.Handled = true;
            }
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
        private void pbBack_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await LoadCautelas();

            tbMaterialSearch.Clear();
            tbNumFuncSearch.Clear();
        }

        private async void btnState_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await _credentials.CheckUserCredential(Credential.ReturnCautela, await _users.GetLoggedUser()))
                {
                    MessageBox.Show("Você não possui permissão para realizar essa operação", "ACESSO NEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (dgvCautelas.SelectedRows.Count > 0)
                {
                    var cautela = await _cautelas.Get(cautelaId);
                    cautela.Materiais = await _materiais.GetByCautela(cautelaId);

                    if (cautela.DataDevolucao.Equals(default))
                    {
                        string numFuncional = dgvCautelas.SelectedRows[0].Cells[1].Value.ToString();
                        DevolucaoForm pinDevolution = new DevolucaoForm(_context, cautela, numFuncional);
                        pinDevolution.ShowDialog();

                        await LoadCautelas();
                    }
                    else
                    {
                        MessageBox.Show("Essa cautela de materiais já foi devolvida.", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma linha.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<RadioButton, Func<Task>> searchOptions = new Dictionary<RadioButton, Func<Task>>
                {
                    { rbDate, async() =>
                        {
                            FillGrid(await _context.Cautela.Where(x => x.DataRetirada >= dtiPicker.Value && x.DataDevolucao <= dtfPicker.Value).ToListAsync());
                        }
                    },

                    { rbMaterial, async () =>
                        {
                            if (!string.IsNullOrEmpty(tbMaterialSearch.Text.Trim()))
                            {
                                FillGrid(await _context.Cautela_Material.
                                Include(x => x.Material).
                                Include(x => x.Cautela).
                                Where(x => x.Material.Code.
                                Contains(tbMaterialSearch.Text.Trim())).
                                Select(x => x.Cautela).
                                ToListAsync()
                                );
                            }
                            else
                            {
                                MessageBox.Show("Preencha o código do material para pesquisar.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbMaterialSearch.Focus();
                            }
                        }
                    },

                    { rbStatus, async () =>
                        {
                            FillGrid(await _context.Cautela.
                            Where(x => cbStatusSearch.SelectedIndex.Equals(0) ?
                            x.DataDevolucao.Equals(default) : !x.DataDevolucao.Equals(default)).
                            ToListAsync());
                        }
                    },

                    { rbMilitar, async () =>
                        {
                            if (!string.IsNullOrEmpty(tbMaterialSearch.Text.Trim()))
                            {
                                FillGrid(await _context.Cautela.
                                Where(x => x.Militar.Funcional.Contains(tbNumFuncSearch.Text.Trim())).
                                ToListAsync()
                                );
                            }
                            else
                            {
                                MessageBox.Show("Preencha o Número Funcional do militar para pesquisar.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbNumFuncSearch.Focus();
                            }                            
                        }
                    },
                };

                var searchResponse = searchOptions.Where(x => x.Key.Checked).Select(x => x.Value).FirstOrDefault();

                if (searchResponse != null)
                {
                    await searchResponse.Invoke();
                    FormatColumns();
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private void FillGrid(List<Cautela> cautelas)
        {
            try
            {
                dgvCautelas.Rows.Clear();

                cautelas.ForEach(curCautela => dgvCautelas.Rows.Add(new object[] {
                    curCautela.Id,
                    curCautela.Militar.Funcional,
                    curCautela.Militar.Nome,
                    $"{curCautela.DataRetirada.ToShortDateString()} {curCautela.DataRetirada.ToShortTimeString()}",
                    $"{(curCautela.DataDevolucao.Year > 1 ? curCautela.DataDevolucao.ToShortDateString() + " " + curCautela.DataDevolucao.ToShortTimeString() : "PENDENTE")}",
                    CreateGridButton(),
                }));
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private void dtfPicker_ValueChanged(object sender, EventArgs e)
        {
            if (dtfPicker.Value < dtiPicker.Value)
            {
                MessageBox.Show("A data final não pode ser menor que a data inicial.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtfPicker.Value = dtiPicker.Value.AddDays(1);
            }
        }
        private void tbNumFuncSearch_MouseDown(object sender, MouseEventArgs e)
        {
            rbMilitar.Checked = true;
        }
        private void tbMaterialSearch_MouseDown(object sender, MouseEventArgs e)
        {
            rbMaterial.Checked = true;
        }
        private void cbStatusSearch_MouseDown(object sender, MouseEventArgs e)
        {
            rbStatus.Checked = true;
        }
        private void dtiPicker_MouseDown(object sender, MouseEventArgs e)
        {
            rbDate.Checked = true;
        }
    }
}