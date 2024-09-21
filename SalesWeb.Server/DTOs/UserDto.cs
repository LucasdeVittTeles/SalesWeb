namespace SalesWeb.Server.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string PasswordHash  { get; set; }
    }
}
