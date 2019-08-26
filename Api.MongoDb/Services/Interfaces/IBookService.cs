using Api.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.MongoDb.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> Get();
        Task<Book> Get(string id);
        Task<Book> Create(Book book);
        Task Update(string id, Book bookIn);
        Task Remove(Book bookIn);
        Task Remove(string id);
    }
}
