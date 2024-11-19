﻿using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models_Logic.Table_Repo
{
    public class ProgressRepo : GenericRepo<Course>,IProgress
    {
        DBcontext context;
        public ProgressRepo(DBcontext c) : base(c)
        {
            context = c;
        } // Dependency Injection - DI

        public async Task<Course> GetByProgressName(string prograssname)
        {
            return await context.Progress.FirstOrDefaultAsync(Progress => Progress.ProgressName == prograssname);
        }
        public async Task<Course> GetById(int id)
        {
            return await context.Progress.FirstOrDefaultAsync(Progress => Progress.Id == id);
        }
        public async Task<List<Course>> GetAllProgress()
        {
            try
            {
                return await context.Progress.ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
