﻿using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace TP4.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string phoneNumber { get; set; }
        public string university { get; set; }
        public DateTime timestamp { get; set; }
        public string course { get; set; }
    }
}
