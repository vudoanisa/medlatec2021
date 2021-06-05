using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class ServiceDetail

    {

        public int ServiceDetailID { get; set; }

        public int ServiceID { get; set; }

        public string TestCode { get; set; }

        public string TestName { get; set; }

        public double Price { get; set; }

        public object GroupTestName { get; set; }

        public object OrderNumber { get; set; }

    }

    public class ServiceGroup
    {
        public int ServiceGroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreate { get; set; }
        public int OrderNum { get; set; }
    }

    public class Service

    {

        public int ServiceID { get; set; }

        public int LocationID { get; set; }

        public string ProvinceID { get; set; }

        public string ServiceName { get; set; }

        public string ServiceDes { get; set; }

        public double Cost { get; set; }

        public string ServiceContent { get; set; }

        public string Img { get; set; }

        public double Discount { get; set; }

        public string DesImg { get; set; }

        public string KeysearchName { get; set; }

        public bool Active { get; set; }

        public double CostFe { get; set; }

        public double DiscountFe { get; set; }

        public int LowAgeLimit { get; set; }

        public int HightAgeLimit { get; set; }

        public int IdGoi { get; set; }

        public string MaGoi { get; set; }

        public int Sex { get; set; }

        public double AverageRating { get; set; }

        public int CountRate { get; set; }

        public string ConditionDate { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int PersonNumService { get; set; }

        public int IsServey { get; set; }

        public int IsInNormal { get; set; }

        public int IsReExamination { get; set; }

        public bool IsHome { get; set; }

        public int TimeBefore { get; set; }

        public int ExtraDay { get; set; }

        public int DefaultNumber { get; set; }

        public int InWeb { get; set; }

        public int ServiceType { get; set; }

        public IList<ServiceDetail> ServiceDetails { get; set; }

    }
    public class Location
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CName { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Mobile { get; set; }
        public object Service { get; set; }
        public object LocationTimeID { get; set; }
        public object WorkingTimeStr { get; set; }
        public string ImagesStr { get; set; }
        public string ImagesThumbnailStr { get; set; }
        public string WorkingTime { get; set; }
        public object SpecialistStr { get; set; }
        public object Ctype { get; set; }
        public object DayStr { get; set; }
        public int LocationTypeID { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public object Specialist { get; set; }
        public double AverageRating { get; set; }
        public string Intro { get; set; }
        public string TinhThanhID { get; set; }
        public string QuanHuyenID { get; set; }
        public object Geog { get; set; }
        public string KeySearchName { get; set; }
        public string UserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool Active { get; set; }
        public int CountLike { get; set; }
        public bool VerifyPhone { get; set; }
        public object FromVicare { get; set; }
        public object NeedReview { get; set; }
        public int DoctorID { get; set; }
        public object DoctorCode { get; set; }
        public string Email { get; set; }
        public bool Duyet { get; set; }
        public string KeySearchAddress { get; set; }
        public string KeySearchAll { get; set; }
        public int OrganizedID { get; set; }
        public string UrlWebsite { get; set; }
        public object UserCreate { get; set; }
        public object DateCreate { get; set; }
        public object IsDel { get; set; }
        public object UserDel { get; set; }
        public object DateDel { get; set; }
    }
    public class ListCustomServiceDetail
    {
        public string ProvinceName { get; set; }
        public object Location { get; set; }
        public Service Service { get; set; }

        public object ServiceDetail { get; set; }
    }
    public class RootObject

    {

        public Service Service { get; set; }

        public string ProvinceName { get; set; }

        public object Services { get; set; }

        public object Location { get; set; }

        public object ServiceGroupsTest { get; set; }

        public ListCustomServiceDetail ListCustomServiceDetail { get; set; }
        public IList<ServiceDetail> ServiceDetail { get; set; }

    }




}



