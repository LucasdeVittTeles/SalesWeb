namespace SalesWeb.Server.Repository.Exeptions
{
    public class UserExistsException : ApplicationException
    {
        public UserExistsException(string message) : base(message) { }
    }
}
