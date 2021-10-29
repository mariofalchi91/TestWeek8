using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Models
{
    public enum Tipologia
    {
        Primo,
        Secondo,
        Contorno,
        Dolce
    }
    public class PiattoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Tipologia Tipologia { get; set; }
        public decimal Prezzo { get; set; }
        public int MenuId { get; set; }
    }
}
