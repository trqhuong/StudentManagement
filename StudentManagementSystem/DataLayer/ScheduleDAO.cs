using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class ScheduleDAO: DataProvider
    {
        public List<ClassDTO> GetAllClass()
        {
            List<ClassDTO> classes = new List<ClassDTO>();
            string query = @"SELECT l.MaLop, l.TenLop 
                         FROM LOPHOC l, NAMHOC n 
                         WHERE l.NamHoc = n.MaNH AND n.TrangThai = 1";

            using (SqlDataReader reader = ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    classes.Add(new ClassDTO(
                        Convert.ToInt32(reader["MaLop"]),
                        reader["TenLop"].ToString()
                    ));
                }
            }
            return classes;
        }

        public List<SubjectDTO> GetSubject(int class_id)
        {
            List<SubjectDTO> subjects = new List<SubjectDTO>();
            string query = @"SELECT * FROM MONHOC 
                         WHERE MaMonHoc NOT IN (
                             SELECT MaMH FROM PHANCONG WHERE MaLop = @class_id
                         )";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@class_id", class_id)
            };
            using (SqlDataReader reader = ExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    subjects.Add(new SubjectDTO(
                        Convert.ToInt32(reader["MaMonHoc"]),
                        reader["TenMonHoc"].ToString()
                    ));
                }
            }
            return subjects;
        }

        public List<TeacherDTO> GetTeacher(int subject_id)
        {
            List<TeacherDTO> teachers = new List<TeacherDTO>();
            string query = @"SELECT g.MaGiaoVien, g.TenGiaoVien 
                         FROM GIAOVIEN g, GIAOVIEN_DAY_MONHOC d 
                         WHERE g.MaGiaoVien = d.MaGV AND d.MaMH = @subject_id AND g.TinhTrang = N'Đang dạy' ";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@subject_id", subject_id)
            };
            using (SqlDataReader reader = ExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    teachers.Add(new TeacherDTO(
                        Convert.ToInt32(reader["MaGiaoVien"]),
                        reader["TenGiaoVien"].ToString()
                    ));
                }
            }
            return teachers;
        }
        public bool SaveSchedule(List<ScheduleDTO> schedules)
        {
            bool allSuccess = true;
            foreach (var schedule in schedules)
            {
                string sql = @" INSERT INTO PHANCONG (MaGV, MaLop, MaMH) VALUES (@MaGV, @MaLop, @MaMH) ";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaGV", schedule.MaGV),
                    new SqlParameter("@MaLop", schedule.MaLop),
                    new SqlParameter("@MaMH", schedule.MaMH)
                };
                try
                {
                    int rowsAffected = MyExecuteNonQuery(sql, CommandType.Text, parameters);
                    if (rowsAffected <= 0)
                    {
                        allSuccess = false;
                    }
                }
                catch (Exception)
                {
                    allSuccess = false;
                }
            }
            return allSuccess;
        }
    }

}
