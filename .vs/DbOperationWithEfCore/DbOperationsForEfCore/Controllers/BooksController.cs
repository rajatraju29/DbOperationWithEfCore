using DbOperationsForEfCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsForEfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(AppDbContext appdbcontext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var bookdata = await appdbcontext.Books.Where(b => b.IsActive).ToListAsync();
            if (bookdata == null)
            {
                return NotFound();
            }
            return Ok(bookdata);
        }
        [HttpGet("TotalUsers")]
        public async Task<IActionResult> TotalUsers()
        {
            try
            {
                var users = await appdbcontext.Books.CountAsync();
                if(users == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpGet("RecentBook")]
        public async Task<IActionResult> RecentBook()
        {
            try
            {
                var users = await appdbcontext.Books
                .OrderByDescending(b => b.CreatedOn)
                .Take(2)
                .ToListAsync();

                if (users == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        [HttpPost("AddNewBookAsync")]
        public async Task<IActionResult> AddNewBookAsync([FromBody] Book book)
        {
            book.CreatedOn = DateTime.Now;
            var bookdata = appdbcontext.Books.Add(book);
            await appdbcontext.SaveChangesAsync();
            return Ok(new
            {
                message = "Book added successfully.",
                data = book
            });
          //  return Ok(book);

        }
        [HttpPost("Bulk")] //Update Data insert data 
        public async Task<IActionResult> AddBulkBookAsync([FromBody] List<Book> book)
        {
            appdbcontext.Books.AddRange(book);
            await appdbcontext.SaveChangesAsync();
            return Ok(book);

        }
        [HttpPut("updateBookAsync/{Bookid}")]
        public async Task<IActionResult> updateBookAsync([FromRoute] int Bookid, [FromBody] Book model)
        {
            var book = appdbcontext.Books.FirstOrDefault(x => x.Id == Bookid);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = model.Title;
            book.Description = model.Description;
            book.NoOfPages = model.NoOfPages;
            book.IsActive = model.IsActive;
            book.CreatedOn = model.CreatedOn;
            book.LanguageId = model.LanguageId;

            await appdbcontext.SaveChangesAsync();
            return Ok(new
            {
                message = "Book Updated Successfully!",
                data=model
            });
            //return Ok(model);

        }
        [HttpDelete("DeleteBookasync/{Bookid}")]
        public async Task<IActionResult>DeleteBookasync(int Bookid)
        {
            var book = appdbcontext.Books.FirstOrDefault(x => x.Id == Bookid);
            if (book == null)
            {
                return NotFound();
            }
            appdbcontext.Remove(book);
            await appdbcontext.SaveChangesAsync();
            return Ok(new { message = "Book Deleted SuccessFully" });
        }
    }
}
