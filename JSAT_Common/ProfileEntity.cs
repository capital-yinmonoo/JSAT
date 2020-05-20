using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class ProfileEntity
    {
        //Properties
        private int id = 0;
        private string name = string.Empty;
        private int gender = 0;
        private string telephone_no = string.Empty;
        private string website = string.Empty;
        private string location = string.Empty;
        private int working_place = 0;
        private string education = string.Empty;
        private string comment = string.Empty;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Telephone_No
        {
            get { return telephone_no; }
            set { telephone_no = value; }
        }

        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public int Working_Place
        {
            get { return working_place; }
            set { working_place = value; }
        }

        public string Education
        {
            get { return education; }
            set { education = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
