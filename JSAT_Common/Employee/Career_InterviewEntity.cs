using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Career_InterviewEntity
    {
        private int id =0;
        private int career_ID =0;
        private int family_Persons =0;
        private int family_Income =0;
        private int location_ID =0;
        private int period =0;
        private string address = string.Empty;
        private string residential_Area = string.Empty;
        private string phone_No1 = string.Empty;
        private string phone_No2 = string.Empty;
        private string email = string.Empty;
        private string emergency_ContactNo = string.Empty;
        private string emergency_ContactName = string.Empty;
        private string family_Occupation = string.Empty;
        private string other_Place = string.Empty;
        private string other_Period = string.Empty;
        private string remarks = string.Empty;
        private bool job_Introduction = false;
        private bool apprentice_Accuracy = false;
        private bool working_Abroad = false;
        private string workingPlace = string.Empty;
        private int createdBy = 0;
        private int updatedBy = 0;
        private int deletedBy = 0;
        private DateTime createdDate = DateTime.Now;
        private DateTime updatedDate = DateTime.Now;
        private DateTime deletedDate = DateTime.Now;
        private int locationID2 = 0;
        private string relationship = string.Empty;

        public int LocationID2
        {
            get { return locationID2; }
            set { locationID2 = value; }
        }

        private int locationID3 = 0;
        public int LocationID3
        {
            get { return locationID3; }
            set { locationID3 = value; }
        }

        private int locationID4 = 0;
        public int LocationID4
        {
            get { return locationID4; }
            set { locationID4 = value; }
        }

        private String workingPlace2 = String.Empty;
        public String WorkingPlace2
        {
            get { return workingPlace2; }
            set { workingPlace2 = value; }
        }

        private String workingPlace3 = String.Empty;
        public String WorkingPlace3
        {
            get { return workingPlace3; }
            set { workingPlace3 = value; }
        }

        private String workingPlace4 = String.Empty;
        public String WorkingPlace4
        {
            get { return workingPlace4; }
            set { workingPlace4 = value; }
        }

        private String updater = String.Empty;
        public String Updater
        {
            get { return updater; }
            set { updater = value; }
        }

        private String updateTime = String.Empty;
        public String UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }

        public int ID
        {
            get { return id; }
            set {id =value; }
        }

        public int Career_ID
        {
            get { return career_ID; }
            set {career_ID =value; }
        }

        public int Family_Persons
        {
            get { return family_Persons; }
            set { family_Persons = value; }
        }

        public int Family_Income
        {
            get { return family_Income;}
            set { family_Income = value; }
        }

        public int Location_ID
        {
            get { return location_ID; }
            set { location_ID = value; }
        }

        public int Period
        {
            get { return period; }
            set { period = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Residential_Area
        {
            get { return residential_Area;}
            set { residential_Area = value; }
        }

        public string Phone_No1
        {
            get { return phone_No1;}
            set { phone_No1 = value; }
        }

        public string Phone_No2
        {
            get { return phone_No2; }
            set { phone_No2 = value; }
        }

        public string Emergency_ContactNo
        {
            get { return emergency_ContactNo; }
            set { emergency_ContactNo=value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Emergency_ContactName
        {
            get { return emergency_ContactName; }
            set { emergency_ContactName=value; }
        }

        public string Family_Occupation
        {
            get { return family_Occupation;}
            set { family_Occupation = value; }
        }

        public string Other_Place
        {
            get { return other_Place;}
            set { other_Place = value; }
        }

        public string Other_Period
        {
            get { return other_Period ;}
            set { other_Period = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks=value; }
        }

        public string WorkingPlace
        {
            get { return workingPlace; }
            set { workingPlace = value; }
        }

        public bool Job_Introduction
        {
            get { return job_Introduction; }
            set {job_Introduction =value; }
        }

         public bool Apprentice_Accuracy
        {
            get { return apprentice_Accuracy; }
            set { apprentice_Accuracy=value; }
        }

         public bool Working_Abroad
        {
            get { return working_Abroad;}
            set { working_Abroad = value; }
        }

         public int UpdatedBy
         {
             get { return updatedBy; }
             set { updatedBy = value; }
         }

         public int CreatedBy
         {
             get { return createdBy; }
             set { createdBy = value; }
         }

         public int DeletedBy
         {
             get { return deletedBy; }
             set { deletedBy = value; }
         }

         public DateTime CreatedDate
         {
             get { return createdDate; }
             set { createdDate = value; }
         }

         public DateTime UpdatedDate
         {
             get { return updatedDate; }
             set { updatedDate = value; }
         }

         public string Relationship 
         {
             get { return relationship; }
             set { relationship = value; }
         }
    }
}
