using Domain.Repository;
using Infra.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PMES_SAM.Forms;
using System;
using System.Windows.Forms;

namespace PMES_SAM
{
    static class Program
    {        
        [STAThread]
        static void Main()
        {            
            using (var serviceProvider = CreateServices().BuildServiceProvider())
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                AuthenticationForm form = serviceProvider.GetRequiredService<AuthenticationForm>();
                form._serviceProvider = serviceProvider;

                Application.Run(form);
            }            
        }

        private static ServiceCollection CreateServices()
        {            
            var services = new ServiceCollection();

            services.AddScoped<ICautelaInterface, CautelaRepository>();
            services.AddScoped<ICautelaMaterialInterface, CautelaMaterialRepository>();
            services.AddScoped<IMaterialInterface, MaterialRepository>();
            services.AddScoped<IMilitaryInterface, MilitarRepository>();            
            services.AddScoped<IUsuarioInterface, UsuarioRepository>();            
            services.AddScoped<ILogInterface, LogRepository>();            
            services.AddScoped<IUsuarioCredencialInterface, UsuarioCredencialRepository>();            
            services.AddSingleton<MainForm>();
            services.AddSingleton<AuthenticationForm>();
            services.AddTransient<ControlAccessForm>();
            services.AddTransient<MilitaryForm>();
            services.AddTransient<MateriaisForm>();
            services.AddTransient<CautelaForm>();
            services.AddTransient<NewCautelaForm>();
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite("Filename=./sam_database.sqlite"));            

            return services;
        }
    }
}
