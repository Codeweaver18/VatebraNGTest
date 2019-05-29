using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Vatebra.core.Services;
using Vatebra.DataAccessLayer.Repositories;
using Xunit;

namespace ServiceTesting
{

    /// <summary>
    /// Test not fully implemented yet to implement mocking framework; sorry i had to stop here; cheer
    /// </summary>
    public class ServiceTesting
    {
        private readonly BooksService _service;
        private readonly BooksRepository _repo;
        public ServiceTesting(BooksRepository repo, ILogger<BooksService> logger, BooksService service)
        {
            _service = service;
           //_repo=
        }
        /// <summary>
        /// testing to make sure null values is return for book with id zero
        /// </summary>
         [Fact]
        public async Task  ReturNullforGetBookwithvalueofZero()
        {
            var result =await  _service.getBook(0);

            Assert.Null(result);
        }


        /// <summary>
        /// testing to make sure null values is returned with a type which is not null for books id (2,3,4,5) just as in database. please replace with your own value
        /// </summary>
        [Fact]
        public async Task  ReturnNotNullforGetBooksNotzero()
        {
            var result =await _service.getBook(2);

            Assert.NotNull(result);
        }
    }
}
