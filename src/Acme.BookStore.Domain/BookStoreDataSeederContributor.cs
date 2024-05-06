using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore;

public class BookStoreDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;

    public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepository.GetCountAsync() <= 0)
        {
            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "1984"
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "The Hitchhiker's Guide to the Galaxy"
                },
                autoSave: true
            );
            await _bookRepository.InsertAsync(
               new Book
               {
                   Name = "The Hitchhiker's Guide to the Galaxy1"
               },
               autoSave: true
           );
            await _bookRepository.InsertAsync(
               new Book
               {
                   Name = "The Hitchhiker's Guide to the Galaxy2"
               },
               autoSave: true

           );
            await _bookRepository.InsertAsync(
               new Book
               {
                   Name = "The Hitchhiker's Guide to the Galaxy3"
               },
               autoSave: true
           );
            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "The Hitchhiker's Guide to the Galaxy4"
                },
                autoSave: true

            );
            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "The Hitchhiker's Guide to the Galaxy5"
                },
                autoSave: true
            );
        }
    }
}
