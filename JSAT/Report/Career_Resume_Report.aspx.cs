using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JSAT_BL;
using JSAT_Common;
using System.IO;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Globalization;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Text;
using System.Management;
using System.Collections;
using Ionic.Zip;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using iTextSharp.text;
using JSAT_Ver1;

namespace JSATVer1.Report
{
    public partial class Career_Resume_Report : System.Web.UI.Page
    {
        string All_DataPath = ConfigurationManager.AppSettings["All_Data"].ToString();
        string Zip_Data = ConfigurationManager.AppSettings["Zip_Data"].ToString();
        string PhotoPath = ConfigurationManager.AppSettings["Photo_DataPath"].ToString();
        string DataSheetPath = ConfigurationManager.AppSettings["Datasheet_DataPath"].ToString();
        string IDCardPath = ConfigurationManager.AppSettings["IDCard_DataPath"].ToString();
        string CredentialPath = ConfigurationManager.AppSettings["Credential_DataPath"].ToString();
        string JapanesePath = ConfigurationManager.AppSettings["Japanese_DataPath"].ToString();
        string GraduationPath = ConfigurationManager.AppSettings["Graduation_DataPath"].ToString();
        string QualificationPath = ConfigurationManager.AppSettings["Qualification_DataPath"].ToString();
        string LabourCardPath = ConfigurationManager.AppSettings["LabourCard_DataPath"].ToString();
        Career_ResumeBL careerResume = new Career_ResumeBL();
        DataTable dtSub = new DataTable();

        public int Career_ID
        {
            get
            {
                if (Request.QueryString["Career_ID"] != null)
                    return int.Parse(Request.QueryString["Career_ID"].ToString());
                return 0;
            }
        }

        public string Career_Code
        {
            get
            {
                if (Request.QueryString["Career_Code"] != null)
                    return Convert.ToString(Request.QueryString["Career_Code"].ToString());
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    fiildata();
            }
        }

