using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Career_ProfileEntity
    {
        private int id;
        private string career_name = string.Empty;
        private string career_code = string.Empty;
        private int age = 0;
        private int genderid = 0;
        private string birth_place = string.Empty;
        private DateTime? dob = null;
        private int religionid = 0;
        private decimal expected_salary = 0;
        private int working_placeid = 0;
        private int positionid = 0;
        private DateTime? startdate = null;
        private string study_field = string.Empty;
        private string stong_weak_point = string.Empty;
        private string english = string.Empty;
        private string japanese = string.Empty;
        private string score = string.Empty;
        private bool isDeleted = false;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Career_Name
        {
            get { return career_name; }
            set { career_name = value; }
        }

        public string Career_Code
        {
            get { return career_code; }
            set { career_code = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int GenderID
        {
            get { return genderid; }
            set { genderid = value; }
        }

        public string Birth_Place
        {
            get { return birth_place; }
            set { birth_place = value; }
        }

        public DateTime? Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        public int ReligionID
        {
            get { return religionid; }
            set { religionid = value; }
        }

        public decimal Expected_Salary
        {
            get { return expected_salary; }
            set { expected_salary = value; }
        }

        public int Working_PlaceID
        {
            get { return working_placeid; }
            set { working_placeid = value; }
        }

        public int PositionID
        {
            get { return positionid; }
            set { positionid = value; }
        }

        public DateTime? StartDate
        {
            get { return startdate; }
            set { startdate = value; }
        }

        public string Study_Field
        {
            get { return study_field; }
            set { study_field = value; }
        }

        public string Strong_Weak_Point
        {
            get { return stong_weak_point; }
            set { stong_weak_point = value; }
        }

        public string English
        {
            get { return english; }
            set { english = value; }
        }

        public string Japanese
        {
            get { return japanese; }
            set { japanese = value; }
        }

        public string Score
        {
            get { return score; }
            set { score = value; }
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
