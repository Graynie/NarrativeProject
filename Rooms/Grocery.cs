using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Grocery : Room
    {
        internal override string CreateDescription()
        {
            return @"You can buy stuff here, but be caareful the owner can get 
suspicious of what you did";
        }

        internal override void ReceiveChoice(string choice)
        {
            throw new NotImplementedException();
        }
    }
}
