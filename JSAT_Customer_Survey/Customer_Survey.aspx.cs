using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Customer_Survey
{
    public partial class Customer_Survey : System.Web.UI.Page
    {

        private readonly SqlConnection con;
        public Customer_Survey()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        public void ShowMessage(string msg)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('" + msg + "');", true);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var isValid = true;
            if (String.IsNullOrEmpty(txtName.Value))
            {
                isValid = false;
                txtName.Focus();
                ShowMessage("Please enter your name!");
                return;
            }

            if (String.IsNullOrEmpty(txtPhno.Value))
            {
                isValid = false;
                txtPhno.Focus();
                ShowMessage("Please enter your phone no!");
                return;
            }

            //if (!isValid)
            //{
            //    ShowMessage("Please enter madantory fields.");
            //}

            try
            {
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into Customer_Survey(name,phno,Q1,Q2,Q3,Q4,Q5,Q6,Q7,Q8,Q9)" +
                        "Values(@name,@phno,@Q1,@Q2,@Q3,@Q4,@Q5,@Q6,@Q7,@Q8,@Q9)";
                    cmd.Parameters.AddWithValue("@name", txtName.Value);
                    cmd.Parameters.AddWithValue("@phno", txtPhno.Value);
                    cmd.Parameters.AddWithValue("@Q1", rdoQ1.Checked);
                    cmd.Parameters.AddWithValue("@Q2", rdoQ2.Checked);
                    cmd.Parameters.AddWithValue("@Q3", rdoQ3.Checked);
                    cmd.Parameters.AddWithValue("@Q4", rdoQ4.Checked);
                    cmd.Parameters.AddWithValue("@Q5", rdoQ5.Checked);
                    cmd.Parameters.AddWithValue("@Q6", rdoQ6.Checked);
                    cmd.Parameters.AddWithValue("@Q7", rdoQ7.Checked);
                    cmd.Parameters.AddWithValue("@Q8", rdoQ8.Checked);
                    cmd.Parameters.AddWithValue("@Q9", rdoQ9.Checked);


                    cmd.ExecuteNonQuery();
                }

                ShowMessage("Data Save successfully...!");
                Clear();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtName.Value = string.Empty;
            txtPhno.Value = string.Empty;

            rdo1.Checked = true;
            rdo2.Checked = true;
            rdo3.Checked = true;
            rdo4.Checked = true;
            rdo5.Checked = true;
            rdo6.Checked = true;
            rdo7.Checked = true;
            rdo8.Checked = true;
            rdo9.Checked = true;
            //rdoQ1.Checked = false;
            //rdoQ2.Checked = false;
            //rdoQ3.Checked = false;
            //rdoQ4.Checked = false;
            //rdoQ5.Checked = false;
            //rdoQ6.Checked = false;
            //rdoQ7.Checked = false;
            //rdoQ8.Checked = false;
            //rdoQ9.Checked = false;

        }
    }
}
