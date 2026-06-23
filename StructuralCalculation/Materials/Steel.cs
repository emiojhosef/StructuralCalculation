using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructuralCalculation.Materials;

namespace StructuralCalculation.Materials;

public class Steel : Material
{
    public Steel() : base(200*1e9, 0.3, 7850)
    {

    }
}
