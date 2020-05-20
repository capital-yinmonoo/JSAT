using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JSAT_Common
{
    public class Career_Profile_QuestionEntity
    {
        DataTable dtCareer_Profile_QuestionEntity;
        public DataTable Career_Profile_Question
        {
            get { return dtCareer_Profile_QuestionEntity; }
            set { dtCareer_Profile_QuestionEntity = value; }
        }

        public Career_Profile_QuestionEntity()
        {
            dtCareer_Profile_QuestionEntity = new DataTable();
            dtCareer_Profile_QuestionEntity.Columns.Add("ID", typeof(int));
            dtCareer_Profile_QuestionEntity.Columns.Add("Career_ID", typeof(int));
            dtCareer_Profile_QuestionEntity.Columns.Add("ProfileQuestion_ID", typeof(int));
        }
    }
}
