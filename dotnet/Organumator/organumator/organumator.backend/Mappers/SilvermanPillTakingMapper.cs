using organumator.Models;

namespace organumator.Mappers
{
    public static class SilvermanPillTakingMapper
    {
        public static SilvermanPillTaking MapToModel(this SilvermanPillTaking entity)
        {
            return new SilvermanPillTaking
            {
                Id = entity.Id,
                PerformedOnDate = entity.PerformedOnDate
            };
        }

        public static SilvermanPillTaking MapToEntity(this SilvermanPillTaking model)
        {
            return new SilvermanPillTaking
            {
                Id = model.Id,
                PerformedOnDate = model.PerformedOnDate
            };
        }
    }
}