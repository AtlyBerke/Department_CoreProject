﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Departman.Models
{
    public class Personel
    {
      [Key]
      public int PersonelID { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        public string PersonelSehir { get; set; }

        public Birim Birim { get; set; }
        public int BirimID { get; set; }
    }
}
