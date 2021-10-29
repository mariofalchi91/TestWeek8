using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual IList<Piatto> Piattos { get; set; }
    }
}
