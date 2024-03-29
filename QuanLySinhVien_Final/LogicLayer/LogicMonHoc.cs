﻿using QuanLySinhVien_Final.DBLayer;
using System.Data;

namespace QuanLySinhVien_Final.LogicLayer
{
    public class LogicMonHoc
    {

        DBMain db = null;
        private static LogicMonHoc instance;

        internal static LogicMonHoc Instance
        {
            get { if (instance == null) instance = new LogicMonHoc(); return LogicMonHoc.instance; }
            private set { instance = value; }
        }
        public LogicMonHoc()
        {
            db = new DBMain();
        }
        public DataTable LayMonHocs()
        {
            return db.ExcuteQueryDataSet("Select maMH,tenMH,soTinChi From MonHoc where status = 0", CommandType.Text);
        }

        public bool ThemMonHoc(string MaMonHoc, string TenMonHoc, int SoTinChi, ref string err)
        {
            string sqlString = null;
            string query = string.Format("Insert Into MonHoc(maMH,tenMH,soTinChi) VALUES (N'{0}', N'{1}', N'{2}')", MaMonHoc, TenMonHoc, SoTinChi);

            sqlString = "Insert Into MonHoc Values('" +
                                             MaMonHoc + "',N'" +
                                             TenMonHoc + "',N'" +
                                             SoTinChi + "')";
            return db.MyExecuteNonQuery(query, CommandType.Text, ref err);
        }

        public bool CapNhatMonHoc(string MaMonHoc, string TenMonHoc, int SoTinChi, ref string err)
        {
            string query = string.Format("Update MonHoc Set tenMH = N'{1}', " + " soTinChi=N'{2}' " +
                "                                           WHERE maMH = {0}", MaMonHoc, TenMonHoc, SoTinChi);
            //string sqlString = "Update MonHoc Set maMH=N'" + MaMonHoc +"',tenMH=N'" + TenMonHoc  + "Where maMH = '" + MaMonHoc + "'";

            return db.MyExecuteNonQuery(query, CommandType.Text, ref err);
        }

        public bool XoaMonHoc(string MaMonHoc, ref string err)
        {
            //string query = string.Format("Delete From MonHoc Where maMH = {0}", MaMonHoc);
            string sqlString = "Update MonHoc Set status=N'" +
            "1" + "' Where maMH='" + MaMonHoc + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }

        public DataTable SearchMonHocByName(string TenMonHoc)
        {
            string sqlString = "Select * From MonHoc Where tenMH Like '%" + TenMonHoc + "%'";
            //string query = string.Format("SELECT * FROM MonHoc WHERE tenMH LIKE N'%' + N'{0}' + '%'", TenMonHoc);
            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }



    }
}
