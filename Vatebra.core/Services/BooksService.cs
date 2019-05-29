using Vatebra.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Vatebra.DataAccessLayer.Entities;

namespace Vatebra.core.Services
{
    public class BooksService
    {
        private readonly BooksRepository _repo;
  
        private readonly ILogger<BooksService> _logger;
        public BooksService(BooksRepository repo,ILogger<BooksService> logger)
        {
            _repo = repo;
            _logger = logger;
        }


       /// <summary>
       /// create new book and it subscription details
       /// </summary>
       /// <param name="req"></param>
       /// <param name="subscriptionDescription"></param>
       /// <param name="subscriptionAmount"></param>
       /// <returns></returns>
        public async Task<bool> createBook(Books req, string subscriptionDescription, DateTime yearPublished, string bookAbstract, string versionTitle, decimal subscriptionAmount = 0)
        {
            var response = false;
            try
            {
                if (req == null)
                {
                    response = false;
                    return response;
                }
               var res=await  _repo.createBook(req,subscriptionDescription,  yearPublished, bookAbstract, versionTitle, subscriptionAmount);

                response = res;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error Has occured", ex);
            }
            return response;
        }

        /// <summary>
        /// Update books records based on the supplied id {id} and parameters
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="bookName"></param>
        /// <param name="bookTitle"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public async Task<bool> updateBookRecord(int bookId, string bookName, string bookTitle, string author)
        {
            var response = false;
            try
            {
                if (bookId != 0)
                {
                response= await _repo.updateBookRecord(bookId, bookName, bookTitle, author);

                }

            }
            catch (Exception ex)
            {

                _logger.LogError("Error Has occured", ex);
            }

            return response;
        }


        /// <summary>
        /// Add More Book copies of a particular book provided {id} is supplied
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="yearPublished"></param>
        /// <param name="bookAbstract"></param>
        /// <param name="description"></param>
        /// <param name="versionTitle"></param>
        /// <returns></returns>
        public async Task<bool> addBookCopies(int bookId, DateTime yearPublished, string bookAbstract, string description, string versionTitle)
        {
            var response = new bool();
            try
            {
               response = await _repo.addBookCopies(bookId, yearPublished, bookAbstract, description, versionTitle);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error Has occured", ex);
            }

            return response;
        }

        /// <summary>
        /// fetch books with a default count of 10
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<Books>> getBooks(int count = 10)
        {
            var response = new List<Books>();
            try
            {
                response = await _repo.getBooks(count);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error Has occured", ex);
            }

            return response;
        }

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>

        public async Task<Books> getBook(int bookid = 0)
        {
            var response = new Books();
            try
            {
                response = await _repo.getBook(bookid);

            }
            catch (Exception ex)
            {

                _logger.LogError("Error Has occured", ex);
            }

            return response;
        }

        /// <summary>
        /// fetch all books borrowed
        /// </summary>
        /// <returns></returns>
        public async Task<List<BooksBorrowed>> getbooksBorrowed()
        {
            var response = new List<BooksBorrowed>();
            try
            {
                response = await _repo.getbooksBorrowed();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error Has occured", ex);
            }

            return response;
        }


        /// <summary>
        /// fetch all books borrowed that are over due
        /// </summary>
        /// <returns></returns>
        public async Task<List<BooksBorrowed>> getbooksBorrowedOverDue()
        {
            var response = new List<BooksBorrowed>();
            try
            {
                response = await _repo.getbooksBorrowedOverDue();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Has occured", ex);
            }

            return response;
        }

        /// <summary>
        /// Get a single booked borrowed based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BooksBorrowed> getbookBorrowed(int id = 0)
        {
            var response = new BooksBorrowed();
            try
            {
                response =await  _repo.getbookBorrowed(id);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error Has occured", ex);
            }

            return response;
        }


        /// <summary>
        /// Get the sum of all the revenue of the borrowed books
        /// </summary>
        /// <returns></returns>
        public async Task<string> getTotalRevenue()
        {
            var response = string.Empty;
            try
            {
                response =await _repo.getTotalRevenue();
            }
            catch (Exception ex)
            {

                _logger.LogError("Error Has occured", ex);
            }

            return response;
        }
    }
}

