using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWEB.Models
{
    public class IndexViewModel
    {
        public PageViewModel PageViewModel { get; set; }
        public IEnumerable<Page> Pages { get; set; }
    }
}
