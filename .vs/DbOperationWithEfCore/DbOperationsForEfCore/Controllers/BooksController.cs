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


        [HttpGet("thisMonthbook")]
        public async Task<IActionResult> thisMonthbook()
        {
            try
            {
                var currentMonth = DateTime.Now.Month;
                var currrentYear = DateTime.Now.Year;
                var result = await appdbcontext.Books.Where(b => b.CreatedOn.Month == currentMonth && b.CreatedOn.Year == currrentYear).ToListAsync();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("RecentBook")]
        public async Task<IActionResult> RecentBook()
        {
            try
            {
                var users = await (from book in appdbcontext.Books
                                  join Status in appdbcontext.Statuses
                                  on book.Statusid equals Status.Statusid
                                  orderby book.CreatedOn descending
                                  select new
                                  {
                                      book.Title,
                                      book.Description,
                                      book.NoOfPages,
                                      book.CreatedOn,
                                      Status.StatusDesc
                                  }
                ).Take(2).ToListAsync();

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

        [HttpPost("ProfileCrud")]

        //public async Task<IActionResult> ProfileCrud([FromBody] ProfileDto request)
        //{
        //    try
        //    {
        //        if (request == null || string.IsNullOrEmpty(request.Action))
        //            return BadRequest("Invalid request data.");

        //        var action = request.Action.Trim();

        //        if (action.Equals("create", StringComparison.OrdinalIgnoreCase))
        //        {
        //            var user = await appdbcontext.Users.FirstOrDefaultAsync(u => u.Id == request.ProfileId);
        //            var newProfile = new Profile
        //            {
        //                ProfileId = user.Id, // 👈 same as UserId
        //                User = user,         // 👈 attach the user
        //                Name = request.Name,
        //                Email = request.Email,
        //                Address = request.Address,
        //                City = request.City,
        //                Mobile = request.Mobile
        //            };
        //            appdbcontext.Add(newProfile);
        //            await appdbcontext.SaveChangesAsync();

        //            return Ok(new { message = "Profile created successfully." });
        //        }

        //        if (action.Equals("read", StringComparison.OrdinalIgnoreCase))
        //        {
        //            var profile = await appdbcontext.Profiles
        //                .Include(p => p.User)
        //                .FirstOrDefaultAsync(p => p.ProfileId == request.ProfileId);

        //            if (profile == null)
        //                return NotFound("Profile not found.");

        //            return Ok(profile);
        //        }

        //        if (action.Equals("update", StringComparison.OrdinalIgnoreCase))
        //        {
        //            var updateProfile = await appdbcontext.Profiles.FindAsync(request.ProfileId);
        //            if (updateProfile == null)
        //                return NotFound("Profile not found.");

        //            updateProfile.Name = request.Name ?? updateProfile.Name;
        //            updateProfile.Mobile = request.Mobile ?? updateProfile.Mobile;
        //            updateProfile.Address = request.Address ?? updateProfile.Address;
        //            updateProfile.Email = request.Email ?? updateProfile.Email;
        //            updateProfile.City = request.City ?? updateProfile.City;

        //            await appdbcontext.SaveChangesAsync();
        //            return Ok(new { message = "Profile updated successfully." });
        //        }

        //        if (action.Equals("delete", StringComparison.OrdinalIgnoreCase))
        //        {
        //            var profileToDelete = await appdbcontext.Profiles.FindAsync(request.ProfileId);
        //            if (profileToDelete == null)
        //                return NotFound("Profile not found.");

        //            appdbcontext.Profiles.Remove(profileToDelete);
        //            await appdbcontext.SaveChangesAsync();

        //            return Ok(new { message = "Profile deleted successfully." });
        //        }

        //        return BadRequest("Invalid action. Use 'create', 'read', 'update', or 'delete'.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}
        [HttpGet("PrfileDetailsbyUsername")]
        public async Task<IActionResult> PrfileDetailsbyUsername(string Username)
        {
            try
            {
                var result = from mst in appdbcontext.Users
                             join up in appdbcontext.Profiles
                             on mst.Id equals up.ProfileId
                             where mst.Username== Username
                             select new
                             {
                                 username = mst.Username,
                                 Name = up.Name,
                                 mobile = up.Mobile,
                                 Address = up.Address,
                                 City = up.City
                             };
                   var userProfileList =  await result.ToListAsync();
                return Ok(userProfileList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("UpdateProfiles")]
        public async Task<IActionResult> UpdateProfiles([FromBody] ProfileDto prof)
        {
            try
            {
                //var existingProfile = await PrfileDetailsbyUsername();
                var user = await appdbcontext.Users.FirstOrDefaultAsync(x => x.Username == prof.username);
                if (user != null)
                {
                    var profiledetails = await appdbcontext.Profiles.FirstOrDefaultAsync(x => x.ProfileId == user.Id);
                    if (profiledetails == null) 
                    {
                        return NotFound(new { message = "profile not found" });
                    }
                    else
                    {
                        profiledetails.Name = prof.Name;
                        profiledetails.Mobile = prof.Mobile;
                        profiledetails.Address = prof.Address;
                        profiledetails.City = prof.City;
                       // profiledetails.Email = prof.Email;
                         await appdbcontext.SaveChangesAsync();
                        return Ok(new { message = "Profile Updated SuccesFully" });
                           
                    }
                }

                    
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(new { returnMsg = "Payee updated successfully." });
        }

        [HttpPost("savecontactinfo")]
        public async Task<IActionResult> savecontactinfo([FromBody] Contact con)
        {

            try
            {
                var res = await appdbcontext.Contacts.AddAsync(con);
                await appdbcontext.SaveChangesAsync();

                return Ok(new { message = "Contact details Saved Successfully" });
            }
            catch (Exception)
            {

                throw;
            }
        }
       

    }
}
