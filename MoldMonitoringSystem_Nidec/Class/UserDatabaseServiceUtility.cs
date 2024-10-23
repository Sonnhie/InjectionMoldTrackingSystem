using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.Class
{
    public class UserDatabaseServiceUtility
    {
        private readonly string _connectionString;
        public UserDatabaseServiceUtility()
        {
            _connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False"; ;
        }
        public class UserData
        {
            public string userid { get; set; }
            public string password { get; set; }
            public string Section { get; set; }
            public string Type { get; set; }
            public string employeename { get; set; }
        }
        
        public string GetEmployeeSection(string userid)
        {
            string section = "";

            string query = "SELECT section FROM Users WHERE username = @username";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@username", userid);
                        section = command.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching section for employee: " + ex.Message);
            }
            return null;
        }
        public UserData Validateuser(string username, string password)
        {
            const string query = "SELECT username, section, type FROM Users WHERE username COLLATE Latin1_General_BIN = @username AND password COLLATE Latin1_General_BIN = @password";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {   
                                return new UserData
                                {
                                    userid = reader["username"].ToString(),
                                    Section = reader["section"].ToString(),
                                    Type = reader["type"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving equipment data: " + ex.Message);
            }

            return null; // User not found or error occurred
        }
        public bool duplicateuser(UserData user)
        {
            try
            {
                string duplicateuser = "select count(*) from Users where username = @username and employeename = @employeename";

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(duplicateuser, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", user.userid);
                        cmd.Parameters.AddWithValue("@employeename", user.employeename);
                        int count = (int)cmd.ExecuteScalar();
                       
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
        }
        public bool AddUserData(UserData user)
        {
            string register = "insert into Users (username, password, type, section, date_created, employeename)" +
                              " values (@username, @password, @type, " +
                              "@section, @date_created, @employeename)";

            string currentdate = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {
                using(SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(register, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", user.userid);
                        cmd.Parameters.AddWithValue("@password", user.password);
                        cmd.Parameters.AddWithValue("@type", user.Type);
                        cmd.Parameters.AddWithValue("@section", user.Section);
                        cmd.Parameters.AddWithValue("@date_created", currentdate);
                        cmd.Parameters.AddWithValue("@employeename", user.employeename);

                        int result = cmd.ExecuteNonQuery();

                        return result > 0;                      
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false ;
        }
        public bool DeleteUser(UserData user)
        {
            string DeleteUsers = "delete from Users where username = @userid";

            try
            {
                using(SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    using(SqlCommand cmd = new SqlCommand(DeleteUsers, con))
                    {
                        cmd.Parameters.AddWithValue("@userid", user.userid.ToString());
                        int result = cmd.ExecuteNonQuery();
                        MessageBox.Show("User deleted successfully!");
                        return result > 0;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
        }
        public bool UpdateUser(UserData user)
        {
            string updatequery = "update Users set type = @role, section = @section, employeename = @employeename" +
                                 "  where username = @userid";
            try
            {
                using(SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using(SqlCommand cmd = new SqlCommand(updatequery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", user.userid);
                        cmd.Parameters.AddWithValue("@role", user.Type);
                        cmd.Parameters.AddWithValue("@section", user.Section);
                        cmd.Parameters.AddWithValue("@employeename", user.employeename.ToString());

                        int result = cmd.ExecuteNonQuery();

                        return result > 0;
 
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
        }
        public UserData UserInformation(string userid)
        {
            string query = "SELECT type, section, employeename FROM Users where username = @userid";

            try
            {
                using(SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    using(SqlCommand cm = new SqlCommand(query, con))
                    {
                        cm.Parameters.AddWithValue("@userid", userid);

                        using(SqlDataReader rdr = cm.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                return new UserData
                                {
                                    Type = rdr["type"].ToString(),
                                    Section = rdr["section"].ToString(),
                                    employeename = rdr["employeename"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return null;
        }
        public bool UpdatePassword(string password, string userid)
        {
            string UpdatePasswordQuery = "update Users set password = @password where username = @userid";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(UpdatePasswordQuery, conn))
                    {
                        // Add parameters with values
                        cmd.Parameters.AddWithValue("@password", password);  // Ideally, hash the password first
                        cmd.Parameters.AddWithValue("@userid", userid);

                        // Execute the query and check the number of affected rows
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public bool ValidateUserExistence(UserData user)
        {
            string CheckUser = "select count(*) from Users where username = @userid";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(CheckUser, conn))
                    {
                        // Pass the username from the UserData object
                        command.Parameters.AddWithValue("@userid", user.userid);

                        // Use ExecuteScalar to retrieve the count
                        int result = (int)command.ExecuteScalar();
                        return result > 0; // Return true if count > 0, indicating user exists
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
        }

    }
}
