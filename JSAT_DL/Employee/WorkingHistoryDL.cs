using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
namespace JSAT_DL
{
    public class WorkingHistoryDL
    {
        public DataTable GetBindData(string code1, string code2)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetWorkingHistory", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@code1", code1);
                da.SelectCommand.Parameters.AddWithValue("@code2", code2);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BindDataForQualification()
        {
            
            SqlCommand myCommand = new SqlCommand("SP_QualificatTitle_Qualification", DataConfig.GetConnectionString());
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(myCommand);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }

        public DataSet BindDataForAbiltity()
        {

            SqlCommand myCommand = new SqlCommand("SP_AbilityTitle_Ability", DataConfig.GetConnectionString());
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(myCommand);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }

        public void InsertData(WorkingHistoryEntity entity, EnumBase.Save option, int careerid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_interviewDataInsert", DataConfig.GetConnectionString());
                cmd.CommandType = CommandType.StoredProcedure;
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Career_ID)))
                {
                    cmd.Parameters.AddWithValue("@id", entity.Career_ID);
                }

                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Career_code)))
                {
                    cmd.Parameters.AddWithValue("@careerCode", entity.Career_code);
                }

                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Name)))
                {
                    cmd.Parameters.AddWithValue("@name", entity.Name);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Age)))
                {
                    cmd.Parameters.AddWithValue("@age", entity.Age);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString((entity.Interviewdate))))
                {
                    cmd.Parameters.AddWithValue("@interviewdate", entity.Interviewdate);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Drivinglicense)))
                {
                    cmd.Parameters.AddWithValue("@drivinglicnese", entity.Drivinglicense);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Workingexperience)))
                {
                    cmd.Parameters.AddWithValue("@workingexperience", entity.Workingexperience);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Thilawa)))
                {
                    cmd.Parameters.AddWithValue("@thilawa", entity.Thilawa);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Hlaingtharyar)))
                {
                    cmd.Parameters.AddWithValue("@hlaingtharyar", entity.Hlaingtharyar);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Oversea)))
                {
                    cmd.Parameters.AddWithValue("@oversea", entity.Oversea);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Overseatraining)))
                {
                    cmd.Parameters.AddWithValue("@overseatraining", entity.Overseatraining);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Positionrequested)))
                {
                    cmd.Parameters.AddWithValue("@positionrequest", entity.Positionrequested);
                }

                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Positionrequested1)))
                {
                    cmd.Parameters.AddWithValue("@positionrequested1", entity.Positionrequested1);
                }

                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Positionrequested2)))
                {
                    cmd.Parameters.AddWithValue("@positionrequested2", entity.Positionrequested2);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.FirstInterviewer)))
                {
                    cmd.Parameters.AddWithValue("@FirstInterviewer", entity.FirstInterviewer);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.SecondInterviewer)))
                {
                    cmd.Parameters.AddWithValue("@SecondInterviewer", entity.SecondInterviewer);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Japanese_Interviewer)))
                {
                    cmd.Parameters.AddWithValue("@Japanese_Interviewer", entity.Japanese_Interviewer);
                }

                cmd.Parameters.AddWithValue("@expsalary", entity.Expectedsalary);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.SalarytypeID)))
                {
                    cmd.Parameters.AddWithValue("@salarytype", entity.SalarytypeID);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Locationrequested)))
                {
                    cmd.Parameters.AddWithValue("@location", entity.Locationrequested);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Worksatday)))
                {
                    cmd.Parameters.AddWithValue("@wokingonsatday", entity.Worksatday);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Desireddate)))
                {
                    cmd.Parameters.AddWithValue("@desireddate", entity.Desireddate);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Qualification)))
                {
                    cmd.Parameters.AddWithValue("@qualification", entity.Qualification);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Other)))
                {
                    cmd.Parameters.AddWithValue("@other", entity.Other);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.UpdateInfo)))
                {
                    cmd.Parameters.AddWithValue("@updateinfo", entity.UpdateInfo);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Engreadingwrite)))
                {
                    cmd.Parameters.AddWithValue("@engread", entity.Engreadingwrite);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Engspeaking)))
                {
                    cmd.Parameters.AddWithValue("@engspeaking", entity.Engspeaking);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Jpreadwrite)))
                {
                    cmd.Parameters.AddWithValue("@jpread", entity.Jpreadwrite);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Jpspeaking)))
                {
                    cmd.Parameters.AddWithValue("@jpspeaking", entity.Jpspeaking);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.TotalMarks)))
                {
                    cmd.Parameters.AddWithValue("@totalmarks", entity.TotalMarks);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Saturday_Condition1)))
                {
                    cmd.Parameters.AddWithValue("@satdaycondition", entity.Saturday_Condition1);
                }

                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Degree1)))
                {
                    cmd.Parameters.AddWithValue("@degree1", entity.Degree1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.University1)))
                {
                    cmd.Parameters.AddWithValue("@university1", entity.University1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Major1)))
                {
                    cmd.Parameters.AddWithValue("@major1", entity.Major1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Year1)))
                {
                    cmd.Parameters.AddWithValue("@year1", entity.Year1);
                }

                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Degree2)))
                {
                    cmd.Parameters.AddWithValue("@degree2", entity.Degree2);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.University2)))
                {
                    cmd.Parameters.AddWithValue("@university2", entity.University2);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Major2)))
                {
                    cmd.Parameters.AddWithValue("@major2", entity.Major2);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Year2)))
                {
                    cmd.Parameters.AddWithValue("@year2", entity.Year2);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Status1)))
                {
                    cmd.Parameters.AddWithValue("@status", entity.Status1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Notice_day)))
                {
                    cmd.Parameters.AddWithValue("@noticeday", entity.Notice_day);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Notice_type)))
                {
                    cmd.Parameters.AddWithValue("@noticetype", entity.Notice_type);
                }
                if (!string.IsNullOrWhiteSpace(Convert.ToString(entity.TownshipID1)))
                {
                    cmd.Parameters.AddWithValue("@township1", entity.TownshipID1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.TownshipID2)))
                {
                    cmd.Parameters.AddWithValue("@township2", entity.TownshipID2);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.SalaryID1)))
                {
                    cmd.Parameters.AddWithValue("@salaryid", entity.SalaryID1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.TotalMark1)))
                {
                    cmd.Parameters.AddWithValue("@totalmark", entity.TotalMark1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Positionlevel1)))
                {
                    cmd.Parameters.AddWithValue("@positionlevel1", entity.Positionlevel1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Positionlevel2)))
                {
                    cmd.Parameters.AddWithValue("@positionlevel2", entity.Positionlevel2);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Positionlevel3)))
                {
                    cmd.Parameters.AddWithValue("@positionlevel3", entity.Positionlevel3);
                }
                cmd.Parameters.AddWithValue("@createddate", DateTime.Now);
                cmd.Parameters.AddWithValue("@updateddate", DateTime.Now);
                cmd.Parameters.AddWithValue("@option", option);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean GetCheckboxlistData(Career_PCSkillsEntity cpe, int id, EnumBase.Save option)
        {
            SqlCommand cmddelete = new SqlCommand("SP_Career_PCSkills_Delete", DataConfig.GetConnectionString());
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("SP_PCSkill", DataConfig.GetConnectionString());
            try
            {
                int result;
                cmddelete.CommandType = CommandType.StoredProcedure;
                cmddelete.Parameters.AddWithValue("@Career_ID", cpe.CareerId);
                cmddelete.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmddelete.Connection.Open();
                cmddelete.ExecuteNonQuery();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmd.Parameters.Add("@PCSkill_ID", SqlDbType.Int, 10, "PCSkill_ID");
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.InsertCommand = cmd;
                da.Update(cpe.PcSkills);
                result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (result == 1 || result == 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public Boolean Getpersonalskill(Career_PersonalSkill cps, int id, EnumBase.Save option)
        {
            SqlCommand cmddeletepersonal = new SqlCommand("SP_DeletePersonal", DataConfig.GetConnectionString());
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("SP_Personalskill", DataConfig.GetConnectionString());
            try
            {
                int result1;
                if (option == EnumBase.Save.Update)
                {
                    cmddeletepersonal.CommandType = CommandType.StoredProcedure;
                    cmddeletepersonal.Parameters.AddWithValue("@Career_ID", cps.CareerId1);
                    cmddeletepersonal.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmddeletepersonal.Connection.Open();
                    cmddeletepersonal.ExecuteNonQuery();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmd.Parameters.Add("@PersonaSkill_ID", SqlDbType.Int, 10, "PersonaSkill_ID");
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.InsertCommand = cmd;
                da.Update(cps.Personal_skill);
                result1 = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (result1 == 1 || result1 == 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public Boolean InsertLocationrequest(Career_WorkingPlaceEntity cwpe, int id, EnumBase.Save option)
        {
            SqlCommand cmddeletelocation = new SqlCommand("SP_Career_WorkingPlace_Delete", DataConfig.GetConnectionString());
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("SP_Career_WorkingPlace_Insert", DataConfig.GetConnectionString());
            try
            {
                int result;
                cmddeletelocation.CommandType = CommandType.StoredProcedure;
                cmddeletelocation.Parameters.AddWithValue("@Career_ID", cwpe.CareerId);
                cmddeletelocation.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmddeletelocation.Connection.Open();
                cmddeletelocation.ExecuteNonQuery();
                cmd.CommandType = CommandType.StoredProcedure;         
                cmd.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmd.Parameters.Add("@WorkingPlace_ID", SqlDbType.Int, 10, "WorkingPlace_ID");
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.InsertCommand = cmd;
                da.Update(cwpe.WorkingPlace);
                result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (result == 1 || result == 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public WorkingHistoryEntity SelectedbyID(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_WorkingHistory_SelectedbyID", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id;
                DataTable dtb = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dtb);
                WorkingHistoryEntity entity = new WorkingHistoryEntity();
                if (dtb.Rows.Count > 0)
                {
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Career_ID"].ToString()))
                    {
                        entity.Career_ID = (int)dtb.Rows[0]["Career_ID"];
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Career_Code"].ToString()))
                    {
                        entity.Career_code = dtb.Rows[0]["Career_Code"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Name"].ToString()))
                    {
                        entity.Name = dtb.Rows[0]["Name"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Age"].ToString()))
                    {
                        entity.Age = (int)dtb.Rows[0]["Age"];
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Gender"].ToString()))
                    {
                        entity.Gender = (int)dtb.Rows[0]["Gender"];
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["FirstInterviewer"].ToString()))
                    {
                        entity.FirstInt = dtb.Rows[0]["FirstInterviewer"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["SecondInterviewer"].ToString()))
                    {
                        entity.SecondInt = dtb.Rows[0]["SecondInterviewer"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["JapaneseInterviewer"].ToString()))
                    {
                        entity.JapaneseInt = dtb.Rows[0]["JapaneseInterviewer"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Interview_Date"].ToString()))
                    {
                        entity.Interviewdate = DateTime.Parse(dtb.Rows[0]["Interview_Date"].ToString());
                    }
                    
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Driving_License"].ToString()))
                    {
                        entity.Drivinglicense = dtb.Rows[0]["Driving_License"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Address"].ToString()))
                    {
                        entity.Address = dtb.Rows[0]["Address"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Education"].ToString()))
                    {
                        entity.Education = dtb.Rows[0]["Education"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Working_Experience"].ToString()))
                    {
                        entity.Workingexperience = dtb.Rows[0]["Working_Experience"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["CareerStatus"].ToString()))
                    {
                        entity.Career_status = dtb.Rows[0]["CareerStatus"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Position"].ToString()))
                    {
                        entity.PositinName = dtb.Rows[0]["Position"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Career_Salary"].ToString()))
                    {
                        entity.Expectedsalary = Convert.ToInt32(dtb.Rows[0]["Career_Salary"].ToString());
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Career_Salary_Type"].ToString()))
                    {
                        entity.SalaryTypeName1 = dtb.Rows[0]["Career_Salary_Type"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Loaction"].ToString()))
                    {
                        entity.LocationName = dtb.Rows[0]["Loaction"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Working_On_Saturday"].ToString()))
                    {
                        entity.Worksatday = dtb.Rows[0]["Working_On_Saturday"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Desired_Date"].ToString()))
                    {
                        entity.Desireddate = DateTime.Parse(dtb.Rows[0]["Desired_Date"].ToString());
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Impression"].ToString()))
                    {
                        entity.Other = dtb.Rows[0]["Impression"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Updating_Info"].ToString()))
                    {
                        entity.UpdateInfo = dtb.Rows[0]["Updating_Info"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Engreadwrite"].ToString()))
                    {
                        entity.Ereadwrite = dtb.Rows[0]["Engreadwrite"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Engspeak"].ToString()))
                    {
                        entity.Espeaking = dtb.Rows[0]["Engspeak"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["JPreadwrite"].ToString()))
                    {
                        entity.Jreadwrite = dtb.Rows[0]["JPreadwrite"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["JPspeak"].ToString()))
                    {
                        entity.Jspeaking = dtb.Rows[0]["JPspeak"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Other_Qualification"].ToString()))
                    {
                        entity.Qualification = dtb.Rows[0]["Other_Qualification"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Total_Marks"].ToString()))
                    {
                        entity.TotalMarks = Convert.ToInt32(dtb.Rows[0]["Total_Marks"]);
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["satcondition"].ToString()))
                    {
                        entity.SatConditionName = dtb.Rows[0]["satcondition"].ToString(); ;
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Position1"].ToString()))
                    {
                        entity.PositionName1 = dtb.Rows[0]["Position1"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Position2"].ToString()))
                    {
                        entity.PositionName2 = dtb.Rows[0]["Position2"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Thilawa"].ToString()))
                    {
                        entity.Thilawa = Convert.ToInt32(dtb.Rows[0]["Thilawa"]);
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Hlaing_Thar_Yar"].ToString()))
                    {
                        entity.Hlaingtharyar = Convert.ToInt32(dtb.Rows[0]["Hlaing_Thar_Yar"]);
                    }
                    if(!String.IsNullOrWhiteSpace(dtb.Rows[0]["Oversea"].ToString()))
                    {
                        entity.Oversea=Convert.ToInt32(dtb.Rows[0]["Oversea"]);
                    }
                    if(!String.IsNullOrWhiteSpace(dtb.Rows[0]["Overseatraining"].ToString()))
                    {
                        entity.Overseatraining=Convert.ToInt32(dtb.Rows[0]["Overseatraining"]);
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Degree1"].ToString()))
                    {
                        entity.Degreename1 = dtb.Rows[0]["Degree1"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["University1"].ToString()))
                    {
                        entity.Universityname1 = dtb.Rows[0]["University1"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Major1"].ToString()))
                    {
                        entity.Majorname1 = dtb.Rows[0]["Major1"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Year1"].ToString()))
                    {
                        entity.Year1 = dtb.Rows[0]["Year1"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Degree2"].ToString()))
                    {
                        entity.Degreename2 = dtb.Rows[0]["Degree2"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["University2"].ToString()))
                    {
                        entity.Universityname2 = dtb.Rows[0]["University2"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Major2"].ToString()))
                    {
                        entity.Majorname2 = dtb.Rows[0]["Major2"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Year2"].ToString()))
                    {
                        entity.Year2 = dtb.Rows[0]["Year2"].ToString();
                    }
                    if(!String.IsNullOrWhiteSpace(dtb.Rows[0]["Notice_Day"].ToString()))
                    {
                        entity.Noticedayname = dtb.Rows[0]["Notice_Day"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Notice_Type"].ToString()))
                    {
                        entity.Noticetypename = dtb.Rows[0]["Notice_Type"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Instituation_Area1"].ToString()))
                    {
                        entity.Townshipname1 = dtb.Rows[0]["Instituation_Area1"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Instituation_Area2"].ToString()))
                    {
                        entity.Townshipname2 = dtb.Rows[0]["Instituation_Area2"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["positionlevel1"].ToString()))
                    {
                        entity.Positionlevelname1 = dtb.Rows[0]["positionlevel1"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["positionlevel2"].ToString()))
                    {
                        entity.Positionlevelname2 = dtb.Rows[0]["positionlevel2"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["positionlevel3"].ToString()))
                    {
                        entity.Positionlevelname3 = dtb.Rows[0]["positionlevel3"].ToString();
                    }
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da.SelectCommand.Connection.Close();
                da.SelectCommand.Connection.Dispose();
            }
        }

        public DataTable SelectedbyIDforpcskill(int Careerid)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_PcSkills_SelectByID", DataConfig.connectionString);
            da.SelectCommand.Parameters.AddWithValue("@Career_ID", Careerid);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtb = new DataTable();
            da.SelectCommand.Connection.Open();
            da.Fill(dtb);
            return dtb;
        }

        public DataTable SelectbyIDForLocation(int Careerid)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LocationRequested_SelectedbyID", DataConfig.connectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Career_ID", Careerid);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return (dtb);
        } 

        public DataTable SelectedbyIDforpersonalskill(int careerid)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Personalskill_SelectedbyID", DataConfig.connectionString);
            da.SelectCommand.Parameters.AddWithValue("@Career_ID", careerid);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtb = new DataTable();
            da.SelectCommand.Connection.Open();
            da.Fill(dtb);
            return dtb;
        }

        public DataTable SelectedbyOldjobhistory(int careerid)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_SelectOldJobHistoryNew", DataConfig.connectionString);
            da.SelectCommand.Parameters.AddWithValue("@Career_ID", careerid);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtb = new DataTable();
            da.SelectCommand.Connection.Open();
            da.Fill(dtb);
            return dtb;
        }

        public DataTable SelectedbyOldjobhistoryForDetail(int careerid)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_SelectOldJobHistory", DataConfig.connectionString);
            da.SelectCommand.Parameters.AddWithValue("@Career_ID", careerid);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtb = new DataTable();
            da.SelectCommand.Connection.Open();
            da.Fill(dtb);
            return dtb;
        }

        public DataTable SelectbyJobDescription(int careerid,string strjobd)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_SelectJobDescription", DataConfig.connectionString);
            da.SelectCommand.Parameters.AddWithValue("@Career_ID", careerid);
            da.SelectCommand.Parameters.AddWithValue("@jobd", strjobd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtb = new DataTable();
            da.SelectCommand.Connection.Open();
            da.Fill(dtb);
            return dtb;
        }

        public DataTable SelectedbyIDforlocation(int careerid)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Career_WorkingPlace_SelectByID", DataConfig.connectionString);
                da.SelectCommand.Parameters.AddWithValue("@Career_ID", careerid);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtb = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Selectforedit(int careerid)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_SelectDataForEdit", DataConfig.connectionString);
            da.SelectCommand.Parameters.AddWithValue("@careerid", careerid);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtb = new DataTable();
            da.SelectCommand.Connection.Open();
            da.Fill(dtb);
            return dtb;
        }

        public void loppinginsertoldjobhistory(WorkingHistoryEntity entity, EnumBase.Save option, DataTable dtb, int careerid)
        {
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                SqlCommand cmd1 = new SqlCommand("SP_InsertOldJobHistory", DataConfig.GetConnectionString());
                cmd1.CommandType = CommandType.StoredProcedure;
                if (!String.IsNullOrWhiteSpace(Convert.ToString(entity.Career_ID)))
                {
                    cmd1.Parameters.AddWithValue("@id", entity.Career_ID);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(dtb.Rows[i]["Company Name"])))
                {
                    cmd1.Parameters.AddWithValue("@companyname", dtb.Rows[i]["Company Name"]);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(dtb.Rows[i]["Company Address"])))
                {
                    cmd1.Parameters.AddWithValue("@companyaddress", dtb.Rows[i]["Company Address"]);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(dtb.Rows[i]["Industry Type"])))
                {
                    cmd1.Parameters.AddWithValue("@industrytype", dtb.Rows[i]["Industry Type"]);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(dtb.Rows[i]["Type of Business"])))
                {
                    cmd1.Parameters.AddWithValue("@typeofbusiness", dtb.Rows[i]["Type of Business"]);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(dtb.Rows[i]["Duration From"])))
                {
                    cmd1.Parameters.AddWithValue("@durationfrom", dtb.Rows[i]["Duration From"]);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(dtb.Rows[i]["Duration To"])))
                {
                    cmd1.Parameters.AddWithValue("@durationto", dtb.Rows[i]["Duration To"]);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(dtb.Rows[i]["Department"])))
                {
                    cmd1.Parameters.AddWithValue("@department", dtb.Rows[i]["Department"]);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(dtb.Rows[i]["Position"])))
                {
                    cmd1.Parameters.AddWithValue("@position", dtb.Rows[i]["Position"]);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(dtb.Rows[i]["Job Description"])))
                {
                    cmd1.Parameters.AddWithValue("@jobdescription", dtb.Rows[i]["Job Description"]);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(dtb.Rows[i]["Reason for leaving"])))
                {
                    cmd1.Parameters.AddWithValue("@reason", dtb.Rows[i]["Reason for leaving"]);
                }
                cmd1.Parameters.AddWithValue("@option", option);
                cmd1.Connection.Open();
                cmd1.ExecuteNonQuery();
                cmd1.Connection.Close();
            }
        }

        public bool DeleteWorkingHistroy(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_DeleteWorkingHistory";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int result = (int)cmd.Parameters["@result"].Value;
                if (result >= 1)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }
        
        public Boolean PCskillDelete(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_Career_PCSkills_Delete", DataConfig.GetConnectionString());
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Career_ID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int result = (int)cmd.Parameters["@result"].Value;
                if (result >= 1)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public Boolean PersonalSkillDelete(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_DeletePersonal", DataConfig.GetConnectionString());
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Career_ID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int result = (int)cmd.Parameters["@result"].Value;
                if (result >= 1)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public DataTable CheckCareerid(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Carrer_ID from Employee_Working_History where Carrer_ID=@id", DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dtcheck = new DataTable();
            da.Fill(dtcheck);
            return dtcheck;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize, out int totalrowcount)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_GridViewPaging", DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Search", search);
            da.SelectCommand.Parameters.AddWithValue("@Sort", sort);
            da.SelectCommand.Parameters.AddWithValue("@StartIndex", startIndex);
            da.SelectCommand.Parameters.AddWithValue("@PageSize", pagesize);
            DataSet ds = new DataSet();
            da.Fill(ds);
            totalrowcount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return ds.Tables[0];
        }

        public DataTable BindIndustry()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetIndustry", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtb = new DataTable();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BindPositionLevel()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetPositionLevel", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtb = new DataTable();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public DataTable SelectedByPosition(int pos_id)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_BindJobDescription", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@pos_id", pos_id);
                DataTable dtb = new DataTable();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectbyPosition(string positionid)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetMorePosition", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@positionid", positionid);
                DataTable dtb = new DataTable();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertOldJobHistory(DataTable dtnew, EnumBase.Save option, int id)
        {
            #region inserrjobhistory
            for (int i = 0; i < dtnew.Rows.Count; i++)
            {
                if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["companyname"])))//Check For Detail Data Companynaem iscan not be empty 
                {
                    SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                    SqlCommand cmd = new SqlCommand("SP_InsertOldJobHistory", DataConfig.GetConnectionString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["companyname"])))
                    {
                        cmd.Parameters.AddWithValue("@companyname", dtnew.Rows[i]["companyname"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["companyaddress"])))
                    {
                        cmd.Parameters.AddWithValue("@companyaddress", dtnew.Rows[i]["companyaddress"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["companytype"])))
                    {
                        cmd.Parameters.AddWithValue("@companytype", dtnew.Rows[i]["companytype"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["country"])))
                    {
                        cmd.Parameters.AddWithValue("@country", dtnew.Rows[i]["country"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["fromdate"])))
                    {
                        cmd.Parameters.AddWithValue("@durationfrom", dtnew.Rows[i]["fromdate"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["todate"])))
                    {
                        cmd.Parameters.AddWithValue("@durationto", dtnew.Rows[i]["todate"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["industry"])))
                    {
                        cmd.Parameters.AddWithValue("@industrytype", dtnew.Rows[i]["industry"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["business"])))
                    {
                        cmd.Parameters.AddWithValue("@typeofbusiness", dtnew.Rows[i]["business"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["deparment"])))
                    {
                        cmd.Parameters.AddWithValue("@department", dtnew.Rows[i]["deparment"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["position"])))
                    {
                        cmd.Parameters.AddWithValue("@position", dtnew.Rows[i]["position"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["jobdescripition"])))
                    {
                        cmd.Parameters.AddWithValue("@jobdescription", dtnew.Rows[i]["jobdescripition"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["reason"])))
                    {
                        cmd.Parameters.AddWithValue("@reason", dtnew.Rows[i]["reason"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["other"])))
                    {
                        cmd.Parameters.AddWithValue("@othernew", dtnew.Rows[i]["other"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["positionlevel"])))
                    {
                        cmd.Parameters.AddWithValue("@positionlevle", dtnew.Rows[i]["positionlevel"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["otherjp"])))
                    {
                        cmd.Parameters.AddWithValue("@otherjp", dtnew.Rows[i]["otherjp"]);
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dtnew.Rows[i]["reasonjp"])))
                    {
                        cmd.Parameters.AddWithValue("@reasonjp", dtnew.Rows[i]["reasonjp"]);
                    }
                    cmd.Parameters.AddWithValue("@option", option);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            #endregion
            }
        }

        public void Deleteforupdate(int careerid)
        {
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            SqlCommand cmdoldhistory = new SqlCommand("Delete from Old_Job_History where Career_ID=@careerid", connection);
            cmdoldhistory.CommandType = CommandType.Text;
            cmdoldhistory.Parameters.AddWithValue("@careerid", careerid);
            cmdoldhistory.Connection.Open();
            cmdoldhistory.ExecuteNonQuery();
            cmdoldhistory.Connection.Close();
        }
        
        public DataTable GetDegree()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetDegree", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtb = new DataTable();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Getlocationrequested(int type)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetLocationrequested", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType=CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@type", type);
                DataTable dtb=new DataTable();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectedbyUniversityID(int index)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_SelectedbyUniversityID", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@unviersityid", index);
                DataTable dtb = new DataTable();
                da.Fill(dtb);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
