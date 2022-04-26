using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veicoli.Business.Models
{
   public class PersonaModel
    {
        public int IdVeicoloNoleggiato { get; set; }
        public int Id { get; set; }
            public string Nome  {get;set;}
            public  string Cognome{get;set;}
            public DateTime? DataDiNascita {get;set;}
            public  string Provincia {get;set;}
            public string Comune {get;set;}
            public string Residenza { get; set; }
            public string Telefono { get; set; }
    }
}
