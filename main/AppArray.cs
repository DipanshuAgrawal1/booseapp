using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOOSE;

namespace main
{
    /// <summary>
    /// Represents a custom array implementation that inherits from the BOOSE.Array class.
    /// This class can be extended with additional functionality specific to the application.
    /// </summary>
    public class AppArray : BOOSE.Array
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppArray"/> class.
        /// The constructor reduces the restriction counter by calling the base class method.
        /// </summary>
        public AppArray()
        {
            // Reduce the restriction counter by invoking the method from the parent class (BOOSE.Array)
            ReduceRestrictionCounter();
        }
    }
}
