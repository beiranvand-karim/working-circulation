using Microsoft.EntityFrameworkCore;
using organumator.Models;

namespace organumator.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<AroundBrushing> AroundBrushings { get; set; }
        public DbSet<FaceHydration> FaceHydrations { get; set; }
        public DbSet<SilvermanPillTaking> SilvermanPillTakings { get; set; }
        public DbSet<LivergolPillTakingModel> LivergolPillTakings { get; set; }
        public DbSet<BetweenTeethBrushing> BetweenTeethBrushings { get; set; }
        public DbSet<CalciferolTakingModel> CalciferolTakings { get; set; }
    }
}