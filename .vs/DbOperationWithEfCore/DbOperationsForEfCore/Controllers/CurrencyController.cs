using DbOperationsForEfCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsForEfCore.Controllers
{
    [Route("api/Currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public CurrencyController(AppDbContext appdbcontext)
        {
            _appDbContext = appdbcontext;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllCurrencyAsync()
        {
            var result = await (from Currency in _appDbContext.Currencies
                                select Currency).ToListAsync();//_appDbContext.Currencies.ToList();
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrenciesByIdasync([FromRoute] int id)
        {
            var result = await _appDbContext.Currencies.FindAsync(id);
            return Ok(result);
        }
        [HttpGet("{Name}/{Description}")] //two paramters
        public async Task<IActionResult> GetCurrencybyNamessync([FromRoute] string Name, [FromRoute] string Description)
        {
            var result = await _appDbContext.Currencies
                .Where(p => p.Title == Name && p.Description==Description).
                FirstOrDefaultAsync();
            return Ok(result); 
        }
        //Multiple Paramters to get data


    }
}
