using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserAgent.Control
{
    public abstract class Abandon
    {
        public abstract Boolean isMatch(String userAgent);
    }
}
