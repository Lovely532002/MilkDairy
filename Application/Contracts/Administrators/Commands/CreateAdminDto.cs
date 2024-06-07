using Microsoft.AspNetCore.Http;

namespace Application.Contracts.Administrators.Commands
{
    public class CreateAdminDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IFormFile? ProfileIcon { get; set; }
        public string? ProfileUrl { get; set; }
    }
}
