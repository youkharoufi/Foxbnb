using FoxBnB.Data;
using FoxBnB.Models;
using FoxBnB.TokenService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoxBnB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersManagement : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        public UsersManagement(DatabaseContext databaseContext,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService)
        {
            _databaseContext = databaseContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;

        }

        private bool IsImageFile(IFormFile file)
        {
            return file.Length > 0 &&
                   file.Length < 5 * 1024 * 1024 &&
                   (file.ContentType.ToLower() == "image/jpeg" ||
                    file.ContentType.ToLower() == "image/png");
        }

        private async Task<string> ProcessImageUploadAsync(IFormFile file)
        {
            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

            using (var fileStream = new FileStream(uploadPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var imageUrl = $"https://localhost:7292/images/{uniqueFileName}";
            return imageUrl;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApplicationUser>> Register([FromForm] RegisterUser registerUser)
        {
            if (registerUser.PasswordConfirmation != registerUser.Password)
            {
                return BadRequest("Password Confirmation should match the Password !");
            }

            if (registerUser.ProfilePic != null && !IsImageFile(registerUser.ProfilePic))
            {
                return BadRequest("Invalid file type. Only image files are allowed.");
            }

            var imageUrl = await ProcessImageUploadAsync(registerUser.ProfilePic);


            var newUser = new ApplicationUser
            {
                UserName = registerUser.UserName,
                Firstname = registerUser.Firstname,
                Lastname = registerUser.Lastname,
                PhoneNumber = registerUser.PhoneNumber,
                Email = registerUser.Email,
                ProfilePicUrl = imageUrl,
                RoleName = registerUser.RoleName

            };

            var result1 = await _userManager.CreateAsync(newUser, registerUser.Password);

            if (!result1.Succeeded)
            {
                return BadRequest(result1.Errors.Select(e => e.Description));

            }

            var result2 = await _userManager.AddToRoleAsync(newUser, registerUser.RoleName);

            if (!result2.Succeeded)
            {
                return BadRequest(result2.Errors.Select(e => e.Description));

            }


            return Ok(newUser);

        
            }
        

        [HttpPost("login")]
        public async Task<ActionResult<ApplicationUser>> login(LoginUser loginUser)
        {
            var userFromDb = await _userManager.FindByEmailAsync(loginUser.Email);

            if (userFromDb == null) return NotFound("No such user is registered");

            var resultA = await _signInManager.CheckPasswordSignInAsync(userFromDb, loginUser.Password, false);

            if (!resultA.Succeeded) return BadRequest("Invalid Password");

            userFromDb.Token = await _tokenService.GenerateToken(userFromDb);

            return Ok(userFromDb);
        }
    }
}
