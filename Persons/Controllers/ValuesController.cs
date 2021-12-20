namespace Persons.Controllers;

[Route("[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
  private readonly PersonsContext db;
  public ValuesController(PersonsContext db)
  {
    this.db = db;
  }
  
  [HttpGet("Persons")]
  public object GetPersons()
  {
    Console.WriteLine($"{DateTime.Now:HH:mm:ss} GetPersons");
    try
    {
  	  int nr = db.Persons.Count();
  	  return new { IsOk = true, Nr = nr };
    }
    catch (Exception exc)
    {
  	  return new { IsOk = false, Nr = -1, Error = exc.Message };
    }
  }

}

