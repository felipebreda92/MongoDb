﻿using Api.MongoDb.Models;
using Api.MongoDb.Services.Interfaces;
using KissLog;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger _logger;

        public BooksController(IBookService bookService, ILogger logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            var books = await _bookService.Get();

            _logger.Info($"Quantidade de registros recuperados: {books.Count}");

            return books;
        }

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            await _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update([FromQuery]string id, Book bookIn)
        {
            var book = await _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            await _bookService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            await _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}