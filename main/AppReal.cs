using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOOSE;

namespace main
{
    /// <summary>
    /// Represents the "real" command in the application, inheriting from <see cref="Real"/>.
    /// This class defines the behavior for the "real" data type command, specifically handling restriction logic.
    /// </summary>
    public class AppReal : Real
    {
        /// <summary>
        /// A static counter used to track the number of times the restrictions have been applied.
        /// This is used to limit the number of times the "real" command can be invoked.
        /// </summary>
        private static int restrictionLimit;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppReal"/> class.
        /// This constructor calls the <see cref="Restrictions"/> method to check and enforce the restrictions for the "real" command.
        /// </summary>
        public AppReal()
        {
            // Enforce restrictions when the command is created
            Restrictions();
        }

        /// <summary>
        /// A method that enforces restrictions on the "real" command.
        /// This method increases the restriction counter each time it is called and throws an exception if the limit is exceeded.
        /// </summary>
        public override void Restrictions()
        {
            // If the restriction limit has been exceeded, throw an exception
            if (restrictionLimit++ > 40)
            {
                throw new RestrictionException("Restrictions REAL Reached");
            }
        }
    }
}