        private DataTable LoadingInfo()
        {
            Career_ResumeBL careerResume = new Career_ResumeBL();
            DataTable dtCareerResume = careerResume.SelectByIDReport(Career_ID);
            if (dtCareerResume.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = careerResume.SelectByIDReport(Career_ID);
                // Modify table columns so that datatable will match with dataset.
                if (dt.Rows[0]["DOB"].ToString() != "")
                {
                    DateTime DOB = DateTime.Parse(dt.Rows[0]["DOB"].ToString());
                    DateTime today = DateTime.Today;
                    int age = today.Year - DOB.Year;
                    if (DOB > today.AddYears(-age)) age--;
                    dt.Rows[0]["Age"] = age.ToString();
                }
                dt.Columns.Remove("Career_Code");
                dt.Columns.Remove("DOB");
                dt.Columns.Remove("Created_Date");
                dt.Columns.Remove("Update_Date");
                dt.Columns.Remove("Graduation_Date");
                dt.Columns.Remove("FromDate");
                dt.Columns.Remove("ToDate");
                DataRow drow;
                dt.Columns.Add("Career_Code", System.Type.GetType("System.String"));
                dt.Columns.Add("PhotoFilePath", System.Type.GetType("System.String"));
                dt.Columns.Add("DataSheetFilePath", System.Type.GetType("System.String"));
                dt.Columns.Add("DataSheetFilePath2", System.Type.GetType("System.String"));
                dt.Columns.Add("DataSheetFilePath3", System.Type.GetType("System.String"));
                dt.Columns.Add("DataSheetFilePath4", System.Type.GetType("System.String"));
                dt.Columns.Add("DataSheetFilePath5", System.Type.GetType("System.String"));

                dt.Columns.Add("IDCardFilePath", System.Type.GetType("System.String"));
                dt.Columns.Add("IDCardFilePath2", System.Type.GetType("System.String"));
                dt.Columns.Add("IDCardFilePath3", System.Type.GetType("System.String"));
                dt.Columns.Add("CredentialFilePath", System.Type.GetType("System.String"));
                dt.Columns.Add("CredentialFilePath2", System.Type.GetType("System.String"));
                dt.Columns.Add("CredentialFilePath3", System.Type.GetType("System.String"));
                dt.Columns.Add("CredentialFilePath4", System.Type.GetType("System.String"));
                dt.Columns.Add("CredentialFilePath5", System.Type.GetType("System.String"));
                dt.Columns.Add("CredentialFilePath6", System.Type.GetType("System.String"));
                dt.Columns.Add("CredentialFilePath7", System.Type.GetType("System.String"));

                dt.Columns.Add("JapaneseFilePath", System.Type.GetType("System.String"));
                dt.Columns.Add("JapaneseFilePath2", System.Type.GetType("System.String"));
                dt.Columns.Add("JapaneseFilePath3", System.Type.GetType("System.String"));
                dt.Columns.Add("GraduationFilePath", System.Type.GetType("System.String"));
                dt.Columns.Add("GraduationFilePath2", System.Type.GetType("System.String"));
                dt.Columns.Add("GraduationFilePath3", System.Type.GetType("System.String"));
                dt.Columns.Add("QualificationFilePath", System.Type.GetType("System.String"));
                dt.Columns.Add("QualificationFilePath2", System.Type.GetType("System.String"));
                dt.Columns.Add("QualificationFilePath3", System.Type.GetType("System.String"));
                dt.Columns.Add("LabourCardFilePath", System.Type.GetType("System.String"));
                dt.Columns.Add("LabourCardFilePath2", System.Type.GetType("System.String"));
                dt.Columns.Add("LabourCardFilePath3", System.Type.GetType("System.String"));

                dt.Columns.Add("DOB", System.Type.GetType("System.String"));
                //dt.Columns.Add("Created_Date", System.Type.GetType("System.String"));
                dt.Columns.Add("Update_Date", System.Type.GetType("System.String"));
                dt.Columns.Add("Graduation_Date", System.Type.GetType("System.String"));
                dt.Columns.Add("FromDate", System.Type.GetType("System.String"));
                dt.Columns.Add("ToDate", System.Type.GetType("System.String"));
                drow = dt.NewRow();
                Career_InformationBL cibl = new Career_InformationBL();
                DataTable dtUpload = cibl.SelectByCareerID(Career_ID, 1);
                String PhotoFilePath, DataSheetFilePath,IDCardFilePath, CredentialFilePath,GraduationFilePath, LabourCardFilePath;
                PhotoFilePath = DataSheetFilePath = IDCardFilePath = CredentialFilePath = GraduationFilePath = LabourCardFilePath = String.Empty;
                if (dtUpload.Rows.Count > 0)
                {
                    PhotoFilePath = Server.MapPath(PhotoPath) + dtUpload.Rows[0]["Photo"].ToString();
                    ArrayList arrlst = Session["Report"] as ArrayList;
                    if (arrlst!=null)
                    {
                        if (arrlst.Contains("IDCard_Data"))
                            IDCardFilePath = Server.MapPath(IDCardPath) + dtUpload.Rows[0]["IDCard_Data"].ToString();
                        else IDCardFilePath = Server.MapPath(IDCardFilePath);

                        if (arrlst.Contains("Datasheet_Data"))
                            DataSheetFilePath = Server.MapPath(DataSheetPath) + dtUpload.Rows[0]["Datasheet_Data"].ToString();
                        else DataSheetFilePath = Server.MapPath(DataSheetPath);
                       
                        if (arrlst.Contains("Credential_Data"))
                            CredentialFilePath = Server.MapPath(CredentialPath) + dtUpload.Rows[0]["Credential_Data"].ToString();
                        else
                            CredentialFilePath = Server.MapPath(CredentialPath);
                       
                        if (arrlst.Contains("Graduation_Data"))
                            GraduationFilePath = Server.MapPath(GraduationPath) + dtUpload.Rows[0]["Graduation_Data"].ToString();
                        else
                            GraduationFilePath = Server.MapPath(GraduationPath);
                       
                        if (arrlst.Contains("LabourCard_Data"))
                            LabourCardFilePath = Server.MapPath(LabourCardPath) + dtUpload.Rows[0]["LabourCard_Data"].ToString();
                        else
                            LabourCardFilePath = Server.MapPath(LabourCardPath);
                    }
                }
                

              if (File.Exists(PhotoFilePath))
                {
                    dt.Rows[0]["PhotoFilePath"] = "file://" + PhotoFilePath;
                }
                #region DataSheet
                if (File.Exists(DataSheetFilePath))
                {
                    dt.Rows[0]["DataSheetFilePath"] = "file://" + DataSheetFilePath;
                }
                #endregion

                #region IDCard
                if (File.Exists(IDCardFilePath))
                {
                    dt.Rows[0]["IDCardFilePath"] = "file://" + IDCardFilePath;
                }
                #endregion

                #region Credential
                if (File.Exists(CredentialFilePath))
                {
                    dt.Rows[0]["CredentialFilePath"] = "file://" + CredentialFilePath;
                }
                #endregion

                #region Graduation
                if (File.Exists(GraduationFilePath))
                {
                    dt.Rows[0]["GraduationFilePath"] = "file://" + GraduationFilePath;
                }
                #endregion

                #region LabourCard
                if (File.Exists(LabourCardFilePath))
                {
                    dt.Rows[0]["LabourCardFilePath"] = "file://" + LabourCardFilePath;
                }

                #endregion
                dt.Rows[0]["Career_Code"] = dtCareerResume.Rows[0]["Career_Code"].ToString();

                if (!String.IsNullOrWhiteSpace(dtCareerResume.Rows[0]["DOB"].ToString()))
                {
                    string date = dtCareerResume.Rows[0]["DOB"].ToString();
                    dt.Rows[0]["DOB"] = GlobalUI.Format_Date(date);
                }

                //if (!String.IsNullOrWhiteSpace(dtCareerResume.Rows[0]["Created_Date"].ToString()))//Created Date
                //{
                //    string date = dtCareerResume.Rows[0]["Created_Date"].ToString();
                //    dt.Rows[0]["Created_Date"] = GlobalUI.Format_Date(date);
                //}

                if (!String.IsNullOrWhiteSpace(dtCareerResume.Rows[0]["Update_Date"].ToString()))//Updaed Date
                {
                    string date = dtCareerResume.Rows[0]["Update_Date"].ToString();
                    dt.Rows[0]["Update_Date"] = GlobalUI.Format_Date(date);
                }

                if (!String.IsNullOrWhiteSpace(dtCareerResume.Rows[0]["Graduation_Date"].ToString()))
                {
                    string date = dtCareerResume.Rows[0]["Graduation_Date"].ToString();
                    dt.Rows[0]["Graduation_Date"] = date;
                }
                dt.AcceptChanges();
                return dt;
            }
            else
            {
                return null;
            }

        }

