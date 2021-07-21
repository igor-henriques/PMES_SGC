using Infra.Model.Data;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Infra.Helpers;
using Microsoft.EntityFrameworkCore;
using Infra.Model;
using System.Threading.Tasks;

namespace PMES_SAM.Forms
{
    public partial class AuthenticationForm : Form
    {
        public ServiceProvider _serviceProvider { get; set; }
        private ApplicationDbContext _context;
        public AuthenticationForm(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;
        }

        #region FormMovement
        private bool mouseDown;
        private System.Drawing.Point lastLocation;
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new System.Drawing.Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion   

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = tbUser.Text.Trim();
            string password = tbPassword.Text;

            if (!VerifyFields(usuario, password))
            {
                tbUser.Focus();
                return;
            }

            var user = _context.Usuario.Where(x => x.User.Equals(usuario)).ToList();

            if (user.Count > 0)
            {
                Usuario _user = user.Where(x => x.Password.Equals(Cryptography.GetMD5(password))).FirstOrDefault();

                if (_user != null)
                {
                    _user.Status = Infra.Model.Enum.UserLogin.Online;
                    await _context.Log.AddAsync(new Log
                    {
                        Date = DateTime.Now,
                        IdUsuario = _user.Id,
                        Usuario = _user,
                        Description = $"O usuário {_user.User} realizou LOG-IN no sistema."
                    });
                    await _context.SaveChangesAsync();

                    MainForm main = _serviceProvider.GetRequiredService<MainForm>();
                    main.serviceProvider = _serviceProvider;
                    main.loggedUser = _user;

                    Hide();
                    main.ShowDialog();
                    Show();

                    if (main.loggedUser is null)
                    {
                        MessageBox.Show($"Você saiu da conta {_user.User}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await _context.Log.AddAsync(new Log
                        {
                            Date = DateTime.Now,
                            IdUsuario = _user.Id,
                            Usuario = _user,
                            Description = $"O usuário {_user.User} realizou LOG-OFF no sistema."
                        });

                        (await _context.Usuario.Where(x => x.Id.Equals(_user.Id)).FirstOrDefaultAsync()).Status = Infra.Model.Enum.UserLogin.Offline;
                        await _context.SaveChangesAsync();

                        tbUser.Clear();
                        tbPassword.Clear();

                        tbUser.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("A senha está incorreta.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show($"O usuário {usuario} não existe.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUser.Focus();
            }
        }

        private bool VerifyFields(string usuario, string password)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Há campos vazios.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnLogin.PerformClick();
            }
        }

        private void tbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                tbPassword.Focus();
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair?", "Saindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) is DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private async void AuthenticationForm_Load(object sender, EventArgs e)
        {
            await CreateFirstMilitar();
            await CreateFirstUser();
        }
        private async Task CreateFirstMilitar()
        {
            try
            {
                int militaresCount = await _context.Militar.CountAsync();
                if (militaresCount <= 0)
                {
                    Militar militar = new Militar
                    {
                        Nome = "HENRIQUES",
                        Numero = 176,
                        Curso = Infra.Model.Enum.Curso.CFSD,
                        Funcional = "4311850",
                        Pelotao = "8",
                        PIN = "E10ADC3949BA59ABBE56E057F20F883E",
                        Posto = Infra.Model.Enum.Posto.Aluno_Soldado,
                    };

                    await _context.Militar.AddAsync(militar);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception) { }
        }
        private async Task CreateFirstUser()
        {
            try
            {
                int usersCount = await _context.Usuario.CountAsync();
                if (usersCount <= 0)
                {
                    Militar fromDbMilitar = await _context.Militar.Where(x => x.Nome.Equals("HENRIQUES")).FirstOrDefaultAsync();
                    if (fromDbMilitar != null)
                    {
                        Usuario user = new Usuario
                        {
                            User = "admin",
                            Password = "E10ADC3949BA59ABBE56E057F20F883E",
                            Status = Infra.Model.Enum.UserLogin.Offline,
                            IdMilitar = fromDbMilitar.Id,
                            Militar = fromDbMilitar
                        };

                        await _context.Usuario.AddAsync(user);
                        await _context.SaveChangesAsync();

                        if (await _context.Usuario_Credential.CountAsync() <= 0)
                        {
                            Usuario mainUser = await _context.Usuario.Where(x => x.User.Equals("admin")).FirstOrDefaultAsync();

                            if (mainUser != null)
                            {
                                Usuario_Credential firstPermission = new Usuario_Credential
                                {
                                    IdUsuario = mainUser.Id,
                                    Usuario = mainUser,
                                    Credential = Infra.Model.Enum.Credential.Master,                                    
                                };

                                await _context.Usuario_Credential.AddAsync(firstPermission);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }
}