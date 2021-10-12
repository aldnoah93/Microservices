using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.api.BookStore.Core.Entities;
using Services.api.BookStore.Repository;

namespace Services.api.BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMongoRepository<Author> _repository;
        public AuthorController(IMongoRepository<Author> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAsync(){
            var authors = await _repository.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Author>>> GetByIdAsync(string id){
            var authors = await _repository.GetByIdAsync(id);
            return Ok(authors);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Author>>> InsertAsync([FromBody]Author author){
            await _repository.InsertAsync(author);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Author>>> InsertAsync(string id, [FromBody]Author author){
            await _repository.UpdateAsync(author);
            return Ok();
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Author>>> DeleteById(string id){
            await _repository.DeleteByIdAsync(id);
            return Ok(); 
        }

        [HttpPost("pagination")]
        public async Task<ActionResult<PaginationEntity<Author>>> PostPagination(PaginationEntity<Author> pagination){
            var result = await _repository.PaginationByAsync(filter => filter.Name == pagination.Filter, pagination);
            return Ok(result);
        }
    }
}