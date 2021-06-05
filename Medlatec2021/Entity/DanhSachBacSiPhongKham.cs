using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.BusinessLayer
{
    public class DoctorWithPhongKham
    {

        public List<timeBS> timeBS { get; set; }
        public int DoctorID { get; set; }
        public string SpecialName { get; set; }
        public string DoctorIDCode { get; set; }
        public int UserID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Avartar { get; set; }
        public decimal Rating { get; set; }
        public int PersonRate { get; set; }
        public int OrganizeID { get; set; }
        public int SpecialistID { get; set; }
        public string OrganizeName { get; set; }

        public DateTime DayKham { get; set; }
        public string SpecialistCode { get; set; }
        public string OrganizeCode { get; set; }

    }
    public class timeBS
    {
        public string DoctorTime { get; set; }
        public int ScheduleTimeID { get; set; }
        public int DoctorScheduleID { get; set; }
    }
}