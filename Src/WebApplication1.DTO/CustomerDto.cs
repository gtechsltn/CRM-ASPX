using System;

namespace WebApplication1.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CCCD { get; set; }
        public string CMND { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public short YoB { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
        public string Gender { get; set; }
        public string Facebook { get; set; }
        public string Facebook2 { get; set; }
        public string Hobbies { get; set; }
        public string Note { get; set; }
        public string Owner { get; set; }
    }
}