﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
namespace LibraryBook
{
    class MagazineRepository:IEntityRepository<Magazine>
    {
        public void Insert(object a)
        {
            var dbContext = new MagazineContext();
            dbContext.dbJournals.Add((Magazine)a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbContext = new MagazineContext();
            Magazine m = dbContext.dbJournals.Find(id);
            dbContext.dbJournals.Remove(m);
            dbContext.SaveChanges();
        }

        public BindingList<Magazine> Load()
        {
            var dbContext = new MagazineContext();
            BindingList<Magazine> m = new BindingList<Magazine>();
            dbContext.dbJournals.Load();

            m = dbContext.dbJournals.Local.ToBindingList();
            return m;
        }
        


        public object Find(int id)
        {
            var dbContext = new MagazineContext();
            Magazine m = dbContext.dbJournals.Find(id);
            return m;
        }
    }
}
