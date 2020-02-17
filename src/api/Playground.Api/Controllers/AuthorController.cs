using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Playground.Data;
using Playground.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Playground.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {

        private readonly ILogger<AuthorController> _logger;
        private readonly IRepository _repository;

        public AuthorController(IRepository repository, ILogger<AuthorController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _repository.Authors.ToList();
        }
    }
}
