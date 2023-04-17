using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace API_WebLinkkien.Data
{
    public interface IConnectData
    {
        public DataTable DataConnect(string sqlstring);
        public int DataConnectInsert(string sqlstring);
    }
    public class ConnectData:IConnectData
    {
        public readonly IConfiguration _configuration;
        public ConnectData(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DataTable DataConnect(string sqlstring)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConnetDatabaseText").ToString());
                SqlDataAdapter da = new SqlDataAdapter(sqlstring, con);
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
           
            return dt;
        }
        public int DataConnectInsert(string sqlstring)
        {
            int kq = 0;
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConnetDatabaseText").ToString());
                SqlCommand cm = new SqlCommand(sqlstring, con);
                con.Open();
                kq = cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
            
            return kq;
        }
    }
}