        private void fiildata()
        {
            Warning[] warnings;
            string[] streamIds;
            string path = Server.MapPath("Print_Files");
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            List<byte[]> collectAllForms = new List<byte[]>();
            string devinfo = "<DeviceInfo><ColorDepth>32</ColorDepth><DpiX>350</DpiX><DpiY>350</DpiY><OutputFormat>PDF</OutputFormat>" +
                   "  <PageWidth>218mm</PageWidth>" +
                    "  <PageHeight>14in</PageHeight>" +
                    "  <MarginTop>20mm</MarginTop>" +
                    "  <MarginLeft>20mm</MarginLeft>" +
                     "  <MarginRight>20mm</MarginRight>" +
                     "  <MarginBottom>20mm</MarginBottom>" +
                   "</DeviceInfo>";
            careerResume = new Career_ResumeBL();
            DataSet ds = careerResume.Report(Career_ID);
            DataTable dtCareerResume = LoadingInfo();
            dtCareerResume.TableName = "dtCareerResume";
            ds.Tables.Add(dtCareerResume);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rd1 = new ReportDataSource("Career_Resume", ds.Tables["dtCareerResume"]);
            ReportDataSource rd2 = new ReportDataSource("PC_Skills", ds.Tables["dtPCSkill"]);
            ReportDataSource rd3 = new ReportDataSource("Qualification", ds.Tables["dtQualification"]);
            ReportDataSource rd4 = new ReportDataSource("Career_Employment", ds.Tables["dtCareerEmployment"]);
            ReportDataSource rd5 = new ReportDataSource("Interview_Question3", ds.Tables["dtInterview_Question3"]);
            ReportDataSource rd6 = new ReportDataSource("Career_Interview3", ds.Tables["dtCareer_Interview3"]);
            ReportDataSource rd7 = new ReportDataSource("Language_Level", ds.Tables["dtLanguageLevel"]);
            ReportDataSource rd8 = new ReportDataSource("Career_Resume1", dtCareerResume);
            ReportDataSource rd9 = new ReportDataSource("Working_History", ds.Tables["dtNotice_Type"]);
            ReportDataSource rd10 = new ReportDataSource("Old_Job_History", ds.Tables["dtOld_Job_History"]);
            ReportDataSource rd11 = new ReportDataSource("Ability", ds.Tables["dtAbility"]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rd1);
            ReportViewer1.LocalReport.DataSources.Add(rd2);
            ReportViewer1.LocalReport.DataSources.Add(rd3);
            ReportViewer1.LocalReport.DataSources.Add(rd4);
            ReportViewer1.LocalReport.DataSources.Add(rd5);
            ReportViewer1.LocalReport.DataSources.Add(rd6);
            ReportViewer1.LocalReport.DataSources.Add(rd7);
            ReportViewer1.LocalReport.DataSources.Add(rd8);
            ReportViewer1.LocalReport.DataSources.Add(rd9);
            ReportViewer1.LocalReport.DataSources.Add(rd10);
            ReportViewer1.LocalReport.DataSources.Add(rd11);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("../Report/Career_Resume_Report.rdlc");
            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubReportHandel);
            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(Interview_Question3_SubReportHandel);
            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(Old_Job_History_Sub_ReportHandel);
            ReportViewer1.LocalReport.EnableExternalImages = true;
            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", devinfo, out mimeType, out encoding, out extension, out streamIds, out warnings);
            collectAllForms.Add(bytes);
            if (Session["chkvalue"] != null)
            {
                ArrayList chkvalue = Session["chkvalue"] as ArrayList;
                for (int i = 0; i < chkvalue.Count; i++)
                {
                   
                    string lastfordername = Path.GetFileName(Path.GetDirectoryName(chkvalue[i].ToString()));
                    string filename = Path.GetFileName(chkvalue[i].ToString());
                    string realfilename = filename.Replace("]","");
                    byte[] finalbytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Upload Folder/Career_Data/" + lastfordername+"/"+realfilename));
                    collectAllForms.Add(finalbytes);
                }
            }
            DownloadAsPDF(MergePDFs(collectAllForms), "AllApplicant.pdf");
        }

