using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JSAT_Common
{
    public class Employee_SelfEntry_Entity
    {
        private string name=string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime? dob = null;
        public DateTime? DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        private int address = 0;
        public int Address
        {
            get { return address; }
            set { address = value; }
        }

        private string detail_add = string.Empty;
        public string Detail_Add
        {
            get { return detail_add; }
            set { detail_add = value; }
        }

        private int age = 0;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private int religion = 0;
        public int Religion
        {
            get { return religion; }
            set { religion = value; }
        }

        private int education = 0;
        public int Education
        {
            get { return education; }
            set { education = value; }
        }

        private int major = 0;
        public int Major
        {
            get { return major; }
            set { major = value; }
        }

        private int institution = 0;
        public int Institution
        {
            get { return institution; }
            set { institution = value; }
        }

        private int condition = 0;
        public int Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        private int working_place_id = 0;
        public int Working_PlaceID
        {
            get { return working_place_id; }
            set { working_place_id = value; }
        }

        private int autocode = 0;
        public int AutoCode
        {
            get { return autocode; }
            set { autocode = value; }
        }

        private string phone = string.Empty;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string emergencycontantperson = String.Empty;
        public string Emergencycontantperson
        {
            get { return emergencycontantperson; }
            set { emergencycontantperson = value; }
        }

        private string emergencyphone = string.Empty;
        public string EmergencyPhone
        {
            get { return emergencyphone; }
            set { emergencyphone = value; }
        }

        private int degree = 0;
        public int Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string workplace = string.Empty;
        public string WorkPlace
        {
            get { return workplace; }
            set { workplace = value; }
        }

        private int gender = 0;
        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string workingPlace=string.Empty;
        public string WorkingPlace
        {
            get { return workingPlace; }
            set { workingPlace = value; }
        }

        private int careerId = 0;
        public int CareerId
        {
            get { return careerId; }
            set { careerId = value; }
        }

        private int day = 0;
        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        private int month = 0;
        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        private int year = 0;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private string photo_Data = string.Empty;
        public string Photo_Data
        {
            get { return photo_Data; }
            set { photo_Data = value; }
        }

        private DateTime currentdate;
        public DateTime Currentdate
        {
            get { return currentdate; }
            set { currentdate = value; }
        }
    }
}
