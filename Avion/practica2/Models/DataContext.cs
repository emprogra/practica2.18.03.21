using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace practica2.Models
{
    public class DataContext :DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<practica2.Models.Aerolinea> Aerolineas { get; set; }
    }
}