using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using System.Configuration;

namespace JSAT_DL
{
    public class Credit_NewDL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Credit_NewDL()
        { }

        public DataTable Get_Info_ByEmpID(int pid, int eid)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_Info_ByEmpID", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@Company_Credit_ID", pid);
                sda.SelectCommand.Parameters.AddWithValue("@Employee_ID", eid);
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_Info_Employee(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_Info_EmpID", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@Employee_Credit_ID", id);
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex) { throw ex; }
        }

        public String Select_Emp_Code(String empid)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select  Career_Code from Career_Resume where ID=" + empid, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                String empcode = (String)cmd.ExecuteScalar();
                cmd.Connection.Close();
                return empcode;
            }
            catch (Exception ex) { throw ex; }
        }

        public int Insert_Company_Credit(Credit_New_Entity creditentity, int PID, int option)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Company_Insert", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@ID", PID);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.ID)))
                    sda.SelectCommand.Parameters.AddWithValue("@Company_ID", creditentity.ID);
                else
                    sda.SelectCommand.Parameters.AddWithValue("@Company_ID", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.Name)))
                    sda.SelectCommand.Parameters.AddWithValue("@JobNo", Convert.ToInt32(creditentity.JobNo));
                else
                    sda.SelectCommand.Parameters.AddWithValue("@JobNo", DBNull.Value);
                sda.SelectCommand.Parameters.AddWithValue("@Option", option);
                sda.SelectCommand.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                sda.SelectCommand.ExecuteNonQuery();
                int id = Convert.ToInt32(sda.SelectCommand.Parameters["@result"].Value);
                sda.SelectCommand.Connection.Close();
                return id;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable GetFirstDurationDate(string FDD)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Insert_FDD", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@FDD", FDD);
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSecondDurationDate(string SDD)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Insert_SDD", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@SDD", SDD);
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_Company_Credit_For_Update(Credit_New_Entity creditentity, int CID)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Company_Update", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@ID", CID);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.ID)))
                    sda.SelectCommand.Parameters.AddWithValue("@Company_ID", creditentity.ID);
                else
                    sda.SelectCommand.Parameters.AddWithValue("@Company_ID", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.JobNo)))
                    sda.SelectCommand.Parameters.AddWithValue("@JobNo", Convert.ToInt32(creditentity.JobNo));
                else
                    sda.SelectCommand.Parameters.AddWithValue("@JobNo", DBNull.Value);
                sda.SelectCommand.ExecuteNonQuery();
                sda.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_Employee_Credit(Credit_New_Entity creditentity, DataTable dt, int id)
        {
            try
            {
                String[] ID = new String[dt.Rows.Count];
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    String FDD = Convert.ToString(dt.Rows[z]["First_Payment_Date"]);
                    String SDD = Convert.ToString(dt.Rows[z]["Second_Payment_Date"]);
                    DataTable dt1 = GetFirstDurationDate(FDD);
                    DataTable dt2 = GetSecondDurationDate(SDD);
                    String FirstDdate = Convert.ToString(dt1.Rows[0]["First_Duration_Date"]);
                    String SecondDdate = Convert.ToString(dt2.Rows[0]["Second_Duration_Date"]);
                    SqlDataAdapter sda = new SqlDataAdapter("SP_Employee_Credit_Insert", connection);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Connection.Open();
                    sda.SelectCommand.Parameters.AddWithValue("@Company_Credit_ID", id);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Employee_ID"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Employee_ID", dt.Rows[z]["Employee_ID"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Employee_ID", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Status"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Status_ID", dt.Rows[z]["Status"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Status_ID", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.JobID)))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Job_Position_ID", Convert.ToInt32(creditentity.JobID));
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Job_Position_ID", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["First_Payment_Date"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@First_Date", dt.Rows[z]["First_Payment_Date"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@First_Date", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Second_Payment_Date"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Second_Date", dt.Rows[z]["Second_Payment_Date"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Second_Date", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Start_Working_Date"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Start_Date", dt.Rows[z]["Start_Working_Date"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Start_Date", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["End_Working_Date"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@End_Date", dt.Rows[z]["End_Working_Date"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@End_Date", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["First_Payment_Amount"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@First_Amt", dt.Rows[z]["First_Payment_Amount"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@First_Amt", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Second_Payment_Amount"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Second_Amt", dt.Rows[z]["Second_Payment_Amount"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Second_Amt", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Salary"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Salary", dt.Rows[z]["Salary"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Salary", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Payment_Term"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Employee_Payment_Term", dt.Rows[z]["Payment_Term"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Employee_Payment_Term", DBNull.Value);
                    sda.SelectCommand.Parameters.AddWithValue("@First_Status", 0);
                    sda.SelectCommand.Parameters.AddWithValue("@Second_Status", 0);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Currency"])))
                        sda.SelectCommand.Parameters.AddWithValue("@Currency", dt.Rows[z]["Currency"]);
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Currency", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(FirstDdate)))
                        sda.SelectCommand.Parameters.AddWithValue("@FirstDDate", FirstDdate);
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@FirstDDate", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(SecondDdate)))
                        sda.SelectCommand.Parameters.AddWithValue("@SecondDDate", SecondDdate);
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@SecondDDate", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.SubID)))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Substitute_ID", creditentity.SubID);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Substitute_ID", 0);
                    sda.SelectCommand.ExecuteNonQuery();
                    sda.SelectCommand.Connection.Close();
                    ID[z] = dt.Rows[z]["Employee_ID"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Employee_Credit_Update(int EID, int CID, DataTable dt, Credit_New_Entity creditentity)
        {
            try
            {
                String[] ID = new String[dt.Rows.Count];
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    String FDD = Convert.ToString(dt.Rows[z]["First_Payment_Date"]);
                    String SDD = Convert.ToString(dt.Rows[z]["Second_Payment_Date"]);
                    DataTable dt1 = GetFirstDurationDate(FDD);
                    DataTable dt2 = GetSecondDurationDate(SDD);
                    String FirstDdate = Convert.ToString(dt1.Rows[0]["First_Duration_Date"]);
                    String SecondDdate = Convert.ToString(dt2.Rows[0]["Second_Duration_Date"]);
                    SqlDataAdapter sda = new SqlDataAdapter("SP_Employee_Credit_Update", connection);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Connection.Open();
                    sda.SelectCommand.Parameters.AddWithValue("@Company_Credit_ID", CID);
                    sda.SelectCommand.Parameters.AddWithValue("@Employee_Credit_ID", EID);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Employee_ID"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Employee_ID", dt.Rows[z]["Employee_ID"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Employee_ID", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Status"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Status_ID", dt.Rows[z]["Status"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Status_ID", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.JobID)))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Job_Position_ID", Convert.ToInt32(creditentity.JobID));
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Job_Position_ID", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["First_Payment_Date"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@First_Date", dt.Rows[z]["First_Payment_Date"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@First_Date", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Second_Payment_Date"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Second_Date", dt.Rows[z]["Second_Payment_Date"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Second_Date", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Start_Working_Date"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Start_Date", dt.Rows[z]["Start_Working_Date"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Start_Date", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["End_Working_Date"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@End_Date", dt.Rows[z]["End_Working_Date"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@End_Date", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["First_Payment_Amount"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@First_Amt", dt.Rows[z]["First_Payment_Amount"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@First_Amt", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Second_Payment_Amount"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Second_Amt", dt.Rows[z]["Second_Payment_Amount"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Second_Amt", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Salary"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Salary", dt.Rows[z]["Salary"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Salary", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Payment_Term"])))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@Employee_Payment_Term", dt.Rows[z]["Payment_Term"]);
                    }
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Employee_Payment_Term", DBNull.Value);
                    if (dt.Rows[z]["Status"].ToString().Equals("3"))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@First_Status", 2);
                        sda.SelectCommand.Parameters.AddWithValue("@Second_Status", 2);
                    }
                    else
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@First_Status", 0);
                        sda.SelectCommand.Parameters.AddWithValue("@Second_Status", 0);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Currency"])))
                        sda.SelectCommand.Parameters.AddWithValue("@Currency", dt.Rows[z]["Currency"]);
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@Currency", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(FirstDdate)))
                        sda.SelectCommand.Parameters.AddWithValue("@FirstDDate", FirstDdate);
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@FirstDDate", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(SecondDdate)))
                        sda.SelectCommand.Parameters.AddWithValue("@SecondDDate", SecondDdate);
                    else
                        sda.SelectCommand.Parameters.AddWithValue("@SecondDDate", DBNull.Value);
                    sda.SelectCommand.ExecuteNonQuery();
                    sda.SelectCommand.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Employee_Credit_Update_New(int EID, int CID, Credit_New_Entity creditentity)
        {
            String FDD = Convert.ToString(creditentity.FirstInvoiceDate);
            String SDD = Convert.ToString(creditentity.SecondInvoiceDate);
            DataTable dt1 = GetFirstDurationDate(FDD);
            DataTable dt2 = GetSecondDurationDate(SDD);
            String FirstDdate = Convert.ToString(dt1.Rows[0]["First_Duration_Date"]);
            String SecondDdate = Convert.ToString(dt2.Rows[0]["Second_Duration_Date"]);
            SqlDataAdapter sda = new SqlDataAdapter("SP_Employee_Credit_Update", connection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Connection.Open();
            sda.SelectCommand.Parameters.AddWithValue("@Company_Credit_ID", CID);
            sda.SelectCommand.Parameters.AddWithValue("@Employee_Credit_ID", EID);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.ID)))
            {
                sda.SelectCommand.Parameters.AddWithValue("@Employee_ID", creditentity.ID);
            }
            else
                sda.SelectCommand.Parameters.AddWithValue("@Employee_ID", DBNull.Value);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.Status)))
            {
                sda.SelectCommand.Parameters.AddWithValue("@Status_ID", creditentity.Status);
            }
            else
                sda.SelectCommand.Parameters.AddWithValue("@Status_ID", DBNull.Value);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.JobID)))
            {
                sda.SelectCommand.Parameters.AddWithValue("@Job_Position_ID", Convert.ToInt32(creditentity.JobID));
            }
            else
                sda.SelectCommand.Parameters.AddWithValue("@Job_Position_ID", DBNull.Value);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.FirstInvoiceDate)))
            {
                sda.SelectCommand.Parameters.AddWithValue("@First_Date", creditentity.FirstInvoiceDate);
            }
            else
                sda.SelectCommand.Parameters.AddWithValue("@First_Date", DBNull.Value);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.SecondInvoiceDate)))
            {
                sda.SelectCommand.Parameters.AddWithValue("@Second_Date", creditentity.SecondInvoiceDate);
            }
            else
                sda.SelectCommand.Parameters.AddWithValue("@Second_Date", DBNull.Value);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.StartWorkingDate)))
            {
                sda.SelectCommand.Parameters.AddWithValue("@Start_Date", creditentity.StartWorkingDate);
            }
            else
                sda.SelectCommand.Parameters.AddWithValue("@Start_Date", DBNull.Value);

            if (creditentity.EndWorkingDate != DateTime.MinValue)
            {
                sda.SelectCommand.Parameters.AddWithValue("@End_Date", creditentity.EndWorkingDate);
            }
            else
                sda.SelectCommand.Parameters.AddWithValue("@End_Date", DBNull.Value);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.FirstAmount)))
            {
                sda.SelectCommand.Parameters.AddWithValue("@First_Amt", creditentity.FirstAmount);
            }
            else
                sda.SelectCommand.Parameters.AddWithValue("@First_Amt", DBNull.Value);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.SecondAmount)))
            {
                sda.SelectCommand.Parameters.AddWithValue("@Second_Amt", creditentity.SecondAmount);
            }
            else
                sda.SelectCommand.Parameters.AddWithValue("@Second_Amt", DBNull.Value);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.Salary)))
            {
                sda.SelectCommand.Parameters.AddWithValue("@Salary", creditentity.Salary);
            }
            else
                sda.SelectCommand.Parameters.AddWithValue("@Salary", DBNull.Value);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.Payment)))
            {
                sda.SelectCommand.Parameters.AddWithValue("@Employee_Payment_Term", creditentity.Payment);
            }
            else
                sda.SelectCommand.Parameters.AddWithValue("@Employee_Payment_Term", DBNull.Value);
            if (creditentity.Status.Equals("3"))
            {
                sda.SelectCommand.Parameters.AddWithValue("@First_Status", 2);
                sda.SelectCommand.Parameters.AddWithValue("@Second_Status", 2);
            }
            else
            {
                sda.SelectCommand.Parameters.AddWithValue("@First_Status", 0);
                sda.SelectCommand.Parameters.AddWithValue("@Second_Status", 0);
            }
            if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.Currency)))
                sda.SelectCommand.Parameters.AddWithValue("@Currency", creditentity.Currency);
            else
                sda.SelectCommand.Parameters.AddWithValue("@Currency", DBNull.Value);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(FirstDdate)))
                sda.SelectCommand.Parameters.AddWithValue("@FirstDDate", FirstDdate);
            else
                sda.SelectCommand.Parameters.AddWithValue("@FirstDDate", DBNull.Value);
            if (!String.IsNullOrWhiteSpace(Convert.ToString(SecondDdate)))
                sda.SelectCommand.Parameters.AddWithValue("@SecondDDate", SecondDdate);
            else
                sda.SelectCommand.Parameters.AddWithValue("@SecondDDate", DBNull.Value);
            sda.SelectCommand.ExecuteNonQuery();
            sda.SelectCommand.Connection.Close();
        }

        public void Update_Company_Credit(Credit_New_Entity creditentity, int id)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Company_Update", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.ID)))
                    sda.SelectCommand.Parameters.AddWithValue("@Company_ID", creditentity.ID);
                else
                    sda.SelectCommand.Parameters.AddWithValue("@Company_ID", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.Name)))
                    sda.SelectCommand.Parameters.AddWithValue("@JobNo", Convert.ToInt32(creditentity.JobNo));
                else
                    sda.SelectCommand.Parameters.AddWithValue("@JobNo", DBNull.Value);
                sda.SelectCommand.ExecuteNonQuery();
                sda.SelectCommand.Connection.Close();
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable BindDropDown()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("Select Career_Code From Career_Resume", connection);
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Connection.Open();
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            return dt;
        }
    }
}
