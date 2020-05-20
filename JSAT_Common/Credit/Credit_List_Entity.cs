using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Credit_List_Entity
    {
        private int id = 0;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string eid =string.Empty;
        public string EID
        {
            get { return eid; }
            set { eid = value; }
        }

        private int jcode = 0;
        public int Jcode
        {
            get { return jcode; }
            set { jcode = value; }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string ename = string.Empty;
        public string EName
        {
            get { return ename; }
            set { ename = value; }
        }

        private string jdesc = string.Empty;
        public string Jdesc
        {
            get { return jdesc; }
            set { jdesc = value; }
        }

        private int payment = 0;
        public int Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        private string group = string.Empty;
        public string Group
        {
            get { return group; }
            set { group = value; }
        }
    }
}
