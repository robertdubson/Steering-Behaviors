﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class Wolf : IActor
    {
        public Point Position { get; set; }
        public float SpeedLimit { get; set; }
    }
}