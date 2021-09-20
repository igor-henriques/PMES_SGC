using Infra.Model;
using Infra.Model.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Infra.Helpers;
using Infra.Model.Enum;

namespace Domain.Repository
{
    public interface IUsuarioInterface
    {
        /// <summary>
        /// Retorna o registro especificado pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Usuario> GetLoggedUser();
        Task<Usuario> Get(int id);
        /// <summary>
        /// Retorna todos os registros
        /// </summary>
        /// <returns></returns>
        Task<List<Usuario>> Get();
        /// <summary>
        /// Adiciona um novo registro à database a partir de uma model populada
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> Add(Usuario user);
        /// <summary>
        /// Remove um registro a partir da ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Remove(int id);
        /// <summary>
        /// Atualiza o registro
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> Update(Usuario user);
    }
    public class UsuarioRepository : IUsuarioInterface
    {
        private static ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Usuario user)
        {
            try
            {
                await _context.Usuario.AddAsync(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }

        public async Task<Usuario> Get(int id)
        {
            try
            {
                return await _context.Usuario.Include(x => x.Militar).Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public Task<List<Usuario>> Get()
        {
            try
            {
                return _context.Usuario.Include(x => x.Militar).ToListAsync();
            }
            catch (Exception){}

            return default;
        }

        public async Task<Usuario> GetLoggedUser()
        {
            try
            {
                return await _context.Usuario.Where(x => x.Status.Equals(UserLogin.Online)).FirstOrDefaultAsync();
            }
            catch (Exception) { }

            return default;
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                _context.Usuario.Remove(await _context.Usuario.FindAsync(id));
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }

        public async Task<bool> Update(Usuario user)
        {
            try
            {
                Usuario currentUser = await Get(user.Id);

                if (currentUser != null)
                {
                    currentUser.Password = user.Password;
                    currentUser.User = user.User;
                    currentUser.IdMilitar = user.IdMilitar;
                    currentUser.Militar = user.Militar;

                    await _context.SaveChangesAsync();

                    return true;
                }                
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }
    }
}
