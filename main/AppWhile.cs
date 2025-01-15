using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOOSE;

namespace main
{
    /// <summary>
    /// Represents the "while" loop command in the application. Inherits from <see cref="While"/>.
    /// This command is used to execute a set of actions as long as a certain condition holds true.
    /// </summary>
    public class AppWhile : While
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppWhile"/> class.
        /// This constructor sets the restrictions for the while loop command.
        /// </summary>
        public AppWhile()
        {
            ReduceRestrictions();
        }

        /// <summary>
        /// Defines the restrictions that apply to the while loop command.
        /// This method can be customized to define specific restrictions, but in this case, it is empty.
        /// </summary>
        public override void Restrictions() { }
    }
}
