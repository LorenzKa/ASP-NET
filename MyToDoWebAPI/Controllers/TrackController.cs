using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDoWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly MusicContext db;

        public TrackController(MusicContext db)
        {
            this.db = db;
        }


    }
}
