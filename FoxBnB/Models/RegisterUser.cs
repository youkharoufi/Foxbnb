namespace FoxBnB.Models
{
    public class RegisterUser
    {
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public IFormFile ProfilePic { get; set; }

        public string RoleName { get; set; }
    }
}
