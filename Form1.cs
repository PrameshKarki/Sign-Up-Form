using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Sign_With_Database.Classes;

namespace Sign_With_Database
{
    public partial class signUpForm : Form
    {
        //Instantiating Objects
        SignUp objSignUp = new SignUp();
        Validation objValidation = new Validation();
        //fields
        bool validFirstName, validLastName, validContactNumber, validEmail, validUserName, validPassword, validConfirmPassword;
       //Constructor
        public signUpForm()
        {
            InitializeComponent();
        }
        //Handling Click event on Sign Up Button
        private void signUpButton_Click(object sender, EventArgs e)
        {
            if (validFirstName && validLastName && validContactNumber && validEmail && validUserName && validPassword && validConfirmPassword)
            {
                //Geting values from textbox
                objSignUp.FirstName = textBoxFirstName.Text.Trim();
                objSignUp.LastName = textBoxLastName.Text.Trim();
                objSignUp.ContactNumber = textBoxContactNumber.Text.Trim();
                objSignUp.Email = textBoxEmail.Text.Trim();
                objSignUp.UserName = textBoxUserName.Text.Trim();
                objSignUp.Password = textBoxPassword.Text.Trim();
                //Inserting data into database
                bool status = objSignUp.CreateAccount(objSignUp);
                if (status)
                {
                    MessageBox.Show("Sucessfully Signed Up.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    ClearStatusImage();
                }
                else
                {
                    MessageBox.Show("OOPS!!! Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        //Method to Clear input fields
        private void ClearFields()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxUserName.Text = "";
            textBoxContactNumber.Text = "";
            textBoxEmail.Text = "";
            textBoxPassword.Text = "";
            textBoxConfirmPassword.Text = "";

        }
        //Method to Clear Status Image
        private void ClearStatusImage()
        {
            firstNameStatus.Image = null;
            lastNameStatus.Image = null;
            contactNumberStatus.Image = null;
            emailStatus.Image = null;
            userNameStatus.Image = null;
            passwordStatus.Image = null;
            confirmPasswordStatus.Image = null;
        }

        //Handling TextChange Event on First Name Text Box

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            
            string tempFirstName = textBoxFirstName.Text.Trim();
            validFirstName = objValidation.ValidateFirstName(tempFirstName);
           //Changing status image as per current status
            if (validFirstName)
            {
                firstNameStatus.Image = Properties.Resources.sucess;
            }
            else
            {
                firstNameStatus.Image = Properties.Resources.error;

            }

        }
        //Handling TextChange Event on Last Name Text Box

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            string tempLastName = textBoxLastName.Text.Trim();
            validLastName = objValidation.ValidateLastName(tempLastName);
            if (validLastName)
            {
                lastNameStatus.Image = Properties.Resources.sucess;
            }
            else
            {
                lastNameStatus.Image = Properties.Resources.error;

            }

        }
        //Handling TextChange Event on Contact Number Text Box

        private void textBoxContactNumber_TextChanged(object sender, EventArgs e)
        {
            string tempContactNumber = textBoxContactNumber.Text.Trim();
            validContactNumber = objValidation.ValidateContactNumber(tempContactNumber);
            if (validContactNumber)
            {
                contactNumberStatus.Image = Properties.Resources.sucess;
            }
            else
            {
                contactNumberStatus.Image = Properties.Resources.error;

            }

        }
        //Handling TextChange Event on Email Text Box

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            string tempEmail = textBoxEmail.Text.Trim();
            validEmail = objValidation.ValidateEmail(tempEmail);
            if (validEmail)
            {
                emailStatus.Image = Properties.Resources.sucess;
            }
            else
            {
                emailStatus.Image = Properties.Resources.error;

            }
        }
        //Handling TextChange Event on User Name Text Box

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            string tempUserName = textBoxUserName.Text.Trim();
            validUserName = objValidation.ValidateUserName(tempUserName);
            if (validUserName)
            {
                userNameStatus.Image = Properties.Resources.sucess;
            }
            else
            {
                userNameStatus.Image = Properties.Resources.error;

            }

        }
        //Handling TextChange Event on Password Text Box

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            string tempPassword = textBoxPassword.Text.Trim();
            validPassword = objValidation.ValidatePassword(tempPassword);
            if (validPassword)
            {
                passwordStatus.Image = Properties.Resources.sucess;

            }
            else
            {
                passwordStatus.Image = Properties.Resources.error;

            }
        }
        //Handling TextChange Event on Confirm Password Text Box

        private void textBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            string tempPassword = textBoxPassword.Text.Trim();
            string tempConfirmPassword = textBoxConfirmPassword.Text.Trim();
            validConfirmPassword = objValidation.ValidateConfirmPassword(tempPassword, tempConfirmPassword);
            if (validConfirmPassword)
            {
                confirmPasswordStatus.Image = Properties.Resources.sucess;
            }
            else
            {
                confirmPasswordStatus.Image = Properties.Resources.error;

            }
        }

    }
}
//Pramesh Karki
