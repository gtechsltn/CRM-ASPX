using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RegisterModel
    {
        [DisplayName("Tên đăng nhập")]
        [StringLength(50, ErrorMessage = "{0} phải dài ít nhất {2} ký tự.", MinimumLength = 4)]
        [Required(ErrorMessage = "Vui lòng nhập Tên đăng nhập")]
        public string UserName2 { get; set; }

        [DisplayName("Mật khẩu")]
        [StringLength(50, ErrorMessage = "{0} phải dài ít nhất {2} ký tự.", MinimumLength = 8)]
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu")]
        public string Password2 { get; set; }
    }
}