using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using JSAT_DL;
using System.Transactions;

namespace JSAT_BL
{    

    public class ProfileBL
    {
        ProfileDL profile;
        EducationBL education;

        public ProfileBL()
        {
            profile = new ProfileDL();
        }

        public DataTable SelectAll()
        {
            return profile.SelectAll();
        }

        public ProfileEntity SelectByID(int id)
        {          
            return profile.SelectByID(id); 
        }

        public string Insert(ProfileEntity profileInfo,EducationEntity educationInfo)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (!Check_Record(profileInfo.Name))//if no record found ,
                {
                    if (profile.Insert(profileInfo))
                    {
                        //to insert education 
                        education = new EducationBL();
                        education.Insert(educationInfo.Education, profileInfo.ID);
                        scope.Complete();
                        return "Save success!";
                    }
                }
                else
                    return "Record already exists";
                return "Save fail!";
            }
        }

        public string Update(ProfileEntity profileInfo, EducationEntity educationInfo)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                    if (profile.Update(profileInfo))
                    {
                        //delete previous Education befroe updating.
                        education = new EducationBL();
                        education.Delete(profileInfo.ID);
                        education.Insert(educationInfo.Education, profileInfo.ID);
                        scope.Complete();
                        return "Update success!";
                    }
                    return "Update fail!";
            }
        }

        public string Delete(int profileID)
        {
            string result = string.Empty;
            if (profile.Delete(profileID))
            {
                education = new EducationBL();
                education.Delete(profileID);
                result = "Delete success!";
            }
            else
                result = "Delete fail!";
            return result;
        }

        public bool Check_Record(string name)
        {
           int count= profile.Check_ExistingName(name);
           if (count >= 1)
               return true;//records exist.
           else
               return false;
        }
    }
}
