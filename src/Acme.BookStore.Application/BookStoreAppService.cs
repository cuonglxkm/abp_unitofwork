using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace Acme.BookStore;

/* Inherit your application services from this class.
 */
public class BookStoreAppService : ApplicationService
{
    public IRepository<Book,Guid> _repo { get; set; }
    public IBookRepository _repoBook { get; set; }
    public IServiceProvider _sp { get; set; }
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    public ILogger<BookStoreAppService> _logger;
    public BookStoreAppService(IRepository<Book, Guid> repo, IBookRepository repoBook, IServiceProvider sp, IUnitOfWorkManager unitOfWorkManager, ILogger<BookStoreAppService> Logger)
    {
        LocalizationResource = typeof(BookStoreResource);
        _repo = repo;
        _sp = sp;
        _unitOfWorkManager = unitOfWorkManager;
        _logger = Logger;
        _repoBook = repoBook;
    }

    public async Task CreateAsync()
    {
        using (var uow = _unitOfWorkManager.Begin(
                requiresNew: true, isTransactional: false
            ))
        {
            var rs = await _repoBook.GetListAsync();
            _logger.LogWarning("dbContext hash " + await _repoBook.GetDbContextHashAsync());
            await uow.CompleteAsync();
        }
    }

    public async Task CreateAsync2(Book book)
    {
        _logger.LogWarning($"CreateAsync1 {_unitOfWorkManager.Current?.GetHashCode()}");
        using (var uow = _unitOfWorkManager.Begin())
        {
            _logger.LogWarning($"CreateAsync2 {uow.GetHashCode()}");
            _unitOfWorkManager.Current?.GetHashCode();
            await uow.CompleteAsync();
        }
    }
    public async Task<List<Book>> ImportExcel()
    {
        _logger.LogWarning($"ImportExcel2 { _unitOfWorkManager.Current?.GetHashCode() }");
        List<Task> tasks = new List<Task>();    
       
        for (int i = 0; i < 100; i++)
        {
            //await CreateAsync2();
            //tasks.Add(CreateAsync());
        }
        Task.WaitAll(tasks.ToArray());
        
        return [];
    }
}
