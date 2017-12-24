using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICT13580075EndB.Models
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(200)]
        public String Type { get; set; }
        public String Brand { get; set; }
        public String Gen { get; set; }
        public int Year { get; set; }
        public decimal Mile { get; set; }
        public String Color { get; set; }
        public String Dealer { get; set; }
        public String Detail { get; set; }
        public decimal Price { get; set; }
        public String City { get; set; }
        public String Phone { get; set; }

    }
}
