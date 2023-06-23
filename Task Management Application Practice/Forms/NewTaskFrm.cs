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

namespace Task_Management_Application_Practice.Forms
{
    public partial class NewTaskFrm : Form
    {
        public NewTaskFrm()
        {
            InitializeComponent();
        }
        

        private void NewTaskFrm_Load(object sender, EventArgs e)
        {
            cmboPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmboAssignedTo.DropDownStyle = ComboBoxStyle.DropDownList;

            //populates the combo box
            SqlDataAdapter fillcombobox = new SqlDataAdapter(SQLQuery.cmbobxAsignto, PIZZAHUT.DB_Conn);
            DataSet data = new DataSet();
            fillcombobox.Fill(data, "Table");
            cmboAssignedTo.DataSource = data.Tables["Table"];
            cmboAssignedTo.DisplayMember = "Name";
            cmboAssignedTo.ValueMember = "Userid";

            using (SqlDataAdapter adapter2 = new SqlDataAdapter(SQLQuery.cmbobxGetPririty, PIZZAHUT.DB_Conn))
            {
                DataSet ddset = new DataSet();
                adapter2.Fill(ddset, "PriorityCMBO");
                cmboPriority.DataSource = ddset.Tables["PriorityCMBO"];
                cmboPriority.DisplayMember = "PriorityDesc";
                cmboPriority.ValueMember = "Priority";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ViewTasksFrm newtask = new ViewTasksFrm();
            newtask.Show();
            this.Close();
        }
        private string newkey;//declare field at class level, will be used in the btnSave event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlCommand insertdata = new SqlCommand(SQLInsertQuery.InsertNewTask, PIZZAHUT.DB_Conn))//add data into new task table
                {

                    insertdata.Connection.Open();
                    insertdata.Parameters.AddWithValue("@TITLE", txtbxTitle.Text);
                    insertdata.Parameters.AddWithValue("@DUEDATE", dtpDueDate.Value );
                    insertdata.Parameters.AddWithValue("@PRIORITY", cmboPriority.SelectedValue);
                    insertdata.Parameters.AddWithValue("@CREATEDBY", LoginFrm.GlobalVariable.LoggedInUser);
                    insertdata.ExecuteNonQuery();
                    object newPrimaryKey = insertdata.ExecuteScalar();//pulls back newly created primary key
                    newkey = newPrimaryKey.ToString();//new string set to the newly created primary key to use then in insert statement for related tables
                    insertdata.Connection.Close();
                }
                using(SqlCommand InsertAssignmentTable = new SqlCommand(SQLInsertQuery.InsertNewAssignmentTable,PIZZAHUT.DB_Conn))//add relational data to assigned table
                {
                    InsertAssignmentTable.Connection.Open();
                    InsertAssignmentTable.Parameters.AddWithValue("@TASKID", newkey);
                    InsertAssignmentTable.Parameters.AddWithValue("@ASSIGNEDUSERID", cmboAssignedTo.SelectedValue);
                    InsertAssignmentTable.ExecuteNonQuery();
                    InsertAssignmentTable.Connection.Close();
                }
                if (rchtxtbxDescription.Text == "")
                {
                    //do nowthing
                }
                else
                {
                    //add description into table
                    SqlCommand inserttaskdescription = new SqlCommand(SQLInsertQuery.InsertNewAddignmentDescription, PIZZAHUT.DB_Conn);
                    inserttaskdescription.Connection.Open();
                    inserttaskdescription.Parameters.AddWithValue("@DESCRIPTION", rchtxtbxDescription.Text);
                    inserttaskdescription.Parameters.AddWithValue("TASKID", newkey);
                    inserttaskdescription.ExecuteNonQuery();
                    inserttaskdescription.Connection.Close();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }

        }
    }
}
