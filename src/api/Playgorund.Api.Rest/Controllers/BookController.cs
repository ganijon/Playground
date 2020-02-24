using System.Collections.Generic;
using System.Linq;
using Playground.Data;
using Playground.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Playground.Api.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private readonly IRepository _repository;

        public BookController(IRepository repository, ILogger<BookController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _repository.Books.ToList();
        }
    }
}
