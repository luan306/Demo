namespace API_WebLinkkien.Models
{
    public class Accounts
    {
        public int AccountId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public int Active { get; set; }//ys =1, no=0
        public string? Fullname { get; set; }
        public int RoleID { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
