using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace JSAT_Common
{
    public class WorkingHistoryEntity
    {
        private String name = string.Empty;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age = 0;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private int gender = 0;
        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string address = string.Empty;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private int firstinterviewer = 0;
        public int FirstInterviewer
        {
            get { return firstinterviewer; }
            set { firstinterviewer = value; }
        }

        private int secondinterviewer = 0;
        public int SecondInterviewer
        {
            get { return secondinterviewer; }
            set { secondinterviewer = value; }
        }

        private int japanese_interviewer = 0;
        public int Japanese_Interviewer
        {
            get { return japanese_interviewer; }
            set { japanese_interviewer = value; }
        }


        private string firstint = string.Empty;
        public string FirstInt
        {
            get { return firstint; }
            set { firstint = value; }
        }

        private string secondint = string.Empty;
        public string SecondInt
        {
            get { return secondint; }
            set { secondint = value; }
        }


        private string japaneseInt = string.Empty;
        public string JapaneseInt
        {
            get { return japaneseInt; }
            set { japaneseInt = value; }
        }


        private string education = string.Empty;
        public string Education
        {
            get { return education; }
            set { education = value; }
        }

        private string career_status = string.Empty;
        public string Career_status
        {
            get { return career_status; }
            set { career_status = value; }
        }

        private int career_ID = 0;
        public int Career_ID
        {
            get { return career_ID; }
            set { career_ID = value; }
        }

        private int Status = 0;
        public int Status1
        {
            get { return Status; }
            set { Status = value; }
        }

        private string career_code = string.Empty;
        public string Career_code
        {
            get { return career_code; }
            set { career_code = value; }
        }

        private DateTime? interviewdate = null;
        public DateTime? Interviewdate
        {
            get { return interviewdate; }
            set { interviewdate = value; }
        }

        private string drivinglicense = string.Empty;
        public string Drivinglicense
        {
            get { return drivinglicense; }
            set { drivinglicense = value; }
        }

        private string workingexperience = string.Empty;
        public string Workingexperience
        {
            get { return workingexperience; }
            set { workingexperience = value; }
        }

        private string company_name = string.Empty;
        public string Company_name
        {
            get { return company_name; }
            set { company_name = value; }
        }

        private string companyaddress = string.Empty;
        public string Companyaddress
        {
            get { return companyaddress; }
            set { companyaddress = value; }
        }

        private int industryType_ID = 0;
        public int IndustryType_ID
        {
            get { return industryType_ID; }
            set { industryType_ID = value; }
        }

        private int business_type = 0;
        public int Business_type
        {
            get { return business_type; }
            set { business_type = value; }
        }

        private int department_ID = 0;
        public int Department_ID
        {
            get { return department_ID; }
            set { department_ID = value; }
        }

        private int position_id = 0;
        public int Position_id
        {
            get { return position_id; }
            set { position_id = value; }
        }

        private DateTime? duration_from = null;
        public DateTime? Duration_from
        {
            get { return duration_from; }
            set { duration_from = value; }
        }

        private DateTime? duration_to = null;
        public DateTime? Duration_to
        {
            get { return duration_to; }
            set { duration_to = value; }
        }

        private string jobdescription = string.Empty;
        public string Jobdescription
        {
            get { return jobdescription; }
            set { jobdescription = value; }
        }

        private string reasonforleaving = string.Empty;
        public string Reasonforleaving
        {
            get { return reasonforleaving; }
            set { reasonforleaving = value; }
        }

        private string othernew = string.Empty;
        public string Othernew
        {
            get { return othernew; }
            set { othernew = value; }
        }

        private int positionlevel = 0;
        public int Positionlevel
        {
            get { return positionlevel; }
            set { positionlevel = value; }
        }

        private int positionlevel1 = 0;
        public int Positionlevel1
        {
            get { return positionlevel1; }
            set { positionlevel1 = value; }
        }

        private int positionlevel2 = 0;
        public int Positionlevel2
        {
            get { return positionlevel2; }
            set { positionlevel2 = value; }
        }

        private int positionlevel3 = 0;
        public int Positionlevel3
        {
            get { return positionlevel3; }
            set { positionlevel3 = value; }
        }

        private string positionlevelname1 = string.Empty;
        public string Positionlevelname1
        {
            get { return positionlevelname1; }
            set { positionlevelname1 = value; }
        }

        private string positionlevelname2 = string.Empty;
        public string Positionlevelname2
        {
            get { return positionlevelname2; }
            set { positionlevelname2 = value; }
        }

        private string positionlevelname3 = string.Empty;
        public string Positionlevelname3
        {
            get { return positionlevelname3; }
            set { positionlevelname3 = value; }
        }

        private string companyname1 = string.Empty;
        public string Companyname1
        {
            get { return companyname1; }
            set { companyname1 = value; }
        }

        private string companyaddress1 = string.Empty;
        public string Companyaddress1
        {
            get { return companyaddress1; }
            set { companyaddress1 = value; }
        }

        private int company_type_ID = 0;
        public int Company_Type_ID
        {
            get { return company_type_ID; }
            set { company_type_ID = value; }
        }

        private int country_ID = 0;
        public int Country_ID
        {
            get { return country_ID; }
            set { country_ID = value; }
        }

        private int industryType_ID1 = 0;
        public int IndustryType_ID1
        {
            get { return industryType_ID1; }
            set { industryType_ID1 = value; }
        }

        private int Businesstype1 = 0;
        public int Businesstype11
        {
            get { return Businesstype1; }
            set { Businesstype1 = value; }
        }

        private DateTime? durationfrom1 = null;
        public DateTime? Durationfrom1
        {
            get { return durationfrom1; }
            set { durationfrom1 = value; }
        }

        private DateTime? durationto1 = null;
        public DateTime? Durationto1
        {
            get { return durationto1; }
            set { durationto1 = value; }
        }

        private int department_ID1 = 0;
        public int Department_ID1
        {
            get { return department_ID1; }
            set { department_ID1 = value; }
        }

        private int position_ID1 = 0;
        public int Position_ID1
        {
            get { return position_ID1; }
            set { position_ID1 = value; }
        }

        private int positon_id1 = 0;
        public int Positon_id1
        {
            get { return positon_id1; }
            set { positon_id1 = value; }
        }

        private string jobdescription1 = string.Empty;
        public string Jobdescription1
        {
            get { return jobdescription1; }
            set { jobdescription1 = value; }
        }

        private string reasonforleaving1 = string.Empty;
        public string Reasonforleaving1
        {
            get { return reasonforleaving1; }
            set { reasonforleaving1 = value; }
        }

        private int positionrequested = 0;
        public int Positionrequested
        {
            get { return positionrequested; }
            set { positionrequested = value; }
        }

        private int positionrequested1 = 0;
        public int Positionrequested1
        {
            get { return positionrequested1; }
            set { positionrequested1 = value; }
        }

        private int positionrequested2 = 0;
        public int Positionrequested2
        {
            get { return positionrequested2; }
            set { positionrequested2 = value; }
        }

        private int expectedsalary = 0;
        public int Expectedsalary
        {
            get { return expectedsalary; }
            set { expectedsalary = value; }
        }

        private int salarytypeID = 0;
        public int SalarytypeID
        {
            get { return salarytypeID; }
            set { salarytypeID = value; }
        }

        private int SalaryID = 0;
        public int SalaryID1
        {
            get { return SalaryID; }
            set { SalaryID = value; }
        }

        private int locationrequested = 0;
        public int Locationrequested
        {
            get { return locationrequested; }
            set { locationrequested = value; }
        }

        private string worksatday = string.Empty;
        public string Worksatday
        {
            get { return worksatday; }
            set { worksatday = value; }
        }

        private int Saturday_Condition = 0;
        public int Saturday_Condition1
        {
            get { return Saturday_Condition; }
            set { Saturday_Condition = value; }
        }

        private DateTime? desireddate = null;
        public DateTime? Desireddate
        {
            get { return desireddate; }
            set { desireddate = value; }
        }

        private int notice_type = 0;
        public int Notice_type
        {
            get { return notice_type; }
            set { notice_type = value; }
        }

        private int notice_day = 0;
        public int Notice_day
        {
            get { return notice_day; }
            set { notice_day = value; }
        }

        private int thilawa = 0;
        public int Thilawa
        {
            get { return thilawa; }
            set { thilawa = value; }
        }

        private int hlaingtharyar = 0;
        public int Hlaingtharyar
        {
            get { return hlaingtharyar; }
            set { hlaingtharyar = value; }
        }

        private int oversea = 0;
        public int Oversea
        {
            get { return oversea; }
            set { oversea = value; }
        }

        private int overseatraining = 0;
        public int Overseatraining
        {
            get { return overseatraining; }
            set { overseatraining = value; }
        }

        private string pcskill = string.Empty;
        public string Pcskill
        {
            get { return pcskill; }
            set { pcskill = value; }
        }

        private string qualification = string.Empty;
        public string Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }

        private string other = string.Empty;
        public string Other
        {
            get { return other; }
            set { other = value; }
        }

        private string updateinfo = string.Empty;
        public string UpdateInfo
        {
            get { return updateinfo; }
            set { updateinfo = value; }
        }

        private int immediate = 0;
        public int Immediate
        {
            get { return immediate; }
            set { immediate = value; }
        }

        private int engreadwrite = 0;
        public int Engreadingwrite
        {
            get { return engreadwrite; }
            set { engreadwrite = value; }
        }

        private int engspeaking = 0;
        public int Engspeaking
        {
            get { return engspeaking; }
            set { engspeaking = value; }
        }

        private int jpreadwrite = 0;
        public int Jpreadwrite
        {
            get { return jpreadwrite; }
            set { jpreadwrite = value; }
        }

        private int jpspeaking = 0;
        public int Jpspeaking
        {
            get { return jpspeaking; }
            set { jpspeaking = value; }
        }

        private int personalskill = 0;
        public int Personalskill
        {
            get { return personalskill; }
            set { personalskill = value; }
        }

        private string positinName = string.Empty;
        public string PositinName
        {
            get { return positinName; }
            set { positinName = value; }
        }

        private string positionName1 = string.Empty;
        public string PositionName1
        {
            get { return positionName1; }
            set { positionName1 = value; }
        }

        private string positionName2 = string.Empty;
        public string PositionName2
        {
            get { return positionName2; }
            set { positionName2 = value; }
        }

        private string locationName = string.Empty;
        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }

        private string SalaryTypeName = string.Empty;
        public string SalaryTypeName1
        {
            get { return SalaryTypeName; }
            set { SalaryTypeName = value; }
        }

        private string ereadwrite = string.Empty;
        public string Ereadwrite
        {
            get { return ereadwrite; }
            set { ereadwrite = value; }
        }

        private string espeaking = string.Empty;
        public string Espeaking
        {
            get { return espeaking; }
            set { espeaking = value; }
        }

        private string jreadwrite = string.Empty;
        public string Jreadwrite
        {
            get { return jreadwrite; }
            set { jreadwrite = value; }
        }

        private string jspeaking = string.Empty;
        public string Jspeaking
        {
            get { return jspeaking; }
            set { jspeaking = value; }
        }

        public struct Criterias
        {
            public string Career_Code;
            public string Name;
        };

        private int totalmarks = 0;
        public int TotalMarks
        {
            get { return totalmarks; }
            set { totalmarks = value; }
        }

        private String satConditionName = string.Empty;
        public String SatConditionName
        {
            get { return satConditionName; }
            set { satConditionName = value; }
        }

        private int degree1 = 0;
        public int Degree1
        {
            get { return degree1; }
            set { degree1 = value; }
        }

        private int university1 = 0;
        public int University1
        {
            get { return university1; }
            set { university1 = value; }
        }

        private int townshipID1 = 0;
        public int TownshipID1
        {
            get { return townshipID1; }
            set { townshipID1 = value; }
        }

        private int townshipID2 = 0;
        public int TownshipID2
        {
            get { return townshipID2; }
            set { townshipID2 = value; }
        }

        private int major1 = 0;
        public int Major1
        {
            get { return major1; }
            set { major1 = value; }
        }

        private string year1 = string.Empty;
        public string Year1
        {
            get { return year1; }
            set { year1 = value; }
        }

        private int degree2 = 0;
        public int Degree2
        {
            get { return degree2; }
            set { degree2 = value; }
        }

        private int university2 = 0;
        public int University2
        {
            get { return university2; }
            set { university2 = value; }
        }

        private int major2 = 0;
        public int Major2
        {
            get { return major2; }
            set { major2 = value; }
        }

        private string year2 = string.Empty;
        public string Year2
        {
            get { return year2; }
            set { year2 = value; }
        }

        private string degreename1 = string.Empty;
        public string Degreename1
        {
            get { return degreename1; }
            set { degreename1 = value; }
        }

        private string universityname1 = string.Empty;
        public string Universityname1
        {
            get { return universityname1; }
            set { universityname1 = value; }
        }

        private string townshipname1 = string.Empty;
        public string Townshipname1
        {
            get { return townshipname1; }
            set { townshipname1 = value; }
        }

        private string townshipname2 = string.Empty;
        public string Townshipname2
        {
            get { return townshipname2; }
            set { townshipname2 = value; }
        }

        private string majorname1 = string.Empty;
        public string Majorname1
        {
            get { return majorname1; }
            set { majorname1 = value; }
        }

        private string degreename2 = string.Empty;
        public string Degreename2
        {
            get { return degreename2; }
            set { degreename2 = value; }
        }

        private string universityname2 = string.Empty;
        public string Universityname2
        {
            get { return universityname2; }
            set { universityname2 = value; }
        }

        private string majorname2 = string.Empty;
        public string Majorname2
        {
            get { return majorname2; }
            set { majorname2 = value; }
        }

        private string noticedayname = string.Empty;
        public string Noticedayname
        {
            get { return noticedayname; }
            set { noticedayname = value; }
        }

        private string noticetypename = string.Empty;
        public string Noticetypename
        {
            get { return noticetypename; }
            set { noticetypename = value; }
        }

        private string Other_Japan = string.Empty;
        public string Other_Japan1
        {
            get { return Other_Japan; }
            set { Other_Japan = value; }
        }

        private string ReasonForLeaving_Japan = String.Empty;
        public string ReasonForLeaving_Japan1
        {
            get { return ReasonForLeaving_Japan; }
            set { ReasonForLeaving_Japan = value; }
        }

        private int TotalMark = 0;
        public int TotalMark1
        {
            get { return TotalMark; }
            set { TotalMark = value; }
        }
    }
}
