using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADRESDEFTERI.Data
{
    public class Il
    {
        [Key]
        public int Id { get; set; }

        public string Ad { get; set; }

        public virtual Ulke Ulke { get; set; }


    }
}