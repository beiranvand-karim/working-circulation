using organumator.Dtos;
using organumator.Models;

namespace organumator.Mappers
{
    public static class VacuumCleaningsMapper
    {
        public static VacuumCleaningsDto ToDto(this VacuumCleanings vacuumCleanings)
        {
            return new VacuumCleaningsDto
            {
                Id = vacuumCleanings.Id,
                PerformedOnDate = vacuumCleanings.PerformedOnDate
            };
        }

        public static VacuumCleanings ToEntity(this VacuumCleaningsDto vacuumCleaningsDto)
        {
            return new VacuumCleanings
            {
                Id = vacuumCleaningsDto.Id,
                PerformedOnDate = vacuumCleaningsDto.PerformedOnDate
            };
        }
    }
}