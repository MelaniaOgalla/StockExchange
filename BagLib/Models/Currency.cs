using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagLib.Models
{

    public class Currency
    {
        public Currency()
        {
            Markets = new HashSet<Market>();
            Countries = new HashSet<Country>();
        }
        public Currency(string code, string name, string symbol)
        {
            Markets = new HashSet<Market>();
            Countries = new HashSet<Country>();
            Code = code;
            Name = name;
            Symbol = symbol;
        }

        public int CurrencyId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public string Symbol { get; set; }

        public ICollection<Market> Markets { get; set; }

        public ICollection <Country> Countries { get; set;}

    }
}
