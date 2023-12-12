using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyXeDap
{
    internal class ChinhSuaDuLieu
    {
        KetNoi dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public ChinhSuaDuLieu()
        {
            dc = new KetNoi();
        }
        public DataTable getAllXe()
        {
            string sql = "select * from tblXeDap";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool insertXe(XeDap d)
        {
            string sql = "insert into tblXeDap(colMa, colTen, colHang, colXuatXu, colSoluong, colGia, colTien, colHinhAnh) values(@colMa, @colTen, @colHang, @colXuatXu, @colSoluong, @colGia, @colTien, @colHinhAnh)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@colMa", SqlDbType.NVarChar).Value = d.Ma;
                cmd.Parameters.Add("@colTen", SqlDbType.NVarChar).Value = d.Ten;
                cmd.Parameters.Add("@colHang", SqlDbType.NVarChar).Value = d.Hang;
                cmd.Parameters.Add("@colXuatXu", SqlDbType.NVarChar).Value = d.XuatXu;
                cmd.Parameters.Add("@colSoluong", SqlDbType.Int).Value = d.SoLuong;
                cmd.Parameters.Add("@colGia", SqlDbType.Float).Value = d.Gia;
                cmd.Parameters.Add("@colTien", SqlDbType.Float).Value = d.Tien;
                cmd.Parameters.Add("@colHinhAnh", SqlDbType.VarBinary).Value = d.HinhAnh;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            CapNhatTon();
            return true;
        }
        public bool updateXe(XeDap d)
        {
            string sql = "update  tblXeDap set colTen = @colTen, colHang = @colHang, colXuatXu = @colXuatXu, colSoluong = @colSoluong, colGia = @colGia, colTien = @colTien, colHinhAnh = @colHinhAnh where colMa = @colMa";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@colMa", SqlDbType.NVarChar).Value = d.Ma;
                cmd.Parameters.Add("@colTen", SqlDbType.NVarChar).Value = d.Ten;
                cmd.Parameters.Add("@colHang", SqlDbType.NVarChar).Value = d.Hang;
                cmd.Parameters.Add("@colXuatXu", SqlDbType.NVarChar).Value = d.XuatXu;
                cmd.Parameters.Add("@colSoluong", SqlDbType.Int).Value = d.SoLuong;
                cmd.Parameters.Add("@colGia", SqlDbType.Float).Value = d.Gia;
                cmd.Parameters.Add("@colTien", SqlDbType.Float).Value = d.Tien;
                cmd.Parameters.Add("@colHinhAnh", SqlDbType.VarBinary).Value = d.HinhAnh;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            CapNhatTon();
            return true;
        }
        public bool delXe(XeDap d)
        {
            string sql = "delete tblXeDap where colMa = @colMa";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@colMa", SqlDbType.NVarChar).Value = d.Ma;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            CapNhatTon();
            return true;
        }
        public DataTable findXe(string key)
        {
            string sql = "select * from tblXeDap where colTen like N'%" + key + "%' or colHang like N'%" + key + "%' or colMa like N'%" + key + "%' or colXuatXu like N'%" + key + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool DangKy(string username, string password)
        {
            string sql = "insert into tblTaiKhoan(username, password, is_admin) values(@username, @password, 0)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool DangNhap(string username, string password)
        {
            string flag = "";
            string sql = "select count(1) from tblTaiKhoan where username = @username and password = @password";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                flag = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            if (flag == "1")
                return true;
            else
                return false;
        }

        public bool insertHoaDon(HoaDon d)
        {
            string sql = "insert into tblHoaDon(maHoaDon, khachHang, tongTien, ngay, thoigian) values (@maHoaDon, @khachHang, @tongTien, @ngay, @thoigian)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@maHoaDon", SqlDbType.NVarChar).Value = d.MaHoaDon;
                cmd.Parameters.Add("@khachHang", SqlDbType.NVarChar).Value = d.KhachHang;
                cmd.Parameters.Add("@tongTien", SqlDbType.NVarChar).Value = d.TongTien;
                cmd.Parameters.Add("@ngay", SqlDbType.NVarChar).Value = d.Ngay;
                cmd.Parameters.Add("@thoigian", SqlDbType.NVarChar).Value = d.Thoigian;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool insertHoaDonChiTiet(HoaDon d)
        {
            SqlConnection con = dc.getConnect();
            try
            {
                con.Open();
                foreach(XeDap xe in d.DanhSachXe)
                {
                    string sql = "insert into tblHoaDonChiTiet(maHoaDon, colMa, colTen, colHang, colXuatXu, colSoLuong, colGia, colTien, colTon, colHinhAnh) " +
                        "values (@maHoaDon, @colMa, @colTen, @colHang, @colXuatXu, @colSoLuong, @colGia, @colTien, @colTon, @colHinhAnh)";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@maHoaDon", SqlDbType.NVarChar).Value = d.MaHoaDon;
                    cmd.Parameters.Add("@colMa", SqlDbType.NVarChar).Value = xe.Ma;
                    cmd.Parameters.Add("@colTen", SqlDbType.NVarChar).Value = xe.Ten;
                    cmd.Parameters.Add("@colHang", SqlDbType.NVarChar).Value = xe.Hang;
                    cmd.Parameters.Add("@colXuatXu", SqlDbType.NVarChar).Value = xe.XuatXu;
                    cmd.Parameters.Add("@colSoLuong", SqlDbType.NVarChar).Value = xe.SoLuong;
                    cmd.Parameters.Add("@colGia", SqlDbType.NVarChar).Value = xe.Gia;
                    cmd.Parameters.Add("@colTien", SqlDbType.NVarChar).Value = xe.Tien;
                    cmd.Parameters.Add("@colTon", SqlDbType.NVarChar).Value = xe.Ton;
                    cmd.Parameters.Add("@colHinhAnh", SqlDbType.VarBinary).Value = xe.HinhAnh;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            CapNhatTon();
            return true;
        }

        public DataTable getAllHoaDon ()
        {
            string sql = "select * from tblHoaDon";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getAllHoaDonChiTiet(string maHoaDon)
        {
            string sql = "select colMa, colTen, colHang, colXuatXu, colSoLuong, colGia, colTien, colTon, colHinhAnh from tblHoaDonChiTiet where maHoaDon = '" + maHoaDon + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public List<XeDap> getListHoaDonChiTiet(string maHoaDon)
        {
            List<XeDap> returnList = new List<XeDap>();
            string sql = "select colMa as Ma, colTen as Ten, colHang as Hang, colXuatXu as XuatXu, colSoLuong as SoLuong, colGia as Gia, colTien as Tien, colTon as Ton, colHinhAnh as HinhAnh from tblHoaDonChiTiet where maHoaDon = '" + maHoaDon + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            foreach (DataRow r in dt.Rows)
            {
                XeDap xe = new XeDap();
                xe.Ma = r["Ma"].ToString();
                xe.Ten = r["Ten"].ToString();
                xe.Hang = r["Hang"].ToString();
                xe.XuatXu = r["XuatXu"].ToString();
                xe.SoLuong = Convert.ToInt32(r["SoLuong"]);
                xe.Ton = Convert.ToInt32(r["Ton"]);
                xe.Gia = Convert.ToDecimal(r["Gia"]);
                xe.Tien = Convert.ToDecimal(r["Tien"]);
                xe.HinhAnh = (byte[])r["HinhAnh"];
                returnList.Add(xe);
            }
            return returnList;
        }

        public bool delHoaDon(string maHoaDon)
        {
            string sql = @"delete from tblHoaDon where maHoaDon = '" + maHoaDon + "';" +
                "delete from tblHoaDonChiTiet where maHoaDon = '" + maHoaDon + "'";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            CapNhatTon();
            return true;
        }

        public bool updateHoaDonChiTiet(HoaDon d)
        {
            SqlConnection con = dc.getConnect();
            try
            {
                con.Open();
                cmd = new SqlCommand("update tblHoaDon set khachHang = @khachHang, tongTien = @tongTien, ngay = @ngay, thoigian = @thoigian where maHoaDon = @maHoaDon; delete from tblHoaDonChiTiet where maHoaDon = @maHoaDon;", con);
                cmd.Parameters.Add("@maHoaDon", SqlDbType.NVarChar).Value = d.MaHoaDon;
                cmd.Parameters.Add("@khachHang", SqlDbType.NVarChar).Value = d.KhachHang;
                cmd.Parameters.Add("@tongTien", SqlDbType.NVarChar).Value = d.TongTien;
                cmd.Parameters.Add("@ngay", SqlDbType.NVarChar).Value = d.Ngay;
                cmd.Parameters.Add("@thoigian", SqlDbType.NVarChar).Value = d.Thoigian;
                cmd.ExecuteNonQuery();

                foreach (XeDap xe in d.DanhSachXe)
                {
                    string sql = "insert into tblHoaDonChiTiet(maHoaDon, colMa, colTen, colHang, colXuatXu, colSoLuong, colGia, colTien, colTon) " +
                        "values (@maHoaDon, @colMa, @colTen, @colHang, @colXuatXu, @colSoLuong, @colGia, @colTien, @colTon)";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@maHoaDon", SqlDbType.NVarChar).Value = d.MaHoaDon;
                    cmd.Parameters.Add("@colMa", SqlDbType.NVarChar).Value = xe.Ma;
                    cmd.Parameters.Add("@colTen", SqlDbType.NVarChar).Value = xe.Ten;
                    cmd.Parameters.Add("@colHang", SqlDbType.NVarChar).Value = xe.Hang;
                    cmd.Parameters.Add("@colXuatXu", SqlDbType.NVarChar).Value = xe.XuatXu;
                    cmd.Parameters.Add("@colSoLuong", SqlDbType.NVarChar).Value = xe.SoLuong;
                    cmd.Parameters.Add("@colGia", SqlDbType.NVarChar).Value = xe.Gia;
                    cmd.Parameters.Add("@colTien", SqlDbType.NVarChar).Value = xe.Tien;
                    cmd.Parameters.Add("@colTon", SqlDbType.NVarChar).Value = xe.Ton;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            CapNhatTon();
            return true;
        }

        public bool CapNhatTon()
        {
            SqlConnection con = dc.getConnect();
            string sql = @"
                            update tblXeDap set colTon = b.so_luong 
                            from (
                                    select colMa, sum(colSoluong) as so_luong
                                    from 
                                    (
                                        select colMa, colSoluong from tblXeDap
                                        union all 
                                        select colMa, -colSoluong from tblHoaDonChiTiet
                                    ) c
		                            group by colMa
                                ) b
                            where tblXeDap.colMa = b.colMa";
            try
            {
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
