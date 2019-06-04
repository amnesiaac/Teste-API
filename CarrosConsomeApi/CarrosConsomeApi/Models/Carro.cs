using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrosConsomeApi.Models
{
    public class Carro
    {
        public int CarroId { get; set; }
        public string Marca { get; set; }
        public string Nome { get; set; }
        public int AnoFabricacao { get; set; }
        public int QuantPortas { get; set; }
        public string Motor { get; set; }
    }
}