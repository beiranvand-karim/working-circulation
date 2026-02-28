using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organumator.Dtos
{
    public class AroundBrushingDto
    {
        public int Id { get; set; }

        public DateTime PerformedOnDate { get; set; } = DateTime.Now;
    }
}