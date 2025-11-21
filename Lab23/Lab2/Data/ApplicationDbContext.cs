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
            var password = hasher.HashPassword(null!, "User@1234"); // Dùng một mật khẩu chung an toàn
            var securePassword2 = hasher.HashPassword(null!, "Anhkhoa2005@"); // Mật khẩu cho user cũ
            var securePassword1 = hasher.HashPassword(null!, "Anhkhoa2005"); // Mật khẩu cho user cũ

            // KHỐI APPLICATIONUSER ĐÃ CẬP NHẬT: BAO GỒM 10 USER
            builder.Entity<ApplicationUser>().HasData(
                // 3 User CŨ
                new ApplicationUser
                {
                    Id = "001",
                    UserName = "tdakhoa14012005@gmail.com",
                    NormalizedUserName = "TDAKHOA14012005@GMAIL.COM",
                    Email = "tdakhoa14012005@gmail.com",
                    NormalizedEmail = "TDAKHOA14012005@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = securePassword1,
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
                    PasswordHash = securePassword2,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = "Anh Khoa 2",
                    RegionId = 2,
                    IsDeleted = false,
                    OTP = "initial"
                },
                new ApplicationUser
                {
                    Id = "003",
                    UserName = "anhkhoa123@gmail.com",
                    NormalizedUserName = "ANHKHOA123@GMAIL.COM",
                    Email = "anhkhoa123@gmail.com",
                    NormalizedEmail = "ANHKHOA123@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = securePassword2,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = "Anh Khoa 3",
                    RegionId = 3, // Dùng Region 3 mới
                    IsDeleted = false,
                    OTP = "initial"
                },

                // 7 User MỚI
                new ApplicationUser
                {
                    Id = "004",
                    UserName = "user4@example.com",
                    NormalizedUserName = "USER4@EXAMPLE.COM",
                    Email = "user4@example.com",
                    NormalizedEmail = "USER4@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = "Người dùng 4",
                    RegionId = 1,
                    IsDeleted = false,
                    OTP = "initial"
                },
                new ApplicationUser
                {
                    Id = "005",
                    UserName = "user5@example.com",
                    NormalizedUserName = "USER5@EXAMPLE.COM",
                    Email = "user5@example.com",
                    NormalizedEmail = "USER5@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = "Người dùng 5",
                    RegionId = 2,
                    IsDeleted = false,
                    OTP = "initial"
                },
                new ApplicationUser
                {
                    Id = "006",
                    UserName = "user6@example.com",
                    NormalizedUserName = "USER6@EXAMPLE.COM",
                    Email = "user6@example.com",
                    NormalizedEmail = "USER6@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = "Người dùng 6",
                    RegionId = 3,
                    IsDeleted = false,
                    OTP = "initial"
                },
                new ApplicationUser
                {
                    Id = "007",
                    UserName = "user7@example.com",
                    NormalizedUserName = "USER7@EXAMPLE.COM",
                    Email = "user7@example.com",
                    NormalizedEmail = "USER7@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = "Người dùng 7",
                    RegionId = 1,
                    IsDeleted = false,
                    OTP = "initial"
                },
                new ApplicationUser
                {
                    Id = "008",
                    UserName = "user8@example.com",
                    NormalizedUserName = "USER8@EXAMPLE.COM",
                    Email = "user8@example.com",
                    NormalizedEmail = "USER8@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = "Người dùng 8",
                    RegionId = 2,
                    IsDeleted = false,
                    OTP = "initial"
                },
                new ApplicationUser
                {
                    Id = "009",
                    UserName = "user9@example.com",
                    NormalizedUserName = "USER9@EXAMPLE.COM",
                    Email = "user9@example.com",
                    NormalizedEmail = "USER9@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = "Người dùng 9",
                    RegionId = 3,
                    IsDeleted = false,
                    OTP = "initial"
                },
                new ApplicationUser
                {
                    Id = "010",
                    UserName = "user10@example.com",
                    NormalizedUserName = "USER10@EXAMPLE.COM",
                    Email = "user10@example.com",
                    NormalizedEmail = "USER10@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = "Người dùng 10",
                    RegionId = 1,
                    IsDeleted = false,
                    OTP = "initial"
                }
            );
        }
    }
}
