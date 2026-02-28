using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organumator.Mappers
{
    public static class AroundBrushingMapper
    {
        public static Dtos.AroundBrushingDto ToAroundBrushingDto(this Models.AroundBrushing aroundBrushing)
        {
            return new Dtos.AroundBrushingDto
            {
                Id = aroundBrushing.Id,
                PerformedOnDate = aroundBrushing.PerformedOnDate
            };
        }
    }
}