using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Career_InformationEntity
    {
        private int id=0;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int career_ID=0;
        public int Career_ID
        {
            get { return career_ID; }
            set { career_ID = value; }
        }

        private string name=string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int genderid=0;
        public int GenderID
        {
            get { return genderid; }
            set { genderid = value; }
        }

        private string address=string.Empty;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string remark=string.Empty;
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private string idCard_Data=string.Empty;
        public string IDCard_Data
        {
            get { return idCard_Data; }
            set { idCard_Data = value; }
        }

        private string idCard_Data2 = string.Empty;
        public string IDCard_Data2
        {
            get { return idCard_Data2; }
            set { idCard_Data2 = value; }
        }

        private string idCard_Data3 = string.Empty;
        public string IDCard_Data3
        {
            get { return idCard_Data3; }
            set { idCard_Data3 = value; }
        }

        private string credential_Data=string.Empty;
        public string Credential_Data
        {
            get { return credential_Data; }
            set { credential_Data = value; }
        }

        private string credential_Data2 = string.Empty;
        public string Credential_Data2
        {
            get { return credential_Data2; }
            set { credential_Data2 = value; }
        }

        private string credential_Data3 = string.Empty;
        public string Credential_Data3
        {
            get { return credential_Data3; }
            set { credential_Data3 = value; }
        }

        private string credential_Data4 = string.Empty;
        public string Credential_Data4
        {
            get { return credential_Data4; }
            set { credential_Data4 = value; }
        }

        private string credential_Data5 = string.Empty;
        public string Credential_Data5
        {
            get { return credential_Data5; }
            set { credential_Data5 = value; }
        }

        private string credential_Data6= string.Empty;
        public string Credential_Data6
        {
            get { return credential_Data6; }
            set { credential_Data6 = value; }
        }

        private string credential_Data7 = string.Empty;
        public string Credential_Data7
        {
            get { return credential_Data7; }
            set { credential_Data7 = value; }
        }

        private string japanese_Data = string.Empty;
        public string Japanese_Data
        {
            get { return japanese_Data; }
            set { japanese_Data = value; }
        }

        private string japanese_Data2 = string.Empty;
        public string Japanese_Data2
        {
            get { return japanese_Data2; }
            set { japanese_Data2 = value; }
        }

        private string japanese_Data3 = string.Empty;
        public string Japanese_Data3
        {
            get { return japanese_Data3; }
            set { japanese_Data3 = value; }
        }

        private string graduation_Data = string.Empty;
        public string Graduation_Data
        {
            get { return graduation_Data; }
            set { graduation_Data = value; }
        }

        private string graduation_Data2 = string.Empty;
        public string Graduation_Data2
        {
            get { return graduation_Data2; }
            set { graduation_Data2 = value; }
        }

        private string graduation_Data3 = string.Empty;
        public string Graduation_Data3
        {
            get { return graduation_Data3; }
            set { graduation_Data3 = value; }
        }

        private string photo_Data = string.Empty;
        public string Photo_Data
        {
            get { return photo_Data; }
            set { photo_Data = value; }
        }

        private string photo_Data2 = string.Empty;
        public string Photo_Data2
        {
            get { return photo_Data2; }
            set { photo_Data2 = value; }
        }

        private string photo_Data3 = string.Empty;
        public string Photo_Data3
        {
            get { return photo_Data3; }
            set { photo_Data3 = value; }
        }

        private string datasheet_Data = string.Empty;
        public string Datasheet_Data
        {
            get { return datasheet_Data; }
            set { datasheet_Data = value; }
        }

        private string datasheet_Data2 = string.Empty;
        public string Datasheet_Data2
        {
            get { return datasheet_Data2; }
            set { datasheet_Data2 = value; }
        }

        private string datasheet_Data3 = string.Empty;
        public string Datasheet_Data3
        {
            get { return datasheet_Data3; }
            set { datasheet_Data3 = value; }
        }

        private string datasheet_Data4 = string.Empty;
        public string Datasheet_Data4
        {
            get { return datasheet_Data4; }
            set { datasheet_Data4 = value; }
        }

        private string datasheet_Data5 = string.Empty;
        public string Datasheet_Data5
        {
            get { return datasheet_Data5; }
            set { datasheet_Data5 = value; }
        }

        private string qualification_Data = string.Empty;
        public string Qualification_Data
        {
            get { return qualification_Data; }
            set { qualification_Data = value; }
        }

        private string qualification_Data2 = string.Empty;
        public string Qualification_Data2
        {
            get { return qualification_Data2; }
            set { qualification_Data2 = value; }
        }

        private string qualification_Data3 = string.Empty;
        public string Qualification_Data3
        {
            get { return qualification_Data3; }
            set { qualification_Data3 = value; }
        }

        private string labourCard_Data = string.Empty;
        public string LabourCard_Data
        {
            get { return labourCard_Data; }
            set { labourCard_Data = value; }
        }

        private string labourCard_Data2 = string.Empty;
        public string LabourCard_Data2
        {
            get { return labourCard_Data2; }
            set { labourCard_Data2 = value; }
        }

        private string labourCard_Data3 = string.Empty;
        public string LabourCard_Data3
        {
            get { return labourCard_Data3; }
            set { labourCard_Data3 = value; }
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

        private bool isDeleted = false;
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
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
    }
}
