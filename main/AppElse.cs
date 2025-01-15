using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOOSE;

namespace main
{
    /// <summary>
    /// Represents the "else" command in the application, inheriting from <see cref="Else"/>.
    /// This class is used for defining behavior associated with the "else" command in the context of control flow statements.
    /// </summary>
    public class AppElse : Else
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppElse"/> class.
        /// This constructor calls the base class method to reduce restrictions.
        /// </summary>
        public AppElse()
        {
            // Reduce restrictions as part of the command initialization process
            ReduceRestrictions();
        }

        /// <summary>
        /// A placeholder for handling any restrictions associated with the "else" command.
        /// This method does not perform any specific action in the <see cref="AppElse"/> class.
        /// </summary>
        public override void Restrictions()
        {
            // No specific restrictions defined for "else" in this implementation
        }
    }
}
