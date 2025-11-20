using Lab2.Models;
using Microsoft.AspNetCore.Identity;
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
                new GameLevel { LevelId = 1, Title = "Cấp độ 1" },
                new GameLevel { LevelId = 2, Title = "Cấp độ 2" },
                new GameLevel { LevelId = 3, Title = "Cấp độ 3" }
                );
            builder.Entity<Region>().HasData(
                new Region { RegionId = 1, Name = "Đồng bằng sông hồng" },
                new Region { RegionId = 2, Name = "Đồng bằng sông cửu long" }
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

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "001",
                    UserName = "tdakhoa14012005@gmail.com",
                    NormalizedUserName = "TDAKHOA14012005@GMAIL.COM",
                    Email = "tdakhoa14012005@gmail.com",
                    NormalizedEmail = "TDAKHOA14012005@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "Anhkhoa2005"),
                    SecurityStamp = Guid.NewGuid().ToString(),

                    Name = "Anh Khoa",
                    RegionId = 1,
                    IsDeleted = false,
                     OTP = "initial"
                },
                new ApplicationUser
                {
                    Id = "002",
                    UserName = "hatakeiku450@gmail.com",
                    NormalizedUserName = "HATAKEIKU450@GMAIL.COM",
                    Email = "hatakeiku450@gmail.com",
                    NormalizedEmail = "HATAKEIKU450@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "Anhkhoa2005@"),
                    SecurityStamp = Guid.NewGuid().ToString(),

                    Name = "Anh Khoa 2",
                    RegionId = 2,
                    IsDeleted = false,
                    OTP = "initial"
                }
            );
        }
    }
}
