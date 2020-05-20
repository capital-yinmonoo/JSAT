using JSAT_DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1
{
    public partial class Company_Type_Details : System.Web.UI.Page
    {
        string str = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAll(str);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                SelectAll(txtSearch.Text);
            }
        }

        public void SelectAll(string str)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Company_Type_Relation_SelectAll", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@Description", str);
                sda.Fill(dt);
                if (dt.Rows.Count < 1)
                {
                    gvCompany.DataSource = dt;
                    gvCompany.DataBind();
                }
                else
                {
                    gvCompany.DataSource = dt;
                    gvCompany.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public bool Delete(int career_relationID)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Company_Type_Relation_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@career_relationID", career_relationID);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int num = Convert.ToInt16(cmd.Parameters["@result"].Value);
                if (num >= 0)
                {
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        protected void gvCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(((Label)gvCompany.Rows[e.RowIndex].FindControl("lblID")).Text);
            if (Delete(id))
                GlobalUI.MessageBox("Delete successfully");
            SelectAll(null);
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            SelectAll(str);
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            SelectAll(str);
            gvCompany.PageIndex = e.NewPageIndex;
            gvCompany.DataBind();
        }

        protected void gvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
    }
}