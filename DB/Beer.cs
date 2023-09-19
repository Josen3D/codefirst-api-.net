using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Beer
    {
        [Key] // indicamos que es una primary key el campo.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // indicamos que el campo sea auto incrementable.
        public int BeerID { get; set; }
        public string Name { get; set; }
        public int BrandID { get; set; }
        [ForeignKey("BrandID")] // indicamos que el campo es una llave foránea. agregando además el campo public virtual Brand, 
        // que es la clase a la que hace referencia esta llave foránea.
        public virtual Brand? Brand { get; set; }

    }
}
