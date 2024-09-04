using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class Person
    {
        protected string Name { get; set; }
        protected List<Haki> Skills { get; set; }

        protected long Bounty { get; set; }

        public long GetBounty()
        {
            return Bounty;
        }
    }
}
