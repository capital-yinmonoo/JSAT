using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace JSAT_Common
{
  public   class Career_PersonalSkill
    {
        private DataTable personal_skill = new DataTable();
        public DataTable Personal_skill
        {
            get { return personal_skill; }
            set { personal_skill = value; }
        }

        private int CareerId = 0;
        public int CareerId1
        {
            get { return CareerId; }
            set { CareerId = value; }
        }

        public Career_PersonalSkill()
        {
            personal_skill = new DataTable();
            personal_skill.Columns.Add("Career_ID", typeof(int));
            personal_skill.Columns.Add("PersonaSkill_ID", typeof(int));
        }
    }
}
