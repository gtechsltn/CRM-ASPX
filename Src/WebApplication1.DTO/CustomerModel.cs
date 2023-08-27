using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class CustomerModel
    {
        [DisplayName("Mã KH")]
        public int Id { get; set; }

        [DisplayName("Họ")]
        [Required(ErrorMessage = "Vui lòng nhập Họ")]
        public string LastName { get; set; }

        [DisplayName("Tên")]
        [Required(ErrorMessage = "Vui lòng nhập Tên")]
        public string FirstName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [DisplayName("Điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập Điện thoại")]
        public string Mobile { get; set; }

        public DateTime DoB { get; set; }

        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Vui lòng nhập Ngày sinh")]
        public string DoBInStr { get; set; }

        [DisplayName("Năm sinh")]
        [Required(ErrorMessage = "Vui lòng nhập Năm sinh")]
        [Range(18, 9999, ErrorMessage = "Năm sinh phải lớn hơn 17 và nhỏ hơn 9999")]
        public short YoB { get; set; }

        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Vui lòng nhập Giới tính")]
        public string Gender { get; set; }
    }
}