﻿using System;
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
        public async Task<IActionResult> CreateBooks(BookViewModel vm)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var result =await _bookService.createBook(new DataAccessLayer.Entities.Books { BookAuthor = vm.BookAuthor, bookName = vm.bookName, bookTitle = vm.bookTitle });
                    if (result)
                    {
                        _logger.LogInformation("New Book has been Created with");

                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An Error has occured, Test May Not be created");
                return StatusCode(500, ex.Message);
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
        /// Get List of all books in the system
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewBooks()
        {
            var response = new List<Books>();
            try
            {
                var result = await _bookService.getBooks();
              
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An Error has occured, Test May Not be created");
                return StatusCode(500, ex.Message);
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