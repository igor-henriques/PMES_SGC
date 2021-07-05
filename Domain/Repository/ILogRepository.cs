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
        Task Add(string description);
        Task<List<Log>> Get();
    }
    public class ILogRepository : ILogInterface
    {
        private ApplicationDbContext _context;
        public ILogRepository(ApplicationDbContext context)
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
        public async Task Add(string description)
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
                }                
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }            
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
    }
}
