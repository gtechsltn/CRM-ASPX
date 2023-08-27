using System;
using System.ComponentModel;

namespace WebApplication1.DTO
{
    public class CustomerModel
    {
        [DisplayName("Mã KH")]
        public int Id { get; set; }

        [DisplayName("Họ")]
        public string LastName { get; set; }

        [DisplayName("Tên")]
        public string FirstName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Điện thoại")]
        public string Mobile { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime? DoB { get; set; }

        [DisplayName("Ngày sinh")]
        public string DoBInStr { get; set; }

        [DisplayName("Năm sinh")]
        public short YoB { get; set; }

        [DisplayName("Giới tính")]
        public string Gender { get; set; }
    }
}