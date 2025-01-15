using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    /// <summary>
    /// Represents an integer variable in the application.
    /// This class extends the base <see cref="Int"/> class and allows for further customization.
    /// </summary>
    public class AppInt : Int
    {
        /// <summary>
        /// Defines restrictions or constraints for the integer variable.
        /// This method can be overridden to implement custom validation logic specific to the application.
        /// </summary>
        public override void Restrictions()
        {
        }
    }
}
