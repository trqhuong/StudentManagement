using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class ClassListDAO
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";
        public List<StudentsDTO> GetAllStudent(int classID)
        {
            List<StudentsDTO> students = new List<StudentsDTO>();
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                string query = "SELECT * FROM HOCSINH WHERE MaHocSinh in (SELECT h.MaHocSinh FROM HOCSINH_LOP hl, HOCSINH h " +
                    "where hl.MaHS = h.MaHocSinh and hl.MaLop = @classID )";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@classID", classID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new StudentsDTO(
                        Convert.ToInt32(reader["MaHocSinh"]),
                        reader["TenHocSinh"].ToString(),
                        Convert.ToDateTime(reader["NgaySinh"]),
                        reader["GioiTinh"].ToString(),
                        reader["TinhTrang"].ToString(),
                        reader["QRCodePath"].ToString()
                    ));
                }
            }
            return students;
        }

        public List<ClassDTO> GetClassTeacher(int teacherID)
        {
            List<ClassDTO> lopHoc = new List<ClassDTO>();
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                string query = "SELECT * FROM LOPHOC WHERE MaLop in (SELECT p.MaLop FROM PHANCONG p, LOPHOC l, NAMHOC m " +
                    "where p.MaLop = l.MaLop and l.NamHoc = m.MaNH and p.MaGV = @teacherID and m.TrangThai = 1)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lopHoc.Add(new ClassDTO(
                     Convert.ToInt32(reader["MaLop"]),
                     reader["TenLop"].ToString(),
                     reader["NamHoc"].ToString(),
                     reader["GVQuanLi"].ToString(),
                     Convert.ToInt32(reader["SiSo"])
                    ));
                }
            }
            return lopHoc;
        }
    }
}
