using organumator.Dtos;
using organumator.Models;

namespace organumator.Mappers
{
    public static class FaceHydrationMapper
    {

        public static FaceHydrationDto ToDto(this FaceHydration faceHydration)
        {
            return new FaceHydrationDto
            {
                Id = faceHydration.Id,
                PerformedOnDate = faceHydration.PerformedOnDate
            };
        }

        public static FaceHydration ToEntity(this FaceHydrationDto faceHydrationDto)
        {
            return new FaceHydration
            {
                Id = faceHydrationDto.Id,
                PerformedOnDate = faceHydrationDto.PerformedOnDate
            };
        }
    }
}