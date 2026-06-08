using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralCalculation.Sections;

public abstract class Section
{
    public abstract double Area();
    public abstract double MomentOfInertiaX();
    public abstract double MomentOfInertiaY();
    public abstract double CentroidX();
    public abstract double CentroidY();
    public abstract double ProductOfInertia();

    public double RadiusOfGyrationX()
    {
        return Math.Sqrt(
            MomentOfInertiaX() / Area());
    }

    public double RadiusOfGyrationY()
    {
        return Math.Sqrt(
            MomentOfInertiaY() / Area());
    }
    public double RotationAngle { get; set; }
}

