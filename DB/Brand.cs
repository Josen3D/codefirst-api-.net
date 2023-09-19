using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Brand
    {
        [Key] // indicamos que es una primary key el campo.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // indicamos que el campo sea auto incrementable.
        public int BrandID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Beer> Beers { get; set; } // creamos una colección de cervezas.
    }
}
