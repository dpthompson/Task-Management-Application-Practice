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
using Task_Management_Application_Practice.Forms;//accidently created NewTaskFrm within the sub folder and not under the main project. adding this to be able to reference the form easier

namespace Task_Management_Application_Practice
{
    public partial class ViewTasksFrm : Form
    {
        public ViewTasksFrm()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }

        private void ViewTasksFrm_Load(object sender, EventArgs e)
        {
            using(SqlDataAdapter pizza = new SqlDataAdapter(SQLQuery.PopulateAssignmentGridView, PIZZAHUT.DB_Conn))
            {
                DataSet datadata = new DataSet();
                pizza.Fill(datadata, "Tablename");
                dataGridView1.DataSource = datadata.Tables["Tablename"];
                dataGridView1.Columns["TaskID"].Visible = false;
                DataGridViewRow firstRow = dataGridView1.Rows[0];//highlights the entire row
                firstRow.Selected = true;//highlights the entire row
                dataGridView1.RowHeadersVisible = false;//hides the index column
                

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //CreateNewAccountFrm CNAF = new CreateNewAccountFrm();
            LoginFrm login = new LoginFrm();
            login.Show();
            this.Close();
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            NewTaskFrm newtask = new NewTaskFrm();
            newtask.Show();
            this.Close();

        }
        //class used to pass the selected task id to the TaskDetailsFrm
        public static class PubVarToPass
        {
            public static string TaskID { get; set; }
            public static string DueDate { get; set; }
            public static string Priority { get; set; }
            public static string AssignToZ { get; set; }
            public static bool Completed { get; set; }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            //public static string taskid = gridview1
            PubVarToPass.TaskID = dataGridView1.SelectedRows[0].Cells["TaskID"].Value.ToString();//sets the class taskid = to the selected row task id to then be passed to TaskDetailsFrm
            TaskDetailsFrm newFrm = new TaskDetailsFrm();
            newFrm.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                selectedRow.Selected = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                PubVarToPass.TaskID = dataGridView1.SelectedRows[0].Cells["TaskID"].Value.ToString();//sets the class taskid = to the selected row task id to then be passed to TaskDetailsFrm
                PubVarToPass.DueDate = dataGridView1.SelectedRows[0].Cells["DueDate"].Value.ToString();
                PubVarToPass.Priority = dataGridView1.SelectedRows[0].Cells["Priority"].Value.ToString();
                using (SqlCommand sqlCommand = new SqlCommand(SQLQuery.GetEditFrmData, PIZZAHUT.DB_Conn))
                {
                    sqlCommand.Parameters.AddWithValue("@TaskID", PubVarToPass.TaskID);
                    sqlCommand.Connection.Open();
                    using (SqlDataReader read = sqlCommand.ExecuteReader())
                    {
                        
                        if(read.Read())
                        {
                            //something is present
                            PubVarToPass.AssignToZ = read.GetString(3);
                            PubVarToPass.Priority = read.GetString(2);
                            
                        }
                        else
                        {
                            //nothing is present
                        }
                    }
                    sqlCommand.Connection.Close();
                }
                PubVarToPass.Completed = (bool)dataGridView1.SelectedRows[0].Cells["Completion"].Value;

                //open new form
                EditTaskFrm newFrm = new EditTaskFrm();
                newFrm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                
            }

        }
    }
}
