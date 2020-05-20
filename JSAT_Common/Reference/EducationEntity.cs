using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_Common
{
    public class EducationEntity
    {
        DataTable dtEducation;
        public DataTable Education
        {
            get { return dtEducation; }
            set { dtEducation = value; }
        }

        public EducationEntity()
        {
            dtEducation = new DataTable();
            dtEducation.Columns.Add("ID", typeof(int));
            dtEducation.Columns.Add("ProfileID", typeof(int));
            dtEducation.Columns.Add("EducationID", typeof(int));
        }
    }
}
