using Infra.Model;
using Infra.Model.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Infra.Helpers;
using Infra.Model.Enum;

namespace Domain.Repository
{
    public interface IMilitaryInterface
    {
        /// <summary>
        /// Retorna o registro especificado pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Militar> Get(int id);

        /// <summary>
        /// Retorna todos os registros
        /// </summary>
        /// <returns></returns>
        Task<List<Militar>> Get();
        /// <summary>
        /// Adiciona um novo registro à database a partir de uma model populada
        /// </summary>
        /// <param name="militar"></param>
        /// <returns></returns>
        Task<bool> Add(Militar militar);
        /// <summary>
        /// Remove um registro a partir da ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Remove(int id);
        /// <summary>
        /// Atualiza o registro
        /// </summary>
        /// <param name="militar"></param>
        /// <returns></returns>
        Task<bool> Update(Militar militar);
        Task<bool> Authenticate(string funcional, string PIN);
    }
    public class IMilitarRepository : IMilitaryInterface
    {
        private static ApplicationDbContext _context;
        public IMilitarRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<bool> Add(Militar militar)
        {
            try
            {
                await _context.Militar.AddAsync(militar);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception) { }

            return false;
        }

        public async Task<bool> Authenticate(string funcional, string PIN)
        {
            try
            {
                string encryptedPIN = Cryptography.GetMD5(PIN);

                return await _context.Militar.Where(x => x.Funcional.Equals(funcional)).Where(x => x.PIN.Equals(encryptedPIN)).FirstOrDefaultAsync() != null ? true : false;
            }
            catch (Exception) { }

            return false;
        }

        public async Task<Militar> Get(int id)
        {
            try
            {
                return await _context.Militar.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public Task<List<Militar>> Get()
        {
            try
            {
                return _context.Militar.ToListAsync();
            }
            catch (Exception) { }

            return default;
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                _context.Militar.Remove(await _context.Militar.FindAsync(id));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }        

        public async Task<bool> Update(Militar militar)
        {
            try
            {
                Militar currentMilitar = await Get(militar.Id);

                if (currentMilitar != null)
                {
                    currentMilitar.Curso = militar.Curso;
                    currentMilitar.Funcional = militar.Funcional;
                    currentMilitar.Nome = militar.Nome;
                    currentMilitar.Numero = militar.Numero;
                    currentMilitar.Pelotao = militar.Pelotao;
                    currentMilitar.PIN = militar.PIN;
                    currentMilitar.Posto = militar.Posto;

                    await _context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }
    }
}
