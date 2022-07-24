using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wikipedia
{
    internal class Result
    {
            public int totalFoundLinks { get; set; }
            public int uniqueLinks { get; set; }
            public List<string> allFoundLinks { get; set; }
    }
}
