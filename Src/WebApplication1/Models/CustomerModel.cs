using System.ComponentModel;

namespace WebApplication1.Models
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
    }
}