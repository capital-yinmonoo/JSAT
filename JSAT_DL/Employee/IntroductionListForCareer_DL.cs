using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
namespace JSAT_DL
{
    public class IntroductionListForCareer_DL
    {
        SqlConnection connection;
        SqlTransaction sqltran;
        public IntroductionListForCareer_DL()
        {
            connection = DataConfig.GetConnectionString();
        }

        #region
        public void BeginTransaction()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            sqltran = connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (sqltran != null)
                sqltran.Commit();
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public void RollBackTransaction()
        {
            if (sqltran != null)
                sqltran.Rollback();
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
        #endregion

        public DataTable Bind()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Situation", connection);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dtb = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BindDDL()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Salary_Type", connection);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dtb = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert_IntroductionList(IntroductionListForCareer_Entity introentity )
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Insert_IntroductionList", connection, sqltran);
                cmd.CommandType = CommandType.StoredProcedure;
                if (!string.IsNullOrWhiteSpace(Convert.ToString(introentity.Career_code)))
                {
                    cmd.Parameters.AddWithValue("@Career_Code", introentity.Career_code);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(introentity.Name)))
                {
                    cmd.Parameters.AddWithValue("@name", introentity.Name);
                }
                if (!string.IsNullOrWhiteSpace(Convert.ToString(introentity.Salary)))
                {
                    cmd.Parameters.AddWithValue("@salary", introentity.Salary);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(introentity.Salary_type)))
                {
                    cmd.Parameters.AddWithValue("@salarytype", introentity.Salary_type);
                }
                if (!string.IsNullOrWhiteSpace(Convert.ToString(introentity.Sign)))
                {
                    cmd.Parameters.AddWithValue("@sign", introentity.Sign);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(introentity.Start_working_date)))
                {
                    cmd.Parameters.AddWithValue("@startworkingdate", introentity.Start_working_date);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(introentity.Gender)))
                {
                    cmd.Parameters.AddWithValue("@gender", introentity.Gender);
                }
                cmd.Parameters.AddWithValue("@createddate", DateTime.Now);
                cmd.Parameters.AddWithValue("@updateddate", DateTime.Now);
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_IntroductionListForCompany(DataTable dt, int id)
        {
            try
            {
                string[] ID = new String[dt.Rows.Count];
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertIntorductionCompany_test", connection, sqltran);
                    cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@success_worker_ID", id);

                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["companyID"])))
                    {
                        cmd.Parameters.AddWithValue("@companyID", dt.Rows[z]["companyID"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@companyID", DBNull.Value);

                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Company_Name"])))
                    {
                        cmd.Parameters.AddWithValue("@companyName", dt.Rows[z]["Company_Name"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@companyName", DBNull.Value);


                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Job_No"])))
                    {
                        cmd.Parameters.AddWithValue("@jobno", dt.Rows[z]["Job_No"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@jobno", DBNull.Value);

                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["positionID"])))
                    {
                        cmd.Parameters.AddWithValue("@position", dt.Rows[z]["positionID"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@position", DBNull.Value);

                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Introduction_Date"])))
                    {
                        cmd.Parameters.AddWithValue("@introduction", dt.Rows[z]["Introduction_Date"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@introduction", DBNull.Value);

                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Sent_CV_Date"])))
                    {
                        cmd.Parameters.AddWithValue("@sentcv", dt.Rows[z]["Sent_CV_Date"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@sentcv", DBNull.Value);

                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Salary_Hidden"])))
                    {
                        cmd.Parameters.AddWithValue("@expectedsalary", dt.Rows[z]["Salary_Hidden"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@expectedsalary", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["expectedsalarytype"])))
                    {
                        cmd.Parameters.AddWithValue("@expectedsalarytype", dt.Rows[z]["expectedsalarytype"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@expectedsalarytype", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["condition"])))
                    {
                        cmd.Parameters.AddWithValue("@condition", dt.Rows[z]["condition"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@condition", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["noticetype"])))
                    {
                        cmd.Parameters.AddWithValue("@noticetype", dt.Rows[z]["noticetype"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@noticetype", DBNull.Value);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["noticeday"])))
                    {
                        cmd.Parameters.AddWithValue("@noticeday", dt.Rows[z]["noticeday"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@noticeday", DBNull.Value);

                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Interview_Date"])))
                    {
                        cmd.Parameters.AddWithValue("@interviewdate", dt.Rows[z]["Interview_Date"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@interviewdate", DBNull.Value);

                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Interview_Time"])))
                    {
                        cmd.Parameters.AddWithValue("@interviewtime", dt.Rows[z]["Interview_Time"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@interviewtime", DBNull.Value);

                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[z]["Result"])))
                    {
                        cmd.Parameters.AddWithValue("@result", dt.Rows[z]["Result"]);
                    }
                    else
                        cmd.Parameters.AddWithValue("@result", DBNull.Value);
                        cmd.Parameters.AddWithValue("@before", false);
                        cmd.Parameters.AddWithValue("@theday", false);
                        cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataForGridView(int id)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetDataForGridView", DataConfig.connectionString);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                da.SelectCommand.Connection.Open();
                DataTable dtb = new DataTable();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable FillData(int id)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_FillSuccessEmployeeInfo", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                da.SelectCommand.Connection.Open();
                DataTable dtb = new DataTable();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDataForGridView(int id)
        {
            try
            {
            SqlCommand cmd = new SqlCommand("SP_DeleteSuccessEmployeeDetail", connection, sqltran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
              }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSuccessWorkerInfo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_DeleteSuccessWorkerInfo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployeeDetail(int successworkereid, int jobno, int companyid, int positionid, string introductiondate, string sentcvdate, int expectedsalary, string expectsalarytype, string condition, string noteicetype, string noticeday, string interviewdate, string interviewtime, string result, string id)
        {
            SqlCommand cmd = new SqlCommand("SP_UpdateSuccessWorkerDetail_test", connection, sqltran);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (!String.IsNullOrWhiteSpace(Convert.ToString(companyid)))
                    {
                        cmd.Parameters.AddWithValue("@companyID", companyid);
                    }
                    else
                        cmd.Parameters.AddWithValue("@companyID", DBNull.Value);

                if (!String.IsNullOrWhiteSpace(Convert.ToString(successworkereid)))
                {
                    cmd.Parameters.AddWithValue("@Success_Worker_ID", successworkereid);
                }
                else
                    cmd.Parameters.AddWithValue("@Success_Worker_ID", DBNull.Value);


                if (!String.IsNullOrWhiteSpace(Convert.ToString(jobno)))
                {
                    cmd.Parameters.AddWithValue("@jobno", jobno);
                }
                else
                    cmd.Parameters.AddWithValue("@jobno", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(positionid)))
                {
                    cmd.Parameters.AddWithValue("@position", positionid);
                }
                else
                    cmd.Parameters.AddWithValue("@position", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(introductiondate)))
                {
                    cmd.Parameters.AddWithValue("@introduction", introductiondate);
                }
                else
                    cmd.Parameters.AddWithValue("@introduction", DBNull.Value);
                
                 
                if(!String.IsNullOrWhiteSpace(Convert.ToString(sentcvdate)))
                {
                 cmd.Parameters.AddWithValue("@sentcvdate",sentcvdate);
                }
                else
                    cmd.Parameters.AddWithValue("@sentcvdate",DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(expectedsalary)))
                {
                    cmd.Parameters.AddWithValue("@expectedsalary", expectedsalary);
                }
                else
                    cmd.Parameters.AddWithValue("@expectedsalary", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(expectsalarytype)))
                {
                    cmd.Parameters.AddWithValue("@expectedsalarytype", expectsalarytype);
                }
                else
                    cmd.Parameters.AddWithValue("@expectedsalarytype", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(condition)))
                {
                    cmd.Parameters.AddWithValue("@condition", condition);
                }
                else
                    cmd.Parameters.AddWithValue("@condition", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(noteicetype)))
                {
                    cmd.Parameters.AddWithValue("@noticetype", noteicetype);
                }
                else
                    cmd.Parameters.AddWithValue("@noticetype", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(noticeday)))
                {
                    cmd.Parameters.AddWithValue("@noticeday", Convert.ToInt32(noticeday));
                }
                else
                    cmd.Parameters.AddWithValue("@noticeday", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(interviewdate)))
                {
                    cmd.Parameters.AddWithValue("@interviewdate", interviewdate);
                }
                else
                    cmd.Parameters.AddWithValue("@interviewdate", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(interviewtime)))
                {
                    cmd.Parameters.AddWithValue("@interviewtime", interviewtime);
                }
                else
                    cmd.Parameters.AddWithValue("@interviewtime", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(result)))
                {
                    cmd.Parameters.AddWithValue("@result", result);
                }
                else
                    cmd.Parameters.AddWithValue("@result", DBNull.Value);
                cmd.Parameters.AddWithValue("@id",id );
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddNewDetail(int successworkereid, int jobno, int companyid, int positionid, string introductiondate, string sentcvdate, int expectedsalary, string expectsalarytype, string condition, string noteicetype, string noticeday, string interviewdate,string interviewtime, string result)
        {
            try
            {
              SqlCommand cmd = new SqlCommand("SP_InsertIntorductionCompany", connection, sqltran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(successworkereid)))
                {
                    cmd.Parameters.AddWithValue("@success_worker_ID", successworkereid);
                }
                else
                    cmd.Parameters.AddWithValue("@success_worker_ID", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(companyid)))
                {
                    cmd.Parameters.AddWithValue("@companyID", companyid);
                }
                else
                    cmd.Parameters.AddWithValue("@companyID", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(jobno)))
                {
                    cmd.Parameters.AddWithValue("@jobno", jobno);
                }
                else
                    cmd.Parameters.AddWithValue("@jobno", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(positionid)))
                {
                    cmd.Parameters.AddWithValue("@position", positionid);
                }
                else
                    cmd.Parameters.AddWithValue("@position", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(introductiondate)))
                {
                    cmd.Parameters.AddWithValue("@introduction", introductiondate);
                }
                else
                    cmd.Parameters.AddWithValue("@introduction", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(sentcvdate)))
                {
                    cmd.Parameters.AddWithValue("@sentcvdate", sentcvdate);
                }
                else
                    cmd.Parameters.AddWithValue("@sentcvdate", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(expectedsalary)))
                {
                    cmd.Parameters.AddWithValue("@expectedsalary", expectedsalary);
                }
                else
                    cmd.Parameters.AddWithValue("@expectedsalary", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(expectsalarytype)))
                {
                    cmd.Parameters.AddWithValue("@expectedsalarytype", expectsalarytype);
                }
                else
                    cmd.Parameters.AddWithValue("@expectedsalarytype", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(condition)))
                {
                    cmd.Parameters.AddWithValue("@condition", condition);
                }
                else
                    cmd.Parameters.AddWithValue("@condition", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(noteicetype)))
                {
                    cmd.Parameters.AddWithValue("@noticetype", noteicetype);
                }
                else
                    cmd.Parameters.AddWithValue("@noticetype", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(noticeday)))
                {
                    cmd.Parameters.AddWithValue("@noticeday", Convert.ToInt32(noticeday));
                }
                else
                    cmd.Parameters.AddWithValue("@noticeday", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(interviewdate)))
                {
                    cmd.Parameters.AddWithValue("@interviewdate", interviewdate);
                }
                else
                    cmd.Parameters.AddWithValue("@interviewdate", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(interviewtime)))
                {
                    cmd.Parameters.AddWithValue("@interviewtime", interviewtime);
                }
                else
                    cmd.Parameters.AddWithValue("@interviewtime", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(result)))
                {
                    cmd.Parameters.AddWithValue("@result", result);
                }
                else
                    cmd.Parameters.AddWithValue("@result", DBNull.Value);
                    cmd.Parameters.AddWithValue("@before", false);
                    cmd.Parameters.AddWithValue("@theday", false);
                    cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectUpdate(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_SelectUpdateIntroductionList", DataConfig.connectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            da.SelectCommand.Connection.Open();
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        public int  UpdateEmployeeInfo(IntroductionListForCareer_Entity introentity)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmployeeInfo", connection, sqltran);
                cmd.CommandType = CommandType.StoredProcedure;
                if (!string.IsNullOrWhiteSpace(Convert.ToString(introentity.Career_code)))
                {
                    cmd.Parameters.AddWithValue("@Career_Code", introentity.Career_code);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(introentity.Name)))
                {
                    cmd.Parameters.AddWithValue("@name", introentity.Name);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(introentity.Gender)))
                {
                    cmd.Parameters.AddWithValue("@gender", introentity.Gender);
                }
                if (!string.IsNullOrWhiteSpace(Convert.ToString(introentity.Salary)))
                {
                    cmd.Parameters.AddWithValue("@salary", introentity.Salary);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(introentity.Salary_type)))
                {
                    cmd.Parameters.AddWithValue("@salarytype", introentity.Salary_type);
                }
                if (!string.IsNullOrWhiteSpace(Convert.ToString(introentity.Sign)))
                {
                    cmd.Parameters.AddWithValue("@sign", introentity.Sign);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(introentity.Start_working_date)))
                {
                    cmd.Parameters.AddWithValue("@startworkingdate", introentity.Start_working_date);
                }
                cmd.Parameters.AddWithValue("@id",introentity.SuccessworkerID);
                cmd.Parameters.AddWithValue("@updateddate", DateTime.Now);
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable CheckUniqueID(string code)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Carrer_Code from Success_Employee_Info where Carrer_Code=@code", DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@code", code);
            DataTable dtcheck = new DataTable();
            da.Fill(dtcheck);
            return dtcheck;
        }

        public DataTable CheckEmployeeExist(string code)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Career_Code from Career_Resume where Career_Code=@code ", DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@code", code);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize, out int totalrowcount)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_GridviewPagingForSucessEmployee", DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Search", search);
            da.SelectCommand.Parameters.AddWithValue("@Sort", sort);
            da.SelectCommand.Parameters.AddWithValue("@StartIndex", startIndex);
            da.SelectCommand.Parameters.AddWithValue("@PageSize", pagesize);
            DataSet ds = new DataSet();
            da.Fill(ds);
            totalrowcount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return ds.Tables[0];
        }

        public void DeleteAllData(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(" Delete from Success_Employe_Details where ID=@id", connection, sqltran);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

    

 
