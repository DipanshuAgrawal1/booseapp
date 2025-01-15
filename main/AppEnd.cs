using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOOSE;

namespace main
{
    /// <summary>
    /// Represents the "end" command in the application, inheriting from <see cref="End"/>.
    /// This class is used to define the behavior for the "end" command in control flow or program termination logic.
    /// </summary>
    public class AppEnd : End
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppEnd"/> class.
        /// This constructor calls the base class method to reduce restrictions associated with the command.
        /// </summary>
        public AppEnd()
        {
            // Reduce restrictions as part of the command initialization process
            ReduceRestrictions();
        }

        /// <summary>
        /// A placeholder method for handling restrictions associated with the "end" command.
        /// This method does not perform any specific action in the <see cref="AppEnd"/> class.
        /// </summary>
        public override void Restrictions()
        {
            // No specific restrictions defined for "end" in this implementation
        }
    }
}
