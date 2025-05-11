using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class ClassListDAO : DataProvider
    {
        public List<StudentsDTO> GetAllStudent(int classID)
        {
            List<StudentsDTO> students = new List<StudentsDTO>();
            string query = "SELECT * FROM HOCSINH WHERE MaHocSinh in (SELECT h.MaHocSinh FROM HOCSINH_LOP hl, HOCSINH h " +
                    "where hl.MaHS = h.MaHocSinh and hl.MaLop = @classID )";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@classID", classID)
            };
            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text, parameters))
            {
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

        public List<ClassDTO> GetClassTeacher()
        {
            List<ClassDTO> lopHoc = new List<ClassDTO>();
            // Lấy mã giáo viên
            int teacher_id = Convert.ToInt32(MyExecuteScalar("sp_GetTeacherActive", CommandType.StoredProcedure));
            //lấy lớp
            string query = @"SELECT l.* FROM LOPHOC l
                     INNER JOIN PHANCONG p ON p.MaLop = l.MaLop
                     INNER JOIN NAMHOC m ON l.NamHoc = m.MaNH
                     WHERE p.MaGV = @teacherID AND m.TrangThai = 1";
            List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@teacherID", teacher_id)
                };
            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text, parameters))
            {
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
