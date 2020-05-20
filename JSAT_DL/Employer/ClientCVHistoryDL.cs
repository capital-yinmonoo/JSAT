using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class ClientCVHistoryDL
    {
        public ClientCVHistoryDL()
        { }

        public bool Insert(ClientCVHistoryEntity cvInfo)
        {
            try {
                SqlCommand cmd = new SqlCommand("SP_Client_CV_History_Update",DataConfig.GetConnectionString());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID",cvInfo.ID);
                cmd.Parameters.AddWithValue("@Client_ID" , cvInfo.Client_ID);
                cmd.Parameters.AddWithValue("@No_History" ,cvInfo.No_History);
                cmd.Parameters.AddWithValue("@Company_Name" ,cvInfo.Company_Name);
                cmd.Parameters.AddWithValue("@Occupation" ,cvInfo.Occupation);
                cmd.Parameters.AddWithValue("@Interview_Date" ,cvInfo.Interview_Date);
                cmd.Parameters.AddWithValue("@Result " ,cvInfo.Result);
                cmd.Parameters.AddWithValue("@Recruitment_Result" ,cvInfo.Recruitment_Result);
                cmd.Parameters.AddWithValue("@Comment" ,cvInfo.Comment);
                cmd.Parameters.AddWithValue("@Option",0);
                cmd.Parameters.Add("@success" ,SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int id = Convert.ToInt32(cmd.Parameters["@success"].Value);
                if (id > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public ClientCVHistoryEntity SelectByClientID(int cid)
        {
            try 
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Client_CV_History_SelectByClientID", DataConfig.GetConnectionString());
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@Client_ID",cid);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                ClientCVHistoryEntity cvInfo = new ClientCVHistoryEntity();
                if (dt.Rows.Count > 0)
                {
                    cvInfo.Client_ID = (int)dt.Rows[0]["Client_ID"];
                    cvInfo.Company_Name = dt.Rows[0]["Company_Name"].ToString();
                    cvInfo.Comment = dt.Rows[0]["Comment"].ToString();
                    cvInfo.ID = (int)dt.Rows[0]["ID"];
                    cvInfo.Interview_Date = (DateTime)dt.Rows[0]["Interview_Date"];
                    cvInfo.No_History = (int)dt.Rows[0]["No_History"];
                    cvInfo.Occupation = dt.Rows[0]["Occupation"].ToString();
                    cvInfo.Recruitment_Result = (bool)dt.Rows[0]["Recruitment_Result"];
                    cvInfo.Result = dt.Rows[0]["Result"].ToString();
                    return cvInfo;
                }
                else 
                {
                    return cvInfo = null;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Update(ClientCVHistoryEntity cvInfo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Client_CV_History_Update", DataConfig.GetConnectionString());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID",cvInfo.ID);
                cmd.Parameters.AddWithValue("@Client_ID", cvInfo.Client_ID);
                cmd.Parameters.AddWithValue("@No_History", cvInfo.No_History);
                cmd.Parameters.AddWithValue("@Company_Name", cvInfo.Company_Name);
                cmd.Parameters.AddWithValue("@Occupation", cvInfo.Occupation);
                cmd.Parameters.AddWithValue("@Interview_Date", cvInfo.Interview_Date);
                cmd.Parameters.AddWithValue("@Result ", cvInfo.Result);
                cmd.Parameters.AddWithValue("@Recruitment_Result", cvInfo.Recruitment_Result);
                cmd.Parameters.AddWithValue("@Comment", cvInfo.Comment);
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@success", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int num = Convert.ToInt32(cmd.Parameters["@success"].Value);
                if (num > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public ClientCVHistoryEntity SelectByID(int id)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Client_CV_History_SelectByID", DataConfig.GetConnectionString());
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                ClientCVHistoryEntity cvInfo = new ClientCVHistoryEntity();
                if (dt.Rows.Count > 0)
                {
                    cvInfo.Client_ID = (int)dt.Rows[0]["Client_ID"];
                    cvInfo.Company_Name = dt.Rows[0]["Company_Name"].ToString();
                    cvInfo.Comment = dt.Rows[0]["Comment"].ToString();
                    cvInfo.ID = (int)dt.Rows[0]["ID"];
                    cvInfo.Interview_Date = (DateTime)dt.Rows[0]["Interview_Date"];
                    cvInfo.No_History = (int)dt.Rows[0]["No_History"];
                    cvInfo.Occupation = dt.Rows[0]["Occupation"].ToString();
                    cvInfo.Recruitment_Result = (bool)dt.Rows[0]["Recruitment_Result"];
                    cvInfo.Result = dt.Rows[0]["Result"].ToString();
                    return cvInfo;
                }
                else
                {
                    return cvInfo = null;
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
