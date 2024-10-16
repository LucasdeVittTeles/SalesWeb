namespace SalesWeb.Server.Repository.Exeptions
{
    public class SellerExistsException : ApplicationException
    {
        public SellerExistsException(string message) : base(message) { }
    }
}
