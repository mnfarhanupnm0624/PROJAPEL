﻿using Microsoft.AspNetCore.Mvc;
using APEL.Helper;
using APEL.LocalServices.Senarai;
//using APEL.LocalServices.Aduan;
using APEL.Models;
//using Newtonsoft.Json;
//using APEL.LocalServices.Public;
//using Net6HrPublicLibrary.PublicShared;
using System.Xml.Linq;


namespace APEL.Controllers
{
    public class ApelCController : Controller
    {

        public IActionResult Index()
        {
            MtdGetDashboardSession("APELC - Index", "");
            ModelUserDTO _data = new();
            return View(_data);
        }
        public IActionResult BackToDashboard()
        {
            return Redirect("/Home/Dashboard");
        }

        private void MtdGetDashboardSession(string id, string id2)
        {
            HttpContext.Session.SetString("_titleTop", "APEL UPNM");
            HttpContext.Session.SetString("_titleSmall", id);
            HttpContext.Session.SetString("_titleSmallSub", id2);
        }

        public IActionResult UnderConstraction()
        {
            MtdGetDashboardSession("Under Constraction", "");
            ModelUserDTO _data = new();
            return View(_data);
        }

        //private bool saveAduanOnSession(CarianAduanMain aduanModel)
        //{
        //    var aduanHelper = new AduanHelper();
        //    HttpContext.Session.SetString("ApelUser", JsonConvert.SerializeObject(aduanHelper.GetApelInfo(aduanModel)));
        //    return true;
        //}




        //public IActionResult Pengesahan()
        //{
        //    string _eUserIdIn = HttpContext.Session.GetString("_userId") ?? "";
        //    if (_eUserIdIn != "")
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return Redirect("/Home/Index");
        //    }
        //}

        // Begin: Sub Topic Kes Siasatan

        //public IActionResult SenaraiAduan()
        //{
        //    MtdGetDashboardSession("Senarai Aduan", "Senarai Aduan");

        //    string _eUserIdIn = HttpContext.Session.GetString("_userId") ?? "";
        //    string _aduanPkEnc = ApelUser.GetApel(HttpContext.Session).ADUAN_PK_ENC ?? "";

        //    if (_eUserIdIn != "")
        //    {
        //        //CarianStaff _data = new();
        //        //return View(_data);
        //    }
        //    else
        //    {
        //        return Redirect("/Home/Index");
        //    }
        //}


        //public IActionResult CttnSstnAwal()
        //{
        //    MtdGetDashboardSession("Senarai Aduan", "Catatan Siasatan Awal");

        //    string _eUserIdIn = HttpContext.Session.GetString("_userId") ?? "";

        //    if (_eUserIdIn != "")
        //    {
        //        CarianStaff _data = new();
        //        return View(_data);
        //    }
        //    else
        //    {
        //        return Redirect("/Home/Index");
        //    }
        //}

        //public IActionResult ButiranAduan()
        //{
        //    MtdGetDashboardSession("Senarai Aduan", "Butiran Aduan");

        //    string _eUserIdIn = HttpContext.Session.GetString("_userId") ?? "";

        //    if (_eUserIdIn != "")
        //    {
        //        CarianStaff _data = new();
        //        return View(_data);
        //    }
        //    else
        //    {
        //        return Redirect("/Home/Index");
        //    }
        //}



        //public IActionResult MaklumatAduan()
        //{
        //    MtdGetDashboardSession("Senarai Aduan", "Maklumat Aduan");

        //    string _eUserIdIn = HttpContext.Session.GetString("_userId") ?? "";

        //    if (_eUserIdIn != "")
        //    {
        //        CarianStaff _data = new();
        //        return View(_data);
        //    }
        //    else
        //    {
        //        return Redirect("/Home/Index");
        //    }
        //}



        //public IActionResult Lampiran()
        //{
        //    MtdGetDashboardSession("Senarai Aduan", "Lampiran");

        //    string _eUserIdIn = HttpContext.Session.GetString("_userId") ?? "";

        //    if (_eUserIdIn != "")
        //    {
        //        CarianStaff _data = new();
        //        return View(_data);
        //    }
        //    else
        //    {
        //        return Redirect("/Home/Index");
        //    }
        //}


        //public IActionResult PerakuanPegawaiPenyiasatKanan()
        //{
        //    MtdGetDashboardSession("Senarai Aduan", "Perakuan Pegawai Penyiasat");

        //    string _eUserIdIn = HttpContext.Session.GetString("_userId") ?? "";

        //    if (_eUserIdIn != "")
        //    {
        //        CarianAduanMain _data = new();
        //        return View(_data);
        //    }
        //    else
        //    {
        //        return Redirect("/Home/Index");
        //    }
        //}
    }
}
