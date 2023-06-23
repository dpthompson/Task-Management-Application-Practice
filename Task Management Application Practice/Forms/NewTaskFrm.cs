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

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
