using Lab2.Data;
using Lab2.DTO;
using Lab2.Models;
using Lab2.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIGameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        protected ResponseApi _response;

        public APIGameController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
            _response = new();
        }

        [HttpGet("GetAllGameLevel")]
        public async Task<IActionResult> GetAllGameLevel()
        {
            try
            {
                var gameLevel = await _context.GameLevels.ToListAsync();
                _response.IsSuccess = true;
                _response.Notification = "Lấy dữ liệu thành công";
                _response.Data = gameLevel;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Notification = "Lỗi";
                _response.Data = ex.Message;
                return Ok(_response);
            }
        }

        [HttpGet("GetAllQuestionGame")]
        public async Task<IActionResult> GetAllQuestionGame()
        {
            try
            {
                var questionGame = await _context.Quessions.ToListAsync();
                _response.IsSuccess = true;
                _response.Notification = "Lấy dữ liệu thành công";
                _response.Data = questionGame;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Notification = "Lỗi";
                _response.Data = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpGet("GetAllRegion")]
        public async Task<IActionResult> GetAllRegion()
        {
            try
            {
                var region = await _context.Regions.ToListAsync();
                _response.IsSuccess = true;
                _response.Notification = "Lấy dữ liệu thành công";
                _response.Data = region;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Notification = "Lỗi";
                _response.Data = ex.Message;
                return BadRequest(_response);
            }
        }
        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.Notification = "Không tìm thấy người dùng";
                    _response.Data = null;
                    return NotFound(_response);
                }

                // Tạo object chỉ chứa thông tin cần thiết (KHÔNG BAO GỒM PASSWORD)
                var userInfo = new
                {
                    user.Id,
                    user.Email,
                    user.Name,
                    user.Avatar,
                    user.RegionId,
                    user.IsDeleted,
                    user.UserName
                    // KHÔNG trả về PasswordHash vì lý do bảo mật
                };

                _response.IsSuccess = true;
                _response.Notification = "Lấy thông tin người dùng thành công";
                _response.Data = userInfo;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Notification = "Lỗi";
                _response.Data = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                // 1. Tạo đối tượng ApplicationUser từ DTO
                var user = new ApplicationUser
                {
                    Email = registerDTO.Email,
                    UserName = registerDTO.Email, // Thường dùng Email làm UserName
                    Name = registerDTO.Name,
                    Avatar = registerDTO.LinkAvatar,
                    RegionId = registerDTO.RegionId
                };

                // 2. Gọi hàm tạo người dùng và lưu vào database
                var result = await _userManager.CreateAsync(user, registerDTO.Password);

                if (result.Succeeded)
                {
                    // Đăng ký thành công
                    _response.IsSuccess = true;
                    _response.Notification = "Đăng ký thành công";
                    _response.Data = user; // Trả về thông tin người dùng đã tạo
                    return Ok(_response); // Trả về HTTP 200 OK
                }
                else
                {
                    // Đăng ký thất bại (ví dụ: Email đã tồn tại, mật khẩu yếu)
                    _response.IsSuccess = false;
                    _response.Notification = "Đăng ký thất bại";
                    _response.Data = result.Errors; // Trả về các lỗi chi tiết
                    return BadRequest(_response); // Trả về HTTP 400 Bad Request
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ngoại lệ chung (ví dụ: lỗi kết nối database)
                _response.IsSuccess = false;
                _response.Notification = "Lỗi";
                _response.Data = ex.Message; // Trả về thông báo lỗi chi tiết
                return BadRequest(_response); // Trả về HTTP 400 Bad Request
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                // 1. Lấy thông tin Email và Password từ request
                var email = loginRequest.Email;
                var password = loginRequest.Password;

                // 2. Tìm kiếm người dùng theo Email
                var user = await _userManager.FindByEmailAsync(email);

                // 3. Kiểm tra: người dùng có tồn tại KHÔNG VÀ mật khẩu có đúng KHÔNG
                if (user != null && await _userManager.CheckPasswordAsync(user, password))
                {
                    // Đăng nhập thành công
                    _response.IsSuccess = true;
                    _response.Notification = "Đăng nhập thành công";
                    _response.Data = user; // Trả về thông tin người dùng
                    return Ok(_response); // Trả về HTTP 200 OK
                }
                else
                {
                    // Đăng nhập thất bại (sai email hoặc mật khẩu)
                    _response.IsSuccess = false;
                    _response.Notification = "Đăng nhập thất bại";
                    _response.Data = null;
                    return BadRequest(_response); // Trả về HTTP 400 Bad Request
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ngoại lệ chung
                _response.IsSuccess = false;
                _response.Notification = "Lỗi";
                _response.Data = ex.Message;
                return BadRequest(_response); // Trả về HTTP 400 Bad Request
            }
        }

        [HttpPut("UpdateUserInfomation")]
        public async Task<IActionResult> UpdateUserInfomation([FromForm] UserInfomationDTO userInfomationDTO)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Id == userInfomationDTO.UserId).FirstOrDefaultAsync();
                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.Notification = "Không tìm thấy người dùng";
                    _response.Data = null;
                    return BadRequest(_response);
                }

                user.Name = userInfomationDTO.Name;
                user.RegionId = userInfomationDTO.RegionId;

                if (userInfomationDTO.Avatar != null)
                {
                    var fileExtension = Path.GetExtension(userInfomationDTO.Avatar.FileName);
                    var fileName = $"{userInfomationDTO.UserId}{fileExtension}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/avatars", fileName);

                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await userInfomationDTO.Avatar.CopyToAsync(stream);
                    }
                    user.Avatar = fileName;
                }

                await _context.SaveChangesAsync();
                _response.IsSuccess = true;
                _response.Notification = "Cập nhật thông tin thành công";
                _response.Data = user;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Notification = "Lỗi";
                _response.Data = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpDelete("DeleteAccount/{userId}")]
        public async Task<IActionResult> DeleteAccount(string userId)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.Notification = "Không tìm thấy người dùng";
                    _response.Data = null;
                    return BadRequest(_response);
                }

                user.IsDeleted = true;
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                _response.IsSuccess = true;
                _response.Notification = "Xóa người dùng thành công";
                _response.Data = user;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Notification = "Lỗi";
                _response.Data = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromQuery] string Email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(Email);
                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.Notification = "Không tìm thấy người dùng";
                    _response.Data = null;
                    return BadRequest(_response);
                }

                Random random = new();
                string OTP = random.Next(100000, 999999).ToString();
                user.OTP = OTP;
                await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();

                string subject = "Reset Password Game 106 -- " + Email;
                string message = "Mã OTP của bạn là: " + OTP;
                await _emailService.SendEmailAsync(Email, subject, message);

                _response.IsSuccess = true;
                _response.Notification = "Gửi mã OTP thành công";
                _response.Data = "email sent to " + Email;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Notification = "Lỗi";
                _response.Data = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpPost("CheckOTP")]
        public async Task<IActionResult> CheckOTP(CheckOTPDTO checkOTPDTO)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(checkOTPDTO.Email);
                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.Notification = "Không tìm thấy người dùng";
                    _response.Data = null;
                    return BadRequest(_response);
                }

                var stringOTP = Convert.ToInt32(checkOTPDTO.OTP).ToString();
                if (user.OTP == stringOTP)
                {
                    _response.IsSuccess = true;
                    _response.Notification = "Mã OTP chính xác";
                    _response.Data = user.Email;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Notification = "Mã OTP không chính xác";
                    _response.Data = null;
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Notification = "Lỗi";
                _response.Data = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.Notification = "Không tìm thấy người dùng";
                    _response.Data = null;
                    return BadRequest(_response);
                }

                var stringOTP = Convert.ToInt32(resetPasswordDTO.OTP).ToString();
                if (user.OTP == stringOTP)
                {
                    DateTime now = DateTime.Now;
                    user.OTP = $"{stringOTP}_used_" + now.ToString("yyyy_MM_dd_HH_mm_ss");

                    // ✅ SỬA: Dùng PasswordHasher<ApplicationUser>
                    var passwordHasher = new PasswordHasher<ApplicationUser>();
                    user.PasswordHash = passwordHasher.HashPassword(user, resetPasswordDTO.NewPassword);

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        _response.IsSuccess = true;
                        _response.Notification = "Đổi mật khẩu thành công";
                        _response.Data = resetPasswordDTO.Email;
                        return Ok(_response);
                    }
                    else
                    {
                        _response.IsSuccess = false;
                        _response.Notification = "Đổi mật khẩu thất bại";
                        _response.Data = result.Errors;
                        return BadRequest(_response);
                    }
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Notification = "Mã OTP không chính xác";
                    _response.Data = null;
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Notification = "Lỗi";
                _response.Data = ex.Message;
                return BadRequest(_response);
            }
        }
    }
}
