using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADRESDEFTERI.Data
{
    public class Ilce
    {

        [Key]
        public int Id { get; set; }

        public string Ad { get; set; }

        public virtual Il Il { get; set; }
        
    }
}