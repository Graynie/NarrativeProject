using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Closet : Room
    {

        internal override string CreateDescription()
        {
            return @"The closet is filled with coats, and it's somewhat messy and dusty";
        }

        internal override void ReceiveChoice(string choice)
        {
            throw new NotImplementedException();
        }
    }
}
