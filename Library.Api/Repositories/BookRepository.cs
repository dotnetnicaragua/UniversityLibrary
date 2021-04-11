using Library.Api.Data;
using Library.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Repositories
{
    public class BookRepository
    {
        private readonly LibraryDemoContext _dbContext;

        public BookRepository(LibraryDemoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Book>> GetAll()
        {
            return _dbContext.Books.ToListAsync();
        }
    }
}
