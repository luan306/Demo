namespace BanHangLinkKien.Models
{
    public class ResData
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public dynamic Data { get; set; } = null;
    }
}
