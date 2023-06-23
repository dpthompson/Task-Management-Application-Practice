using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Task_Management_Application_Practice
{
    class DBConnectionCls
    {
    }

    public static class PIZZAHUT
    {
        public static SqlConnection DB_Conn = new SqlConnection("Server = demoinitialserver.database.windows.net; Database =InitialTest; User ID = dpthompson21; Password =Divad#1267");
    }
    
    public static class SQLQuery
    {
        public static string AuditCreateUser = "Select username from User_Table where username = @USERNAME ";
        public static string PopulateComboBX = "select ID, RoleName From User_Roles where ID <> 1 order by RoleName";
        public static string GetCreatedPrimaryKey = "SELECT SCOPE_IDENTITY() AS NewPrimaryKey";//couldnt get to work =(
        public static string GetCreatedUserID = "select UserID From User_Table where username = @USERNAME";
        public static string PopulateAssignmentGridView = "Select TaskID,Title,DueDate,Priority from New_Task_Table order by Priority,DueDate";//used to populate the datagrid view on the view task form
    }

    public static class SQLInsertQuery
    {
        public static string InsertUser = "INSERT INTO User_Table (FirstName,LastName,Email,RoleID,CreatedDate,Username)" +
                                          " VALUES(@FIRSTNAME, @LASTNAME, @EMAIL, @ROLEID, GETDATE(), @USERNAME)";
        public static string InsertPassword = "INSERT INTO Password (UserID, PassWord)" +
                                              " Values(@USERID, @PASSWORD)";
    }
}
