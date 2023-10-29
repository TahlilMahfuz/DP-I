﻿using System.ComponentModel.DataAnnotations;

namespace ExScheduler_Server.Models
{
    public class Department
    {
        [Key]
        public Guid departmentID { get; set; }
        public string departmentName { get; set; } = default!;
        public List<Programme> Programmes { get; set; } = default!;
    }
}
