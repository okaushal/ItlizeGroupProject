﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JOOLE.ModelsDTO
{
    public class ProductDTO
    {
        public int productID { get; set; }
        public int sub_catID { get; set; }
        public string manufName { get; set; }
        public string prodname { get; set; }
        public string prodimage { get; set; }
        public decimal price { get; set; }
        public string series { get; set; }
        public string model { get; set; }
        public int modelyear { get; set; }
        public string usetype { get; set; }
        public string applicate { get; set; }
        public string mountingloc { get; set; }
        public string accessories { get; set; }
        public Nullable<int> Airflow { get; set; }
        public Nullable<decimal> PwrMin { get; set; }
        public Nullable<decimal> PwrMax { get; set; }
        public string OperatingVoltageMin { get; set; }
        public string OperatingVoltageMax { get; set; }
        public string FanSpeedMin { get; set; }
        public string FanSpeedMax { get; set; }
        public string NumofSpeeds { get; set; }
        public string SoundAtMaxSpeed { get; set; }
        public string FanSweepDiam { get; set; }
        public string SuctionSpeed { get; set; }
        public string PipeDiameter { get; set; }
        public string Brightness { get; set; }
        public string Warranty { get; set; }
        public string HeightMin { get; set; }
        public string HeightMax { get; set; }
        public string Wght { get; set; }
    }
}