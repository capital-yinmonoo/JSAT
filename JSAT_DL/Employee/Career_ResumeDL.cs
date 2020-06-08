using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Career_ResumeDL
    {
        public Career_ResumeDL()
        {

        }

        public DataTable BindReligion()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Religion", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.SelectCommand.Dispose();
            }
        }

        public DataTable GetPDF(int Career_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Career_Information where Career_ID=@Career_ID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@Career_ID", Career_ID);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.SelectCommand.Dispose();
            }
        }

        public DataTable SelectByClientRecruitment(Career_ResumeEntity cre, int age1, int age2, int salary1, int salary2, int salaryformat)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Resume_SelectByClientRecruitment", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Japanese_RW_LevelID", cre.LanguageJapaneseRWLevel);
                da.SelectCommand.Parameters.AddWithValue("@Japanese_Speaking_LevelID", cre.LanguageJapaneseSKLevel);
                da.SelectCommand.Parameters.AddWithValue("@English_RW_LevelID", cre.LanguageEnglishRWLevel);
                da.SelectCommand.Parameters.AddWithValue("@English_Speaking_LevelID", cre.LanguageEnglishSKLevel);
                da.SelectCommand.Parameters.AddWithValue("@Myanmar_RW_LevelID", cre.LanguageMyanmarRWLevel);
                da.SelectCommand.Parameters.AddWithValue("@Myanmar_Speaking_LevelID", cre.LanguageMyanmarSKLevel);
                da.SelectCommand.Parameters.AddWithValue("@PositionID", cre.PositionName1);
                da.SelectCommand.Parameters.AddWithValue("@salary", salary1);
                da.SelectCommand.Parameters.AddWithValue("@salaryto", salary2);
                da.SelectCommand.Parameters.AddWithValue("@salaryformat", salaryformat);
                da.SelectCommand.Parameters.AddWithValue("@age1", age1);
                da.SelectCommand.Parameters.AddWithValue("@age2", age2);
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
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

        public DataTable SelectByCareerID(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Resume_SelectByCareerID", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Career_ID", id);
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
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

        public DataTable SearchAndPaging(string search, int exptype, string sort, int startIndex, int pagesize, out int totalrowcount)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Sample_Search_Paging", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@search", search);
                if (startIndex == 0)
                {
                    startIndex = 1;
                }
                else
                {
                    startIndex = (startIndex / 10) + 1;
                }
                da.SelectCommand.Parameters.AddWithValue("@experiencetype", exptype);
                da.SelectCommand.Parameters.AddWithValue("@StartIndex", startIndex);
                da.SelectCommand.Parameters.AddWithValue("@sort", sort);
                da.SelectCommand.Parameters.AddWithValue("@pagesize", pagesize);
                DataSet ds = new DataSet();
                da.SelectCommand.Connection.Open();
                da.Fill(ds);
                totalrowcount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                return ds.Tables[0];
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

        public DataTable SearchData(ref Career_ResumeEntity.Criterias Criteria, int pindex, int psize)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Search_Resume_Paging", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (!String.IsNullOrWhiteSpace(Criteria.Name))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Name", Criteria.Name);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Name", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(Criteria.Career_Code1))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Career_Code1", Criteria.Career_Code1);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Career_Code1", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(Criteria.Career_Code2))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Career_Code2", Criteria.Career_Code2);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Career_Code2", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.GenderID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@GenderID", Criteria.GenderID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@GenderID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.English_RW_LevelID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@English_RW_LevelID", Criteria.English_RW_LevelID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@English_RW_LevelID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.English_Speaking_LevelID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@English_Speaking_LevelID", Criteria.English_Speaking_LevelID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@English_Speaking_LevelID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Japanese_RW_LevelID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Japanese_RW_LevelID", Criteria.Japanese_RW_LevelID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Japanese_RW_LevelID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Japanese_Speaking_LevelID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Japanese_Speaking_LevelID", Criteria.Japanese_Speaking_LevelID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Japanese_Speaking_LevelID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.InstitutionName_ID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@InstitutionName_ID", Criteria.InstitutionName_ID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@InstitutionName_ID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.MajorID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@MajorID", Criteria.MajorID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@MajorID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.PositionID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@PositionID", Criteria.PositionID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@PositionID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.requested_position1_id)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@requested_position1_id", Criteria.requested_position1_id);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@requested_position1_id", -1);
                }
                //ssw
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.positionlevel_id)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@positionlevel_id", Criteria.positionlevel_id);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@positionlevel_id", -1);
                }
                //ssw
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.requested_position1level_id)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@requested_positionlevel_id", Criteria.requested_position1level_id);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@requested_positionlevel_id", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.QualificationID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@QualificationID", Criteria.QualificationID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@QualificationID", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Ability)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@ability", Criteria.Ability);
                }
                else
                {
                    da.SelectCommand.Parameters.Add("@ability", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.JPRWcheck)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@JPRWcheck", Criteria.JPRWcheck);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@JPRWcheck", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.JPSpeakingcheck)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@JPSpeakingcheck", Criteria.JPSpeakingcheck);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@JPSpeakingcheck", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.EngRWcheck)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@EngRWcheck", Criteria.EngRWcheck);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@EngRWcheck", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.EngSpeakingcheck)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@EngSpeakingcheck", Criteria.EngSpeakingcheck);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@EngSpeakingcheck", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.JobIntro)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@JobIntro", Criteria.JobIntro);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@JobIntro", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Township1)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Township", Criteria.Township1);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Township", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Age)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@age1", Criteria.Age);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@age1", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.ToAge)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@age2", Criteria.ToAge);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@age2", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.typeofbusiness)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@typeofbusiness", Criteria.typeofbusiness);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@typeofbusiness", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.position)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@position", Criteria.position);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@position", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Salary)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@salary", Criteria.Salary);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@salary", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Salaryto)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@salaryto", Criteria.Salaryto);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@salaryto", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.SalaryType)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@salarytype", Criteria.SalaryType);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@salarytype", -1);
                }

                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.SalaryFormat)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@salaryformat", Criteria.SalaryFormat);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@salaryformat", -1);
                }
                //ssw
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.experiences)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@experience", Criteria.experiences);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@experience", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.experiencesto)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@experienceto", Criteria.experiencesto);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@experienceto", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.ExperienceType)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@experiencetype", Criteria.ExperienceType);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@experiencetype", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.totalmark)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@mark", Criteria.totalmark);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@mark", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.totalmark1)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@mark1", Criteria.totalmark1);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@mark1", -1);
                }
                da.SelectCommand.Parameters.AddWithValue("@PageIndex", pindex);
                da.SelectCommand.Parameters.AddWithValue("@PageSize", psize);
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
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

        public DataTable SelectAll(int Option)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Resume_SelectAll", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Option", SqlDbType.Int).Value = Option;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
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

        public DataTable SelectCareerCode(int Option)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Resume_SelectAll", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Option", SqlDbType.Int).Value = Option;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
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

        public Career_ResumeEntity SelectByID(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Resume_SelectByID", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                Career_ResumeEntity careerResume = new Career_ResumeEntity();
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Career_ID"].ToString()))
                    {
                        careerResume.Career_ID = (int)dt.Rows[0]["Career_ID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Career_Code"].ToString()))
                    {
                        careerResume.Career_Code = dt.Rows[0]["Career_Code"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Name"].ToString()))
                    {
                        careerResume.Name = dt.Rows[0]["Name"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["DOB"].ToString()))
                    {
                        careerResume.DOB = DateTime.Parse(dt.Rows[0]["DOB"].ToString());
                    }
                    //added by nyisoe
                    if(!string.IsNullOrEmpty(dt.Rows[0]["Age"].ToString()))
                    {
                        careerResume.Age = (int)dt.Rows[0]["Age"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Career_OldCode"].ToString()))
                    {
                        careerResume.Career_Oldcode = dt.Rows[0]["Career_OldCode"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["GenderID"].ToString()))
                    {
                        careerResume.GenderID = (int)dt.Rows[0]["GenderID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CareerStatus"].ToString()))
                    {
                        careerResume.Career_Status = dt.Rows[0]["CareerStatus"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Religion_ID"].ToString()))
                    {
                        careerResume.Religion_ID = (int)dt.Rows[0]["Religion_ID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Other_Religion"].ToString()))
                    {
                        careerResume.Other_Religion = dt.Rows[0]["Other_Religion"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Requested_Division1_ID"].ToString()))
                    {
                        careerResume.Requested_Division1_ID = (int)dt.Rows[0]["Requested_Division1_ID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Requested_Position1_ID"].ToString()))
                    {
                        careerResume.Requested_Position1_ID = (int)dt.Rows[0]["Requested_Position1_ID"];
                    }
                    //ssw
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Requested_PositionLevel1_ID"].ToString()))
                    {
                        careerResume.Requested_PositionLevel1_ID = (int)dt.Rows[0]["Requested_PositionLevel1_ID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Requested_Division2_ID"].ToString()))
                    {
                        careerResume.Requested_Division2_ID = (int)dt.Rows[0]["Requested_Division2_ID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Requested_Position2_ID"].ToString()))
                    {
                        careerResume.Requested_Position2_ID = (int)dt.Rows[0]["Requested_Position2_ID"];
                    }
                    //ssw
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Requested_PositionLevel2_ID"].ToString()))
                    {
                        careerResume.Requested_PositionLevel2_ID = (int)dt.Rows[0]["Requested_PositionLevel2_ID"];
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["Requested_Division3_ID"].ToString()))
                    {
                        careerResume.Requested_Division3_ID = (int)dt.Rows[0]["Requested_Division3_ID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Requested_Position3_ID"].ToString()))
                    {
                        careerResume.Requested_Position3_ID = (int)dt.Rows[0]["Requested_Position3_ID"];
                    }
                    //ssw
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Requested_PositionLevel3_ID"].ToString()))
                    {
                        careerResume.Requested_PositionLevel3_ID = (int)dt.Rows[0]["Requested_PositionLevel3_ID"];
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["SituationID"].ToString()))
                    {
                        careerResume.SituationID = (int)dt.Rows[0]["SituationID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Availability_ID"].ToString()))
                    {
                        careerResume.Availability_ID = (int)dt.Rows[0]["Availability_ID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Other_Availability"].ToString()))
                    {
                        careerResume.Other_Availability = dt.Rows[0]["Other_Availability"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["Other_Address"].ToString()))
                    {
                        careerResume.Other_Address = dt.Rows[0]["Other_Address"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Residential_AreaID"].ToString()))
                    {
                        careerResume.Residential_AreaID = (int)dt.Rows[0]["Residential_AreaID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Education_ID"].ToString()))
                    {
                        careerResume.Education_ID = (int)dt.Rows[0]["Education_ID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Other_Education"].ToString()))
                    {
                        careerResume.Other_Education = dt.Rows[0]["Other_Education"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["InstitutionArea_ID"].ToString()))
                    {
                        careerResume.InstitutionArea_ID = (int)dt.Rows[0]["InstitutionArea_ID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["InstituationAreaName"].ToString()))
                    {
                        careerResume.InstituationAreaName = dt.Rows[0]["InstituationAreaName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["InstituationAreaName2"].ToString()))
                    {
                        careerResume.InstituationAreaName2 = dt.Rows[0]["InstituationAreaName2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["InstitutionName_ID"].ToString()))
                    {
                        careerResume.InstitutionName_ID = (int)dt.Rows[0]["InstitutionName_ID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["InstitutionName"].ToString()))
                    {
                        careerResume.InstitutionName = dt.Rows[0]["InstitutionName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["InstitutionName2"].ToString()))
                    {
                        careerResume.InstitutionName2 = dt.Rows[0]["InstitutionName2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Other_Institution"].ToString()))
                    {
                        careerResume.Other_Institution = dt.Rows[0]["Other_Institution"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Major_ID"].ToString()))
                    {
                        careerResume.Major_ID = (int)dt.Rows[0]["Major_ID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["MajorName"].ToString()))
                    {
                        careerResume.MajorName = dt.Rows[0]["MajorName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["MajorName2"].ToString()))
                    {
                        careerResume.MajorName2 = dt.Rows[0]["MajorName2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Degree"].ToString()))
                    {
                        careerResume.DegreeName = dt.Rows[0]["Degree"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Degree2"].ToString()))
                    {
                        careerResume.DegreeName2 = dt.Rows[0]["Degree2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Other_Major"].ToString()))
                    {
                        careerResume.Other_Major = dt.Rows[0]["Other_Major"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Graduation_Date"].ToString()))
                    {
                        careerResume.Graduation_Date = dt.Rows[0]["Graduation_Date"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Major_Reason"].ToString()))
                    {
                        careerResume.Major_Reason = dt.Rows[0]["Major_Reason"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Salary"].ToString()))
                    {
                        careerResume.Salary = (int)(dt.Rows[0]["Salary"]);
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Working_PlaceID"].ToString()))
                    {
                        careerResume.Working_PlaceID = (int)dt.Rows[0]["Working_PlaceID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Other_WorkingPlace"].ToString()))
                    {
                        careerResume.Other_WorkingPlace = dt.Rows[0]["Other_WorkingPlace"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["English_RW_LevelID"].ToString()))
                    {
                        careerResume.English_RW_LevelID = (int)dt.Rows[0]["English_RW_LevelID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["English_Speaking_LevelID"].ToString()))
                    {
                        careerResume.English_Speaking_LevelID = (int)dt.Rows[0]["English_Speaking_LevelID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Japanese_RW_LevelID"].ToString()))
                    {
                        careerResume.Japanese_RW_LevelID = (int)dt.Rows[0]["Japanese_RW_LevelID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Japanese_Speaking_LevelID"].ToString()))
                    {
                        careerResume.Japanese_Speaking_LevelID = (int)dt.Rows[0]["Japanese_Speaking_LevelID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Myanmar_RW_LevelID"].ToString()))
                    {
                        careerResume.Myanmar_RW_LevelID = (int)dt.Rows[0]["Myanmar_RW_LevelID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Myanmar_Speaking_LevelID"].ToString()))
                    {
                        careerResume.Myanmar_Speaking_LevelID = (int)dt.Rows[0]["Myanmar_Speaking_LevelID"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Other_Qualification"].ToString()))
                    {
                        careerResume.Other_Qualification = dt.Rows[0]["Other_Qualification"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["Other_PCskills"].ToString()))
                    {
                        careerResume.Other_PCskills = dt.Rows[0]["Other_PCskills"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["IsDeleted"].ToString()))
                    {
                        careerResume.IsDeleted = (bool)dt.Rows[0]["IsDeleted"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["GenderName"].ToString()))
                    {
                        careerResume.GenderName = dt.Rows[0]["GenderName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ReligionName"].ToString()))
                    {
                        careerResume.ReligionName = dt.Rows[0]["ReligionName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ResidentialAreaName"].ToString()))
                    {
                        careerResume.ResidentialAreaName = dt.Rows[0]["ResidentialAreaName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["WorkingPlaceName"].ToString()))
                    {
                        careerResume.WorkingPlaceName = dt.Rows[0]["WorkingPlaceName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["DepartmentName1"].ToString()))
                    {
                        careerResume.DepartmentName1 = dt.Rows[0]["DepartmentName1"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["DepartmentName2"].ToString()))
                    {
                        careerResume.DepartmentName2 = dt.Rows[0]["DepartmentName2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["DepartmentName3"].ToString()))
                    {
                        careerResume.DepartmentName3 = dt.Rows[0]["DepartmentName3"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PositionName1"].ToString()))
                    {
                        careerResume.PositionName1 = dt.Rows[0]["PositionName1"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PositionName2"].ToString()))
                    {
                        careerResume.PositionName2 = dt.Rows[0]["PositionName2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PositionName3"].ToString()))
                    {
                        careerResume.PositionName3 = dt.Rows[0]["PositionName3"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["PositionLevelName1"].ToString()))
                    {
                        careerResume.PositionLevelName1 = dt.Rows[0]["PositionLevelName1"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PositionLevelName2"].ToString()))
                    {
                        careerResume.PositionLevelName2 = dt.Rows[0]["PositionLevelName2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PositionLevelName3"].ToString()))
                    {
                        careerResume.PositionLevelName3 = dt.Rows[0]["PositionLevelName3"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["SituationName"].ToString()))
                    {
                        careerResume.SituationName = dt.Rows[0]["SituationName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PCSkillName"].ToString()))
                    {
                        careerResume.PCSkillName = dt.Rows[0]["PCSkillName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LanguageEnglishRWLevel"].ToString()))
                    {
                        careerResume.LanguageEnglishRWLevel = dt.Rows[0]["LanguageEnglishRWLevel"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LanguageEnglishSKLevel"].ToString()))
                    {
                        careerResume.LanguageEnglishSKLevel = dt.Rows[0]["LanguageEnglishSKLevel"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LanguageJapaneseRWLevel"].ToString()))
                    {
                        careerResume.LanguageJapaneseRWLevel = dt.Rows[0]["LanguageJapaneseRWLevel"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LanguageJapaneseSKLevel"].ToString()))
                    {
                        careerResume.LanguageJapaneseSKLevel = dt.Rows[0]["LanguageJapaneseSKLevel"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LanguageMyanmarRWLevel"].ToString()))
                    {
                        careerResume.LanguageMyanmarRWLevel = dt.Rows[0]["LanguageMyanmarRWLevel"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LanguageMyanmarSKLevel"].ToString()))
                    {
                        careerResume.LanguageMyanmarSKLevel = dt.Rows[0]["LanguageMyanmarSKLevel"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PhoneNo1"].ToString()))
                    {
                        careerResume.Phone_No1 = dt.Rows[0]["PhoneNo1"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Year1"].ToString()))
                    {
                        careerResume.YearName = dt.Rows[0]["Year1"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Year2"].ToString()))
                    {
                        careerResume.YearName2 = dt.Rows[0]["Year2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PhoneNo2"].ToString()))
                    {
                        careerResume.Phone_No2 = dt.Rows[0]["PhoneNo2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Email"].ToString()))
                    {
                        careerResume.Email = dt.Rows[0]["Email"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ContactNo"].ToString()))
                    {
                        careerResume.Emergency_ContactNo = dt.Rows[0]["ContactNo"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ContactName"].ToString()))
                    {
                        careerResume.Emergency_ContactName = dt.Rows[0]["ContactName"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["Impression"].ToString()))
                    {
                        careerResume.Impression = dt.Rows[0]["Impression"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Impression_Japan"].ToString()))
                    {
                        careerResume.Impressionjp = dt.Rows[0]["Impression_Japan"].ToString();
                    }
                    careerResume.UpdatedInfo = dt.Rows[0]["Updating_Info"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["NoticeType"].ToString()))
                    {
                        careerResume.Notice_Type = dt.Rows[0]["NoticeType"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Notice_Day"].ToString()))
                    {
                        careerResume.Notice_Day = dt.Rows[0]["Notice_Day"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["TotalMark"].ToString()))
                    {
                        careerResume.TotalMark1 = Convert.ToInt32(dt.Rows[0]["TotalMark"].ToString());
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Created_Date"].ToString()))
                    {
                        careerResume.CreatedDate = DateTime.Parse(dt.Rows[0]["Created_Date"].ToString());
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Update_Date"].ToString()))
                    {
                        careerResume.UpdatedDate = DateTime.Parse(dt.Rows[0]["Update_Date"].ToString());
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Domestic"].ToString()))
                    {
                        careerResume.Status = dt.Rows[0]["Domestic"].ToString();
                    }
                }
                return careerResume;
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

        public DataTable SelectByIDReport(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Resume_SelectByID_Report", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                string Location = string.Empty;
                string Position = string.Empty;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!Location.Contains(dt.Rows[i]["Location"].ToString()))
                        {
                            Location += dt.Rows[i]["Location"].ToString();
                            if (i != dt.Rows.Count - 1)
                            {
                                Location += " , \n";
                            }
                        }
                        if (!Position.Contains(dt.Rows[i]["Position"].ToString()))
                        {
                            Position += dt.Rows[i]["Position"].ToString();
                            if (i != dt.Rows.Count - 1)
                            {
                                Position += " ,  \n";
                            }
                        }
                        if (dt.Rows[i]["Availability_ID"].ToString() == "1")
                        {
                            dt.Rows[0]["Availability"] = "即日(Immediately)";
                        }
                        else if (dt.Rows[i]["Availability_ID"].ToString() == "2")
                        {
                            dt.Rows[0]["Availability"] = "要１ヶ月(One month notice)";
                        }
                        else if (dt.Rows[i]["Availability_ID"].ToString() == "3")
                        {
                            dt.Rows[0]["Availability"] = "その他(Others)";
                        }
                    }
                    dt.Rows[0]["Location"] = Location;
                    dt.Rows[0]["Position"] = Position;
                    dt.AcceptChanges();
                    DataTable dtClone = dt.Clone();
                    return dt;
                }
                else
                {
                    return dt;
                }
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

        public DataSet Report(int id)
        {
            SqlDataAdapter daPCSkill = new SqlDataAdapter("SP_Career_Resume_Report", DataConfig.connectionString);
            SqlDataAdapter daQualification = new SqlDataAdapter("SP_Career_Resume_Report", DataConfig.connectionString);
            SqlDataAdapter daCareerEmployment = new SqlDataAdapter("SP_Career_Resume_Report", DataConfig.connectionString);
            SqlDataAdapter daInterview_Question3 = new SqlDataAdapter("SP_Career_Resume_Report", DataConfig.connectionString);
            SqlDataAdapter daCareer_Interview3 = new SqlDataAdapter("SP_Career_Resume_Report", DataConfig.connectionString);
            SqlDataAdapter daLanguage_Level = new SqlDataAdapter("SP_Career_Resume_Report", DataConfig.connectionString);
            SqlDataAdapter daNotice_Type = new SqlDataAdapter("SP_Career_Resume_Report", DataConfig.connectionString);
            SqlDataAdapter daoldjobhistory = new SqlDataAdapter("SP_Career_Resume_Report", DataConfig.connectionString);
            SqlDataAdapter daAbility = new SqlDataAdapter("SP_Career_Resume_Report", DataConfig.connectionString);
            try
            {
                DataSet ds = new DataSet();                

                #region PC_Skill
                daPCSkill.SelectCommand.CommandType = CommandType.StoredProcedure;
                daPCSkill.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                daPCSkill.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = 1;
                DataTable dtPCSkill = new DataTable();
                daPCSkill.SelectCommand.Connection.Open();
                daPCSkill.Fill(dtPCSkill);
                #endregion

                #region Qualification
                daQualification.SelectCommand.CommandType = CommandType.StoredProcedure;
                daQualification.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                daQualification.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = 2;
                DataTable dtQualification = new DataTable();
                daQualification.SelectCommand.Connection.Open();
                daQualification.Fill(dtQualification);
                #endregion

                #region Career_Employment
                daCareerEmployment.SelectCommand.CommandType = CommandType.StoredProcedure;
                daCareerEmployment.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                daCareerEmployment.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = 3;
                DataTable dtCareerEmployment = new DataTable();
                daCareerEmployment.SelectCommand.Connection.Open();
                daCareerEmployment.Fill(dtCareerEmployment);
                DataTable dtClone = dtCareerEmployment.Clone();
                dtClone.Columns["Last_Salary"].DataType = typeof(string);
                foreach (DataRow dr in dtCareerEmployment.Rows)
                {
                    dtClone.ImportRow(dr);
                }
                for (int i = 0; i < dtClone.Rows.Count; i++)
                {
                    if (dtClone.Rows[i]["SalaryType"].ToString() != "")
                    {
                        string Last_Salary = dtClone.Rows[i]["Last_Salary"].ToString() + " " + dtClone.Rows[i]["SalaryType"].ToString();
                        dtClone.Rows[i]["Last_Salary"] = Last_Salary;
                    }
                }
                dtClone.AcceptChanges();
                #endregion

                #region Interview_Question3
                daInterview_Question3.SelectCommand.CommandType = CommandType.StoredProcedure;
                daInterview_Question3.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                daInterview_Question3.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = 4;
                DataTable dtInterview_Question3 = new DataTable();
                daInterview_Question3.SelectCommand.Connection.Open();
                daInterview_Question3.Fill(dtInterview_Question3);
                #endregion

                #region Career_Interview3
                daCareer_Interview3.SelectCommand.CommandType = CommandType.StoredProcedure;
                daCareer_Interview3.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                daCareer_Interview3.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = 5;
                DataTable dtCareer_Interview3 = new DataTable();
                daCareer_Interview3.SelectCommand.Connection.Open();
                daCareer_Interview3.Fill(dtCareer_Interview3);
                #endregion

                #region Language_Level
                daLanguage_Level.SelectCommand.CommandType = CommandType.StoredProcedure;
                daLanguage_Level.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                daLanguage_Level.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = 6;
                DataTable dtLanguageLevel = new DataTable();
                daLanguage_Level.SelectCommand.Connection.Open();
                daLanguage_Level.Fill(dtLanguageLevel);
                #endregion

                #region Notice_Type
                daNotice_Type.SelectCommand.CommandType = CommandType.StoredProcedure;
                daNotice_Type.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                daNotice_Type.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = 7;
                DataTable dtnotice_Type = new DataTable();
                daNotice_Type.SelectCommand.Connection.Open();
                daNotice_Type.Fill(dtnotice_Type);
                #endregion

                #region Old_Job_History
                daoldjobhistory.SelectCommand.CommandType = CommandType.StoredProcedure;
                daoldjobhistory.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                daoldjobhistory.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = 8;
                DataTable dtoldjobhistory = new DataTable();
                daoldjobhistory.SelectCommand.Connection.Open();
                daoldjobhistory.Fill(dtoldjobhistory);
                #endregion

                #region Ability
                daAbility.SelectCommand.CommandType = CommandType.StoredProcedure;
                daAbility.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                daAbility.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = 9;
                DataTable dtAbility = new DataTable();
                daAbility.SelectCommand.Connection.Open();
                daAbility.Fill(dtAbility);
                #endregion

                //#region Created_Updated_Date
                //daCareer_Condition.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daCareer_Condition.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                //daCareer_Condition.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = 9;
                //DataTable dtCareer_Condition = new DataTable();
                //daCareer_Condition.SelectCommand.Connection.Open();
                //daCareer_Condition.Fill(dtCareer_Condition);
                //#endregion

                string PCSkill = string.Empty;
                if (dtPCSkill.Rows.Count > 0)
                {
                    for (int i = 0; i < dtPCSkill.Rows.Count; i++)
                    {
                        PCSkill += dtPCSkill.Rows[i]["PC_Skill"].ToString();
                        if (i != dtPCSkill.Rows.Count - 1)
                        {
                            PCSkill += " , ";
                        }
                    }
                    dtPCSkill.Rows[0]["PC_Skill"] = PCSkill;
                    dtPCSkill.AcceptChanges();
                }
                //string Qualification = string.Empty;
                //if (dtQualification.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dtQualification.Rows.Count; i++)
                //    {
                //        Qualification += dtQualification.Rows[i]["Qualification"].ToString();
                //        if (i != dtQualification.Rows.Count - 1)
                //        {
                //            Qualification += " , \n";
                //        }
                //    }
                //    dtQualification.Rows[0]["Qualification"] = Qualification;
                //    dtQualification.AcceptChanges();
                //}
                dtoldjobhistory.Columns.Add("Job_Description", typeof(string));
                DataTable dtjobdescripition = new DataTable();
                for (int j = 0; j < dtoldjobhistory.Rows.Count; j++)
                {
                    string strjobd = string.Empty;
                    strjobd = dtoldjobhistory.Rows[j]["Job_Description_ID"].ToString();
                    dtjobdescripition = WorkingHistroyForJobDescritpion(id, strjobd);
                    string concatjobd = string.Empty;
                    for (int i = 0; i < dtjobdescripition.Rows.Count; i++)
                    {
                        concatjobd += dtjobdescripition.Rows[i]["Description"].ToString();
                        if (i != dtjobdescripition.Rows.Count - 1)
                        {
                            concatjobd += ",";
                        }
                    }
                    dtoldjobhistory.Rows[j]["Job_Description"] = concatjobd.ToString();
                }
                dtPCSkill.TableName = "dtPCSkill";
                dtQualification.TableName = "dtQualification";
                dtClone.TableName = "dtCareerEmployment";
                dtInterview_Question3.TableName = "dtInterview_Question3";
                dtCareer_Interview3.TableName = "dtCareer_Interview3";
                dtLanguageLevel.TableName = "dtLanguageLevel";
                dtnotice_Type.TableName = "dtNotice_Type";
                dtoldjobhistory.TableName = "dtOld_Job_History";
                dtAbility.TableName = "dtAbility";
                ds.Tables.Add(dtPCSkill);
                ds.Tables.Add(dtQualification);
                ds.Tables.Add(dtClone);
                ds.Tables.Add(dtInterview_Question3);
                ds.Tables.Add(dtCareer_Interview3);
                ds.Tables.Add(dtLanguageLevel);
                ds.Tables.Add(dtnotice_Type);
                ds.Tables.Add(dtoldjobhistory);
                ds.Tables.Add(dtAbility);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                daPCSkill.SelectCommand.Connection.Close();
                daQualification.SelectCommand.Connection.Close();
                daCareerEmployment.SelectCommand.Connection.Close();
                daInterview_Question3.SelectCommand.Connection.Close();
                daCareer_Interview3.SelectCommand.Connection.Close();
                daNotice_Type.SelectCommand.Connection.Close();
                daPCSkill.Dispose();
                daQualification.Dispose();
                daCareerEmployment.Dispose();
                daInterview_Question3.Dispose();
                daCareer_Interview3.Dispose();
                daNotice_Type.Dispose();
                daoldjobhistory.Dispose();
            }
        }

        public DataTable SelectQualificationByCareerID(int CareerID)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Resume_SelectQualificationByCareerID", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Career_ID", SqlDbType.Int).Value = CareerID;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
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

        public Career_ResumeEntity SelectByCareerCode(string Career_Code)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Resume_SelectByCareerCode", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Career_Code", SqlDbType.NVarChar).Value = Career_Code;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                Career_ResumeEntity careerResume = new Career_ResumeEntity();
                if (dt != null)
                {
                    careerResume.Career_ID = (int)dt.Rows[0]["Career_ID"];
                }
                return careerResume;
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

        public int Insert_Update(Career_ResumeEntity cie, EnumBase.Save option)
        {

            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            SqlCommand cmdInsert = new SqlCommand("SP_Career_Resume_Update", connection);
            try
            {
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@ID", cie.ID);
                cmdInsert.Parameters.AddWithValue("@Career_Code", cie.Career_Code);
                cmdInsert.Parameters.AddWithValue("@Name", cie.Name);
                cmdInsert.Parameters.AddWithValue("@Age", cie.Age);
                cmdInsert.Parameters.AddWithValue("@DOB", cie.DOB);
                cmdInsert.Parameters.AddWithValue("@GDate", cie.Graduation_Date);
                cmdInsert.Parameters.AddWithValue("@OldCode", cie.Career_Oldcode);
                cmdInsert.Parameters.AddWithValue("@GenderID", cie.GenderID);
                cmdInsert.Parameters.AddWithValue("@Religion_ID", cie.Religion_ID);
                cmdInsert.Parameters.AddWithValue("@Phone_No1", cie.Phone_No1);
                cmdInsert.Parameters.AddWithValue("@Phone_No2", cie.Phone_No2);
                cmdInsert.Parameters.AddWithValue("@Email", cie.Email);
                cmdInsert.Parameters.AddWithValue("@Emergency_ContactNo", cie.Emergency_ContactNo);
                cmdInsert.Parameters.AddWithValue("@Emergency_ContactName ", cie.Emergency_ContactName);
                cmdInsert.Parameters.AddWithValue("@Residential_AreaID", cie.Residential_AreaID);
                cmdInsert.Parameters.AddWithValue("@Salary", cie.Salary);
                cmdInsert.Parameters.AddWithValue("@Working_PlaceID", cie.Working_PlaceID);
                cmdInsert.Parameters.AddWithValue("@Requested_Division1_ID", cie.Requested_Division1_ID);
                cmdInsert.Parameters.AddWithValue("@Requested_Position1_ID", cie.Requested_Position1_ID);
                cmdInsert.Parameters.AddWithValue("@Requested_PositionLevel1_ID", cie.Requested_PositionLevel1_ID);
                cmdInsert.Parameters.AddWithValue("@Requested_Division2_ID", cie.Requested_Division2_ID);
                cmdInsert.Parameters.AddWithValue("@Requested_Position2_ID", cie.Requested_Position2_ID);
                cmdInsert.Parameters.AddWithValue("@Requested_PositionLevel2_ID", cie.Requested_PositionLevel2_ID);
                cmdInsert.Parameters.AddWithValue("@Requested_Division3_ID", cie.Requested_Division3_ID);
                cmdInsert.Parameters.AddWithValue("@Requested_Position3_ID", cie.Requested_Position3_ID);
                cmdInsert.Parameters.AddWithValue("@Requested_PositionLevel3_ID", cie.Requested_PositionLevel3_ID);
                cmdInsert.Parameters.AddWithValue("@SituationID", cie.SituationID);
                cmdInsert.Parameters.AddWithValue("@Education_ID", cie.Education_ID);
                cmdInsert.Parameters.AddWithValue("@InstitutionArea_ID", cie.InstitutionArea_ID);
                cmdInsert.Parameters.AddWithValue("@InstitutionArea_ID2", cie.InstitutionArea_ID2);
                cmdInsert.Parameters.AddWithValue("@InstitutionName_ID", cie.InstitutionName_ID);
                cmdInsert.Parameters.AddWithValue("@InstitutionName_ID2", cie.InstitutionName_ID2);
                cmdInsert.Parameters.AddWithValue("@Other_Institution", cie.Other_Institution);
                cmdInsert.Parameters.AddWithValue("@Major_ID", cie.Major_ID);
                cmdInsert.Parameters.AddWithValue("@Major_ID2", cie.Major_ID2);
                cmdInsert.Parameters.AddWithValue("@Degree", cie.Degree);
                cmdInsert.Parameters.AddWithValue("@Degree2", cie.Degree2);
                cmdInsert.Parameters.AddWithValue("@Year", cie.Year);
                cmdInsert.Parameters.AddWithValue("@Year2", cie.Year2);
                cmdInsert.Parameters.AddWithValue("@Other_Major", cie.Other_Major);
                cmdInsert.Parameters.AddWithValue("@English_RW_LevelID", cie.English_RW_LevelID);
                cmdInsert.Parameters.AddWithValue("@English_Speaking_LevelID", cie.English_Speaking_LevelID);
                cmdInsert.Parameters.AddWithValue("@Japanese_RW_LevelID", cie.Japanese_RW_LevelID);
                cmdInsert.Parameters.AddWithValue("@Japanese_Speaking_LevelID", cie.Japanese_Speaking_LevelID);
                cmdInsert.Parameters.AddWithValue("@Myanmar_RW_LevelID", cie.Myanmar_RW_LevelID);
                cmdInsert.Parameters.AddWithValue("@Myanmar_Speaking_LevelID", cie.Myanmar_Speaking_LevelID);
                cmdInsert.Parameters.AddWithValue("@impression", cie.Impressionjp);
                cmdInsert.Parameters.AddWithValue("@Domestic", cie.Domestic);
                cmdInsert.Parameters.AddWithValue("@Oversea", cie.Oversea);
                cmdInsert.Parameters.AddWithValue("@CreatedBy", cie.CreatedBy);
                cmdInsert.Parameters.AddWithValue("@CreatedDate", cie.CreatedDate);
                cmdInsert.Parameters.AddWithValue("@UpdatedBy", cie.UpdatedBy);
                cmdInsert.Parameters.AddWithValue("@UpdatedDate", cie.UpdatedDate);
                cmdInsert.Parameters.AddWithValue("@Option", option);
                cmdInsert.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.InsertCommand = cmdInsert;
                cmdInsert.Connection.Open();
                cmdInsert.ExecuteNonQuery();
                int result = 0;
                if (cmdInsert.Parameters["@result"].Value != DBNull.Value)
                    result = BaseLib.Convert_Int(cmdInsert.Parameters["@result"].Value.ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmdInsert.Connection.Close();
                cmdInsert.Dispose();
            }
        }

        public int Check_ExistingCode(string careerCode, int ID)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_Career_Resume_Check_ExistCode";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Carrer_Code", careerCode);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count;
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

        public bool Delete(int id, int sessionID, DateTime date)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_Career_Resume_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@SessionID", sessionID);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int result = (int)cmd.Parameters["@result"].Value;
                if (result >= 1) return true;
                else
                    return false;
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

        public bool DeleteAll()
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_Career_Resume_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", 1); // For returning @result from database stored procedure.
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1) return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }

        public DataTable SelectByCriteria(ref Career_ResumeEntity.Criterias Criteria)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Resume_SearchSample", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (!String.IsNullOrWhiteSpace(Criteria.Name))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Name", Criteria.Name);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Name", DBNull.Value);
                }
                if (!String.Equals(Criteria.Career_Code, "-"))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Career_Code", Criteria.Career_Code);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Career_Code", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.GenderID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@GenderID", Criteria.GenderID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@GenderID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.English_RW_LevelID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@English_RW_LevelID", Criteria.English_RW_LevelID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@English_RW_LevelID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.English_Speaking_LevelID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@English_Speaking_LevelID", Criteria.English_Speaking_LevelID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@English_Speaking_LevelID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Japanese_RW_LevelID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Japanese_RW_LevelID", Criteria.Japanese_RW_LevelID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Japanese_RW_LevelID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Japanese_Speaking_LevelID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Japanese_Speaking_LevelID", Criteria.Japanese_Speaking_LevelID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Japanese_Speaking_LevelID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Myanmar_RW_LevelID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Myanmar_RW_LevelID", Criteria.Myanmar_RW_LevelID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Myanmar_RW_LevelID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Myanmar_Speaking_LevelID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Myanmar_Speaking_LevelID", Criteria.Myanmar_Speaking_LevelID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Myanmar_Speaking_LevelID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.InstitutionName_ID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@InstitutionName_ID", Criteria.InstitutionName_ID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@InstitutionName_ID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.MajorID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@MajorID", Criteria.MajorID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@MajorID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.PositionID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@PositionID", Criteria.PositionID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@PositionID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.DepartmentID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@DepartmentID", Criteria.DepartmentID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@DepartmentID", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.QualificationID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@QualificationID", Criteria.QualificationID);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@QualificationID", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.JPRWcheck)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@JPRWcheck", Criteria.JPRWcheck);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@JPRWcheck", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.JPSpeakingcheck)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@JPSpeakingcheck", Criteria.JPSpeakingcheck);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@JPSpeakingcheck", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.EngRWcheck)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@EngRWcheck", Criteria.EngRWcheck);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@EngRWcheck", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.EngSpeakingcheck)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@EngSpeakingcheck", Criteria.EngSpeakingcheck);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@EngSpeakingcheck", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.MnRWcheck)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@MnRWcheck", Criteria.MnRWcheck);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@MnRWcheck", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.MnSpeakingcheck)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@MnSpeakingcheck", Criteria.MnSpeakingcheck);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@MnSpeakingcheck", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.JobIntro)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@JobIntro", Criteria.JobIntro);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@JobIntro", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Township1)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Township", Criteria.Township1);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Township", 0);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Age)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@age1", Criteria.Age);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@age1", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.ToAge)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@age2", Criteria.ToAge);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@age2", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Keyword)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Keyword", Criteria.Keyword);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Keyword", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Salary)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@salary", Criteria.Salary);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@salary", -1);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Criteria.Salaryto)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@salaryto", Criteria.Salaryto);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@salaryto", -1);
                }
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
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

        public DataTable SearchByName(String Name, String Code1, String Code)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                SqlCommand cmdSelect = new SqlCommand("SP_Career_SearchByName", connection);
                cmdSelect.Parameters.AddWithValue("@Name", Name);
                cmdSelect.Parameters.AddWithValue("@Career_Code1", Code1);
                cmdSelect.Parameters.AddWithValue("@Career_Code", Code);
                da.SelectCommand = cmdSelect;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
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

        public int InsertCareerInterview(int cid, string ph1, string ph2, string email, string emno, string emname)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);

            SqlCommand cmdInsert = new SqlCommand("SP_Career_Resume_Public_Insert", connection);
            try
            {
                int resultid = 0;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@ID", 1);
                cmdInsert.Parameters.AddWithValue("@CareerID", cid);
                cmdInsert.Parameters.AddWithValue("@ph1", ph1);
                cmdInsert.Parameters.AddWithValue("@ph2", ph2);
                cmdInsert.Parameters.AddWithValue("@email", email);
                cmdInsert.Parameters.AddWithValue("@EM_Phno", emno);
                cmdInsert.Parameters.AddWithValue("@EM_Name", emname);
                cmdInsert.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.InsertCommand = cmdInsert;
                cmdInsert.Connection.Open();
                cmdInsert.ExecuteNonQuery();
                if (cmdInsert.Parameters["@result"].Value != DBNull.Value)
                    resultid = Convert.ToInt32(cmdInsert.Parameters["@result"].Value);
                return resultid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmdInsert.Connection.Close();
                cmdInsert.Dispose();
            }
        }

        public DataTable SelectTownship()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SP_Township_Search", DataConfig.connectionString);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAbilityTitle()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SP_Ability_SelectByID", DataConfig.connectionString);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet AbilitySelect()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter("SP_Ability_Title", DataConfig.connectionString);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.Fill(ds);
                sda.SelectCommand.Connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public DataTable GetAbility()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SP_Ability", DataConfig.connectionString);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectbyBusinessType()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SP_BusinessTypeSearch", DataConfig.connectionString);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectedbyIndustry()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SP_GetIndustry", DataConfig.connectionString);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByInterview(int cid)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Resume_Public_SelectbyID", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Career_ID", cid);
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
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

        public void Insert_Career_Status(int cid, int careerstatusid)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            SqlCommand cmdInsert = new SqlCommand("SP_Career_Status_Update", connection);
            try
            {
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@ID", cid);
                cmdInsert.Parameters.AddWithValue("@CareerStatusID", careerstatusid);
                cmdInsert.Connection.Open();
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmdInsert.Connection.Close();
                cmdInsert.Dispose();
            }
        }

        public void Insert_Update_Salary(DataTable dtnew, EnumBase.Save option, int id)
        {
            int result;
            if (option == EnumBase.Save.Update)
            {
                SqlCommand cmd = new SqlCommand("SP_Delete_Salary", DataConfig.GetConnectionString());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@careerid", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            for (int i = 0; i < dtnew.Rows.Count; i++)
            {
                SqlDataAdapter daSalary = new SqlDataAdapter();
                SqlCommand cmdSalary = new SqlCommand("SP_Insert_Update_Salary", DataConfig.GetConnectionString());
                cmdSalary.CommandType = CommandType.StoredProcedure;
                cmdSalary.Parameters.AddWithValue("@careerid", id);
                if (!String.IsNullOrWhiteSpace(dtnew.Rows[i]["Salary"].ToString()))
                {
                    cmdSalary.Parameters.AddWithValue("@salary", Convert.ToInt32(dtnew.Rows[i]["Salary"]));
                }
                if (!String.IsNullOrWhiteSpace(dtnew.Rows[i]["Salarytype1"].ToString()))
                {
                    cmdSalary.Parameters.AddWithValue("@salarytype1", dtnew.Rows[i]["Salarytype1"]);
                }
                if (!string.IsNullOrWhiteSpace(dtnew.Rows[i]["SalaryFormat"].ToString())) ;
                {
                    cmdSalary.Parameters.AddWithValue("@salaryformat", dtnew.Rows[i]["SalaryFormat"]);
                }
                if (!String.IsNullOrWhiteSpace(dtnew.Rows[i]["SelectSalary"].ToString()))
                {
                    cmdSalary.Parameters.AddWithValue("@selectedsalary", Convert.ToBoolean(dtnew.Rows[i]["SelectSalary"]));
                }
                cmdSalary.Parameters.AddWithValue("@option", option);
                cmdSalary.Connection.Open();
                cmdSalary.ExecuteNonQuery();
                cmdSalary.Connection.Close();
            }
        }

        public DataTable SelectBySalary_CareerID(int careerid)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                SqlCommand cmdSelect = new SqlCommand("SelectBy_SalaryCareerID", connection);
                cmdSelect.Parameters.AddWithValue("@careerid", careerid);
                da.SelectCommand = cmdSelect;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectedbySalaryIDdetail(int careerid)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                SqlCommand cmdSelect = new SqlCommand("SelectedbySalaryIDDetail", connection);
                cmdSelect.Parameters.AddWithValue("@careerid", careerid);
                da.SelectCommand = cmdSelect;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectedByWorkingHistoryForCareer_Resume(int careerid)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_SelectOldJobHistoryFForCareer_Resume", DataConfig.connectionString);
            da.SelectCommand.Parameters.AddWithValue("@Career_ID", careerid);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtb = new DataTable();
            da.SelectCommand.Connection.Open();
            da.Fill(dtb);
            return dtb;
        }

        public void Insert_Update_WorkingHistory(DataTable dttext, int id)
        {
            try
            {
                DeleteForWorkingHistory(id);
                for (int i = 0; i < dttext.Rows.Count; i++)
                {
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["companyname"])))//Check For Detail Data Companynaem iscan not be empty 
                    {
                        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                        SqlCommand cmd = new SqlCommand("SP_Insert_Update_WorkingHistory", DataConfig.GetConnectionString());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@careerid", id);
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["companyname"])))
                        {
                            cmd.Parameters.AddWithValue("@companyname", dttext.Rows[i]["companyname"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["companyaddress"])))
                        {
                            cmd.Parameters.AddWithValue("@companyaddress", dttext.Rows[i]["companyaddress"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["fromdate"])))
                        {
                            cmd.Parameters.AddWithValue("@durationfrom", dttext.Rows[i]["fromdate"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["todate"])))
                        {
                            cmd.Parameters.AddWithValue("@durationto", dttext.Rows[i]["todate"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["industry"])))
                        {
                            cmd.Parameters.AddWithValue("@industrytype", dttext.Rows[i]["industry"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["business"])))
                        {
                            cmd.Parameters.AddWithValue("@typeofbusiness", dttext.Rows[i]["business"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["deparment"])))
                        {
                            cmd.Parameters.AddWithValue("@department", dttext.Rows[i]["deparment"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["position"])))
                        {
                            cmd.Parameters.AddWithValue("@position", dttext.Rows[i]["position"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["positionlevel"])))
                        {
                            cmd.Parameters.AddWithValue("@positionlevel", dttext.Rows[i]["positionlevel"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["jobdescripition"])))
                        {
                            cmd.Parameters.AddWithValue("@jobdescription", dttext.Rows[i]["jobdescripition"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["reasoneng"])))
                        {
                            cmd.Parameters.AddWithValue("@reason", dttext.Rows[i]["reasoneng"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["othereng"])))
                        {
                            cmd.Parameters.AddWithValue("@othernew", dttext.Rows[i]["othereng"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["otherjp"])))
                        {
                            cmd.Parameters.AddWithValue("@otherjp", dttext.Rows[i]["otherjp"]);
                        }
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(dttext.Rows[i]["reasonjp"])))
                        {
                            cmd.Parameters.AddWithValue("@reasonjp", dttext.Rows[i]["reasonjp"]);
                        }
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteForWorkingHistory(int id)
        {
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            SqlCommand cmdoldhistory = new SqlCommand("Delete from Old_Job_History where Career_ID=@careerid", connection);
            cmdoldhistory.CommandType = CommandType.Text;
            cmdoldhistory.Parameters.AddWithValue("@careerid", id);
            cmdoldhistory.Connection.Open();
            cmdoldhistory.ExecuteNonQuery();
            cmdoldhistory.Connection.Close();
        }

        public DataTable WorkingHistroyForJobDescritpion(int id, string strjobd)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_SelectJobDescription", DataConfig.connectionString);
            da.SelectCommand.Parameters.AddWithValue("@Career_ID", id);
            da.SelectCommand.Parameters.AddWithValue("@jobd", strjobd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtb = new DataTable();
            da.SelectCommand.Connection.Open();
            da.Fill(dtb);
            return dtb;
        }

        public DataTable GetImpressionData(string impression)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetImpressionData", DataConfig.connectionString);
                da.SelectCommand.Parameters.AddWithValue("@impression", impression);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch
            {
                return dt;
            }
        }

        public DataTable GetOtherData(string other)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetOtherData", DataConfig.connectionString);
                da.SelectCommand.Parameters.AddWithValue("@other", other);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch
            {
                return dt;
            }
        }   
    }
}
