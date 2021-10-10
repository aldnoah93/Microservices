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
        private readonly IAuthorRepository _repository;
        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAsync(){
            var authors = await _repository.GetAuthorsAsync();
            return Ok(authors);
        }
    }
}