namespace SalesWeb.Server.Repository.Exeptions
{
    public class SellerNotFoundException : ApplicationException
    {
        public SellerNotFoundException(string message) : base(message) { }
    }
}
