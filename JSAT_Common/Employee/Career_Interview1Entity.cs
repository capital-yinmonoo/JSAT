using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace JSAT_Common
{
   public class CareerInterview1Entity
    {
   
       public CareerInterview1Entity()
       {
       }

       private int id = 0;
       public int Id
       {
           get { return id; }
           set { id = value; }
       }

       private int careerId = 0;
       public int CareerId
       {
           get { return careerId; }
           set { careerId = value; }
       }

       private String careerCode = String.Empty;
       public String CareerCode
       {
           get { return careerCode; }
           set { careerCode = value; }
       }

       private String name = String.Empty;
       public String Name
       {
           get { return name; }
           set { name = value; }
       }

       private DateTime dob = DateTime.Today;
       public DateTime Dob
       {
           get { return dob; }
           set { dob = value; }
       }

       private int genderId = 0;
       public int GenderId
       {
           get { return genderId; }
           set { genderId = value; }
       }

       private int religionId = 0;
       public int ReligionId
       {
           get { return religionId; }
           set { religionId = value; }
       }

       private String otherReligion = String.Empty;
       public String OtherReligion
       {
           get { return otherReligion; }
           set { otherReligion = value; }
       }

       private int addressId = 0;
       public int AddressId
       {
           get { return addressId; }
           set { addressId = value; }
       }

       private String otherAddress = String.Empty;
       public String OtherAddress
       {
           get { return otherAddress; }
           set { otherAddress = value; }
       }

       private Decimal salary = 0;
       public Decimal Salary
       {
           get { return salary; }
           set { salary = value; }
       }

       private int workableAreaId = 0;
       public int WorkableAreaId
       {
           get { return workableAreaId; }
           set { workableAreaId = value; }
       }

       private String otherWorkableArea = String.Empty;
       public String OtherWorkableArea
       {
           get { return otherWorkableArea; }
           set { otherWorkableArea = value; }
       }

       private int division1 = 0;
       public int Division1
       {
           get { return division1; }
           set { division1 = value; }
       }

       private int position1 = 0;
       public int Position1
       {
           get { return position1; }
           set { position1 = value; }
       }

       private int division2 = 0;
       public int Division2
       {
           get { return division2; }
           set { division2 = value; }
       }

       private int position2 = 0;
       public int Position2
       {
           get { return position2; }
           set { position2 = value; }
       }

       private int division3 = 0;
       public int Division3
       {
           get { return division3; }
           set { division3 = value; }
       }

       private int position3 = 0;
       public int Position3
       {
           get { return position3; }
           set { position3 = value; }
       }

       private int situationId = 0;
       public int SituationId
       {
           get { return situationId; }
           set { situationId = value; }
       }

       private int availabilityId = 0;
       public int AvailabilityId
       {
           get { return availabilityId; }
           set { availabilityId = value; }
       }

       private String otherAvailability = String.Empty;
       public String OtherAvailibality
       {
           get { return otherAvailability; }
           set { otherAvailability = value; }
       }

       private int educationId = 0;
       public int EducationId
       {
           get { return educationId; }
           set { educationId = value; }
       }

       private String otherEducation = String.Empty;
       public String OtherEducation
       {
           get { return otherEducation; }
           set { otherEducation = value; }
       }

       private int instituteAreaId = 0;
       public int InstituteAreaId
       {
           get { return instituteAreaId; }
           set { instituteAreaId = value; }
       }

       private int instituteNameId = 0;
       public int InstituteNameId
       {
           get { return instituteNameId; }
           set { instituteNameId = value; }
       }

       private String otherInstitution = String.Empty;
       public String OtherInstitution
       {
           get { return otherInstitution; }
           set { otherInstitution = value; }
       }

       private int majorId = 0;
       public int MajorId
       {
           get { return majorId; }
           set { majorId = value; }
       }

       private String otherMajor = String.Empty;
       public String OtherMajor
       {
           get { return otherMajor; }
           set { otherMajor = value; }
       }

       private DateTime graduateDate = DateTime.Today;
       public DateTime GraduateDate
       {
           get { return graduateDate; }
           set { graduateDate = value; }
       }

       private String otherQualification = String.Empty;
       public String OtherQualification
       {
           get { return otherQualification; }
           set { otherQualification = value; }
       }

       private int pcSkill = 0;
       public int PcSkill
       {
           get { return pcSkill; }
           set { pcSkill = value; }
       }

       private String otherPcSkill = String.Empty;
       public String OtherPcSkill
       {
           get { return otherPcSkill; }
           set { otherPcSkill = value; }
       }

       private int engListeningId = 0;
       public int EngListeningId
       {
           get { return engListeningId; }
           set { engListeningId = value; }
       }

       private int engSpeakingId = 0;
       public int EngSpeakingId
       {
           get { return engSpeakingId; }
           set { engSpeakingId = value; }
       }

       private int japListeningId = 0;
       public int JapListeningId
       {
           get { return japListeningId; }
           set { japListeningId = value; }
       }

       private int japSpeakingId = 0;
       public int JapSpeakingId
       {
           get { return japSpeakingId; }
           set { japSpeakingId = value; }
       }

       private int myanListeningId = 0;
       public int MyanListeningId
       {
           get { return myanListeningId; }
           set { myanListeningId = value; }
       }

       private int myanSpeakingId = 0;
       public int MyanSpeakingId
       {
           get { return myanSpeakingId; }
           set { myanSpeakingId = value; }
       }
    }
}
