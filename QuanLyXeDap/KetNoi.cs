using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyXeDap
{
    internal class KetNoi
    {
        string conStr;
        public KetNoi()
        {
            //conStr = @"Data Source=DONGNP-DA\SQLEXPRESS;Initial Catalog=DONGNP;Integrated Security=True";
            conStr = @"Data Source=DESKTOP-TMQ39CO\NGUYENQUOCMANH;Initial Catalog=QuanLyXeDap;Integrated Security=True";
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
