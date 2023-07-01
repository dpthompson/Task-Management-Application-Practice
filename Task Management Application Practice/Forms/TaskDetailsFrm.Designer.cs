
namespace Task_Management_Application_Practice
{
    partial class TaskDetailsFrm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rchtxtbxDescription = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(48, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(673, 234);
            this.dataGridView1.TabIndex = 0;
            // 
            // rchtxtbxDescription
            // 
            this.rchtxtbxDescription.Location = new System.Drawing.Point(213, 312);
            this.rchtxtbxDescription.Name = "rchtxtbxDescription";
            this.rchtxtbxDescription.ReadOnly = true;
            this.rchtxtbxDescription.Size = new System.Drawing.Size(276, 91);
            this.rchtxtbxDescription.TabIndex = 12;
            this.rchtxtbxDescription.Text = "";
            // 
            // TaskDetailsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rchtxtbxDescription);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TaskDetailsFrm";
            this.Text = "TaskDetailsFrm";
            this.Load += new System.EventHandler(this.TaskDetailsFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox rchtxtbxDescription;
    }
}