using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDbCRUD.Models
{
    public class StudentPageModel
    {


        public string session { get; set; }
        public string standard { get; set; }
        public string AdmissionNumber { get; set; }
        public string NameOfStudent { get; set; }
        public string House { get; set; }
        public string DOB { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public string TotalAttendence { get; set; }
        public string TotalWorkingDays { get; set; }
        public Object signature { get; set; }

       public StudentPageModel()
        {

        }


      public  StudentPageModel(string session ,string standard , string AdmisionNo , string Name , string house ,string DOB , string father
            ,string mother , string address , string totalatten , string totalworkingday)
        {
            this.session = session;
            this.standard = standard;
            this.AdmissionNumber = AdmisionNo;
            this.NameOfStudent = Name;
            this.House = house;
            this.DOB = DOB;
            this.FatherName = father;
            this.MotherName = mother;
            this.Address = address;
            this.TotalAttendence = totalatten;
            this.TotalWorkingDays = totalworkingday; 
 

        }


    }
     

}