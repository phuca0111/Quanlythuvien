﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace qltv.Models
{
    public partial class Thuthu
    {
        public Thuthu()
        {
            Muons = new HashSet<Muon>();
            Tras = new HashSet<Tra>();
        }

        public int ThuthuId { get; set; }
        public string Hoten { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Matkhau { get; set; }

        public virtual ICollection<Muon> Muons { get; set; }
        public virtual ICollection<Tra> Tras { get; set; }
    }
}