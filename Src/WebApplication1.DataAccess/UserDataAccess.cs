using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using WebApplication1.DTO;

namespace WebApplication1.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private static readonly string _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public (string, UserDto) GetUserInfoByUserName(string userName)
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
                        cmd.Parameters.AddWithValue("@UserName", userName);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = reader.GetInt32(0);
                                var userNameDb = reader.GetString(1);
                                var password = reader.GetString(2);
                                Debug.WriteLine($"Id: {id}, UserName: {userNameDb}, Password: {password},");
                                dto.Id = id;
                                dto.UserName = userNameDb;
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

        public (string, bool) RegisterUser(string userName, string password)
        {
            var registerSuccess = false;
            var errorMsg = string.Empty;
            var rowsAffected = 0;
            try
            {
                string cmdText = "INSERT INTO [dbo].[User](UserName, Password) VALUES (@UserName, @Password)";
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@Password", password);
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.ToString();
                //throw;
            }
            finally
            {
                registerSuccess = rowsAffected > 0;
            }

            return (errorMsg, registerSuccess);
        }
    }
}