using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AroundBrushingController
    {
        
        [HttpGet]
            public IEnumerable<AroundBrushing> Get()
            {
                return
                [
                    new AroundBrushing { Id = 1, PerformedOnDate = DateTime.Now },
                    new AroundBrushing { Id = 2, PerformedOnDate = DateTime.Now.AddDays(-1) }
                ];
            }
    }
}