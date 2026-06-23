using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralCalculation.Supports;

public abstract class Support
{
    public bool Vertical { get; }
    public bool Horizontal { get; }
    public bool Moment { get; }
    protected Support(bool vertical, bool horizontal, bool moment)
    {
        Vertical = vertical; 
        Horizontal = horizontal; 
        Moment = moment;
    }

}
