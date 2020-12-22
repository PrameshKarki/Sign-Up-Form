using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sign_With_Database.Classes
{
    class Validation
    {
        //Connection String
        public static string connectionString = "server=localhost;user id=root;database=userdatabase;pwd=password";
        //Method to validate FirstName
        public bool ValidateFirstName(string firstName)
        {
            //Declaring and initializing default variable with default value
            bool isValid = false;
            //Check least length it must have 
            isValid = firstName.Length >= 2 ? true : false;
            return isValid;
        }
        //Method to validate LastName
        public bool ValidateLastName(string lastName)
        {
            //Declaring and initializing default variable with default value
            bool isValid = false;
            //Check least length it must have
            isValid = lastName.Length >=2 ? true : false;
            return isValid;
        }
        //Method to validate ContactNumber
        public bool ValidateContactNumber(string contactNumber)
        {
            //Declaring and initializing default variable with default value
            bool isValid = false;
            //Check least length it must have
            if (contactNumber.Length >= 6)
            {
                //Check this number already exist in database or not
                //Database connection
                MySqlConnection conn = new MySqlConnection(connectionString);
                try
                {   //SQL Query
                    string SQLQuery = "SELECT COUNT(User_ID) FROM Users WHERE Contact_Number=BINARY @contactNumber";
                    //SQL Command
                    MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
                    //Creating parameters to add values
                    cmd.Parameters.AddWithValue("@contactNumber", contactNumber);
                    //Open connection
                    conn.Open();
                    //Execute Query
                    object returnValue = cmd.ExecuteScalar();
                    if (returnValue != null)
                    {
                        int value = Convert.ToInt32(returnValue);
                        isValid = value == 0 ? true : false;
                    }
                    else
                    {
                        MessageBox.Show("OOPS!!!Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                isValid = false;
            }
            return isValid;
        }
        //Method to validate Email
        public bool ValidateEmail(string email)
        {
            //Declaring and initializing default variable with default value
            bool isValid = false;
            //Check least length it must have
            if (email.Contains(".com"))
            {
                //Check this email already exist in database or not
                //Database connection
                MySqlConnection conn = new MySqlConnection(connectionString);
                try
                {   //SQL Query
                    string SQLQuery = "SELECT COUNT(User_ID) FROM Users WHERE Email=BINARY @email";
                    //SQL Command
                    MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
                    //Creating parameters to add values
                    cmd.Parameters.AddWithValue("@email",email);
                    //Open connection
                    conn.Open();
                    //Execute Query
                    object returnValue = cmd.ExecuteScalar();
                    if (returnValue != null)
                    {
                        int value = Convert.ToInt32(returnValue);
                        isValid = value == 0 ? true : false;
                    }
                    else
                    {
                        MessageBox.Show("OOPS!!!Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                isValid = false;
            }
            return isValid;
        }
        //Method to validate UserName
        public bool ValidateUserName(string userName)
        {
            //Declaring and initializing default variable with default value
            bool isValid = false;
            //Check least length it must have
            if (userName.Length >4 )
            {
                //Check this userName already exist in database or not
                //Database connection
                MySqlConnection conn = new MySqlConnection(connectionString);
                try
                {   //SQL Query
                    string SQLQuery = "SELECT COUNT(User_ID) FROM Users WHERE User_Name=BINARY @userName";
                    //SQL Command
                    MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
                    //Creating parameters to add values
                    cmd.Parameters.AddWithValue("@userName",userName);
                    //Open connection
                    conn.Open();
                    //Execute Query
                    object returnValue = cmd.ExecuteScalar();
                    if (returnValue != null)
                    {
                        int value = Convert.ToInt32(returnValue);
                        isValid = value == 0 ? true : false;
                    }
                    else
                    {
                        MessageBox.Show("OOPS!!!Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                isValid = false;
            }
            return isValid;
        }
        //Method to validate Password
        public bool ValidatePassword(string password)
        {
            //Declaring and initializing default variable with default value
            bool isValid = false;
            //Check least length it must have 
            isValid = password.Length >= 6 ? true : false;
            return isValid;
        }
        //Method to validate ConfirmPassword
        public bool ValidateConfirmPassword(string password,string confirmPassword)
        {
            //Declaring and initializing default variable with default value
            bool isValid = false;
            //Check least length it must have 
            isValid = password.Equals(confirmPassword);
            return isValid;
        }

    }
}
