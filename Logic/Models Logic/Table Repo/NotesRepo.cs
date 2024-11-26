using Logic.Interfaces.Table_Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models_Logic.Table_Repo
{
    public class NotesRepo : GenericRepo<Notes>, INotes
    {
        DBcontext context;
        public NotesRepo(DBcontext c) : base(c)
        {
            context = c;
        } // Dependency Injection - DI
        public async Task<Notes> GetById(int id)
        {
            return await context.Notes.FirstOrDefaultAsync(Notes => Notes.Id == id);
        }
    }
}
