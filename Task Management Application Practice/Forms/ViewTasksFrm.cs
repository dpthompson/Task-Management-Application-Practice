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
    }
}
