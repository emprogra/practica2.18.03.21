using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace practica2.Models
{
    public enum Paises
    {
        Bolivia,
        Brasil,
        Chile,
        Miami,
        San_Francisco,

    }
    public class Aerolinea
    {
        [Key]
        [Display(Name ="Nombre Completo")]
        [StringLength(200,MinimumLength =50,ErrorMessage ="Ingrese nombre entre 50 a 200 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(10,MinimumLength =3,ErrorMessage ="Ingrese siglas entre 3 a 10 caracteres")]
        public string Siglas { get; set; }
        [Required]
        public string Pais_de_origen { get; set; }

        [Required]
        public Paises Destinos { get; set; }


    }
}