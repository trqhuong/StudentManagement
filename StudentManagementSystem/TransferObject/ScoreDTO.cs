﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class ScoreDTO
    {
        public int MaLop { get; set; }
        public int MaHS { get; set; }
        public int MaMH { get; set; }
        public int HocKy { get; set; }
        public float Diem15P { get; set; }
        public float Diem1T { get; set; }
        public float DiemThi { get; set; }

        public ScoreDTO(int maLop, int maHS, int maMH, int hocKy, float diem15P, float diem1T, float diemThi)
        {
            MaLop = maLop;
            MaHS = maHS;
            MaMH = maMH;
            HocKy = hocKy;
            Diem15P = diem15P;
            Diem1T = diem1T;
            DiemThi = diemThi;
        }
        public ScoreDTO(int maLop, int maHS, int maMH, float diem15P, float diem1T, float diemThi)
        {
            MaLop = maLop;
            MaHS = maHS;
            MaMH = maMH;
            Diem15P = diem15P;
            Diem1T = diem1T;
            DiemThi = diemThi;
        }
    }
}
