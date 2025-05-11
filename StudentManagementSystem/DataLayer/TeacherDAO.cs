using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TransferObject;

namespace DataLayer
{
    public class TeacherDAO : DataProvider
    {
        public List<TeacherDTO> GetAllTeacher()
        {
            List<TeacherDTO> teachers = new List<TeacherDTO>();
            string query = "SELECT gv.MaGiaoVien, gv.TenGiaoVien, gv.NgaySinh, gv.GioiTinh, gv.DienThoai, gv.TaiKhoan, gv.TinhTrang, tk.Email " +
                           "FROM GIAOVIEN gv JOIN TAIKHOAN tk ON gv.TaiKhoan = tk.MaTK";

            try
            {
                Connect();
                using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        teachers.Add(new TeacherDTO(
                            Convert.ToInt32(reader["MaGiaoVien"]),
                            reader["TenGiaoVien"].ToString(),
                            Convert.ToDateTime(reader["NgaySinh"]),
                            reader["GioiTinh"].ToString(),
                            reader["DienThoai"].ToString(),
                            Convert.ToInt32(reader["TaiKhoan"]),
                            reader["TinhTrang"].ToString(),
                            reader["Email"].ToString()
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }

            return teachers;
        }


        public int AddTeacher(TeacherDTO gv)
        {
            try
            {
                // Tạo tài khoản tạm
                int maTaiKhoan = Convert.ToInt32(MyExecuteScalar(
                    "INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan, TrangThai, Email) " +
                    "VALUES ('temp', '123456', N'Giáo viên', 0, @Email); SELECT SCOPE_IDENTITY();",
                     CommandType.Text, new List<SqlParameter>
                     {
                        new SqlParameter("@Email", gv.Email ?? (object)DBNull.Value)
                     }));

                if (maTaiKhoan <= 0) throw new Exception("Không tạo được tài khoản.");

                // Thêm giáo viên, gán tài khoản
                int maGiaoVien = Convert.ToInt32(MyExecuteScalar(
                    "INSERT INTO GIAOVIEN (TenGiaoVien, NgaySinh, GioiTinh, DienThoai, TaiKhoan) " +
                    "VALUES (@TenGiaoVien, @NgaySinh, @GioiTinh, @DienThoai, @TaiKhoan); SELECT SCOPE_IDENTITY();",
                    CommandType.Text, new List<SqlParameter>
                    {
                        new SqlParameter("@TenGiaoVien", gv.TenGV),
                        new SqlParameter("@NgaySinh", gv.NgaySinh),
                        new SqlParameter("@GioiTinh", gv.GioiTinh),
                        new SqlParameter("@DienThoai", gv.DienThoai),
                        new SqlParameter("@TaiKhoan", maTaiKhoan)
                    }));

                if (maGiaoVien <= 0) throw new Exception("Không thêm được giáo viên.");

                // Update lại tên đăng nhập
                MyExecuteNonQuery(
                    "UPDATE TAIKHOAN SET TenDangNhap = @TenDangNhap WHERE MaTK = @MaTK",
                    CommandType.Text, new List<SqlParameter>
                    {
                        new SqlParameter("@TenDangNhap", "gv00" + maGiaoVien),
                        new SqlParameter("@MaTK", maTaiKhoan)
                    });

                return maGiaoVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm giáo viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public int UpdateTeacher(TeacherDTO gv)
        {
            try
            {
                string updateQuery = "UPDATE GIAOVIEN SET TenGiaoVien=@TenGiaoVien, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, DienThoai=@DienThoai, TaiKhoan=@TaiKhoan, TinhTrang=@TinhTrang WHERE MaGiaoVien=@MaGiaoVien";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaGiaoVien", gv.MaGV),
                    new SqlParameter("@TenGiaoVien", gv.TenGV),
                    new SqlParameter("@NgaySinh", gv.NgaySinh),
                    new SqlParameter("@GioiTinh", gv.GioiTinh),
                    new SqlParameter("@DienThoai", gv.DienThoai),
                    new SqlParameter("@TaiKhoan", gv.TaiKhoan),
                    new SqlParameter("@TinhTrang", gv.TinhTrang)
                };
                string updateTaiKhoanQuery = "UPDATE TAIKHOAN SET Email = @Email WHERE MaTK = @MaTK";
                MyExecuteNonQuery(updateTaiKhoanQuery, CommandType.Text, new List<SqlParameter>
                {
                    new SqlParameter("@Email", gv.Email ?? (object)DBNull.Value),
                    new SqlParameter("@MaTK", gv.TaiKhoan)
                });

                return MyExecuteNonQuery(updateQuery, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return -1;
            }
        }

        public bool DeleteTeacher(int maGV)
        {
            try
            {
                // Lấy mã tài khoản liên kết với giáo viên
                string getAccountQuery = "SELECT TaiKhoan FROM GIAOVIEN WHERE MaGiaoVien = @MaGV";
                var getAccountParams = new List<SqlParameter>
        {
            new SqlParameter("@MaGV", maGV)
        };
                object result = MyExecuteScalar(getAccountQuery, CommandType.Text, getAccountParams);

                if (result == null || result == DBNull.Value)
                {
                    return false;
                }

                int maTaiKhoan = Convert.ToInt32(result);

                // Cập nhật tình trạng giáo viên và bỏ liên kết tài khoản
                string updateGVQuery = "UPDATE GIAOVIEN SET TinhTrang = N'Nghỉ Dạy', TaiKhoan = NULL WHERE MaGiaoVien = @MaGV";
                var updateGVParams = new List<SqlParameter>
                {
                    new SqlParameter("@MaGV", maGV)
                };
                MyExecuteNonQuery(updateGVQuery, CommandType.Text, updateGVParams);

                // Xóa tài khoản khỏi bảng TAIKHOAN
                string deleteAccountQuery = "DELETE FROM TAIKHOAN WHERE MaTK = @MaTK";
                var deleteParams = new List<SqlParameter>
                {
                    new SqlParameter("@MaTK", maTaiKhoan)
                };
                MyExecuteNonQuery(deleteAccountQuery, CommandType.Text, deleteParams);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa giáo viên: " + ex.Message);
                return false;
            }
        }
        public List<TeacherDTO> GetTeacherBySubject(int subject_id)
        {
            List<TeacherDTO> teachers = new List<TeacherDTO>();
            string query = @"SELECT g.MaGiaoVien, g.TenGiaoVien 
                         FROM GIAOVIEN g, GIAOVIEN_DAY_MONHOC d 
                         WHERE g.MaGiaoVien = d.MaGV AND d.MaMH = @subject_id AND g.TinhTrang = N'Đang dạy' ";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@subject_id", subject_id)
            };
            Connect();
            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    teachers.Add(new TeacherDTO(
                        Convert.ToInt32(reader["MaGiaoVien"]),
                        reader["TenGiaoVien"].ToString()
                    ));
                }
            }
            DisConnect();
            return teachers;
        }
    }
}
