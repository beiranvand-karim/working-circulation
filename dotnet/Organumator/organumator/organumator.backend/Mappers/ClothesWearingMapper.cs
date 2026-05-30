using organumator.Dtos;
using organumator.Models;

namespace organumator.Mappers
{
    public static class ClothesWearingMapper
    {
        public static ClothesWearingDto ToDto(this ClothesWearing clothesWearing)
        {
            return new ClothesWearingDto
            {
                Id = clothesWearing.Id,
                Differentiator = clothesWearing.Differentiator,
                WearingStart = clothesWearing.WearingStart,
                WearingFinish = clothesWearing.WearingFinish
            };
        }

        public static ClothesWearing ToEntity(this ClothesWearingDto clothesWearingDto)
        {
            return new ClothesWearing
            {
                Id = clothesWearingDto.Id,
                Differentiator = clothesWearingDto.Differentiator,
                WearingStart = clothesWearingDto.WearingStart,
                WearingFinish = clothesWearingDto.WearingFinish
            };
        }
    }
}
