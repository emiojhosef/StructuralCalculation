using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralCalculation.Supports;

public class PinnedSupport:Support
{
    public PinnedSupport():base(true, true, false)
    {
    }
}
