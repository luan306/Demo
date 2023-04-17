namespace BanHangLinkKien.Extension
{
    public class BanHangException: Exception
    {
        public BanHangException()
        {
        }

        public BanHangException(string message)
            : base(message)
        {
        }

        public BanHangException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
