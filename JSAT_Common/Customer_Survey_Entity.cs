using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Customer_Survey_Entity
    {
        public class Customer
        {
            private string id = string.Empty;
            public string ID
            {
                get { return id; }
                set { id = value; }
            }

            private string name = string.Empty;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string phone = string.Empty;
            public string PhoneNo
            {
                get { return phone; }
                set { phone = value; }
            }
           
        }
    }
}
