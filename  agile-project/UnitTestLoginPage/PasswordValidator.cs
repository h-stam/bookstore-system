using System;
using System.Linq;

namespace BookStoreTests
{
    public class PasswordValidator
    {
        public string Password { get; set; }
        public Boolean Validate(string Password)
        {
            return (Password.Any(char.IsLetter) &&
                    Password.Any(char.IsDigit) &&
                    !Password.Any(ch => !Char.IsLetterOrDigit(ch)) &&
                    Password.Length >= 6) &&
                    char.IsLetter(Password.First());
        }
    }
}