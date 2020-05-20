using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;

namespace JSAT_BL
{
    public class GlobalBL
    {
        GlobalData globalData;

        public DataTable Get_Data(string tableName)
        {
            try
            {
                globalData = new GlobalData();
                return globalData.Get_Data(tableName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_DataOrderbyID(string tableName)
        {
            try
            {
                globalData = new GlobalData();
                return globalData.Get_DataOrderbyID(tableName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Getpresonalskill()
        {
            try
            {
                globalData = new GlobalData();
                return globalData.Getpersonalskill();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_Datanew(string tableName)
        {
            try
            {
                globalData = new GlobalData();
                return globalData.Get_Datanew(tableName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
