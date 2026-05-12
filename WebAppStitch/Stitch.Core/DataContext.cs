using Microsoft.EntityFrameworkCore;
using Stitch.Core.Dtos;

namespace Stitch.Core
{
    public class DataContext : DbContext
    {
        public DataContext()
        { }
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        { }
        public DbSet<CanvasDto> Canvas { get; set; }
        public DbSet<KitDto> Kit { get; set; }
        public DbSet<ManufacturerDto> Manufacturer { get; set; }
        public DbSet<NeedleworkDto> Needlework { get; set; }
        public DbSet<StatusDto> Status { get; set; }
        public DbSet<ThemeDto> Theme { get; set; }
    }
}
