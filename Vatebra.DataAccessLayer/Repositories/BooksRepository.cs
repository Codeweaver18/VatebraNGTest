﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vatebra.DataAccessLayer.Dbcontext;
using Vatebra.DataAccessLayer.Entities;
using System.Linq;

namespace Vatebra.DataAccessLayer.Repositories
{

    /// <summary>
    /// Class repository for handling all sort of database persistency.
    /// //******************

    /// </summary>
    public class BooksRepository : GenericRepository<BooksRepository>
    {
        private VatebraDbContext _dbContext;

        public BooksRepository(VatebraDbContext dbContext)
            : base(dbContext)
        {

            _dbContext = dbContext;
        }


        public async Task<bool> borrowBooks(BooksBorrowed req){

            var response = false;
            try
            {
                _dbContext.BooksBorrowed.Add(req);
                if (await _dbContext.SaveChangesAsync()>0)
                {
                    response = true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;
        }
        /// <summary>
        /// Create/Persit new book record into the Db and also add it type of subscription
        /// TODO:// All Literals should be in enums
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<bool> createBook(Books req, string subscriptionDescription, DateTime yearPublished, string bookAbstract, string versionTitle, decimal subscriptionAmount = 0)
        {
            var response = false; 
            try
            {
                if (req==null)
                {
                    response = false;
                    return response;
                }
                _dbContext.Books.Add(req);
                if (await _dbContext.SaveChangesAsync()>0)
                {
                    //create subscription for the books
                    var bookSub = new BookSubscriptionDetails();
                    bookSub.Description = subscriptionDescription;
                    bookSub.Books = req;
                    bookSub.Amount = subscriptionAmount;
                    if (subscriptionAmount>0)
                    {
                        bookSub.isfree = "NO";
                    }

                    else if (subscriptionAmount<=0)
                    {
                        bookSub.isfree = "YES";
                            
                    }
                    _dbContext.BookSubscriptionDetails.Add(bookSub);

                    if (await _dbContext.SaveChangesAsync()>0)
                    {
                        //create copies of the book
                        _dbContext.BookCopies.Add(new BookCopies {Books=req, bookAbstract=bookAbstract, description=subscriptionDescription, versionTitle=versionTitle, yearPublished=yearPublished});
                       await _dbContext.SaveChangesAsync();//saving changes to database

                        response = true;
                        return response;
                    }

                  
                }
            }
            catch (Exception ex)
            {

                throw ex;
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
        public async Task<bool> updateBookRecord (int bookId, string bookName, string bookTitle, string author)
        {
            var response = false;
            try
            {
                if (bookId != 0)
                {
                    var getBook = (from x in _dbContext.Books where x.id == bookId select x).FirstOrDefault();
                    if (getBook==null)
                    {
                        response= false;
                        return response;
                    }



                    //update object with supplied parameters
                    getBook.bookName = bookName;
                    getBook.bookTitle = bookTitle;
                    getBook.BookAuthor = author;
                    getBook.dateModified = DateTime.Now;

                    var save = await _dbContext.SaveChangesAsync();
                    if (save>0)
                    {
                        response = true;
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;
        }

  
        /// <summary>
        /// Add More Book copies of a particular book provided id is supplied
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="yearPublished"></param>
        /// <param name="bookAbstract"></param>
        /// <param name="description"></param>
        /// <param name="versionTitle"></param>
        /// <returns></returns>
        public async Task <bool> addBookCopies(int bookId, DateTime yearPublished, string bookAbstract, string description, string versionTitle)
        {
            var response = new bool();
            try
            {
                var result = (from x in _dbContext.Books where x.id == bookId select x).FirstOrDefault();
                if (result!=null)
                {

                   _dbContext.BookCopies.Add(new BookCopies { bookAbstract = bookAbstract, description = description, versionTitle = versionTitle, yearPublished = yearPublished, Books=result });
                    if (await _dbContext.SaveChangesAsync()>0)
                    {
                        response = true;
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;
        }

        /// <summary>
        /// fetch books with a default count of 10
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task <List<Books>> getBooks(int count=10)
        {
            var response =new  List<Books>();
            try
            {
                var result = (from x in _dbContext.Books select x).Take(count).ToList();
                response = result;
                //return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;
        }

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>

        public async Task<Books> getBook(int bookid=0)
        {
            var response = new Books();
            try
            {
                var result = (from x in _dbContext.Books where x.id == bookid select x).FirstOrDefault();
                response = result;

            }
            catch (Exception ex)
            {

                throw ex;
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
                var result = (from x in _dbContext.BooksBorrowed select x).ToList();
                response = result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;
        }

        /// <summary>
        /// fetch all books borrowed that are overdue
        /// </summary>
        /// <returns></returns>
        public async Task<List<BooksBorrowed>> getbooksBorrowedOverDue()
        {
            var response = new List<BooksBorrowed>();
            try
            {
                var result = (from x in _dbContext.BooksBorrowed where x.dueReturnedDate.Date>DateTime.Today.Date select x).ToList();
                response = result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;
        }

        /// <summary>
        /// Get a single booked borrowed based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BooksBorrowed> getbookBorrowed(int id=0)
        {
            var response = new BooksBorrowed();
            try
            {
                var result = (from x in _dbContext.BooksBorrowed where x.id == id select x).FirstOrDefault();
                response = result;

            }
            catch (Exception ex)
            {

                throw ex;
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
                var result = (from x in _dbContext.BooksBorrowed where x.dateBorrowed.Date == DateTime.Today.Date select x.books.BookSubscriptionDetails.Amount).Sum();
                response = result.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;
        }

        /// <summary>
        /// delete/detach/remove a book entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> deleteBookById(int id)
        {
            var response = false;
            try
            {
                var bookid = (from x in _dbContext.Books where x.id == id select x).FirstOrDefault();
                _dbContext.Books.Remove(bookid);
                var result= await _dbContext.SaveChangesAsync();
                if (result>0)
                {
                    response = true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;
        }
    }
}
