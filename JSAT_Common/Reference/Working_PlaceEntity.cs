using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Working_PlaceEntity
    {
        //Properties
        private int id = 0;
        private string city = string.Empty;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }
    }
}
