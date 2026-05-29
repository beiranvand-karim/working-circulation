using organumator.Dtos;
using organumator.Models;

namespace organumator.Mappers
{
    public static class SimcardChargingMapper
    {
        public static SimcardChargingDto ToDto(this SimcardCharging model)
        {
            return new SimcardChargingDto
            {
                Id = model.Id,
                ChargedAt = model.ChargedAt
            };
        }

        public static SimcardCharging ToEntity(this SimcardChargingDto dto)
        {
            return new SimcardCharging
            {
                Id = dto.Id,
                ChargedAt = dto.ChargedAt
            };
        }
    }
}
