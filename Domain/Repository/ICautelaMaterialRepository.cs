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
    public interface ICautelaMaterialInterface
    {
        Task<Cautela_Material> Get(int id);
        Task<List<Cautela_Material>> Get();
        Task<bool> Add(Cautela_Material material);
        Task<bool> Add(Cautela material);
        Task<bool> Remove(int id);
        Task<bool> Update(Cautela_Material material);
    }
    public class ICautelaMaterialRepository : ICautelaMaterialInterface
    {
        private ApplicationDbContext _context;
        public ICautelaMaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Cautela_Material material)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Add(Cautela cautela)
        {
            try
            {
                List<Cautela_Material> toAdd = new List<Cautela_Material>();

                foreach (var mat in cautela.Materiais)
                {
                    toAdd.Add(new Cautela_Material
                    {
                        Id_Cautela = cautela.Id,       
                        IdMaterial = mat.Id
                    });

                    var fromDbCurMat = await _context.Material.Where(x => x.Id.Equals(mat.Id)).FirstOrDefaultAsync();
                    if (fromDbCurMat != null)
                    {
                        fromDbCurMat.Status = Infra.Model.Enum.Status.Cautelado;
                    }
                }

                await _context.Cautela_Material.AddRangeAsync(toAdd);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }

        public Task<Cautela_Material> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cautela_Material>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Cautela_Material material)
        {
            throw new NotImplementedException();
        }
    }
}
