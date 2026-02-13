using System;

namespace StudentComplaintSystem.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Status { get; set; }
        public string AdminComment { get; set; }
    }
}