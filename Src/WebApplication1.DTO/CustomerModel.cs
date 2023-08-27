using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class CustomerModel
    {
        [DisplayName("Mã KH")]
        public int Id { get; set; }

        [DisplayName("Họ")]
        [StringLength(50, ErrorMessage = "{0} phải dài ít nhất {2} ký tự.", MinimumLength = 1)]
        [Required(ErrorMessage = "Vui lòng nhập Họ")]
        public string LastName { get; set; }

        [DisplayName("Tên")]
        [StringLength(50, ErrorMessage = "{0} phải dài ít nhất {2} ký tự.", MinimumLength = 1)]
        [Required(ErrorMessage = "Vui lòng nhập Tên")]
        public string FirstName { get; set; }

        [DisplayName("Email")]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "{0} phải dài ít nhất {2} ký tự.", MinimumLength = 1)]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        public string Email { get; set; }

        [DisplayName("Điện thoại")]
        [StringLength(50, ErrorMessage = "{0} phải dài ít nhất {2} ký tự.", MinimumLength = 1)]
        [Required(ErrorMessage = "Vui lòng nhập Điện thoại")]
        public string Mobile { get; set; }

        [DisplayName("Ngày sinh")]
        [StringLength(50, ErrorMessage = "{0} phải dài ít nhất {2} ký tự.", MinimumLength = 1)]
        [Required(ErrorMessage = "Vui lòng nhập Ngày sinh")]
        public string DoB { get; set; }

        [DisplayName("Ngày sinh")]
        [StringLength(50, ErrorMessage = "{0} phải dài ít nhất {2} ký tự.", MinimumLength = 1)]
        [Required(ErrorMessage = "Vui lòng nhập Ngày sinh")]
        public string DoBInStr { get; set; }

        [DisplayName("Năm sinh")]
        [StringLength(50, ErrorMessage = "{0} phải dài ít nhất {2} ký tự.", MinimumLength = 1)]
        [Required(ErrorMessage = "Vui lòng nhập Năm sinh")]
        public short YoB { get; set; }

        [DisplayName("Giới tính")]
        [StringLength(50, ErrorMessage = "{0} phải dài ít nhất {2} ký tự.", MinimumLength = 1)]
        [Required(ErrorMessage = "Vui lòng nhập Giới tính")]
        public string Gender { get; set; }
    }
}