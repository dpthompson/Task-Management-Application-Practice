using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Task_Management_Application_Practice
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        public static class GlobalVariable
        {
            public static string LoggedInUser { get; set; }
        }



        //practice putting the sql connection string in various locations
        //public static SqlConnection pizza = new SqlConnection( "Server =demoinitialserver.database.windows.net; Database =InitialTest; User ID =dpthompson21; Password =Divad#1267");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //SqlConnection connectionstingg =  new SqlConnection( "Server =demoinitialserver.database.windows.net; Database =InitialTest; User ID =dpthompson21; Password =Divad#1267");
            String query = "Select UserID from User_Table where username = @USERNAME";
            //using (SqlConnection connection = new SqlConnection(connectionstring))
            using (SqlCommand newcommand = new SqlCommand(query,  PIZZAHUT.DB_Conn))
            {
                try
                {
                    string username;//passed in username that user types in
                    username = txtbxUserName.Text;// pass textbox to variable to then pass into sql query

                    newcommand.Parameters.AddWithValue("@Username", username);//pass username into parameter
                    newcommand.Connection.Open();//starting connection

                    using (SqlDataReader reader = newcommand.ExecuteReader())//uses a sqldatareader to see if a username is found
                    {
                        if (reader.HasRows)//audits to see if username was found
                        {
                            //username was found
                            newcommand.Connection.Close();//starting connection
                            string querygetuserpass = "select UT.UserID From User_Table UT Join Password P on UT.UserID = p.userid where UT.Username = @USERNAME and P.Password = @PASSWORD";
                            using (SqlCommand newcommandget = new SqlCommand(querygetuserpass, PIZZAHUT.DB_Conn))
                            {
                                newcommandget.Parameters.AddWithValue("@USERNAME", txtbxUserName.Text);
                                newcommandget.Parameters.AddWithValue("@PASSWORD",txtbxPassword.Text);
                                newcommandget.Connection.Open();
                                SqlDataReader readerr = newcommandget.ExecuteReader();                               
                                    
                                if(readerr.HasRows)
                                {
                                    readerr.Close();//close the executeReader so a new one can be opened
                                    object getUserID = newcommandget.ExecuteScalar();//pulls back userid
                                    GlobalVariable.LoggedInUser = getUserID.ToString();//sets the logged in user
                                    //username/password was correct
                                    //MessageBox.Show("user/pass found");

                                    newcommandget.Connection.Close();
                                    ViewTasksFrm f2 = new ViewTasksFrm();
                                    f2.Show();
                                    this.Hide();
                                        
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect username/password, try again");
                                    //username and or password incorrect
                                    newcommandget.Connection.Close();
                                }
                                    
                            }
                        }
                        else
                        {
                            //no usernames were found
                            MessageBox.Show("Incorrect username, try again");
                            newcommand.Connection.Close();//closing connection
                        }
                    }               

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateNewAccountFrm CNAF = new CreateNewAccountFrm();
            CNAF.Show();
            this.Hide();
        }
    }
}
