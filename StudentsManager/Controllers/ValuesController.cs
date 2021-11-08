using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsManagerDb;

namespace StudentsManager.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
	private readonly StudentsManagerContext db;
	public ValuesController(StudentsManagerContext db)
	{
	  this.db = db;
	}
	  
    [HttpGet("Getstudents")]
    public object Getstudents()
    {
      try
      {
        int nr = db.Students.Count();
        return new { IsOk = true, Nr = nr };
      }
      catch (Exception exc)
      {
        return new { IsOk = false, Nr = -1, Error = exc.Message };
      }
    }

  }
}
