using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiForneceCarro.Models
{
    public class Pneu
    {
        public int PneuId { get; set; }
        public string Marca { get; set; }
        public int Aro { get; set; }
        public int CarroId { get; set; }
        public virtual Carro Carro { get; set; }
    }
}