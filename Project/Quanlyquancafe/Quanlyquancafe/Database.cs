using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlyquancafe
{
    internal class Database
    {
        private string connectionString = @"Server=DESKTOP-FOORN5L\SQLEXPRESS;Database=QuanLyQuanCafe;Trusted_Connection=True;";
        private SqlConnection conn;
        private DataTable dt;
        private SqlCommand cmd;
        //hàm dựng
        public Database()
        {
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("connected failed: " + ex.Message);
            }
        }
        //hàm truy vấn dữ liệu
        public DataTable SelectData(string sql, List<CustomParameter> lstPara = null)
        {
            try
            {
                conn.Open();//mo ket noi
                cmd = new SqlCommand(sql, conn); //ndung sql duoc truyen
                cmd.CommandType = CommandType.StoredProcedure;
                if (lstPara != null)
                {
                    foreach (var para in lstPara)//gan cac tham so cho cmd
                    {
                        cmd.Parameters.AddWithValue(para.key, para.value);
                    }
                }

                dt = new DataTable();
                dt.Load(cmd.ExecuteReader()); // đổ dlieu
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        //hàm thêm , update dlieu, trả về bảng dl
        public int ExeCute(string sql, List<CustomParameter> lstPara = null)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in lstPara)//gan cac tham so cho cmd
                {
                    cmd.Parameters.AddWithValue(p.key, p.value);
                }
                var rs = cmd.ExecuteNonQuery(); // lấy kqua thực thi truy vấn
                return rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi câu lệnh: " + ex.Message);
                return -100;
            }
            finally
            {
                conn.Close();
            }
        }
        //trả về 1 dòng dlieu
        public DataRow Select(string sql)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);// truyền gtri vào cmd
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader()); //thực thi câu lệnh
                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thông tin chi tiết: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }

    public class CustomParameter
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