        public MemoryStream MergePDFs(List<byte[]> pdfFiles)
        {
            if (pdfFiles.Count > 1)
            {
                PdfReader finalPdf;
                Document pdfContainer;
                PdfWriter pdfCopy;
                MemoryStream msFinalPdf = new MemoryStream();
                finalPdf = new PdfReader(pdfFiles[0]);
                pdfContainer = new Document();
                pdfCopy = new PdfSmartCopy(pdfContainer, msFinalPdf);
                pdfContainer.Open();
                PdfReader.unethicalreading = true;
                for (int k = 0; k < pdfFiles.Count; k++)
                {
                    finalPdf = new PdfReader(pdfFiles[k]);
                    for (int i = 1; i < finalPdf.NumberOfPages + 1; i++)
                    {
                        ((PdfSmartCopy)pdfCopy).AddPage(pdfCopy.GetImportedPage(finalPdf, i));
                    }
                    pdfCopy.FreeReader(finalPdf);
                }
                finalPdf.Close();
                pdfCopy.Close();
                pdfContainer.Close();
                return msFinalPdf;
            }
            else if (pdfFiles.Count == 1)
            {
                return new MemoryStream(pdfFiles[0]);
            }
            return null;
        }

        public void DownloadAsPDF(MemoryStream msFinal, String theFileName)
        {
            theFileName = "attachment; filename =" + theFileName + ".pdf";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            Context.Response.AppendHeader("Content-Disposition", "inline; filename="+Career_Code+".pdf");
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.BinaryWrite(msFinal.ToArray());
            HttpContext.Current.Response.OutputStream.Flush();
            HttpContext.Current.Response.OutputStream.Close();
            HttpContext.Current.Response.End();
            msFinal.Close();
        }

        private void AttatchmentReport()
        {
            DataTable dtCareerResume = LoadingInfo();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rd1 = new ReportDataSource("Career_Resume", dtCareerResume);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("../Report/Career_Resume_Attatchment_Report.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rd1);
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.DataBind();
        }

        private void SubReportHandel(object sender, SubreportProcessingEventArgs e)
        {            
            careerResume = new Career_ResumeBL();
            dtSub = careerResume.Report(Career_ID).Tables["dtCareerEmployment"];
            e.DataSources.Add(new ReportDataSource("Career_Employment", dtSub));
        }

        private void Interview_Question3_SubReportHandel(object sender, SubreportProcessingEventArgs e)
        {
            careerResume = new Career_ResumeBL();
            dtSub = careerResume.Report(Career_ID).Tables["dtInterview_Question3"];
            e.DataSources.Add(new ReportDataSource("Interview_Question3", dtSub));
        }

        private void Old_Job_History_Sub_ReportHandel(object sender, SubreportProcessingEventArgs e)
        {
            careerResume = new Career_ResumeBL();
            dtSub = careerResume.Report(Career_ID).Tables["dtOld_Job_History"];
            e.DataSources.Add(new ReportDataSource("Old_Job_History", dtSub));
        }

        //private void Career_Condition_Sub_ReportHandel(object sender, SubreportProcessingEventArgs e)
        //{
        //    careerResume = new Career_ResumeBL();
        //    dtSub = careerResume.Report(Career_ID).Tables["dtCareer_Condition"];
        //    e.DataSources.Add(new ReportDataSource("CareerCondition", dtSub));
        //}
    }
}