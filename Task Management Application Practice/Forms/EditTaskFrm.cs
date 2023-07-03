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
    public partial class EditTaskFrm : Form
    {
        public EditTaskFrm()
        {
            InitializeComponent();
        }

        private void EditTaskFrm_Load(object sender, EventArgs e)

          
        {
            chkbxCompleted.Checked = ViewTasksFrm.PubVarToPass.Completed;

            using (SqlDataAdapter adapter = new SqlDataAdapter(SQLQuery.GetDetailsValues, PIZZAHUT.DB_Conn))//populating datagridview
            {

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;//tells  adapter to use a stored procedure vs normal query
                adapter.SelectCommand.Parameters.AddWithValue("@TaskID", ViewTasksFrm.PubVarToPass.TaskID);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Table");
                dataGridView1.DataSource = dataSet.Tables["Table"];
                dataGridView1.Columns["TaskID"].Visible = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.RowHeadersVisible = false;
            }

            //populates the combo box assigned user
            using (SqlDataAdapter fillcombobox = new SqlDataAdapter(SQLQuery.cmbobxAsignto, PIZZAHUT.DB_Conn))
            {
                DataSet data = new DataSet();
                fillcombobox.Fill(data, "Table");
                cmboAssignedTo.DataSource = data.Tables["Table"];
                cmboAssignedTo.DisplayMember = "Name";
                cmboAssignedTo.ValueMember = "Userid";
                cmboAssignedTo.Text = ViewTasksFrm.PubVarToPass.AssignToZ;//passed default value from previous form

            }

            //populate combobox priority
            using (SqlDataAdapter adapter2 = new SqlDataAdapter(SQLQuery.cmbobxGetPririty, PIZZAHUT.DB_Conn))
            {
                DataSet ddset = new DataSet();
                adapter2.Fill(ddset, "PriorityCMBO");
                cmboPriority.DataSource = ddset.Tables["PriorityCMBO"];
                cmboPriority.DisplayMember = "PriorityDesc";
                cmboPriority.ValueMember = "Priority";
                cmboPriority.Text = ViewTasksFrm.PubVarToPass.Priority;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //open new form
            ViewTasksFrm newFrm = new ViewTasksFrm();
            newFrm.Show();
            this.Close();
        }
    }
}
