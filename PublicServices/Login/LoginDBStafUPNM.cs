﻿using APELC.Model;
using Dapper;
using APELC.PublicShared;
////using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APELC.PublicServices.Login
{
    public class LoginDBStafUPNM
    {
        static readonly string ConnSyAkademik = PublicConstant.ConnUpnmDbAkademik();
        static readonly string _encryptCode = PublicConstant.EncryptCode();

        static readonly string _VW_STAF_AKTIF =
           @" SELECT nopekerja AS NOPEKERJA,
              gelar_nama AS NAMA,
              kdjwthakiki AS KOD_JAWATAN_HAKIKI,
              jawatanhakiki AS JAWATAN_HAKIKI,
              kdjbtnhakiki AS KOD_JABATAN_HAKIKI,
              jabatanhakiki AS JABATAN_HAKIKI,
              kdjwtsemasa AS KOD_JAWATAN_SEMASA,
              jawatansemasa AS JAWATAN_SEMASA,
              kdjbtnsemasa AS JAWATAN_SEMASA,
              jabatansemasa AS JABATAN_SEMASA,
              email AS EMAIL,
              handphone AS HANDPHONE,
              kodstatus AS KOD_STATUS
              FROM v630staf_apel where status='Aktif'; ";

        //static readonly string _VW_STAF_AKTIF =
        //    @" SELECT NO_BARCODE AS NOBARCODE, IC AS SPR_NOKP, NOMATRIK AS NOPEKERJA,
        //              NAMA, KURSUS AS KOD_KURSUS, KOD_KOLEJ AS KOD_KOLEJ, KOD_KAMPUS, KOD_FAKULTI as KOD_PTJ, 
        //              EMAIL, HANDPHONE, GAMBAR as PHOTO, NAMA_PENDEK as USERNAME,
        //              KOLEJ AS NAMA_KOLEJ, '1' as RESULTSET
        //         FROM SENARAI.VW_STUDENT_AKTIF_KESELURUHAN ";

        public static string SQL_GetStaffRecord(string _nokp)
        {
            string _sQL = _VW_STAF_AKTIF;
            _sQL += " WHERE ( IC = '" + _nokp + "') ";
            var log = NLog.LogManager.GetCurrentClassLogger();
            log.Info("SQL_GetStaffRecord  _sQL ~ " + _sQL);
            return _sQL;
        }

        public static ModelUserDTO MtdGetDataPelajarByNokp(string _nokp)
        {
            ModelUserDTO _return = new ModelUserDTO();
            _return.RESULTSET = "0";
            _return.RESULTSET_TEXT = "BEGIN GET STAF RECORD";
            //try
            //{
            //    string _sQl = SQL_GetStaffRecord(_nokp);
            //    //var log = NLog.LogManager.GetCurrentClassLogger();
            //    //log.Info("MtdGetDataPelajarByNokp _sQl ~ " + _sQl);

            //    using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnSyAkademik))
            //    {
            //        ModelUserDTO _data = dbConn.QueryFirstOrDefault<ModelUserDTO>(_sQl);
            //        //log.Info("MtdGetDataPelajarByNokp try catch _data.RESULTSET ~ " + _data.RESULTSET);
            //        if (_data != null && _data.RESULTSET == "1")
            //        {
            //            if (_data.USERNAME == null)
            //            {
            //                _data.USERNAME = (PublicConstant.SplitAyat(PublicConstant.MtdRemoveSpecialCharacter5space(_data.NAMA), " "))[0];
            //            }
            //            _return = _data;
            //            _return.HRSTAFFK = "0";
            //            //_return.PHOTOSTUDENT = MtdGetStudenBhoto(_return.GRK_NOKP);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    var log = NLog.LogManager.GetCurrentClassLogger();
            //    log.Info("MtdGetDataPelajarByNokp _nokp ~ " + _nokp);
            //    log.Info("MtdGetDataPelajarByNokp try catch ex.Message ~ " + ex.Message);
            //}
            return _return;
        }

        //public static ModelUserDTO MtdGetDataPelajarByNokp(string _nokp)
        //{
        //    ModelUserDTO _return = new ModelUserDTO();
        //    _return.RESULTSET = "0";
        //    _return.RESULTSET_TEXT = "BEGIN GET STAF RECORD";
        //    //try
        //    //{
        //    //    string _sQl = SQL_GetStaffRecord(_nokp);
        //    //    //var log = NLog.LogManager.GetCurrentClassLogger();
        //    //    //log.Info("MtdGetDataPelajarByNokp _sQl ~ " + _sQl);

        //    //    using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnSyAkademik))
        //    //    {
        //    //        ModelUserDTO _data = dbConn.QueryFirstOrDefault<ModelUserDTO>(_sQl);
        //    //        //log.Info("MtdGetDataPelajarByNokp try catch _data.RESULTSET ~ " + _data.RESULTSET);
        //    //        if (_data != null && _data.RESULTSET == "1")
        //    //        {
        //    //            if (_data.USERNAME == null)
        //    //            {
        //    //                _data.USERNAME = (PublicConstant.SplitAyat(PublicConstant.MtdRemoveSpecialCharacter5space(_data.NAMA), " "))[0];
        //    //            }
        //    //            _return = _data;
        //    //            _return.HRSTAFFK = "0";
        //    //            //_return.PHOTOSTUDENT = MtdGetStudenBhoto(_return.GRK_NOKP);
        //    //        }
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    var log = NLog.LogManager.GetCurrentClassLogger();
        //    //    log.Info("MtdGetDataPelajarByNokp _nokp ~ " + _nokp);
        //    //    log.Info("MtdGetDataPelajarByNokp try catch ex.Message ~ " + ex.Message);
        //    //}
        //    return _return;
        //}

        //public static ModelUserDTO MtdGetPhotoStudent(string _nokp)
        //{
        //ModelUserDTO _return = new ModelUserDTO();
        //_return.RESULTSET = "0";
        //_return.RESULTSET_TEXT = "BEGIN GET PHOTO STUDENT";
        //try
        //{
        //    using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnSyAkademik))
        //    {
        //        ModelUserDTO _data = dbConn.QueryFirstOrDefault<ModelUserDTO>(SQL_GetStaffRecord(_nokp));
        //        if (_data != null && _data.RESULTSET == "1")
        //        {
        //            _return.PHOTO = _data.PHOTO;
        //            _return.RESULTSET = "1";
        //            _return.HRSTAFFK = "0";
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    var log = NLog.LogManager.GetCurrentClassLogger();
        //    log.Info("MtdGetDataPelajarByNokp try catch ex.Message ~ " + ex.Message);
        //}
        //return _return;
        //}


    }
}
