using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Career_ResumeEntity
    {
        private int id = 0;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string township1 = string.Empty;
        public string Township1
        {
            get { return Township1; }
            set { Township1 = value; }
        }

        private string ability = string.Empty;
        public string Ability
        {
            get { return Ability; }
            set { Ability = value; }
        }

        private int township = 0;
        public int Township
        {
            get { return township; }
            set { township = value; }
        }

        private int career_id = 0;
        public int Career_ID
        {
            get { return career_id; }
            set { career_id = value; }
        }

        private String career_code = String.Empty;
        public String Career_Code
        {
            get { return career_code; }
            set { career_code = value; }
        }

        private String career_code1 = String.Empty;
        public String Career_Code1
        {
            get { return career_code1; }
            set { career_code1 = value; }
        }

        private String career_code2 = string.Empty;
        public String Career_Code2
        {
            get { return career_code2; }
            set { career_code2 = value; }
        }

        private String career_oldcode = String.Empty;
        public String Career_Oldcode
        {
            get { return career_oldcode; }
            set { career_oldcode = value; }
        }

        private String name = String.Empty;
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

        private string other_japan = string.Empty;
        public string Other_japan
        {
            get { return other_japan; }
            set { other_japan = value; }
        }

        private string reasonleaving_japan = string.Empty;
        public string Reasonleaving_japan
        {
            get { return reasonleaving_japan; }
            set { reasonleaving_japan = value; }
        }

        private DateTime? dob = null;
        public DateTime? DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        private int genderID = 0;
        public int GenderID
        {
            get { return genderID; }
            set { genderID = value; }
        }

        private int religion_id = 0;
        public int Religion_ID
        {
            get { return religion_id; }
            set { religion_id = value; }
        }

        private String other_religion = String.Empty;
        public String Other_Religion
        {
            get { return other_religion; }
            set { other_religion = value; }
        }

        private int requested_division1_id = 0;
        public int Requested_Division1_ID
        {
            get { return requested_division1_id; }
            set { requested_division1_id = value; }
        }

        private int requested_position1_id = 0;
        public int Requested_Position1_ID
        {
            get { return requested_position1_id; }
            set { requested_position1_id = value; }
        }
        //ssw
        private int requested_positionlevel1_id = 0;
        public int Requested_PositionLevel1_ID
        {
            get { return requested_positionlevel1_id; }
            set { requested_positionlevel1_id = value; }
        }

        private int requested_division2_id = 0;
        public int Requested_Division2_ID
        {
            get { return requested_division2_id; }
            set { requested_division2_id = value; }
        }

        private int requested_position2_id = 0;
        public int Requested_Position2_ID
        {
            get { return requested_position2_id; }
            set { requested_position2_id = value; }
        }
        //ssw
        private int requested_positionlevel2_id = 0;
        public int Requested_PositionLevel2_ID
        {
            get { return requested_positionlevel2_id; }
            set { requested_positionlevel2_id = value; }
        }

        private int requested_division3_id = 0;
        public int Requested_Division3_ID
        {
            get { return requested_division3_id; }
            set { requested_division3_id = value; }
        }

        private int requested_position3_id = 0;
        public int Requested_Position3_ID
        {
            get { return requested_position3_id; }
            set { requested_position3_id = value; }
        }
        //ssw
        private int requested_positionlevel3_id = 0;
        public int Requested_PositionLevel3_ID
        {
            get { return requested_positionlevel3_id; }
            set { requested_positionlevel3_id = value; }
        }

        private int situationID = 0;
        public int SituationID
        {
            get { return situationID; }
            set { situationID = value; }
        }

        private int availability_id = 0;
        public int Availability_ID
        {
            get { return availability_id; }
            set { availability_id = value; }
        }

        private String other_availability = String.Empty;
        public String Other_Availability
        {
            get { return other_availability; }
            set { other_availability = value; }
        }

        private Boolean driver_license = false;
        public Boolean Driver_License
        {
            get { return driver_license; }
            set { driver_license = value; }
        }

        private string other_address = String.Empty;
        public string Other_Address
        {
            get { return other_address; }
            set { other_address = value; }
        }

        private int residential_areaID = 0;
        public int Residential_AreaID
        {
            get { return residential_areaID; }
            set { residential_areaID = value; }
        }

        private String occupation = String.Empty;
        public String Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        private String education = String.Empty;
        public String Education
        {
            get { return education; }
            set { education = value; }
        }

        private int education_id = 0;
        public int Education_ID
        {
            get { return education_id; }
            set { education_id = value; }
        }

        private String other_education = String.Empty;
        public String Other_Education
        {
            get { return other_education; }
            set { other_education = value; }
        }

        private int institutionArea_id = 0;
        public int InstitutionArea_ID
        {
            get { return institutionArea_id; }
            set { institutionArea_id = value; }
        }

        private int institutionArea_id2 = 0;
        public int InstitutionArea_ID2
        {
            get { return institutionArea_id2; }
            set { institutionArea_id2 = value; }
        }

        private int institutionName_id = 0;
        public int InstitutionName_ID
        {
            get { return institutionName_id; }
            set { institutionName_id = value; }
        }

        private int institutionName_id2 = 0;
        public int InstitutionName_ID2
        {
            get { return institutionName_id2; }
            set { institutionName_id2 = value; }
        }

        private String other_institution = String.Empty;
        public String Other_Institution
        {
            get { return other_institution; }
            set { other_institution = value; }
        }

        private int major_id = 0;
        public int Major_ID
        {
            get { return major_id; }
            set { major_id = value; }
        }

        private int major_id2 = 0;
        public int Major_ID2
        {
            get { return major_id2; }
            set { major_id2 = value; }
        }

        private int degree = 0;
        public int Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        private int degree2 = 0;
        public int Degree2
        {
            get { return degree2; }
            set { degree2 = value; }
        }

        private String other_major = String.Empty;
        public String Other_Major
        {
            get { return other_major; }
            set { other_major = value; }
        }

        private String graduation_date = null;
        public String Graduation_Date
        {
            get { return graduation_date; }
            set { graduation_date = value; }
        }

        private String major_reason;
        public String Major_Reason
        {
            get { return major_reason; }
            set { major_reason = value; }
        }

        private int job_objective_id = 0;
        public int Job_ObjectiveID
        {
            get { return job_objective_id; }
            set { job_objective_id = value; }
        }

        private int salary = 0;
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        private int salaryto = 0;
        public int Salaryto
        {
            get { return salaryto; }
            set { salaryto = value; }
        }

        private int salaryformat = 0;
        public int SalaryFormat
        {
            get { return salaryformat; }
            set { salaryformat = value; }
        }

        private int preferred_location_id = 0;
        public int Preferred_LocationID
        {
            get { return preferred_location_id; }
            set { preferred_location_id = value; }
        }

        private int apprentice_accuracy_id = 0;
        public int Apprentice_AccuracyID
        {
            get { return apprentice_accuracy_id; }
            set { apprentice_accuracy_id = value; }
        }

        private int working_place_id = 0;
        public int Working_PlaceID
        {
            get { return working_place_id; }
            set { working_place_id = value; }
        }

        private String other_workingPlace;
        public String Other_WorkingPlace
        {
            get { return other_workingPlace; }
            set { other_workingPlace = value; }
        }

        private String period = String.Empty;
        public String Period
        {
            get { return period; }
            set { period = value; }
        }

        private DateTime startDate = DateTime.Now.Date;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private int english_rw_level_id = 0;
        public int English_RW_LevelID
        {
            get { return english_rw_level_id; }
            set { english_rw_level_id = value; }
        }

        private int english_speaking_level_id = 0;
        public int English_Speaking_LevelID
        {
            get { return english_speaking_level_id; }
            set { english_speaking_level_id = value; }
        }

        private int japanese_rw_level_id = 0;
        public int Japanese_RW_LevelID
        {
            get { return japanese_rw_level_id; }
            set { japanese_rw_level_id = value; }
        }

        private int japanese_speaking_level_id = 0;
        public int Japanese_Speaking_LevelID
        {
            get { return japanese_speaking_level_id; }
            set { japanese_speaking_level_id = value; }
        }

        private int myanmar_rw_level_id = 0;
        public int Myanmar_RW_LevelID
        {
            get { return myanmar_rw_level_id; }
            set { myanmar_rw_level_id = value; }
        }

        private int myanmar_speaking_level_id = 0;
        public int Myanmar_Speaking_LevelID
        {
            get { return myanmar_speaking_level_id; }
            set { myanmar_speaking_level_id = value; }
        }

        private String other_qualification = String.Empty;
        public String Other_Qualification
        {
            get { return other_qualification; }
            set { other_qualification = value; }
        }

        private int pc_skillsID = 0;
        public int PC_SkillsID
        {
            get { return pc_skillsID; }
            set { pc_skillsID = value; }
        }

        private String other_PCskills = String.Empty;
        public String Other_PCskills
        {
            get { return other_PCskills; }
            set { other_PCskills = value; }
        }

        private String japanese_author_comments = String.Empty;
        public String Japanese_Author_Comments
        {
            get { return japanese_author_comments; }
            set { japanese_author_comments = value; }
        }

        private String myanmar_author_comments = String.Empty;
        public String Myanmar_Author_Comments
        {
            get { return myanmar_author_comments; }
            set { myanmar_author_comments = value; }
        }

        private Boolean isDeleted = false;
        public Boolean IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        private string genderName = string.Empty;
        public string GenderName
        {
            get { return genderName; }
            set { genderName = value; }
        }

        private string religionName = string.Empty;
        public string ReligionName
        {
            get { return religionName; }
            set { religionName = value; }
        }

        private string residentialAreaName = string.Empty;
        public string ResidentialAreaName
        {
            get { return residentialAreaName; }
            set { residentialAreaName = value; }
        }

        private string workingPlaceName = string.Empty;
        public string WorkingPlaceName
        {
            get { return workingPlaceName; }
            set { workingPlaceName = value; }
        }

        private string departmentName1 = string.Empty;
        public string DepartmentName1
        {
            get { return departmentName1; }
            set { departmentName1 = value; }
        }

        private string departmentName2 = string.Empty;
        public string DepartmentName2
        {
            get { return departmentName2; }
            set { departmentName2 = value; }
        }

        private string departmentName3 = string.Empty;
        public string DepartmentName3
        {
            get { return departmentName3; }
            set { departmentName3 = value; }
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

        private string positionName3 = string.Empty;
        public string PositionName3
        {
            get { return positionName3; }
            set { positionName3 = value; }
        }

        //ssw
        private string positionLevelName1 = string.Empty;
        public string PositionLevelName1
        {
            get { return positionLevelName1; }
            set { positionLevelName1 = value; }
        }

        private string positionLevelName2 = string.Empty;
        public string PositionLevelName2
        {
            get { return positionLevelName2; }
            set { positionLevelName2 = value; }
        }

        private string positionLevelName3 = string.Empty;
        public string PositionLevelName3
        {
            get { return positionLevelName3; }
            set { positionLevelName3 = value; }
        }

        private string situationName = string.Empty;
        public string SituationName
        {
            get { return situationName; }
            set { situationName = value; }
        }

        private string instituationAreaName = string.Empty;
        public string InstituationAreaName
        {
            get { return instituationAreaName; }
            set { instituationAreaName = value; }
        }

        private string instituationAreaName2 = string.Empty;
        public string InstituationAreaName2
        {
            get { return instituationAreaName2; }
            set { instituationAreaName2 = value; }
        }

        private string institutionName = string.Empty;
        public string InstitutionName
        {
            get { return institutionName; }
            set { institutionName = value; }
        }

        private string institutionName2 = string.Empty;
        public string InstitutionName2
        {
            get { return institutionName2; }
            set { institutionName2 = value; }
        }

        private string year = string.Empty;
        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        private string year2 = string.Empty;
        public string Year2
        {
            get { return year2; }
            set { year2 = value; }
        }

        private string yearname = string.Empty;
        public string YearName
        {
            get { return yearname; }
            set { yearname = value; }
        }

        private string yearname2 = string.Empty;
        public string YearName2
        {
            get { return yearname2; }
            set { yearname2 = value; }
        }

        private string majorName = string.Empty;
        public string MajorName
        {
            get { return majorName; }
            set { majorName = value; }
        }

        private string majorName2 = string.Empty;
        public string MajorName2
        {
            get { return majorName2; }
            set { majorName2 = value; }
        }

        private string degreeName = string.Empty;
        public string DegreeName
        {
            get { return degreeName; }
            set { degreeName = value; }
        }

        private string degreeName2 = string.Empty;
        public string DegreeName2
        {
            get { return degreeName2; }
            set { degreeName2 = value; }
        }

        private string pcSkillName = string.Empty;
        public string PCSkillName
        {
            get { return pcSkillName; }
            set { pcSkillName = value; }
        }

        private string languageEnglishRWLevel = string.Empty;
        public string LanguageEnglishRWLevel
        {
            get { return languageEnglishRWLevel; }
            set { languageEnglishRWLevel = value; }
        }

        private string languageEnglishSKLevel = string.Empty;
        public string LanguageEnglishSKLevel
        {
            get { return languageEnglishSKLevel; }
            set { languageEnglishSKLevel = value; }
        }

        private string languageJapaneseRWLevel = string.Empty;
        public string LanguageJapaneseRWLevel
        {
            get { return languageJapaneseRWLevel; }
            set { languageJapaneseRWLevel = value; }
        }

        private string languageJapaneseSKLevel = string.Empty;
        public string LanguageJapaneseSKLevel
        {
            get { return languageJapaneseSKLevel; }
            set { languageJapaneseSKLevel = value; }
        }

        private string languageMyanmarRWLevel = string.Empty;
        public string LanguageMyanmarRWLevel
        {
            get { return languageMyanmarRWLevel; }
            set { languageMyanmarRWLevel = value; }
        }

        private string languageMyanmarSKLevel = string.Empty;
        public string LanguageMyanmarSKLevel
        {
            get { return languageMyanmarSKLevel; }
            set { languageMyanmarSKLevel = value; }
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

        private string phone_No1 = string.Empty;
        public string Phone_No1
        {
            get { return phone_No1; }
            set { phone_No1 = value; }
        }

        private string phone_No2 = string.Empty;
        public string Phone_No2
        {
            get { return phone_No2; }
            set { phone_No2 = value; }
        }

        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string emergency_ContactNo = string.Empty;
        public string Emergency_ContactName
        {
            get { return emergency_ContactName; }
            set { emergency_ContactName = value; }
        }

        public string Emergency_ContactNo
        {
            get { return emergency_ContactNo; }
            set { emergency_ContactNo = value; }
        }

        private string Qualificaiton = string.Empty;
        public string qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }

        private string otherqualification = string.Empty;
        public string Otherqualification
        {
            get { return otherqualification; }
            set { otherqualification = value; }
        }

        private string emergency_ContactName = string.Empty;
        public struct Criterias
        {
            public string Career_Code;
            public string Career_Code1;
            public string Career_Code2;
            public string Name;
            public bool? JobIntro;
            public int? GenderID;
            public int? English_RW_LevelID;
            public int? English_Speaking_LevelID;
            public int? Japanese_RW_LevelID;
            public int? Japanese_Speaking_LevelID;
            public int? Myanmar_RW_LevelID;
            public int? Myanmar_Speaking_LevelID;
            public int? InstitutionName_ID;
            public int? MajorID;
            public int? PositionID;
            public int? DepartmentID;
            public string QualificationID;
            public int? JPRWcheck;
            public int? JPSpeakingcheck;
            public int? EngRWcheck;
            public int? EngSpeakingcheck;
            public int? MnRWcheck;
            public int? MnSpeakingcheck;
            public string Keyword;
            public int? Township;
            public string Township1;
            public string Ability;
            public int? Age;
            public int? ToAge;
            public int? Salary;
            public int? Salaryto;
            public int? SalaryType;
            public int? SalaryFormat;
            public int? department;
            public int? position;
            public int? typeofbusiness;
            public int? industry;
            public int? requested_position1_id;
            public int? positionlevel_id;
            public int? requested_position1level_id;
            public int? totalmark;
            public int? totalmark1;
            public int? totalcheck;
            public int? experiences;
            public int? experiencesto;
            public int? experiencescheck;
            public int? ExperienceType;
            public string experiencetype { get; set; }
        };

        private string careerstatus = string.Empty;
        public string Career_Status
        {
            get { return careerstatus; }
            set { careerstatus = value; }
        }

        private int requested_careerStatus_id = 0;
        public int Requested_CareerStatus_ID
        {
            get { return requested_careerStatus_id; }
            set { requested_careerStatus_id = value; }
        }

        private string impressionjp = string.Empty;
        public string Impressionjp
        {
            get { return impressionjp; }
            set { impressionjp = value; }
        }

        private string other = string.Empty;
        public string Other
        {
            get { return other; }
            set { other = value; }
        }

        private string impression = string.Empty;
        public string Impression
        {
            get { return impression; }
            set { impression = value; }
        }

        private string updatedinfo = string.Empty;
        public string UpdatedInfo
        {
            get { return updatedinfo; }
            set { updatedinfo = value; }
        }

        private string notice_Type = string.Empty;
        public string Notice_Type
        {
            get { return notice_Type; }
            set { notice_Type = value; }
        }

        private string notice_Day = string.Empty;
        public string Notice_Day
        {
            get { return notice_Day; }
            set { notice_Day = value; }
        }

        private int TotalMark = 0;
        public int TotalMark1
        {
            get { return TotalMark; }
            set { TotalMark = value; }
        }

        private int domestic = 0;
        public int Domestic
        {
            get { return domestic; }
            set { domestic = value; }
        }

        private int oversea = 0;
        public int Oversea
        {
            get { return oversea; }
            set { oversea = value; }
        }

        private string status = string.Empty;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
