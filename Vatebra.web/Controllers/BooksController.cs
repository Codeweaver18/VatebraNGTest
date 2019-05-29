using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vatebra.core.Services;
using Vatebra.DataAccessLayer.Entities;
using Vatebra.web.ViewModels;

namespace Vatebra.web.Controllers
{
    public class BooksController : Controller
    {
       
        private readonly ILogger<BooksController> _logger;
        private readonly BooksService _bookService;

        public BooksController(ILogger<BooksController> logger, BooksService booksService)
        {
            _logger = logger;
            _bookService = booksService;
        }

        /// <summary>
        /// Create Instance of a new book
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateBooks(CreateBookViewModel vm)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var result = await _bookService.createBook(new DataAccessLayer.Entities.Books { BookAuthor = vm.BookAuthor, bookName = vm.bookName, bookTitle = vm.bookTitle }, vm.Description,vm.yearPublished, vm.bookAbstract, vm.versionTitle, vm.Amount);
                    if (result)
                    {
                        _logger.LogInformation("New Book has been Created with");
                        ViewData["CreateBookMessage"] = "New Book has been created successfully";//TODO: Make all this literals to enums to avoid too much strings

                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["CreateBookMessageError"] = ex.Message;
                _logger.LogError(ex, "An Error has occured, Test May Not be created");
            
            }

            return View();

        }

        /// <summary>
        /// Get method for createbooks
        /// </summary>
        /// <returns></returns>
       [HttpGet]
        public async Task<IActionResult> CreateBooks()
        {

          
            return View();


        }


        /// <summary>
        /// Get List of all books in the system=?NOTE: implementation is done from razor view using injectable service
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewBooks()
        {
          

            return View();
        }

        /// <summary>
        /// View all the details of a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> viewBooksDetails(int id=0)
        {
            try
            {
                ViewData["viewBookId"] = id;
                _logger.LogInformation("Logged Books Id::"+id);

            }
            catch (Exception ex)
            {

                ViewData["ViewBookMessageError"] = ex.Message;
                _logger.LogError(ex, "An Error has occured, Test May Not be created");
            }

            return View();
        }


        /// <summary>
        /// Add more copies of a particular book {bookId}
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async  Task<IActionResult> addBookCopies (addBookCopiesViewModel vm)
        {

            try
            {
                var result =await  _bookService.addBookCopies(int.Parse(vm.bookId), vm.yearPublished, vm.bookAbstract, vm.description, vm.versionTitle);
                if (result)
                {
                    ViewData["addBookCopiesSuccess"] = "Book Copoies has been added successfully";

                    return RedirectToAction("viewBooksDetails", new { id = int.Parse(vm.bookId) });
                }

                else if (!result)
                {
                    ViewData["addBookCopiesError"] = "Oops an error has occured";
                }
            }
            catch (Exception ex)
            {

                ViewData["ViewBookMessageError"] = ex.Message;
                _logger.LogError(ex, "An Error has occured", ex.Message);
            }


            return View();
        }

        /// <summary>
        /// Get the 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> addBookCopies(int id = 0)
        {

            try
            {
                ViewData["addBookCopiesId"] = id;
            }
            catch (Exception ex)
            {

                ViewData["ViewBookMessageError"] = ex.Message;
                _logger.LogError(ex, "An Error has occured", ex.Message);
            }


            return View();
        }

        /// <summary>
        /// Get More Details of a ParticularBook such as copies available, subscription etc
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<IActionResult> ViewBook(int bookId=0)
        {
            var response = new Books();
            try
            {
                var result = await _bookService.getBook(bookId);
                

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An Error has occured, Test May Not be created");
                StatusCode(500, ex.Message);
                return View();
            }

            return View(response);
        }

        /// <summary>
        /// Delete a book from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> deleteBooks(int id)
        {
            try
            {
                var result =await _bookService.deletebookbyId(id);
                if (result)
                {
                    _logger.LogInformation("Book has been deleted with ID::=>"+id);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error has occured, Test May Not be created");
                StatusCode(500, ex.Message);
                return View();
            }

            return View();
        }

        public IActionResult BorrowedBooks()
        {
            return View();
        }
        public IActionResult OverdueBorrowedDate()
        {
            return View();
        }
        public IActionResult TodayRevenue()
        {
            return View();
        }
       
    }
}