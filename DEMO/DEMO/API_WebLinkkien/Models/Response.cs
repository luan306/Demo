namespace API_WebLinkkien.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public dynamic Data { get; set; } = null;
    }
}
