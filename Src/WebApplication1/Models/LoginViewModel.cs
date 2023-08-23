using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LoginViewModel
    {
        [DisplayName("Tên đăng nhập")]
        [StringLength(50, MinimumLength = 4)]
        [Required(ErrorMessage = "Vui lòng nhập Tên đăng nhập"), MaxLength(50)]
        public string UserName { get; set; }

        [DisplayName("Mật khẩu")]
        [StringLength(50, MinimumLength = 8)]
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu"), MaxLength(50)]
        public string Password { get; set; }
    }
}