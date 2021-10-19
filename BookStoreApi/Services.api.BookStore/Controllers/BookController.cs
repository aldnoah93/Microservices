using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Services.api.BookStore.Core.Entities;
using Services.api.BookStore.Repository;

namespace Services.api.BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMongoRepository<Book> _repository;
        public BookController(IMongoRepository<Book> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAsync(){
            var books = await _repository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Author>>> GetByIdAsync(string id){
            var authors = await _repository.GetByIdAsync(id);
            return Ok(authors);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Book>>> InsertAsync([FromBody]Book book){
            await _repository.InsertAsync(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Book>>> InsertAsync(string id, [FromBody]Book book){
            await _repository.UpdateAsync(book);
            return Ok();
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Book>>> DeleteById(string id){
            await _repository.DeleteByIdAsync(id);
            return Ok(); 
        }

        [HttpPost("pagination")]
        public async Task<ActionResult<PaginationEntity<Author>>> PostPagination(PaginationEntity<Book> pagination){
            var result = await _repository.PaginationByAsync(filter => filter.Description == pagination.Filter, pagination);
            return Ok(result);
        }

        [HttpPost("paginationFiltered")]
        public async Task<ActionResult<PaginationEntity<Author>>> PostPaginationByFilter(PaginationEntity<Book> pagination){
            var result = await _repository.PaginationByFilterAsync(pagination);
            return Ok(result);
        }
    }
}