using Api.MongoDb.Interfaces;
using Api.MongoDb.Models;
using Api.MongoDb.Services.Interfaces;
using KissLog;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : MainController
    {
        private readonly IService _bookService;
        private readonly ILogger _logger;

        public BooksController(IService bookService
                               ,ILogger logger
                               ,INotificador notificador) : base(notificador)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet("obter-todos")]
        public async Task<ActionResult<List<Book>>> Get()
        {
            var books = await _bookService.Get();

            _logger.Info($"Quantidade de registros recuperados: {books.Count}");

            return CustomResponse(books);
        }

        [HttpGet("obter-por-id/{id:length(24)}", Name = "GetBook")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _bookService.Get(id);

            if (book == null)
            {
                return CustomResponse();
            }

            return CustomResponse(book);
        }

        [HttpPost("inserir")]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            await _bookService.Create(book);

            return CustomResponse(book);
        }

        [HttpPut("autualizar/{id:length(24)}")]
        public async Task<IActionResult> Update([FromQuery]string id, Book bookIn)
        {
            var book = await _bookService.Get(id);

            if (book == null)
            {
                return CustomResponse();
            }

            await _bookService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("deletar/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _bookService.Get(id);

            if (book == null)
            {
                return CustomResponse();
            }

            await _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}