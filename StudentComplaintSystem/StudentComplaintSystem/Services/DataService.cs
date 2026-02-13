using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using StudentComplaintSystem.Models;

namespace StudentComplaintSystem.Services
{
    public class DataService
    {
        private readonly string _complaintsFilePath = "complaints.json";

        public DataService()
        {
            if (!File.Exists(_complaintsFilePath))
            {
                File.WriteAllText(_complaintsFilePath, JsonConvert.SerializeObject(new List<Complaint>()));
            }
        }

        public List<Complaint> LoadComplaints()
        {
            var json = File.ReadAllText(_complaintsFilePath);
            return JsonConvert.DeserializeObject<List<Complaint>>(json) ?? new List<Complaint>();
        }

        public void AddComplaint(Complaint complaint)
        {
            var complaints = LoadComplaints();
            complaint.Id = complaints.Any() ? complaints.Max(c => c.Id) + 1 : 1;
            complaints.Add(complaint);
            File.WriteAllText(_complaintsFilePath, JsonConvert.SerializeObject(complaints, Formatting.Indented));
        }

        public void UpdateComplaint(Complaint updatedComplaint)
        {
            var complaints = LoadComplaints();
            var existingComplaint = complaints.FirstOrDefault(c => c.Id == updatedComplaint.Id);
            if (existingComplaint != null)
            {
                existingComplaint.Category = updatedComplaint.Category;
                existingComplaint.Description = updatedComplaint.Description;
                existingComplaint.SubmissionDate = updatedComplaint.SubmissionDate;
                existingComplaint.Status = updatedComplaint.Status;
                existingComplaint.AdminComment = updatedComplaint.AdminComment;
                File.WriteAllText(_complaintsFilePath, JsonConvert.SerializeObject(complaints, Formatting.Indented));
            }
        }
    }
}