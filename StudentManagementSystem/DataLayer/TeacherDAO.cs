using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace DataLayer
{
    public class TeacherDAO
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";
        public List<TeacherDTO> GetAllTeacher()
        {
            List<TeacherDTO> teachers = new List<TeacherDTO>();
            try
            {
                using (SqlConnection connect = new SqlConnection(cnn))
                {
                    connect.Open();
                    //lay du lieu giao vien
                    string query = "SELECT gv.MaGiaoVien,gv.TenGiaoVien,gv.NgaySinh,gv.GioiTinh,gv.DienThoai,gv.TaiKhoan,gv.TinhTrang FROM GIAOVIEN gv";


                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
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
                                reader["TinhTrang"].ToString()));

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                Console.WriteLine("Error: " + ex.Message);
            }

            return teachers;
        }
        public int AddTeacher(TeacherDTO gv)
        {
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // 1. Thêm giáo viên
                    string query = "INSERT INTO GIAOVIEN (TenGiaoVien, NgaySinh, GioiTinh, DienThoai) " +
                                   "VALUES (@TenGiaoVien, @NgaySinh, @GioiTinh, @DienThoai); " +
                                   "SELECT SCOPE_IDENTITY();"; // SCOPE_IDENTITY() lấy MaGiaoVien mới

                    int maGiaoVien;
                    int taiKhoan = 0; // Giá trị mặc định cho TaiKhoan (sẽ được tính sau khi có MaGiaoVien)

                    using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@TenGiaoVien", gv.TenGV);
                        cmd.Parameters.AddWithValue("@NgaySinh", gv.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gv.GioiTinh);
                        cmd.Parameters.AddWithValue("@DienThoai", gv.DienThoai);

                        // Lấy MaGiaoVien sau khi insert vào bảng GIAOVIEN
                        maGiaoVien = Convert.ToInt32(cmd.ExecuteScalar());
                        taiKhoan = maGiaoVien; // Gán taiKhoan là MaGiaoVien
                    }

                    // 2. Cập nhật tài khoản trong bảng GIAOVIEN
                    string updateQuery = "UPDATE GIAOVIEN SET TaiKhoan = @TaiKhoan WHERE MaGiaoVien = @MaGiaoVien";

                    using (SqlCommand cmd2 = new SqlCommand(updateQuery, conn, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
                        cmd2.Parameters.AddWithValue("@MaGiaoVien", maGiaoVien);
                        cmd2.ExecuteNonQuery();
                    }

                    // 3. Thêm vào bảng TAIKHOAN
                    string insertAccount = "INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan, TrangThai) " +
                                           "VALUES (@TenDangNhap, @MatKhau, @LoaiTaiKhoan, @TrangThai)";

                    string tenDangNhap = "gv00" + taiKhoan; // Tạo tên đăng nhập mặc định (có thể thay đổi logic nếu cần)

                    using (SqlCommand cmd3 = new SqlCommand(insertAccount, conn, transaction))
                    {
                        cmd3.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd3.Parameters.AddWithValue("@MatKhau", "123456"); // Mật khẩu mặc định
                        cmd3.Parameters.AddWithValue("@LoaiTaiKhoan", "Giáo viên");
                        cmd3.Parameters.AddWithValue("@TrangThai", 0);
                        cmd3.ExecuteNonQuery();
                    }

                    // Commit giao dịch nếu mọi thứ thành công
                    transaction.Commit();

                    // Trả về mã giáo viên vừa thêm
                    return maGiaoVien;
                }
                catch (Exception ex)
                {
                    // Rollback giao dịch nếu có lỗi
                    transaction.Rollback();

                    // Ghi lỗi chi tiết vào MessageBox và log
                    MessageBox.Show($"Lỗi khi thêm giáo viên:\n{ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Log chi tiết lỗi vào Console
                    Console.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");

                    return -1; // Trả về -1 nếu có lỗi
                }
            }
        }

        public int UpdateTeacher(TeacherDTO gv)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cnn))
                {
                    conn.Open();

                    string updateQuerry = "UPDATE GIAOVIEN " +
                      "SET TenGiaoVien=@TenGiaoVien, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, DienThoai=@DienThoai, TaiKhoan=@TaiKhoan,TinhTrang=@TinhTrang " +
                      "WHERE MaGiaoVien=@MaGiaoVien";


                    using (SqlCommand cmd = new SqlCommand(updateQuerry, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaGiaoVien", gv.MaGV);
                        cmd.Parameters.AddWithValue("@TenGiaoVien", gv.TenGV);
                        cmd.Parameters.AddWithValue("@NgaySinh", gv.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gv.GioiTinh);
                        cmd.Parameters.AddWithValue("@DienThoai", gv.DienThoai);
                        cmd.Parameters.AddWithValue("@TaiKhoan", gv.TaiKhoan);
                        cmd.Parameters.AddWithValue("@TinhTrang", gv.TinhTrang);
                        return cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1; // Trả về -1 nếu có lỗi
            }
        }
        public bool DeleteTeacher(int maGV)
        {
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Cập nhật tình trạng giáo viên
                    string updateStatusQuery = "UPDATE GIAOVIEN SET TinhTrang = N'Nghỉ Dạy' WHERE MaGiaoVien = @MaGV";
                    using (SqlCommand cmd1 = new SqlCommand(updateStatusQuery, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@MaGV", maGV);
                        cmd1.ExecuteNonQuery();
                    }
                    transaction.Commit();

                    // 2. Xóa tài khoản giáo viên
                    string tenDangNhap = "gv" + maGV.ToString("D3");
                    string deleteAccountQuery = "DELETE FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap";

                    using (SqlCommand cmd2 = new SqlCommand(deleteAccountQuery, conn, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd2.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi xóa giáo viên: " + ex.Message);
                    return false;
                }
            }
        }


    }
}