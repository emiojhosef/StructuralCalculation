using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralCalculation.Sections.CircularSections;

public class SemiCircle : Section
{
    public double Radius { get; }

    public SemiCircle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be positive.");

        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI* Radius*Radius/2;
    }
    public override double CentroidX()
    {
        return 0;
    }
    public override double CentroidY()
    {
        return 4 * Radius / (Math.PI * 3);
    }


    public override double MomentOfInertiaX()
    {
        return Math.PI * Math.Pow(Radius, 4) / 8.0-Area()*CentroidY()*CentroidY();
    }

    public override double MomentOfInertiaY()
    {
        return Math.PI * Math.Pow(Radius, 4) / 8.0;
    }

    public override double ProductOfInertia()
    {
        return 0;
    }
}