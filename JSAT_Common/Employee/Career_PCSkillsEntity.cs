using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JSAT_Common
{
    public class Career_PCSkillsEntity
    {
        private DataTable pcSkills=new DataTable();
        public DataTable PcSkills
        {
            get { return pcSkills; }
            set { pcSkills = value; }
        }

        private int careerId = 0;
        public int CareerId
        {
            get { return careerId; }
            set { careerId = value; }
        }

        public Career_PCSkillsEntity()
        {
            pcSkills = new DataTable();
            pcSkills.Columns.Add("Career_ID", typeof(int));
            pcSkills.Columns.Add("PCSkill_ID", typeof(int));
        }
    }
}
