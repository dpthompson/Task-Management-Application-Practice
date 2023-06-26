using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Task_Management_Application_Practice
{
    class DBConnectionCls
    {
     public string txtpassworjd = "123";
    } 

   
    public static class PIZZAHUT
    {
        public static string txtpassword = File.ReadAllText("C:/Users/msi3070/Documents/Visual Studio 2019/SQL_PASS.txt");//get password from local txt file
        public static string server = File.ReadAllText("C:/Users/msi3070/Documents/Visual Studio 2019/Conn.txt");//get server location from local txt file
        public static SqlConnection DB_Conn = new SqlConnection("Server = " + server + "; Database =InitialTest; User ID = dpthompson21; Password =" + txtpassword);
    }
    
    public static class SQLQuery
    {
        public static string AuditCreateUser = "Select username from User_Table where username = @USERNAME ";
        public static string PopulateComboBX = "select ID, RoleName From User_Roles where ID <> 1 order by RoleName";
        public static string GetCreatedPrimaryKey = "SELECT SCOPE_IDENTITY() AS NewPrimaryKey";//couldnt get to work =(
        public static string GetCreatedUserID = "select UserID From User_Table where username = @USERNAME";
        public static string PopulateAssignmentGridView = "Select TaskID,Title,DueDate,Priority from New_Task_Table order by Priority,DueDate";//used to populate the datagrid view on the view task form
        public static string cmbobxAsignto = "select Userid, CONCAT(FirstName,' ', LastName) as Name From User_Table order by FirstName";//used to populate cmbobxAsignto on newtaskfrm
        public static string cmbobxGetPririty = "Select Priority, PriorityDesc from Priority order by Priority";// used to populate cmboboxpriority on newtaskfrm
    }

    public static class SQLInsertQuery
    {
        //public static string InsertUser = "INSERT INTO User_Table (FirstName,LastName,Email,RoleID,CreatedDate,Username)" +
        //                                  " VALUES(@FIRSTNAME, @LASTNAME, @EMAIL, @ROLEID, GETDATE(), @USERNAME)";
        public static string InsertUser = "InsertUser";//calls a stored procedure
        public static string InsertPassword = "INSERT INTO Password (UserID, PassWord)" +
                                              " Values(@USERID, @PASSWORD)";
        public static string InsertNewTask = "  Insert Into New_Task_Table (Title,DueDate,Priority,CreatedBy)" +
                                             " VALUES(@TITLE, @DUEDATE, @PRIORITY, @CREATEDBY) SELECT SCOPE_IDENTITY()";
        public static string InsertNewAssignmentTable = "Insert Into Assignment_Table(TaskID,Assigned_UserID,AssignedDate)" +
                                                        "VALUES(@TASKID, @ASSIGNEDUSERID, GETDATE())";
        public static string InsertNewAddignmentDescription = "  Insert Into TaskTableDetails(TaskID,Description)" +
                                                              "VALUES(@TASKID, @DESCRIPTION)";
    }
}
