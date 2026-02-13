using StudentComplaintSystem.Models;

namespace StudentComplaintSystem.Services
{
    public class AuthService
    {
        public (bool IsAuthenticated, UserRole Role) Authenticate(string id, string password, UserRole role)
        {
            if (role == UserRole.Student && id == "student1" && password == "pass123")
            {
                return (true, UserRole.Student);
            }
            else if (role == UserRole.Admin && id == "admin1" && password == "admin123")
            {
                return (true, UserRole.Admin);
            }
            return (false, UserRole.None);
        }
    }
}