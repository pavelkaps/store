﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
namespace LibraryBook
{
    class BookRepository : IEntityRepository<Book>
    {
        public void Insert(object a)
        {
            var dbContext = new BookContext();
            dbContext.dbBooks.Add((Book)a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbContext = new BookContext();
            Book book = dbContext.dbBooks.Find(id);
            dbContext.dbBooks.Remove(book);
            dbContext.SaveChanges();
        }

        public BindingList<Book> Load()
        {
            var dbContext = new BookContext();
            BindingList<Book> books = new BindingList<Book>();
            dbContext.dbBooks.Load();

            books = dbContext.dbBooks.Local.ToBindingList(); 
            return books;
        }

        public object Find(int id)
        {
            var dbContext = new BookContext();
            Book book = dbContext.dbBooks.Find(id);
            return book;
        }
    }
}
