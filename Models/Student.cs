using System;

namespace StudentManagementAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? RollNumber { get; set; }
        public string? Class { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ContactNumber { get; set; }
    }
}
