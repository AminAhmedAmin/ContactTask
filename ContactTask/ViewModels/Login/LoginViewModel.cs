using System.ComponentModel.DataAnnotations;

namespace ContactTask.ViewModels.Login
{
    public class LoginViewModel
    {
        [Required] 
        public string username { get; set;}
        [Required]

        public string password { get; set;}


    }
}
