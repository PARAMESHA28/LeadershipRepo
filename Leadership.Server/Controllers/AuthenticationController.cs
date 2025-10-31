using Leadership.Domain.Models;
using Leadership.Domain.Models.Dto;
using Leadership.Repositories.Data;
using Leadership.Service.ServiceImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leadership.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly LeaderBoardDbContext _context;
        private readonly PasswordService _passwordService;
        private readonly JwtService _jwtService;

        public AuthenticationController(LeaderBoardDbContext context, PasswordService passwordService, JwtService jwtService)
        {
            _context = context;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return Conflict(new { message = "Email already registered" });

            var user = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                PasswordHash = _passwordService.HashPassword(dto.Password),
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = _jwtService.GenerateToken(user);
            return Ok(token);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            if (!_passwordService.VerifyPassword(user.PasswordHash, dto.Password))
                return Unauthorized(new { message = "Invalid credentials" });

            var token = _jwtService.GenerateToken(user);
            return Ok(new
            {
                token = token,
                userId = user.UserId,
                fullName = user.FullName,
                email = user.Email
            });
        }
    }
}
