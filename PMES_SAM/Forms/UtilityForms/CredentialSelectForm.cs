using Domain.Repository;
using Infra.Helpers;
using Infra.Model;
using Infra.Model.Data;
using Infra.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMES_SAM.Forms.UtilityForms
{
    public partial class CredentialSelectForm : Form
    {
        private int userId;
        private ApplicationDbContext _context;
        private IUsuarioCredencialInterface _credentials;
        private ILogInterface _logs;

        public CredentialSelectForm(int userId, ApplicationDbContext _context)
        {
            InitializeComponent();

            this._context = _context;
            this.userId = userId;

            _credentials = new IUsuarioCredencialRepository(_context);
            _logs = new ILogRepository(_context);
        }
        private List<Control> GetCredentialsTypes()
        {
            List<Control> credentialsBoxes = new List<Control>();
            var credentials = Enum.GetValues(typeof(Credential));

            foreach (var credential in credentials)
            {
                CheckBox cb = new CheckBox();

                cb.Name = $"{credential.ToString()}";
                cb.Text = EnumHelper.GetDescription((Credential)credential);
                cb.Tag = (int)credential;
                cb.Dock = DockStyle.Top;
                cb.AutoSize = true;

                credentialsBoxes.Add(cb);
            }            

            return credentialsBoxes.Where(x => (int)x.Tag > 0).ToList();
        }

        private async void CredentialSelectForm_Load(object sender, EventArgs e)
        {
            flowCbCredentials.Controls.AddRange(GetCredentialsTypes().ToArray());
            CheckUserCredentials((await _credentials.GetUserCredentials(userId)).Select(x => x.Credential).ToList());
        }
        private void CheckUserCredentials(List<Credential> userCredentials)
        {
            try
            {
                foreach (Credential credential in userCredentials)
                {
                    foreach (CheckBox cbCredential in flowCbCredentials.Controls)
                    {
                        if (cbCredential.Tag.Equals((int)credential))
                        {
                            cbCredential.Checked = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            bool anySelected = false;

            for (int i = 0; i < flowCbCredentials.Controls.Count; i++)
            {
                var userCredentials = await _credentials.GetUserCredentials(userId);
                CheckBox curCheckbox = (CheckBox)flowCbCredentials.Controls[i];
                Credential credential = (Credential)Enum.Parse(typeof(Credential), curCheckbox.Name);

                if (curCheckbox.Checked)
                {
                    if (!CredentialExists(userCredentials, credential))
                    {
                        await AddCredential(userId, credential);
                        await _logs.Add($"Permissão de '{EnumHelper.GetDescription(credential)}' ADICIONADA ao usuário {(await _context.Usuario.FindAsync(userId)).User}.");
                    }

                    anySelected = true;
                }
                else
                {
                    if (CredentialExists(userCredentials, credential))
                    {
                        var credentialToRemove = await _context.Usuario_Credential.Where(x => x.IdUsuario.Equals(userId) && x.Credential.Equals(credential)).FirstOrDefaultAsync();
                        await _credentials.Remove(credentialToRemove);
                        await _logs.Add($"Permissão de '{EnumHelper.GetDescription(credential)}' REMOVIDA do usuário {(await _context.Usuario.FindAsync(userId)).User}.");
                    }
                }
            }

            if (anySelected)
            {
                Close();
            }
            else
            {
                MessageBox.Show("Selecione ao menos uma permissão.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task AddCredential(int userId, Credential credential)
        {
            try
            {
                Usuario curUser = await _context.Usuario.Where(x => x.Id.Equals(userId)).FirstOrDefaultAsync();

                Usuario_Credential userCredential = new Usuario_Credential
                {
                    IdUsuario = curUser.Id,
                    Usuario = curUser,
                    Credential = credential
                };

                await _credentials.Add(userCredential);
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
        private bool CredentialExists(List<Usuario_Credential> credentials, Credential curCredential) => credentials.Select(x => x.Credential).Contains(curCredential) ? true : false;        
    }
}
