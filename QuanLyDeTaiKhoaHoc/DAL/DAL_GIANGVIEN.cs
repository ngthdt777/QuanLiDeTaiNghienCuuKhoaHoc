﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDeTaiKhoaHoc.GUI;
using QuanLyDeTaiKhoaHoc.BUS;
using QuanLyDeTaiKhoaHoc.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QuanLyDeTaiKhoaHoc.DAL
{
    class DAL_GIANGVIEN
    {
        private static DAL_GIANGVIEN instance;

        public static DAL_GIANGVIEN Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_GIANGVIEN();
                }
                return instance;
            }
            set { instance = value; }
        }
        public DataTable LoadListGV()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT * FROM GIANGVIEN";
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
        public void AddGV()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string AddQuery = "";
            AddQuery += "INSERT INTO GIANGVIEN(maGiangVien,tenGiangVien,Nganh,maHopDong,maAccount,maKhoa,trinhDo,ngaySinh)";
            AddQuery += "VALUES(@maGiangVien,@tenGiangVien,@Nganh,@maHopDong,'1',@maKhoa,@trinhDo,@ngaySinh)";

            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("@maGiangVien", ((frmMain)f).tb_MaGV.Text);
            param.Add("@tenGiangVien", ((frmMain)f).tb_TenGV.Text);
            param.Add("@Nganh", ((frmMain)f).tb_ChuyenNganh.Text);
            param.Add("@maHopDong", ((frmMain)f).tb_HopDong.Text);
            param.Add("@maKhoa", ((frmMain)f).cb_Khoa.SelectedValue.ToString());
            param.Add("@ngaySinh", ((frmMain)f).dt_NgSinh.Value.ToString());
            param.Add("@trinhDo", ((frmMain)f).tb_trinhDo.Text);
            int result = HandleDB.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Thêm giảng viên thành công");

            }
        }
        public void XoaGV()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string id_xoa = ((frmMain)f).tb_MaGV.Text;
            string DeleteQuery = "DELETE FROM GIANGVIEN WHERE maGiangVien ='" + id_xoa + "'";
            int result = HandleDB.Instance.ExecuteNonQuery(DeleteQuery, null);
            if (result > 0)
            {
                MessageBox.Show("Xóa giảng viên thành công");
            }
        }
        public void SuaGV()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            // string UpdateQuery = "UPDATE GIANGVIEN"+
            //"SET tenGiangVien='"+"'"
            string UpdateQuery = "";
            UpdateQuery += "UPDATE GIANGVIEN SET";
            UpdateQuery += "tenGiangVien=@tenGiangVien";
            UpdateQuery += "maGiangVien=@maGiangVien";
            UpdateQuery += "Nganh=@Nganh";
            UpdateQuery += "maHopDong=@maHopDong";
            UpdateQuery += "maAccount=@maAccount";
            UpdateQuery += "maKhoa=@maKhoa";
            UpdateQuery += "trinhDo=@trinhDo";
            UpdateQuery += "ngaySinh=@ngaySinh";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@maGiangVien", ((frmMain)f).tb_MaGV.Text);
            param.Add("@tenGiangVien", ((frmMain)f).tb_TenGV.Text);
            param.Add("@Nganh", ((frmMain)f).tb_ChuyenNganh.Text);
            param.Add("@maHopDong", ((frmMain)f).tb_HopDong.Text);
            // param.Add("@maKhoa", ((frmMain)f).cb_Khoa.Text);
            param.Add("@ngaySinh", ((frmMain)f).dt_NgSinh.Value.ToString());
            int result = HandleDB.Instance.ExecuteNonQuery(UpdateQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Sửa giảng viên thành công");
            }
        }
        public int GetNextID()
        {
            int nextID = 1;

            string Query = String.Empty;
            Query += "SELECT TOP 1 maGiangVien FROM GIANGVIEN ";
            Query += "ORDER BY maGiangVIen DESC";

            DataTable dt = HandleDB.Instance.ExecuteQuery(Query, null);
            if (dt.Rows.Count > 0)
            {
                Int32.TryParse(dt.Rows[0]["maGiangVien"].ToString(), out nextID);
                ++nextID;
            }
            return nextID;
        }

    }







}
