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
        public static class TTaskID
        {
            public static string TextData { get; set; }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            //public static string taskid = gridview1
            TTaskID.TextData = dataGridView1.SelectedRows[0].Cells["TaskID"].Value.ToString();//sets the class taskid = to the selected row task id to then be passed to TaskDetailsFrm
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


    }
}
