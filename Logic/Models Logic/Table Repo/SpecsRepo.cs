using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models_Logic.Table_Repo
{
    public class SpecsRepo : ISpecs
    {
        DBcontext context;
        public SpecsRepo(DBcontext c)
        {
            context = c;
        } // Dependency Injection - DI
        public async Task<List<Specs>> GetAllSpecs()
        {
            try
            {
                return await context.Specs.ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Specs> GetById(int id)
        {
            return await context.Specs.FirstOrDefaultAsync(Specs => Specs.Id == id);
        }

        public async Task<Specs> GetBySpecsName(string specsname)
        {
            return await context.Specs.FirstOrDefaultAsync(Specs => Specs.SpecsName == specsname);
        }
    }
}
