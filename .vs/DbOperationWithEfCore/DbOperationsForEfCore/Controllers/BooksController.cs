using DbOperationsForEfCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbOperationsForEfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(AppDbContext appdbcontext) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddNewBookAsync([FromBody] Book book)
        {
            book.CreatedOn = DateTime.Now;
            var bookdata = appdbcontext.Books.Add(book);
            await appdbcontext.SaveChangesAsync();
            return Ok(book);

        }
        [HttpPost("Bulk")] //Update Data insert data 
        public async Task<IActionResult> AddBulkBookAsync([FromBody] List<Book> book)
        {
            appdbcontext.Books.AddRange(book);
            await appdbcontext.SaveChangesAsync();
            return Ok(book);

        }
        [HttpPut("{Bookid}")] //List of insert data 
        public async Task<IActionResult> updateBookAsync([FromRoute] int Bookid, [FromBody] Book model)
        {
            var book = appdbcontext.Books.FirstOrDefault(x => x.Id == Bookid);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = model.Title;
            book.Description = model.Description;
            await appdbcontext.SaveChangesAsync();
            return Ok(model);

        }
        [HttpDelete("{Bookid}")]
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
