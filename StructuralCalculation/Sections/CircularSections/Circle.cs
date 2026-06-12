using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralCalculation.Sections.CircularSections;

public class Circle : Section
{
    public double Radius { get; }
    public double OffsetX { get; }
    public double OffsetY { get; }

    public Circle(double radius, double offsetX, double offsetY)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be positive.");

        Radius = radius;
        OffsetX = offsetX;
        OffsetY = offsetY;
    }

    public override double Area()
    {
        return Math.PI * Radius*Radius;
    }

    public override double CentroidX()
    {
        return OffsetX;
    }

    public override double CentroidY()
    {
        return OffsetY;
    }

    public override double MomentOfInertiaX()
    {
        return Math.PI * Math.Pow(Radius, 4) / 4.0;
    }

    public override double MomentOfInertiaY()
    {
        return Math.PI * Math.Pow(Radius, 4) / 4.0;
    }

    public override double ProductOfInertia()
    {
        return 0;
    }


}

