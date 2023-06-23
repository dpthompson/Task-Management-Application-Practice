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
    public partial class CreateNewAccountFrm : Form
    {
        public CreateNewAccountFrm()
        {
            InitializeComponent();
        }

        private void CreateNewAccountFrm_Load(object sender, EventArgs e)
        {
            using(SqlDataAdapter adapter = new SqlDataAdapter(SQLQuery.PopulateComboBX,PIZZAHUT.DB_Conn))
            {
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Combobox");
                cmbobxRole.DataSource = dataSet.Tables["Combobox"];
                cmbobxRole.DisplayMember = "RoleName";
                cmbobxRole.ValueMember = "ID";
            }

        }     
               
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoginFrm frm3 = new LoginFrm();
            frm3.Show();
            this.Close();
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //lookup to see if entered data is already present
                using(SqlCommand command = new SqlCommand(SQLQuery.AuditCreateUser,PIZZAHUT.DB_Conn))
                {
                    //use a reader to see if any values are returned
                    command.Parameters.AddWithValue("@USERNAME", txtbxUserName.Text);//passes the textbox username as a parameter to see if value is already used
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    if(reader.HasRows)
                    {
                        MessageBox.Show("this username is already used");
                        command.Connection.Close();
                    }
                    else
                    {
                        //MessageBox.Show("new username");
                        command.Connection.Close();

                        //creates new entries
                        SqlCommand insert = new SqlCommand(SQLInsertQuery.InsertUser, PIZZAHUT.DB_Conn);
                        insert.Connection.Open();
                        insert.Parameters.AddWithValue("@ROLEID", cmbobxRole.SelectedValue);
                        insert.Parameters.AddWithValue("@FIRSTNAME", txtbxFirstName.Text);
                        insert.Parameters.AddWithValue("@LASTNAME", txtbxLastName.Text);
                        insert.Parameters.AddWithValue("@EMAIL", txtbxEmail.Text);
                        insert.Parameters.AddWithValue("@USERNAME", txtbxUserName.Text);
                        insert.ExecuteNonQuery();
                        insert.Connection.Close();

                        //code below gets the newly created primary key that identifies a user
                        SqlCommand getprimarykey = new SqlCommand(SQLQuery.GetCreatedUserID, PIZZAHUT.DB_Conn);
                        getprimarykey.Connection.Open();
                        getprimarykey.Parameters.AddWithValue("@USERNAME", txtbxUserName.Text);
                        object newPrimaryKey = getprimarykey.ExecuteScalar();//pulls back a single value via executescalar sqlcommanb
                        string userid = newPrimaryKey.ToString();
                        getprimarykey.Connection.Close();

                        //password gets stored in a seperate table
                        SqlCommand updatepassword = new SqlCommand(SQLInsertQuery.InsertPassword, PIZZAHUT.DB_Conn);
                        updatepassword.Connection.Open();
                        updatepassword.Parameters.AddWithValue("@UserID", userid.ToString());
                        updatepassword.Parameters.AddWithValue("@PASSWORD", txtbxPassword.Text);
                        updatepassword.ExecuteNonQuery();
                        updatepassword.Connection.Close();

                        LoginFrm Loginnz = new LoginFrm();
                        Loginnz.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);              
            }
        }
    }
}
