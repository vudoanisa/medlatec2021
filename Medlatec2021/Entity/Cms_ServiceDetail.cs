using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MEDLATEC.BusinessLayer
{
    [Serializable]

//public class Location
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public int LocationID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Name { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Address { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string CName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public double Lat { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public double Long { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Mobile { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Service { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string LocationTimeID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string WorkingTimeStr { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ImagesStr { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ImagesThumbnailStr { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string WorkingTime { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string SpecialistStr { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Ctype { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DayStr { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int LocationTypeID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string District { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string City { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Specialist { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public double AverageRating { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Intro { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string TinhThanhID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string QuanHuyenID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Geog { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string KeySearchName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string UserUpdate { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DateUpdate { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Active { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int CountLike { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string VerifyPhone { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string FromVicare { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string NeedReview { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int DoctorID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DoctorCode { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Email { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Duyet { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string KeySearchAddress { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string KeySearchAll { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int OrganizedID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string UrlWebsite { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string UserCreate { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DateCreate { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string IsDel { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string UserDel { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DateDel { get; set; }
//}

public class ServiceDetailsItem
{
    /// <summary>
    /// 
    /// </summary>
    public int ServiceDetailID { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int ServiceID { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string TestCode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string TestName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int Price { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string GroupTestName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string OrderNumber { get; set; }
}

//public class Service
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ServiceID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int LocationID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ProvinceID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ServiceName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ServiceDes { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int Cost { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ServiceContent { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Img { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int Discount { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DesImg { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string KeysearchName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Active { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int CostFe { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int DiscountFe { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int LowAgeLimit { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int HightAgeLimit { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IdGoi { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string MaGoi { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int Sex { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int AverageRating { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int CountRate { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ConditionDate { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DateFrom { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DateTo { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int PersonNumService { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IsServey { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IsInNormal { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IsReExamination { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string IsHome { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int TimeBefore { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ExtraDay { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int DefaultNumber { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int InWeb { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ServiceType { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public List<ServiceDetailsItem> ServiceDetails { get; set; }
//}

//public class ServiceDetailsItem
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ServiceDetailID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ServiceID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string TestCode { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string TestName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int Price { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string GroupTestName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string OrderNumber { get; set; }
//}

//public class Service
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ServiceID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int LocationID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ProvinceID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ServiceName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ServiceDes { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int Cost { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ServiceContent { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Img { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int Discount { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DesImg { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string KeysearchName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Active { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int CostFe { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int DiscountFe { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int LowAgeLimit { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int HightAgeLimit { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IdGoi { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string MaGoi { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int Sex { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int AverageRating { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int CountRate { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ConditionDate { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DateFrom { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DateTo { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int PersonNumService { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IsServey { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IsInNormal { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IsReExamination { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string IsHome { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int TimeBefore { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ExtraDay { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int DefaultNumber { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int InWeb { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ServiceType { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public List<ServiceDetailsItem> ServiceDetails { get; set; }
//}

public class ListCustomServiceDetailItem
{
    /// <summary>
    /// 
    /// </summary>
    public string ProvinceName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Location { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Service Service { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ListCustomServiceDetail { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ServiceDetail { get; set; }
}

//public class ServiceDetailsItem
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ServiceDetailID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ServiceID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string TestCode { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string TestName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int Price { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string GroupTestName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string OrderNumber { get; set; }
//}

//public class Service
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ServiceID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int LocationID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ProvinceID { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ServiceName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ServiceDes { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int Cost { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ServiceContent { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Img { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int Discount { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DesImg { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string KeysearchName { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string Active { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int CostFe { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int DiscountFe { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int LowAgeLimit { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int HightAgeLimit { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IdGoi { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string MaGoi { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int Sex { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int AverageRating { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int CountRate { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string ConditionDate { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DateFrom { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string DateTo { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int PersonNumService { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IsServey { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IsInNormal { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int IsReExamination { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public string IsHome { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int TimeBefore { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ExtraDay { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int DefaultNumber { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int InWeb { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public int ServiceType { get; set; }
//    /// <summary>
//    /// 
//    /// </summary>
//    public List<ServiceDetailsItem> ServiceDetails { get; set; }
//}

public class ServiceDetailItem
{
    /// <summary>
    /// 
    /// </summary>
    public int ServiceDetailID { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int ServiceID { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string TestCode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string TestName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Price { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string GroupTestName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string OrderNumber { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Service Service { get; set; }
}

public class Root
{
    /// <summary>
    /// 
    /// </summary>
    public string ProvinceName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Location Location { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Service Service { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<ListCustomServiceDetailItem> ListCustomServiceDetail { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<ServiceDetailItem> ServiceDetail { get; set; }
}
}


