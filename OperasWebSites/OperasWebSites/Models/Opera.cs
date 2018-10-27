using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OperasWebSites.Models
{
    public class Opera
    {
        public int OperaID { get; set; }

        [Required]
        [StringLength(200 , ErrorMessage ="El título es demasiado grande. Revise los datos.")]
        public string Title { get; set; }

        [Required]
        [CheckValidYear]
        public int Year { get; set; }

        [Display(Name ="Compositor", Prompt ="Compositor")]
        [Column("nombre_compositor")]
        public string Composer { get; set; }

    }

    public class CheckValidYear : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int year = (int)value;

            if (year < 1598) return false;

            return true;
        }

        public CheckValidYear()
        {
            ErrorMessage = "La primer opera, Daphne de Corsi, Peri, y Rinuccini, data del año 1598.";

        }

    }
}