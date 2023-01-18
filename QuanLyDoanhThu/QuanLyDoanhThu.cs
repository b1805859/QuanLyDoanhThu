﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoanhThu
{
    internal class QuanLyDoanhThu
    {
        private string _tenCLB;
        private string _tenNuoc;
        private int _slVe;
        private double _giaVe;

        public QuanLyDoanhThu()
        {
        }

        public QuanLyDoanhThu(string tenCLB, string tenNuoc, int slVe, double giaVe)
        {
            TenCLB = tenCLB;
            TenNuoc = tenNuoc;
            SlVe = slVe;
            GiaVe = giaVe;
        }

        public string TenCLB { get => _tenCLB; set => _tenCLB = value; }
        public string TenNuoc { get => _tenNuoc; set => _tenNuoc = value; }
        public int SlVe { get => _slVe; set => _slVe = value; }
        public double GiaVe { get => _giaVe; set => _giaVe = value; }



        public double DoanhThu()
        {
            return SlVe * GiaVe;
        }
    }
}
