using System;

namespace MEDLATEC2019.Models
{
    public class CustomerServiceModel
    {
        public DateTime Intime { get; set; }
        public string PID { get; set; }
        public string SID { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public double SumMoney { get; set; }
        public double SumPerTage { get; set; }
        public double SumTransport { get; set; }
        public double Total { get; set; }
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Valid { get; set; }
        public bool FullResult { get; set; }
        public int Random { get; set; }
        public bool ShowWeb { get; set; }
        public object Description { get; set; }
        public bool ShowMoney { get; set; }
        public object Mabs { get; set; }
        public object Tenbs { get; set; }
        public object Result { get; set; }
    }
}