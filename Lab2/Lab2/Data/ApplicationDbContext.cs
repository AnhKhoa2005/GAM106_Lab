using Lab2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<GameLevel> GameLevels { get; set; }
        public DbSet<Quession> Quessions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<LevelResult> LevelResults { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<GameLevel>().HasData(
                new GameLevel { LevelId = 1, Title = "Cấp độ 1"},
                new GameLevel { LevelId = 2, Title = "Cấp độ 2"},
                new GameLevel { LevelId = 3, Title = "Cấp độ 3"}
                );
            builder.Entity<Region>().HasData(
                new Region { RegionId = 1, Name = "Đồng bằng sông hồng"},
                new Region { RegionId = 2, Name = "Đồng bằng sông cửu long"}
                );
            builder.Entity<Quession>().HasData(
                new Quession
                {
                    QuessionId = 1,
                    ContentQuession = "Câu hỏi 1",
                    Answer = "Đáp án 1",
                    Option1 = "Đáp án 1",
                    Option2 = "Đáp án 2",
                    Option3 = "Đáp án 3",
                    Option4 = "Đáp án 4",
                    levelId = 1,
                },
                new Quession
                {
                    QuessionId = 2,
                    ContentQuession = "Câu hỏi 2",
                    Answer = "Đáp án 2",
                    Option1 = "Đáp án 1",
                    Option2 = "Đáp án 2",
                    Option3 = "Đáp án 3",
                    Option4 = "Đáp án 4",
                    levelId = 2,
                }
                );
        }
    }
}
