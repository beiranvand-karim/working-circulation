using organumator.Dtos;
using organumator.Models;

namespace organumator.Mappers
{
    public static class CleanupTimeManagementMapper
    {
        public static CleanupTimeManagementDto ToDto(this CleanupTimeManagement model)
        {
            return new CleanupTimeManagementDto
            {
                Id = model.Id,
                StartedAt = model.StartedAt,
                FinishedAt = model.FinishedAt
            };
        }

        public static CleanupTimeManagement ToEntity(this CleanupTimeManagementDto dto)
        {
            return new CleanupTimeManagement
            {
                Id = dto.Id,
                StartedAt = dto.StartedAt,
                FinishedAt = dto.FinishedAt
            };
        }
    }
}
