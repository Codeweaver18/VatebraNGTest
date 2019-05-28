using System;
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
    
    //-get list of borrowed books
    //-get list of borrowedbooks which duedateis greater than today.date
    //-get sum of amount where
    /// </summary>
    public class BooksRepository : GenericRepository<BooksRepository>
    {
        private VatebraDbContext _dbContext;

        public BooksRepository(VatebraDbContext dbContext)
            : base(dbContext)
        {

            _dbContext = dbContext;
        }


        /// <summary>
        /// Create/Persit new book record into the Db
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<bool> createBook(Books req)
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
                    response = true;
                    return response;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
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
        public async Task <bool> addBookCopies(int bookId, string yearPublished, string bookAbstract, string description, string versionTitle)
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
    }
}
