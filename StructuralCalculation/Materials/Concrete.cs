using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructuralCalculation.Materials;

namespace StructuralCalculation.Materials;

//This project was calculation as NBR 6118, Brazilian.
public class Concrete : Material
{
    public double Fck {  get; }

    public Concrete (double fck):base(5600*Math.Sqrt(fck)*1e6, 0.2, 2500)
    {
        if (fck <= 0)
            throw new ArgumentException("Fck must be positive.");
        Fck = fck;
    }
}
