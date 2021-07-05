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
    public interface IMaterialInterface
    {
        Task<Material> Get(int id);
        Task<List<Material>> GetByCautela(int cautelaId);
        Task<List<Material>> Get();
        Task<bool> Add(Material material);
        Task<bool> Remove(int id);
        Task<bool> Update(Material material);
    }
    public class IMaterialRepository : IMaterialInterface
    {
        private ApplicationDbContext _context;
        public IMaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Material material)
        {
            try
            {
                await _context.Material.AddAsync(material);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public async Task<Material> Get(int id)
        {
            try
            {
                return await _context.Material.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public async Task<List<Material>> Get()
        {
            try
            {
                return await _context.Material.ToListAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public async Task<List<Material>> GetByCautela(int cautelaId)
        {
            try
            {
                List<Material> allMats = await _context.Cautela_Material.
                            Include(x => x.Material).
                            Where(x => x.Id_Cautela.Equals(cautelaId)).
                            Select(x => x.Material).ToListAsync();

                return allMats;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                _context.Material.Remove(await Get(id));
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }

        public async Task<bool> Update(Material material)
        {
            try
            {
                Material mat = await Get(material.Id);

                if (mat != null)
                {
                    mat.Code = material.Code;
                    mat.Nome = material.Nome;
                    mat.Status = mat.Status;

                    await _context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }
    }
}
