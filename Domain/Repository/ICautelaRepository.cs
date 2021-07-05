using Infra.Helpers;
using Infra.Model;
using Infra.Model.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ICautelaInterface
    {
        Task<Cautela> Get(int id);
        Task<List<Cautela>> Get();
        Task<Cautela> Add(Cautela material);
        Task<bool> Remove(int id);
        Task<bool> Update(Cautela material);
        Task<List<Material>> GetCautelaMaterials(int idCautela);
    }
    public class ICautelaRepository : ICautelaInterface
    {
        private ApplicationDbContext _context;
        public ICautelaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Cautela> Add(Cautela cautela)
        {
            try
            {
                await _context.Cautela.AddAsync(cautela);
                await _context.SaveChangesAsync();

                return await _context.Cautela.FindAsync(await _context.Cautela.MaxAsync(x => x.Id));
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public async Task<Cautela> Get(int id)
        {
            try
            {
                return await _context.Cautela.Include(x => x.Militar).Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public async Task<List<Cautela>> Get()
        {
            try
            {
                return await _context.Cautela.Include(x => x.Militar).ToListAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public async Task<List<Material>> GetCautelaMaterials(int idCautela)
        {
            try
            {
                List<Material> curCautelaMaterials = await _context.Cautela_Material.
                                    Include(x => x.Material).
                                    Where(x => x.Id_Cautela.Equals(idCautela)).
                                    Select(x => x.Material).ToListAsync();

                return curCautelaMaterials;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Cautela material)
        {
            throw new NotImplementedException();
        }
    }
}
