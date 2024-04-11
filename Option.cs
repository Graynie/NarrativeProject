using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject
{
    internal abstract class Option
    {
        internal abstract string CreateDescription();
        internal abstract void ReceiveChoice(string choice);
    }
}

