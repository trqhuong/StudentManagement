using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class SemesterDAO : DataProvider
    {
        public List<SemesterDTO> GetAllHocKy()
        {
            List<SemesterDTO> list = new List<SemesterDTO>();
            string sql = "SELECT * FROM HOCKY";
            try
            {
                Connect();
                using (SqlDataReader reader = MyExecuteReader(sql, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        SemesterDTO hk = new SemesterDTO
                        {
                            MaHK = Convert.ToInt32(reader["MaHK"]),
                            SoHocKy = Convert.ToInt32(reader["SoHocKy"]),
                            NamHoc = Convert.ToInt32(reader["NamHoc"]),
                            TrangThai = Convert.ToBoolean(reader["TrangThai"])
                        };

                        list.Add(hk);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy học kỳ: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return list;
        }
        public bool EndSemester()
        {
            SemesterDTO hocKy = new SemesterDTO();
            string semester = "SELECT * FROM HocKy where TrangThai = 1";
            Connect();
            using (SqlDataReader reader = MyExecuteReader(semester, CommandType.Text))
            {
                if (reader.Read())
                {
                    hocKy = new SemesterDTO(
                        Convert.ToInt32(reader["MaHK"]),
                        Convert.ToInt32(reader["SoHocKy"]),
                        Convert.ToInt32(reader["NamHoc"])
                    );
                }
                else
                {
                    return false;
                }
            }
            DisConnect();
            if (hocKy.SoHocKy == 1)
            {
                string query = @"
                    INSERT INTO HOCKY (SoHocKy, NamHoc) VALUES (2, @namhoc);
                    UPDATE HOCKY SET TrangThai = 0 WHERE MaHK = @mahk;";
                List<SqlParameter> parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@namhoc", hocKy.NamHoc),
                        new SqlParameter("@mahk", hocKy.MaHK)
                    };
                return MyExecuteNonQuery(query, CommandType.Text, parameters) > 0;
            }
            else
            {
                // Đang là học kỳ 2, chuyển sang năm học mới
                //lấy năm học cũ
                SchoolYearDTO old_year = new SchoolYearDTO();
                string year = "SELECT * FROM NAMHOC where MaNH = @namhoc ";
                List<SqlParameter> parameter = new List<SqlParameter>
                    {
                        new SqlParameter("@namhoc", hocKy.NamHoc)
                    };
                Connect();
                using (SqlDataReader reader = MyExecuteReader(year, CommandType.Text, parameter))
                {
                    if (reader.Read())
                    {
                        old_year = new SchoolYearDTO(
                            Convert.ToInt32(reader["MaNH"]),
                            Convert.ToInt32(reader["NamBatDau"]),
                            Convert.ToInt32(reader["NamKetThuc"])
                        );
                    }
                    else
                    {
                        return false;
                    }
                }
                DisConnect();
                //thêm năm học mới
                string query = @"
                        UPDATE NAMHOC SET TrangThai = 0;
                        UPDATE HOCKY SET TrangThai = 0;
                        INSERT INTO NAMHOC (NamBatDau, NamKetThuc, TrangThai)
                        VALUES (@nambatdau, @namketthuc, 1);
                        SELECT SCOPE_IDENTITY();";
                List<SqlParameter> parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@nambatdau", old_year.NamKetThuc),
                        new SqlParameter("@namketthuc", old_year.NamKetThuc + 1)
                    };
                // Lấy MaNH mới thêm
                int new_year = Convert.ToInt32(MyExecuteScalar(query, CommandType.Text, parameters));
                string insert_semester = "INSERT INTO HOCKY (SoHocKy, NamHoc) VALUES (1, @namhoc)";
                List<SqlParameter> namhoc = new List<SqlParameter> { new SqlParameter("@namhoc", new_year) };
                if (MyExecuteNonQuery(insert_semester, CommandType.Text, namhoc) > 0)
                {
                    UpgradeClass(old_year, new_year);
                    return true;
                }
                else
                    return false;
            }
        }
        public void UpgradeClass(SchoolYearDTO old_year, int new_year)
        {
            //bắt đầu tiến hành upgrade class -> lấy các lớp năm học cũ, lấy học sinh của lớp
            List<ClassDTO> classes = new List<ClassDTO>();
            string query_class = "SELECT * FROM LOPHOC where NamHoc = @namhoc ";
            List<SqlParameter> p_class = new List<SqlParameter>
            {
                new SqlParameter("@namhoc", old_year.MaNH)
            };
            Connect();
            using (SqlDataReader reader = MyExecuteReader(query_class, CommandType.Text, p_class))
            {
                while (reader.Read())
                {
                    classes.Add(new ClassDTO(
                        Convert.ToInt32(reader["MaLop"]),
                        reader["TenLop"].ToString(),
                        Convert.ToInt32(reader["Khoi"])

                    ));
                }
            }
            DisConnect();
            foreach (var c in classes)
            {
                List<StudentsDTO> students = new List<StudentsDTO>();
                string query_student = "SELECT * FROM HOCSINH where MaHocSinh IN " +
                    "( SELECT MaHS FROM HOCSINH_LOP Where MaLop = @malop )";
                List<SqlParameter> p_student = new List<SqlParameter>
                {
                    new SqlParameter("@malop", c.MaLop)
                };
                Connect();
                using (SqlDataReader reader = MyExecuteReader(query_student, CommandType.Text, p_student))
                {
                    while (reader.Read())
                    {
                        students.Add(new StudentsDTO(
                            Convert.ToInt32(reader["MaHocSinh"]),
                            reader["TenHocSinh"].ToString()
                        ));
                    }
                }
                DisConnect();
                if (c.Khoi != 12)
                {
                    string new_class = (c.Khoi + 1).ToString() + ((char)(c.TenLop[2] + 1)).ToString() + c.TenLop[3];
                    string q_new_class = "INSERT INTO LOPHOC (TenLop, Khoi, SiSo, NamHoc) OUTPUT INSERTED.MaLop VALUES (@new_class,@khoi, 0, @new_year)";
                    List<SqlParameter> p_new_class = new List<SqlParameter>
                    {
                        new SqlParameter("@new_class", new_class),
                        new SqlParameter("@new_year", new_year),
                        new SqlParameter("@khoi", c.Khoi + 1)
                    };
                    int new_class_id = Convert.ToInt32(MyExecuteScalar(q_new_class, CommandType.Text, p_new_class));
                    if (new_class_id != 0)
                    {
                        bool result;
                        foreach (var s in students)
                        {
                            result = FinalScore(s.MaHS, c.MaLop);
                            if (result)
                            {
                                string query = @" INSERT INTO HOCSINH_LOP (MaHS, MaLop) VALUES (@mahs, @malopmoi);
                                               UPDATE LOPHOC SET SiSo = SiSo + 1 WHERE MaLop = @malopmoi ";
                                List<SqlParameter> parameter = new List<SqlParameter>
                                {
                                    new SqlParameter("@malopmoi",new_class_id ),
                                    new SqlParameter("@mahs", s.MaHS)
                                };
                                int r = MyExecuteNonQuery(query, CommandType.Text, parameter);
                            }
                        }
                    }
                }
                else
                {
                    bool result;
                    foreach (var s in students)
                    {
                        result = FinalScore(s.MaHS, c.MaLop);
                        if (result)
                        {
                            string query = @"UPDATE HOCSINH SET TinhTrang = N'Hoàn thành' WHERE MaHocSinh = @mahs ";
                            List<SqlParameter> parameter = new List<SqlParameter>
                                {
                                    new SqlParameter("@mahs", s.MaHS)
                                };
                            int r = MyExecuteNonQuery(query, CommandType.Text, parameter);
                        }
                    }
                }
            }
        }

        public bool FinalScore(int mahs, int malop_cu)
        {
            float final_score = 0;
            int count = Convert.ToInt32(MyExecuteScalar("Select count(*) from MONHOC", CommandType.Text));
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@malop", malop_cu),
                new SqlParameter("@mahs", mahs)
            };
            Connect();
            using (SqlDataReader reader = MyExecuteReader("sp_FinalScore", CommandType.StoredProcedure, parameters))
            {
                while (reader.Read())
                {
                    final_score += Convert.ToInt32(reader["DiemTBCaNam"]);
                }
            }
            DisConnect();
            if (final_score / count > 3.5)
                return true;
            else
                return false;
        }
        public List<SchoolYearDTO> GetAllYear()
        {
            List<SchoolYearDTO> years = new List<SchoolYearDTO>();
            string query = "SELECT * FROM NAMHOC";
            Connect();
            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    years.Add(new SchoolYearDTO(
                        Convert.ToInt32(reader["MaNH"]),
                        Convert.ToInt32(reader["NamBatDau"]),
                        Convert.ToInt32(reader["NamKetThuc"]),
                        Convert.ToBoolean(reader["TrangThai"])
                    ));
                }
            }
            DisConnect();
            return years;
        }
        public List<SemesterDTO> GetAllSemester()
        {
            List<SemesterDTO> semesters = new List<SemesterDTO>();
            string query = "SELECT * FROM HOCKY";
            Connect();
            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    semesters.Add(new SemesterDTO(
                        Convert.ToInt32(reader["MaHK"]),
                        Convert.ToInt32(reader["SoHocKy"]),
                        Convert.ToInt32(reader["NamHoc"]),
                        Convert.ToBoolean(reader["TrangThai"])
                    ));
                }
            }
            DisConnect();
            return semesters;
        }
    }
}
