using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_DL;
using JSAT_Common;

namespace JSAT_BL
{
    public class Interview_Question3BL
    {
        Interview_Question3_DL iq3dl;

        public Interview_Question3BL()
        {
            iq3dl = new Interview_Question3_DL();
        }

        public DataTable SelectAll()
        {
            return iq3dl.SelectAll();
        }

        public Interview_Question3_Entity SelectByID(int id)
        {
            return iq3dl.SelectByID(id);
        }

        public bool Insert(Interview_Question3_Entity QuestionTitle)
        {
            bool result = false;
            result = iq3dl.Insert(QuestionTitle);
            return result;
        }

        public bool Update(Interview_Question3_Entity QuestionTitle)
        {
            bool result = false;
            result = iq3dl.Update(QuestionTitle);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = iq3dl.Delete(id);
            return result;
        }

        public DataTable Search(int id, string str)
        {
            return iq3dl.Search(id, str);
        }

        public bool CheckExistingType(int titleid, string str, int id)
        {
            int count = iq3dl.CheckExistingType(titleid, str, id);
            if (count > 0)
                return true;
            else return false;
        }

        public DataTable SelectByTitleID(int question_id)
        {
            return iq3dl.SlectByQuestionID(question_id);
        }

        public DataTable SelectAllData()
        {
            return iq3dl.SelectAllData();
        }

        public DataTable GetByTitleID(int question_id)
        {
            return iq3dl.GetByTitleID(question_id);
        }

        public DataTable GetInterviwTitle(int bbid)
        {
            return iq3dl.GetInterviwTitle(bbid);
        }
    }
}


