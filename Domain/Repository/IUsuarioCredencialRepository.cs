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
    public interface IUsuarioCredencialInterface
    {
        Task Add(Usuario_Credential credential);
        Task Add(List<Usuario_Credential> credentials);
        Task Remove(Usuario_Credential credential);
        Task RemoveAllFromUser(int userId);
        Task<List<Usuario_Credential>> GetUserCredentials(int userId);
        Task<bool> CheckUserCredential(Credential credential, Usuario user);
    }
    public class IUsuarioCredencialRepository : IUsuarioCredencialInterface
    {
        private static ApplicationDbContext _context;
        public IUsuarioCredencialRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Usuario_Credential credential)
        {
            try
            {
                await _context.Usuario_Credential.AddAsync(credential);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }

        public async Task Add(List<Usuario_Credential> credentials)
        {
            try
            {
                await _context.Usuario_Credential.AddRangeAsync(credentials);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }

        public async Task<bool> CheckUserCredential(Credential credential, Usuario user)
        {
            try
            {
                int userId = user.Id;
                bool hasPermission = await _context.Usuario_Credential.Where(x => x.Id.Equals(userId) && x.Credential.Equals(credential)).FirstOrDefaultAsync() != null;
                return hasPermission;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }

        public async Task<List<Usuario_Credential>> GetUserCredentials(int userId)
        {
            try
            {
                var credentials = await _context.Usuario_Credential.Where(x => x.IdUsuario.Equals(userId)).ToListAsync();                 
                return credentials;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public async Task Remove(Usuario_Credential credential)
        {
            try
            {
                _context.Usuario_Credential.Remove(credential);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }

        public async Task RemoveAllFromUser(int userId)
        {
            try
            {
                _context.Usuario_Credential.RemoveRange(_context.Usuario_Credential.Where(x => x.IdUsuario.Equals(userId)));
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
    }
}