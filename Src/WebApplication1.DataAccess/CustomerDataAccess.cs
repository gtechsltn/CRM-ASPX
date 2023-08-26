using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using WebApplication1.DTO;
using WebApplication1.Infrastructure;

namespace WebApplication1.DataAccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private readonly string _connString;

        public CustomerDataAccess()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Debug.WriteLine(connString); // => Data Source=localhost;Initial Catalog=CRMS;Integrated Security=SSPI;MultipleActiveResultSets=True
            _connString = connString;
        }

        public (string, CustomerDto) GetCustomerById(int customerId, string userName)
        {
            var item = new CustomerDto();
            var errorMsg = string.Empty;

            try
            {
                string cmdText = "SELECT [Id], [FirstName], [LastName], [Email], [Mobile], [DoB], [YoB], [Gender] FROM [dbo].[Customer] WHERE ";
                if (customerId > 0)
                {
                    cmdText += $" [Id] = @Id";
                    if (!string.IsNullOrEmpty(userName) && !userName.Equals(AppUsers.Admin, StringComparison.OrdinalIgnoreCase))
                    {
                        cmdText += $" AND ";
                        cmdText += $" [Owner] = @UserName";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(userName) && !userName.Equals(AppUsers.Admin, StringComparison.OrdinalIgnoreCase))
                    {
                        cmdText += $" [Owner] = @UserName";
                    }
                }

                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@Id", customerId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = reader.GetInt32(0);
                                var firstName = reader.GetString(1);
                                var lastName = reader.GetString(2);
                                var email = reader.GetString(3);
                                var mobile = reader.GetString(4);
                                var doB = reader.GetDateTime(5);
                                var yoB = reader.GetInt16(6);
                                var gender = reader.GetString(7);
                                item.Id = id;
                                item.FirstName = firstName;
                                item.LastName = lastName;
                                item.Email = email;
                                item.Mobile = mobile;
                                item.DoB = doB;
                                item.YoB = yoB;
                                item.Gender = gender;
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

            return (errorMsg, item);
        }

        public (string, IEnumerable<CustomerDto>) GetCustomerByOwner(string userName)
        {
            var lst = new List<CustomerDto>();
            var errorMsg = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    string cmdText = "SELECT [Id], [FirstName], [LastName], [Email], [Mobile], [DoB], [YoB], [Gender] FROM [dbo].[Customer]";
                    if (!userName.Equals(AppUsers.Admin, StringComparison.OrdinalIgnoreCase))
                    {
                        cmdText += $" WHERE [Owner] = @UserName";
                    }
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
                                    var item = new CustomerDto();
                                    var id = reader.GetInt32(0);
                                    var firstName = reader.GetString(1);
                                    var lastName = reader.GetString(2);
                                    var email = reader.GetString(3);
                                    var mobile = reader.GetString(4);
                                    var doB = reader.GetDateTime(5);
                                    var yoB = reader.GetInt16(6);
                                    var gender = reader.GetString(7);
                                    item.Id = id;
                                    item.FirstName = firstName;
                                    item.LastName = lastName;
                                    item.Email = email;
                                    item.Mobile = mobile;
                                    item.DoB = doB;
                                    item.YoB = yoB;
                                    item.Gender = gender;
                                    lst.Add(item);
                                }
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

            return (errorMsg, lst);
        }
    }
}