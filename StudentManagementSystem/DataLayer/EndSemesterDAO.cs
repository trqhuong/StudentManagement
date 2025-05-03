using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Windows.Forms;

namespace DataLayer
{
    public class EndSemesterDAO : DataProvider
    {
        public bool EndSemester()
        {
            try
            {
                SemesterDTO hocKy = new SemesterDTO();
                string semester = "SELECT * FROM HocKy where TrangThai = 1";
                using (SqlDataReader reader = ExecuteReader(semester, CommandType.Text))
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
                    using (SqlDataReader reader = ExecuteReader(year, CommandType.Text, parameter))
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
                    //thêm năm học mới
                    string query = @"
                    UPDATE NAMHOC SET TrangThai = 0;
                    UPDATE HOCKY SET TrangThai = 0 ;
                    INSERT INTO NAMHOC (NamBatDau, NamKetThuc, TrangThai) VALUES (@nambatdau, @namketthuc, 1);";
                    List<SqlParameter> parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@nambatdau", old_year.NamKetThuc),
                        new SqlParameter("@namketthuc", old_year.NamKetThuc + 1)
                    };
                    if ( MyExecuteNonQuery(query, CommandType.Text, parameters) > 0)
                    {
                        // thêm học kì mới 
                        string query_year = "SELECT MaNH FROM NAMHOC WHERE TrangThai = 1";
                        int new_year = Convert.ToInt32(MyExecuteScalar(query_year, CommandType.Text));
                        string insert_semester = "INSERT INTO HOCKY (SoHocKy, NamHoc) VALUES (1, @namhoc)";
                        List<SqlParameter> namhoc = new List<SqlParameter> { new SqlParameter("@namhoc", new_year) };
                        return MyExecuteNonQuery(insert_semester, CommandType.Text, namhoc) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
