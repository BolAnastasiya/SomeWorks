using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AMONIC_Airlines_3
{
    class SqlConnect
    {
        private SqlConnection _sqlConnection = new SqlConnection(@"Server=localhost;Integrated Security=true; Database=Amonic2");
        public SqlConnection sqlConnection { get { return _sqlConnection; } }

        public string CheckLogin(string login, string password)
        {
            DataTable dt_Users = new DataTable();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select User_Role, User_Active from User_Info where User_Email = '" + login + "' and User_Password = '" + password + "'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_Users);

            if (dt_Users.Rows.Count > 0)
                return dt_Users.Rows[0][0].ToString() + ";" + dt_Users.Rows[0][1].ToString();
            else
                return null;
        }

        public List<string> FillingCb()
        {
            DataTable dt_Offices = new DataTable();
            List<string> offices = new List<string>();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select distinct User_Title from User_Info";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_Offices);

            for (int i = 0; i < dt_Offices.Rows.Count; i++)
                offices.Add(dt_Offices.Rows[i][0].ToString());

            return offices;
        }

        public List<string> FillingCb(string FirstItem)
        {
            DataTable dt_Offices = new DataTable();
            List<string> offices = new List<string>() { FirstItem };

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select distinct User_Title from User_Info";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_Offices);

            for (int i = 0; i < dt_Offices.Rows.Count; i++)
                offices.Add(dt_Offices.Rows[i][0].ToString());

            return offices;
        }

        public DataTable FindAllUsersInfo()
        {
            DataTable dt_Users = new DataTable();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select User_FirstName, User_LastName, datediff(year, User_Birthday, getdate()) as User_Age, User_Role, User_Email, User_Title, case when User_Active = 0 then 'red' when User_Role = 'Administrator' then 'green' else 'white' end as User_Color from User_Info";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_Users);

            return dt_Users;
        }

        public DataTable FindByOfficesUsersInfo(string office)
        {
            DataTable dt_Users = new DataTable();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select User_FirstName, User_LastName, datediff(year, User_Birthday, getdate()) as User_Age, User_Role, User_Email, User_Title, case when User_Active = 0 then 'red' when User_Role = 'Administrator' then 'green' else 'white' end as User_Color from User_Info where User_Title = '" + office + "'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_Users);

            return dt_Users;
        }

        public void EnableOrDisableLogin(string userEmails)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "update User_Info set User_Active = case when User_Active = 0 then 1 else 0 end where" + userEmails;
            sqlCommand.ExecuteNonQuery();
        }

        public void AddNewUser(string values)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "insert into User_Info values " + values;
            sqlCommand.ExecuteNonQuery();
        }

        public void ChangeUser(string values, string userEmail)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "update User_Info set " + values + " where User_Email = '" + userEmail + "'";
            sqlCommand.ExecuteNonQuery();
        }

        public List<string> FindUserInfo(List<string> user)
        {
            DataTable dt_User = new DataTable();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select User_FirstName, User_LastName, User_Title, User_Role from User_Info where User_Email = '" + user[0] + "'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_User);

            for (int i = 0; i < dt_User.Columns.Count; i++)
                user.Add(dt_User.Rows[0][i].ToString());

            return user;
        }

        public DataTable FindUserTime(string email)
        {
            DataTable dt_User = new DataTable();
            dt_User.Columns.Add("User_Date", System.Type.GetType("System.String"));

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select User_Date, convert(nvarchar, User_Login_Time, 108) as User_Login_Time, case when User_Logout_Time is null then '**' else convert(nvarchar, User_Logout_Time, 108) end as User_Logout_Time,  case when User_Time_Spent is null then '**' else convert(nvarchar, User_Time_Spent, 108) end as User_Time_Spent, User_Logout_Reason, case when User_Crash = 1 then 'red' else 'white' end as Color from Users_Session_Time where User_Email = '" + email + "'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_User);

            for (int i = 0; i < dt_User.Rows.Count; i++)
                dt_User.Rows[i][0] = dt_User.Rows[i][0].ToString().Replace(" 0:00:00", "").Replace('.', '/');

            return dt_User;
        }

        public string FindUserName(string email)
        {
            DataTable dt_User = new DataTable();
            dt_User.Columns.Add("User_Date", System.Type.GetType("System.String"));

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select User_FirstName from User_Info where User_Email = '" + email + "'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_User);

            return dt_User.Rows[0][1].ToString();
        }

        public string FindUserCrashes(string email)
        {
            DataTable dt_User = new DataTable();
            dt_User.Columns.Add("User_Date", System.Type.GetType("System.String"));

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select count(*) from Users_Session_Time where User_Crash = 1 and User_Email = '" + email + "'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_User);

            return dt_User.Rows[0][1].ToString();
        }

        public void FindActiveSession(string email)
        {
            DataTable dt_User = new DataTable();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select count(*) from Users_Session_Time where User_login_Time = (select max(User_Login_Time) as User_Login_Time from Users_Session_Time where User_Date = (select max(User_Date) as User_Date from Users_Session_Time where User_Email = '" + email + "')) and User_Date = (select max(User_Date) as User_Date from Users_Session_Time where User_Email = '" + email + "') and User_Logout_Time is null";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt_User);

            if (Convert.ToInt32(dt_User.Rows[0][0]) > 0)
            {
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "update Users_Session_Time set User_Logout_Reason = 'Power Outage', User_Crash = 1 where User_login_Time = (select max(User_Login_Time) as User_Login_Time from Users_Session_Time where User_Date = (select max(User_Date) as User_Date from Users_Session_Time where User_Email = '" + email + "')) and User_Date = (select max(User_Date) as User_Date from Users_Session_Time where User_Email = '" + email + "') and User_Logout_Time is null";
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void AddNewUserSession(string values)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "insert into Users_Session_Time values (" + values + ")";
            sqlCommand.ExecuteNonQuery();
        }

        public void UpdateUserTimeInfo(string values, string date, string time)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "update Users_Session_Time set " + values + " where User_Date = '" + date + "'" + " and User_Login_Time = '" + time + "'";
            sqlCommand.ExecuteNonQuery();
        }

        public void OpenConnect()
        {
            _sqlConnection.Open();
        }

        public void CloseConnect()
        {
            _sqlConnection.Close();
        }
    }
}
