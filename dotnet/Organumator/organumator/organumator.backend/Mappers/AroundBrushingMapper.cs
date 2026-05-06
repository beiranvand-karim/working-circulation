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