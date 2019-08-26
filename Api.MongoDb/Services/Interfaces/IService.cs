using Api.MongoDb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.MongoDb.Services.Interfaces
{
    public interface IService
    {
        Task<List<Book>> Get();
        Task<Book> Get(string id);
        Task<Book> Create(Book book);
        Task Update(string id, Book bookIn);
        Task Remove(Book bookIn);
        Task Remove(string id);
    }
}
