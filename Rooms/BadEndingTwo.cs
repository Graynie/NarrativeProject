using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class BadEndingTwo : Room
    {

        internal override string CreateDescription()
        {
            return @"As the police arrive and enter the living room, their expressions shift from curiosity to grim realization. Their eyes narrow as they take in the scene—the lifeless body of your husband.
The lead officer's gaze locks onto you, suspicion etched on his face as he begins to piece together what has happened.
You feel a knot form in your stomach as the weight of their scrutiny bears down on you, knowing that they have caught onto the truth:
you are the one who killed your husband. The room feels suffocatingly silent as the gravity of the situation sinks in, and you brace yourself for the inevitable consequences of your actions.
Reason why you failed:" +Failed();
            
        }

        internal override void ReceiveChoice(string choice)
        {
            throw new NotImplementedException();
        }
        internal string Failed()
        {

        }
    }
}
