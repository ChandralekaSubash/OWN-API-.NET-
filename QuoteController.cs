using Microsoft.AspNetCore.Mvc;
using webapiqoute.Models;

namespace webapiqoute.Controllers;

[ApiController]
[Route("api/quotecontroller")]
public class QuoteController : ControllerBase
{
  private readonly QuotDbContext DB;
  public QuoteController (QuotDbContext db)
  {
    this.DB = db;
  }

   [HttpGet("advice")]
  public IQueryable<Quote> advice()
  {
    try
    {
        return DB.Quotes;
    }
    catch(System.Exception)
    {
        throw;
    }
  }
    [HttpGet("getuser")]
    public Quote getbyid(string advicetopic)
{
    try
    {
       return  DB.Quotes.Where(e =>e.AdviceCatagory.Equals(advicetopic)).FirstOrDefault();
    }
    catch (System.Exception)
    {
        
        throw;
    }
}

  
}