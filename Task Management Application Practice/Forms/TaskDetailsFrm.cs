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
    public partial class TaskDetailsFrm : Form
    {
        public TaskDetailsFrm()
        {
            InitializeComponent();
        }

        private void TaskDetailsFrm_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(SQLQuery.GetDetailsValues, PIZZAHUT.DB_Conn))//populating datagridview
                {

                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;//tells  adapter to use a stored procedure vs normal query
                    adapter.SelectCommand.Parameters.AddWithValue("@TaskID", ViewTasksFrm.PubVarToPass.TaskID);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Table");
                    dataGridView1.DataSource = dataSet.Tables["Table"];
                    dataGridView1.Columns["TaskID"].Visible = false;
                }

                using (SqlCommand sqlCom = new SqlCommand(SQLQuery.GetDesc, PIZZAHUT.DB_Conn))//populating rich textbox
                {
                    sqlCom.Connection.Open();
                    sqlCom.Parameters.AddWithValue("TaskID", ViewTasksFrm.PubVarToPass.TaskID);

                    using (SqlDataReader reader = sqlCom.ExecuteReader())//adding using so connection automatically closes
                    {
                        if (reader.Read())//reader.read must be called first before reader.getstring
                        {
                            //there is something
                            rchtxtbxDescription.Text = reader.GetString(0);
                        }
                        else
                        {
                            //nothing
                        }
                    }
               
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("err" + ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ViewTasksFrm frm3 = new ViewTasksFrm();
            frm3.Show();
            this.Close();
        }
    }
}


