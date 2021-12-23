using ApiStocksLib;
using System.ComponentModel.DataAnnotations;

namespace BagMVC.Models
{
    public class SearchMyStocksViewModel
    {
        [Required]
        public string Text { get; set; }

        public RootBestMatches rootBestMatches { get; set; }
    }
}
