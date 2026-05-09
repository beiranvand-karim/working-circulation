using organumator.Dtos;
using organumator.Models;

namespace organumator.Mappers
{
    public static class BetweenTeethBrushingMapper
    {
        public static BetweenTeethBrushingDto ToDto(BetweenTeethBrushing betweenTeethBrushing)
        {
            return new BetweenTeethBrushingDto
            {
                Id = betweenTeethBrushing.Id,
                PerformedOnDate = betweenTeethBrushing.PerformedOnDate
            };
        }

        public static BetweenTeethBrushing ToEntity(BetweenTeethBrushingDto betweenTeethBrushingDto)
        {
            return new BetweenTeethBrushing
            {
                Id = betweenTeethBrushingDto.Id,
                PerformedOnDate = betweenTeethBrushingDto.PerformedOnDate
            };
        }
    }
}