using System;
using Domain.Enums;

namespace Domain.Models
{
    public class Appeal
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Reason { get; set; }
        public Departments Department { get; set; }
        public DateTime Time { get; set; }
    }
}
