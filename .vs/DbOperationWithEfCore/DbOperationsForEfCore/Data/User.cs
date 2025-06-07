namespace DbOperationsForEfCore.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int profileid { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Profile Profile { get; set; }
    }


    public class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
