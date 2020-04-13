using System.Data;
using System.Data.SqlClient;

namespace ProductLibrary
{
    public class DataProvider
    {
        private string connectionStr = @"Data Source=THIEN-AI\THIENAI;Initial Catalog=HotelManagement;Integrated Security=True";

        public string ConnectionStr { get => connectionStr; set => connectionStr = value; }

        public DataProvider(string connectionStr)
        {
            this.ConnectionStr = connectionStr;
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameter(query, parameter, command);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public int ExecuteNoneQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameter(query, parameter, command);
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = new object();
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameter(query, parameter, command);
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
        private void AddParameter(string query, object[] parameter, SqlCommand command)
        {
            if (parameter != null)
            {
                string[] listParameter = query.Split(' ');
                int i = 0;
                foreach (string item in listParameter)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        ++i;
                    }
                }
            }
        }
    }
}