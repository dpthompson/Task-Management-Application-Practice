
namespace Task_Management_Application_Practice
{
    partial class EditTaskFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkbxCompleted = new System.Windows.Forms.CheckBox();
            this.rchtxtbxDescription = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.cmboPriority = new System.Windows.Forms.ComboBox();
            this.cmboAssignedTo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkbxCompleted
            // 
            this.chkbxCompleted.AutoSize = true;
            this.chkbxCompleted.Location = new System.Drawing.Point(667, 161);
            this.chkbxCompleted.Name = "chkbxCompleted";
            this.chkbxCompleted.Size = new System.Drawing.Size(103, 17);
            this.chkbxCompleted.TabIndex = 0;
            this.chkbxCompleted.Text = "Task Completed";
            this.chkbxCompleted.UseVisualStyleBackColor = true;
            // 
            // rchtxtbxDescription
            // 
            this.rchtxtbxDescription.Location = new System.Drawing.Point(199, 297);
            this.rchtxtbxDescription.Name = "rchtxtbxDescription";
            this.rchtxtbxDescription.Size = new System.Drawing.Size(276, 91);
            this.rchtxtbxDescription.TabIndex = 12;
            this.rchtxtbxDescription.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(109, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(634, 67);
            this.dataGridView1.TabIndex = 13;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(95, 161);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDueDate.TabIndex = 15;
            // 
            // cmboPriority
            // 
            this.cmboPriority.FormattingEnabled = true;
            this.cmboPriority.Location = new System.Drawing.Point(354, 160);
            this.cmboPriority.Name = "cmboPriority";
            this.cmboPriority.Size = new System.Drawing.Size(121, 21);
            this.cmboPriority.TabIndex = 21;
            // 
            // cmboAssignedTo
            // 
            this.cmboAssignedTo.FormattingEnabled = true;
            this.cmboAssignedTo.Location = new System.Drawing.Point(498, 161);
            this.cmboAssignedTo.Name = "cmboAssignedTo";
            this.cmboAssignedTo.Size = new System.Drawing.Size(121, 21);
            this.cmboAssignedTo.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Description (Optional)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(532, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Assign To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Priority";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Due Date";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(609, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(713, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditTaskFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmboPriority);
            this.Controls.Add(this.cmboAssignedTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rchtxtbxDescription);
            this.Controls.Add(this.chkbxCompleted);
            this.Name = "EditTaskFrm";
            this.Text = "EditTaskFrm";
            this.Load += new System.EventHandler(this.EditTaskFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkbxCompleted;
        private System.Windows.Forms.RichTextBox rchtxtbxDescription;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.ComboBox cmboPriority;
        private System.Windows.Forms.ComboBox cmboAssignedTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}