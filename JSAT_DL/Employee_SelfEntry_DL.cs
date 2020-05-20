using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Employee_SelfEntry_DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        int autoCode;
        public Employee_SelfEntry_DL()
        { }

        public DataTable GetEmpInfo(string code)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SP_Get_EmpInfo", connection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@code", code);
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt;
        }

        public DataTable GetDOB(string code)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Convert(nvarchar(50),DOB,100) as DOB From Career_Resume where Career_Code=@code", connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@code", code);
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt; 
        }

        public DataTable GetAddress(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Description From Residential_Area where ID=@id", connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@id", id);
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt;
        }
        
        public int Insert(Employee_SelfEntry_Entity see)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Insert_Emp_Information", connection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@name", see.Name);
            sda.SelectCommand.Parameters.AddWithValue("@gender", see.Gender);
            sda.SelectCommand.Parameters.AddWithValue("@dob", see.DOB);
            sda.SelectCommand.Parameters.AddWithValue("@age", see.Age);
            sda.SelectCommand.Parameters.AddWithValue("@religion", see.Religion);
            sda.SelectCommand.Parameters.AddWithValue("@address", see.Address);
            sda.SelectCommand.Parameters.AddWithValue("@detail_add", see.Detail_Add);
            sda.SelectCommand.Parameters.AddWithValue("@phone", see.Phone);
            sda.SelectCommand.Parameters.AddWithValue("@ename", see.Emergencycontantperson);
            sda.SelectCommand.Parameters.AddWithValue("@ephone", see.EmergencyPhone);
            sda.SelectCommand.Parameters.AddWithValue("@email", see.Email);
            sda.SelectCommand.Parameters.AddWithValue("@photo", see.Photo_Data);
            sda.SelectCommand.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
            sda.SelectCommand.Parameters.AddWithValue("@autoNo", SqlDbType.Int).Direction = ParameterDirection.Output;
            sda.SelectCommand.Parameters.AddWithValue("@date",see.Currentdate);
            sda.SelectCommand.ExecuteNonQuery();
            sda.SelectCommand.Connection.Close();
            int id = Convert.ToInt32(sda.SelectCommand.Parameters["@result"].Value);
            see.CareerId = id;
            autoCode = Convert.ToInt32(sda.SelectCommand.Parameters["@autoNo"].Value);
            return autoCode;
        }

        public DataTable SelectPhotoData(string code)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("Select Upload_FileName FROM Career_Upload where Career_ID=(SELECT ID From Career_Resume where Career_Code=@autoNo)", connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@autoNo", code);
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt;
        }

        public void Update(Employee_SelfEntry_Entity see,string code)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Update_Emp_Information", connection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@name", see.Name);
            sda.SelectCommand.Parameters.AddWithValue("@gender", see.Gender);
            sda.SelectCommand.Parameters.AddWithValue("@dob", see.DOB);
            sda.SelectCommand.Parameters.AddWithValue("@religion", see.Religion);
            sda.SelectCommand.Parameters.AddWithValue("@address", see.Address);
            sda.SelectCommand.Parameters.AddWithValue("@detail_add", see.Detail_Add);
            sda.SelectCommand.Parameters.AddWithValue("@phone", see.Phone);
            sda.SelectCommand.Parameters.AddWithValue("@ephone", see.EmergencyPhone);
            sda.SelectCommand.Parameters.AddWithValue("@email", see.Email);
            sda.SelectCommand.Parameters.AddWithValue("@ename", see.Emergencycontantperson);
            sda.SelectCommand.Parameters.AddWithValue("@photo", see.Photo_Data);
            sda.SelectCommand.Parameters.AddWithValue("@autoNo", code);
            sda.SelectCommand.Parameters.AddWithValue("@date",see.Currentdate);
            sda.SelectCommand.ExecuteNonQuery();
            sda.SelectCommand.Connection.Close();
        }

        public void DeleteWorkingPlace(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("DELETE Career_WorkingPlace WHERE Career_ID=@ID", connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@ID", id);
            sda.SelectCommand.ExecuteNonQuery();
            sda.SelectCommand.Connection.Close();
        }
     
        public DataTable GetWorkingDescription(int workingplace)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Working_Place where ID=@ID ", connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@ID", workingplace);
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt;
        }

        public DataTable SelectByWorkingPlace(string AutoCode)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Career_WorkingPlace wp INNER JOIN Career_Resume cr ON wp.Career_ID=cr.ID INNER JOIN Working_Place wp1 ON wp1.ID=wp.WorkingPlace_ID where Career_Code=@code",connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@code", AutoCode);
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt;
        }

        public void InsertWorkingPlace(int id, int workingplace)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Insert_Career_WorkingPlace", connection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@careerid",id);
            sda.SelectCommand.Parameters.AddWithValue("@workingplace", workingplace);
            sda.SelectCommand.ExecuteNonQuery();
            sda.SelectCommand.Connection.Close();
        }

        public DataTable GetReligion(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Religion where ID=@id and IsDeleted=0", connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@id", id);
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt;
        }

        public DataTable GetEducation(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Education where ID=@id and IsDeleted=0", connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@id", id);
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt;
        }

        public DataTable GetMajor(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Major where ID=@id and IsDeleted=0", connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@id", id);
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt;
        }

        public DataTable GetInstitution(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Institution where ID=@id and IsDeleted=0", connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@id", id);
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt;
        }

        public DataTable GetSituation(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Situation where ID=@id", connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@id", id);
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt;
        }
    }
}
