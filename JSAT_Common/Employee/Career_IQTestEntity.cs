using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_Common
{
    public class Career_IQTestEntity
    {
        DataTable dtCareer_IQTestEntity;

        public DataTable Career_IQTest
        {
            get { return dtCareer_IQTestEntity; }
            set { dtCareer_IQTestEntity = value; }
        }

        public Career_IQTestEntity()
        {
            dtCareer_IQTestEntity = new DataTable();
            dtCareer_IQTestEntity.Columns.Add("ID", typeof(int));
            dtCareer_IQTestEntity.Columns.Add("Career_ID", typeof(int));
            dtCareer_IQTestEntity.Columns.Add("IQTestQuestion_ID", typeof(int));
            dtCareer_IQTestEntity.Columns.Add("IQTest_Answer", typeof(string));
            dtCareer_IQTestEntity.Columns.Add("IsCorrect",typeof(bool));
        }
    }
}
