using Acme.BookStore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore
{
    public class BookRepository
    : EfCoreRepository<BookStoreDbContext, Book, Guid>, IBookRepository
    {
        public BookRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        

        public async Task<int> GetDbContextHashAsync()
        {
            var dbContext = await base.GetDbContextAsync();
            return dbContext.GetHashCode();
        }
    }
}
