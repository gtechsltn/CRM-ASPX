﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WebApplication1.DTO;
using WebApplication1.Infrastructure;

namespace WebApplication1.DataAccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private static readonly string _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

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

        public (string, IEnumerable<CustomerDto>) GetCustomersByOwner(string userName)
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

        public (string errorMsg, bool saveSuccess) SaveCustomer(CustomerDto dto)
        {
            if (dto.Id == 0) { return InsertCustomer(dto); }
            else { return UpdateCustomer(dto); }
        }

        private (string errorMsg, bool saveSuccess) UpdateCustomer(CustomerDto dto)
        {
            var registerSuccess = false;
            var errorMsg = string.Empty;
            var rowsAffected = 0;
            try
            {
                string cmdUpdate = @"UPDATE [dbo].[Customer]
   SET [FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[CCCD] = @CCCD
      ,[CMND] = @CMND
      ,[Address] = @Address
      ,[DoB] = @DoB
      ,[YoB] = @YoB
      ,[Email] = @Email
      ,[Mobile] = @Mobile
      ,[Gender] = @Gender
      ,[Facebook] = @Facebook
      ,[Hobbies] = @Hobbies
      ,[Note] = @Note
      ,[Owner] = @Owner
 WHERE [Id] = @Id
";
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(cmdUpdate, conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Id", dto.Id);
                        cmd.Parameters.AddWithValue("@FirstName", dto.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", dto.LastName);
                        cmd.Parameters.AddWithValue("@CCCD", dto.CCCD);
                        cmd.Parameters.AddWithValue("@CMND", dto.CMND);
                        cmd.Parameters.AddWithValue("@Address", dto.Address);
                        cmd.Parameters.AddWithValue("@DoB", dto.DoB);
                        cmd.Parameters.AddWithValue("@YoB", dto.YoB);
                        cmd.Parameters.AddWithValue("@Email", dto.Email);
                        cmd.Parameters.AddWithValue("@Mobile", dto.Mobile);
                        cmd.Parameters.AddWithValue("@Gender", dto.Gender);
                        cmd.Parameters.AddWithValue("@Facebook", dto.Facebook);
                        cmd.Parameters.AddWithValue("@Hobbies", dto.Hobbies);
                        cmd.Parameters.AddWithValue("@Note", dto.Note);
                        cmd.Parameters.AddWithValue("@Owner", dto.Owner);
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

        private (string errorMsg, bool saveSuccess) InsertCustomer(CustomerDto dto)
        {
            var registerSuccess = false;
            var errorMsg = string.Empty;
            var rowsAffected = 0;
            try
            {
                string cmdInsert = @"INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[CCCD]
           ,[CMND]
           ,[Address]
           ,[DoB]
           ,[YoB]
           ,[Email]
           ,[Mobile]
           ,[Gender]
           ,[Facebook]
           ,[Hobbies]
           ,[Note]
           ,[Owner])
     VALUES
           (@FirstName
           ,@LastName
           ,@CCCD
           ,@CMND
           ,@Address
           ,@DoB
           ,@YoB
           ,@Email
           ,@Mobile
           ,@Gender
           ,@Facebook
           ,@Hobbies
           ,@Note
           ,@Owner
		   )";
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(cmdInsert, conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@FirstName", dto.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", dto.LastName);
                        cmd.Parameters.AddWithValue("@CCCD", dto.CCCD);
                        cmd.Parameters.AddWithValue("@CMND", dto.CMND);
                        cmd.Parameters.AddWithValue("@Address", dto.Address);
                        cmd.Parameters.AddWithValue("@DoB", dto.DoB);
                        cmd.Parameters.AddWithValue("@YoB", dto.YoB);
                        cmd.Parameters.AddWithValue("@Email", dto.Email);
                        cmd.Parameters.AddWithValue("@Mobile", dto.Mobile);
                        cmd.Parameters.AddWithValue("@Gender", dto.Gender);
                        cmd.Parameters.AddWithValue("@Facebook", dto.Facebook);
                        cmd.Parameters.AddWithValue("@Hobbies", dto.Hobbies);
                        cmd.Parameters.AddWithValue("@Note", dto.Note);
                        cmd.Parameters.AddWithValue("@Owner", dto.Owner);
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