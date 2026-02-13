namespace StudentComplaintSystem.Models
{
    public class User
    {
        public string Id { get; set; } = string.Empty; // Non-nullable, with default value
        public string? Password { get; set; } // Nullable
        public UserRole Role { get; set; } // Non-nullable enum
        public string? Name { get; set; } // Nullable
        public string? Email { get; set; } // Nullable
    }
}