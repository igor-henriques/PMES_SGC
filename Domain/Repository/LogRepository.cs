using Infra.Helpers;
using Infra.Model;
using Infra.Model.Data;
using Infra.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ILogInterface
    {
        Task<bool> Add(string description);
        Task<List<Log>> Get();
        Task Remove(List<Log> logs);
    }
    public class LogRepository : ILogInterface
    {
        private ApplicationDbContext _context;
        public LogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        private async Task<Usuario> GetLoggedUser()
        {
            try
            {
                return await _context.Usuario.Where(x => x.Status.Equals(UserLogin.Online)).FirstOrDefaultAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }
        public async Task<bool> Add(string description)
        {
            try
            {
                Log log = new Log { Description = description };
                Usuario loggedUser = await GetLoggedUser();

                if (loggedUser != null)
                {
                    log.IdUsuario = loggedUser.Id;
                    log.Usuario = loggedUser;
                    log.Date = DateTime.Now;

                    await _context.Log.AddAsync(log);
                    await _context.SaveChangesAsync();

                    return true;
                }                
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }

        public async Task<List<Log>> Get()
        {
            try
            {
                return await _context.Log.ToListAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public async Task Remove(List<Log> logs)
        {
            try
            {
                logs.Select(x => x.Id)
                    .ToList()
                    .ForEach(async x => _context.Log
                    .Remove((await _context.Log
                    .FindAsync(x))));

                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
    }
}
