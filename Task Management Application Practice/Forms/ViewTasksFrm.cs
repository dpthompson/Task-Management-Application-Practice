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
    }
}
