﻿namespace EmployeeContact.Model
{
    public class updateEmpDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}