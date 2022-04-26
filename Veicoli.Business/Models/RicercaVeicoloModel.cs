using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliBusiness.Models
{
    public class RicercaVeicoloModel
    {
     
        public int Id { get; set; }
        public int IdMarca {get;set;}
        public string Marca { get; set; }
        public string Modello {get;set;}
        public string Targa {get;set;}
        public DateTime? ImmatricolazioneDa {get;set;}
        public DateTime? ImmatricolazioneA {get;set;}
        public string Noleggiato { get; set; }


    }
}
