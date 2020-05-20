using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common.Employee
{
    public class CareerUploadEntity
    {
        private int careerID = 0;
        public int CareerID
        {
            set { careerID = value; }
            get { return careerID; }
        }

        private String upload_FileName = String.Empty;
        public String Upload_FileName
        {
            set { upload_FileName = value; }
            get { return upload_FileName; }
        }

        private String upload_Type = String.Empty;
        public String Upload_Type
        {
            set { upload_Type = value; }
            get { return upload_Type; }
        }
    }
}
