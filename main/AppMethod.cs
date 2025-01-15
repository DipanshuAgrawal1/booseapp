using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    public class AppMethod : Method
    {
        public AppMethod()
        {
            base.ReduceRestrictions();
            base.ReduceRestrictions();
            ResetOrDecreaseCount(0);
            ResetOrDecreaseMethodCount(0);
        }

        public void ResetOrDecreaseCount(int newValue)
        {
            var fieldInfo = typeof(BOOSE.Boolean).GetField("뇀", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(null, newValue);
            }
            else
            {
                throw new BOOSEException("Unable to access the 뇀 field in Boolean class.");
            }
        }

        public void ResetOrDecreaseMethodCount(int newValue)
        {
            var fieldInfo = typeof(Method).GetField("뇔", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(null, newValue);
            }
            else
            {
                throw new BOOSEException("Unable to access the 꿁 field in Boolean class.");
            }
        }
    }
}
