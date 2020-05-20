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
    public class Career_ProfileBL
    {
        Career_ProfileDL careerProfile;
        Career_Profile_QuestionBL career_Profile_Question;
        Career_IQTestBL career_IQTestBL;

        public Career_ProfileBL()
        {
            careerProfile = new Career_ProfileDL();
        }

        public DataTable SelectAll()
        {
            return careerProfile.SelectAll();
        }

        public Career_ProfileEntity SelectByID(int id)
        {
            return careerProfile.SelectByID(id);
        }

        public string Insert(Career_ProfileEntity careerProfileInfo, Career_Profile_QuestionEntity careerProfileQuestionInfo, Career_IQTestEntity careerIQTestInfo, int Option)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (!Check_Record(careerProfileInfo.Career_Code, careerProfileInfo.ID))//if no record found ,
                {
                    if (careerProfile.Insert(careerProfileInfo, Option))
                    {
                        career_Profile_Question = new Career_Profile_QuestionBL();
                        career_Profile_Question.Insert(careerProfileQuestionInfo.Career_Profile_Question, careerProfileInfo.ID);
                        career_IQTestBL = new Career_IQTestBL();
                        career_IQTestBL.Insert(careerIQTestInfo.Career_IQTest, careerProfileInfo.ID);
                        scope.Complete();
                        return "Save success!";
                    }
                }
                else
                    return "Record already exists";
                return "Save fail!";
            }
        }

        public string Update(Career_ProfileEntity careerProfileInfo, Career_Profile_QuestionEntity careerProfileQuestionInfo, Career_IQTestEntity careerIQTestInfo, int Option)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (!Check_Record(careerProfileInfo.Career_Code, careerProfileInfo.ID))//if no record found ,
                {
                    if (careerProfile.Update(careerProfileInfo, Option))
                    {
                        career_Profile_Question = new Career_Profile_QuestionBL();
                        career_Profile_Question.Delete(careerProfileInfo.ID);
                        career_Profile_Question.Insert(careerProfileQuestionInfo.Career_Profile_Question, careerProfileInfo.ID);
                        career_IQTestBL = new Career_IQTestBL();
                        career_IQTestBL.Delete(careerProfileInfo.ID);
                        career_IQTestBL.Insert(careerIQTestInfo.Career_IQTest, careerProfileInfo.ID);
                        scope.Complete();
                        return "Save success!";
                    }
                }
                else
                    return "Record already exists";
                return "Save fail!";
            }
        }

        public string Delete(int ID)
        {
            string result = string.Empty;
            if (careerProfile.Delete(ID))
            {
                result = "Delete success!";
            }
            else
                result = "Delete fail!";
            return result;
        }

        public string DeleteAll()
        {
            string result = string.Empty;
            if (careerProfile.DeleteAll())
            {
                result = "Delete success!";
            }
            else
                result = "Delete fail!";
            return result;
        }

        public bool Check_Record(string code, int ID)
        {
            int count = careerProfile.Check_ExistingCode(code, ID);
            if (count >= 1)
                return true;//records exist.
            else
                return false;
        }

        public DataTable SelectByCriteria(string SearchValue)
        {
            return careerProfile.SelectByCriteria(SearchValue);
        }
    }
}
