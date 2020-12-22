using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sign_With_Database.Classes
{
    class SignUp
    {
        //Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //Connection String
        public static string connectionString = "server=localhost;user id=root;database=userdatabase;pwd=password";
       //Method to SignUp
       public bool CreateAccount(SignUp S)
        {
            //Creating default variable and initializing with default value
            bool isSucess = false;
            //Database connection
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                //SQL Query
               string SQLString = "INSERT INTO Users(First_Name,Last_Name,Contact_Number,Email,User_Name,Password) values(@firstName,@lastName,@contactNumber,@email,@userName,@password)";
                //SQL Command
                MySqlCommand cmd = new MySqlCommand(SQLString, conn);
                //Parameters to add value
                cmd.Parameters.AddWithValue("@firstName", S.FirstName);
                cmd.Parameters.AddWithValue("@lastName", S.LastName);
                cmd.Parameters.AddWithValue("@contactNumber", S.ContactNumber);
                cmd.Parameters.AddWithValue("@email", S.Email);
                cmd.Parameters.AddWithValue("@userName", S.UserName);
                cmd.Parameters.AddWithValue("@password", S.Password);
                //Open Connection
                conn.Open();
                //Execute Query
                //And it will return the number of rows affected
                int row = cmd.ExecuteNonQuery();
                isSucess = row > 0 ? true : false;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Close connection
                conn.Close();
            }
            return isSucess;
        }
    }
}
//Pramesh karki
