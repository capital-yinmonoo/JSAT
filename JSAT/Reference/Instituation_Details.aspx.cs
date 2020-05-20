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
    public partial class Instituation_Details : System.Web.UI.Page
    {
        string str = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAll(str);
            }
        }

        public void SelectAll(string str)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Institution_Relation_SelectAll", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@Description", str);
                sda.Fill(dt);
                if (dt.Rows.Count < 1)
                {
                    gvInstituation.DataSource = dt;
                    gvInstituation.DataBind();
                }
                else
                {
                    gvInstituation.DataSource = dt;
                    gvInstituation.DataBind();
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

        public bool Delete(int relationID)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Institution_Relation_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@crelationID", relationID);
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

        protected void gvInstituation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(((Label)gvInstituation.Rows[e.RowIndex].FindControl("lblID")).Text);
            if (Delete(id))
                GlobalUI.MessageBox("Delete successfully");
            SelectAll(null);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                SelectAll(txtSearch.Text);
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            SelectAll(str);
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            str = txtSearch.Text;
            SelectAll(str);
            gvInstituation.PageIndex = e.NewPageIndex;
            gvInstituation.DataBind();
        }

        protected void gvInstituation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
    }
}