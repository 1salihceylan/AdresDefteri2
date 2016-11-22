using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ADRESDEFTERI.Data
{
    public class AdresDefteri
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public double TcNo { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        public string SoyAd { get; set; }

        [Required(ErrorMessage = "Lütfen doğum tarihinizi giriniz.")]
        public DateTime DogumTarihi
        {
            get; set;
        }

        [Required(ErrorMessage = "Lütfen adresinizi giriniz.")]
        public string Adres { get; set; }

        public virtual Il Il { get; set; }

        public virtual Ilce Ilce { get; set; }

        public virtual Ulke Ulke { get; set; }

        [MaxLength(11,ErrorMessage ="Telefon numarası 11 haneden oluşmalıdır.")]
        [MinLength(11, ErrorMessage = "Telefon numarası 11 haneden oluşmalıdır.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Lütfen telefonunuzu geçerli bir formatta giriniz.")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Uygun bir telefon numarası değil.")]
        public string Telefon { get; set; }

        public double Enlem { get; set; }

        public double Boylam { get; set; }


    }
}