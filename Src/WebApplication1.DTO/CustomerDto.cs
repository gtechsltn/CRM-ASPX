using System;

namespace WebApplication1.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DoB { get; set; }
        public short YoB { get; set; }
        public string Gender { get; set; }
    }
}