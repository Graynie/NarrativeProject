using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Closet
    {
        internal class BadEndingTwo : Room
        {

            internal override string CreateDescription()
            {
                return @"The garage is filled with boxes, but the space for the car is empty";
            }

            internal override void ReceiveChoice(string choice)
            {
                throw new NotImplementedException();
            }
        }
    }
}
