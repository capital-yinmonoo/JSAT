using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Client_RecruitmentEntity
    {
        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int clientId = 0;
        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

        private DateTime? subDate = null;
        public DateTime? SubDate
        {
            get { return subDate; }
            set { subDate = value; }
        }

        private int majorIndustryId = 0;
        public int MajorIndustryId
        {
            get { return majorIndustryId; }
            set { majorIndustryId = value; }
        }

        private int smallIndustryId = 0;
        public int SmallIndustryId
        {
            get { return smallIndustryId; }
            set { smallIndustryId = value; }
        }

        private String otherIndustry = String.Empty;
        public String OtherIndustry
        {
            get { return otherIndustry; }
            set { otherIndustry = value; }
        }

        private int postId = 0;
        public int PostId
        {
            get { return postId; }
            set { postId = value; }
        }

        private String otherPost = String.Empty;
        public string OtherPost
        {
            get { return otherPost; }
            set { otherPost = value; }
        }

        private int genderId = 0;
        public int GenderId
        {
            get { return genderId; }
            set { genderId = value; }
        }

        private int salaryFrom = 0;
        public int SalaryFrom
        {
            get { return salaryFrom; }
            set { salaryFrom = value; }
        }

        private int salaryTo = 0;
        public int SalaryTo
        {
            get { return salaryTo; }
            set { salaryTo = value; }
        }

        private int salaryformat = 0;
        public int Salary_Format
        {
            get { return salaryformat; }
            set { salaryformat = value; }
        }

        private int salaryTypeId = 0;
        public int SalaryTypeId
        {
            get { return salaryTypeId; }
            set { salaryTypeId = value; }
        }

        private int otherSalary = 0;
        public int OtherSalary
        {
            get { return otherSalary; }
            set { otherSalary = value; }
        }

        private int workingPlaceId = 0;
        public int WorkingPlaceId
        {
            get { return workingPlaceId; }
            set { workingPlaceId = value; }
        }

        private String otherWorkingPlace = String.Empty;
        public string OtherWorkingPlace
        {
            get { return otherWorkingPlace; }
            set { otherWorkingPlace = value; }
        }

        private int dayServiceId = 0;
        public int DayServiceId
        {
            get { return dayServiceId; }
            set { dayServiceId = value; }
        }

        private String starting = String.Empty;
        public string Starting
        {
            get { return starting; }
            set { starting = value; }
        }

        private string closing = String.Empty;
        public string Closing
        {
            get { return closing; }
            set { closing = value; }
        }

        private int languageId = 0;
        public int LanguageId
        {
            get { return languageId; }
            set { languageId = value; }
        }

        private int ageFrom = 0;
        public int AgeFrom
        {
            get { return ageFrom; }
            set { ageFrom = value; }
        }

        private int ageTo = 0;
        public int AgeTo
        {
            get { return ageTo; }
            set { ageTo = value; }
        }

        private int personInChargeId = 0;
        public int PersonInChargeId
        {
            get { return personInChargeId; }
            set { personInChargeId = value; }
        }

        private String personInCharge = String.Empty;
        public String PersonInCharge
        {
            get { return personInCharge; }
            set { personInCharge = value; }
        }

        private int personInChargeId1 = 0;
        public int PersonInChargeId1
        {
            get { return personInChargeId1; }
            set { personInChargeId1 = value; }
        }

        private String personInCharge1 = String.Empty;
        public String PersonInCharge1
        {
            get { return personInCharge1; }
            set { personInCharge1 = value; }
        }

        private int personInChargeId2 = 0;
        public int PersonInChargeId2
        {
            get { return personInChargeId2; }
            set { personInChargeId2 = value; }
        }

        private String personInCharge2 = String.Empty;
        public String PersonInCharge2
        {
            get { return personInCharge2; }
            set { personInCharge2 = value; }
        }
        private String department = String.Empty;
        public String Department
        {
            get { return department; }
            set { department = value; }
        }

        private String telephoneNo = String.Empty;
        public string TelePhoneNo
        {
            get { return telephoneNo; }
            set { telephoneNo = value; }

        }

        private String telephoneNo1 = String.Empty;
        public string TelePhoneNo1
        {
            get { return telephoneNo1; }
            set { telephoneNo1 = value; }

        }

        private String telephoneNo2 = String.Empty;
        public string TelePhoneNo2
        {
            get { return telephoneNo2; }
            set { telephoneNo2 = value; }

        }

        private String email = String.Empty;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private String email1 = String.Empty;
        public string Email1
        {
            get { return email1; }
            set { email1 = value; }
        }

        private String email2 = String.Empty;
        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }

        private int jobno = 0;

        public int Jobno
        {
            get { return jobno; }
            set { jobno = value; }
        }

        private String emailConfirm = String.Empty;
        public String EmailConfirm
        {
            get { return emailConfirm; }
            set { emailConfirm = value; }
        }

        private String emailConfirm1 = String.Empty;
        public String EmailConfirm1
        {
            get { return emailConfirm1; }
            set { emailConfirm1 = value; }
        }

        private String emailConfirm2 = String.Empty;
        public String EmailConfirm2
        {
            get { return emailConfirm2; }
            set { emailConfirm2 = value; }
        }

        private String remark = String.Empty;
        public String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private Boolean wanted = false;
        public Boolean Wanted
        {
            get { return wanted; }
            set { wanted = value; }
        }
        private Boolean asap1 = false;
        public Boolean ASAP1
        {
            get { return asap1; }
            set { asap1 = value; }
        }
        private Boolean asap2 = false;
        public Boolean ASAP2
        {
            get { return asap2; }
            set { asap2 = value; }
        }

        private int updatedBy = 0;
        public int UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        private int createdBy = 0;
        public int CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        private int deletedBy = 0;
        public int DeletedBy
        {
            get { return deletedBy; }
            set { deletedBy = value; }
        }

        private DateTime createdDate = DateTime.Now;
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        private DateTime updatedDate = DateTime.Now;
        public DateTime UpdatedDate
        {
            get { return updatedDate; }
            set { updatedDate = value; }
        }

        private DateTime deletedDate = DateTime.Now;
        public DateTime DeletedDate
        {
            get { return deletedDate; }
            set { deletedDate = value; }
        }

        private int englishRWid = 0;
        public int EnglishRWId
        {
            get { return englishRWid; }
            set { englishRWid = value; }
        }

        private int englishspeakID = 0;
        public int EnglishSpeakID
        {
            get { return englishspeakID; }
            set { englishspeakID = value; }
        }

        private int japanRWid = 0;
        public int JapanRWId
        {
            get { return japanRWid; }
            set { japanRWid = value; }
        }

        private int japanspeakID = 0;
        public int JapanSpeakID
        {
            get { return japanspeakID; }
            set { japanspeakID = value; }
        }
        private int myanmarRWid = 0;
        public int MyanmarRWId
        {
            get { return myanmarRWid; }
            set { myanmarRWid = value; }
        }

        private int myanmarspeakID = 0;
        public int MyanmarSpeakID
        {
            get { return myanmarspeakID; }
            set { myanmarspeakID = value; }
        }


        private int ToenglishRWID = 0;
        public int ToEnglishRWID
        {
            get { return ToenglishRWID; }
            set { ToenglishRWID = value; }
        }

        private int ToenglishspeakID = 0;
        public int ToEnglishspeakID
        {
            get { return ToenglishspeakID; }
            set { ToenglishspeakID = value; }
        }

        private int TojapanRWID = 0;
        public int ToJapanRWID
        {
            get { return TojapanRWID; }
            set { TojapanRWID = value; }
        }

        private int TojapanspeakID = 0;
        public int ToJapanspeakID
        {
            get { return TojapanspeakID; }
            set { TojapanspeakID = value; }

        }


        private int TomyanmarRWID = 0;
        public int ToMyanmarRWID
        {
            get { return TomyanmarRWID; }
            set { TomyanmarRWID = value; }
        }

        private int TomyanmarspeakID = 0;
        public int ToMyanmarspeakID
        {
            get { return TomyanmarspeakID; }
            set { TomyanmarspeakID = value; }
        }

        private DateTime? enterDate = null;
        public DateTime? EnterDate
        {
            get { return enterDate; }
            set { enterDate = value; }
        }

        private DateTime? interviewdate = null;
        public DateTime? InterviewDate
        {
            get { return interviewdate; }
            set { interviewdate = value; }
        }

        public struct SearchRecruitment
        {
            public String Name;
            public String ClientNo;
            public String RecruitmentNo;
            public String PersonInCharge;
            public String ContactPhoneNo;
            public String PositionID;
            public int? JpRW;
            public int? JpSpeaking;
            public int? EngRW;
            public int? EngSpeaking;
            public int? MnRW;
            public int? MnSpeaking;
            public int? JpRWcheck;
            public int? JpSpeakingcheck;
            public int? EngRWcheck;
            public int? EngSpeakingcheck;
            public int? MnRWcheck;
            public int? MnSpeakingcheck;
            public Boolean Wanted;
            public Boolean ASAP1;
            public Boolean ASAP2;
        }
    }
}
