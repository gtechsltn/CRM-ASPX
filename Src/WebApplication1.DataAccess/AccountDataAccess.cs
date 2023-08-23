using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using WebApplication1.DTO;

namespace WebApplication1.DataAccess
{
    public class AccountDataAccess : IAccountDataAccess
    {
        private readonly string _connString;

        public AccountDataAccess()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Debug.WriteLine(connString); // => Data Source=localhost;Initial Catalog=CRMS;Integrated Security=SSPI;MultipleActiveResultSets=True
            _connString = connString;
        }

        public (string, UserDto) GetUserInfoByUserName(string username)
        {
            var dto = new UserDto();
            var errorMsg = string.Empty;

            try
            {
                string cmdText = "SELECT TOP 1 [Id], [UserName], [Password] FROM [dbo].[User] WHERE [UserName] = @UserName";
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@UserName", username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = reader.GetInt32(0);
                                var userName = reader.GetString(1);
                                var password = reader.GetString(2);
                                Debug.WriteLine($"Id: {id}, UserName: {userName}, Password: {password},");
                                dto.Id = id;
                                dto.UserName = userName;
                                dto.Password = password;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.ToString();
                //throw;
            }

            return (errorMsg, dto);
        }
    }
}