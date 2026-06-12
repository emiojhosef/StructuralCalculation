using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StructuralCalculation.Sections.CircularSections;
namespace StructuralCalculation.Sections.HollowSections;

public class CircularTube : Section
{
    public double LargerRadius { get; }
    public double LargerOffsetX { get; }
    public double LargerOffsetY { get; }
    public double SmallerRadius { get; }
    public double SmallerOffsetX { get; }
    public double SmallerOffsetY { get; }
    public Circle LargerCircle { get; }
    public Circle SmallerCircle { get; }

    public CircularTube(double largerRadius, double smallerRadius, double largerOffsetX, double largerOffsetY, double smallerOffsetX, double smallerOffsetY)
    {
        if (largerRadius <= 0 || smallerRadius <= 0)
            throw new ArgumentException("Radius must be positive.");

        if (smallerRadius >= largerRadius)
            throw new ArgumentException("Inner radius must be smaller than outer radius.");

        double distanceCenter =
            Math.Sqrt(Math.Pow(largerOffsetX - smallerOffsetX, 2)+Math.Pow(largerOffsetY - smallerOffsetY, 2));

        if (distanceCenter + smallerRadius > largerRadius)
            throw new ArgumentException("The inner circle must be completely inside the outer circle.");

        LargerRadius = largerRadius;
        SmallerRadius = smallerRadius;
        LargerOffsetX = largerOffsetX;
        LargerOffsetY = largerOffsetY;
        SmallerOffsetX = smallerOffsetX;
        SmallerOffsetY = smallerOffsetY;

        LargerCircle = new Circle(LargerRadius, LargerOffsetX, LargerOffsetY);
        SmallerCircle = new Circle(SmallerRadius, SmallerOffsetX, SmallerOffsetY);

    }

    public override double Area()
    {
        return LargerCircle.Area() - SmallerCircle.Area();
    }

    public override double CentroidX()
    {
        return (LargerCircle.Area() * LargerCircle.CentroidX() - SmallerCircle.Area() * SmallerCircle.CentroidX()) / (LargerCircle.Area() - SmallerCircle.Area());
    }

    public override double CentroidY()
    {
        return (LargerCircle.Area() * LargerCircle.CentroidY() - SmallerCircle.Area() * SmallerCircle.CentroidY()) / (LargerCircle.Area() - SmallerCircle.Area());
    }
    public override double MomentOfInertiaX()
    {
        double centroidY = CentroidY();
        double centroitYLargerCircle = LargerCircle.CentroidY();
        double centroidYSmallerCircle = SmallerCircle.CentroidY();
        double dE = centroitYLargerCircle - centroidY;
        double dI = centroidYSmallerCircle - centroidY;

        double firstTerm = LargerCircle.MomentOfInertiaX() + LargerCircle.Area() * dE * dE;
        double secondTerm = SmallerCircle.MomentOfInertiaX() + SmallerCircle.Area() * dI * dI;
        return firstTerm - secondTerm;
    }
    public override double MomentOfInertiaY()
    {
        double centroidX = CentroidX();
        double centroitXLargerCircle = LargerCircle.CentroidX();
        double centroidXSmallerCircle = SmallerCircle.CentroidX();
        double dE = centroitXLargerCircle - centroidX;
        double dI = centroidXSmallerCircle - centroidX;

        double firstTerm = LargerCircle.MomentOfInertiaY() + LargerCircle.Area() * dE * dE;
        double secondTerm = SmallerCircle.MomentOfInertiaY() + SmallerCircle.Area() * dI * dI;
        return firstTerm - secondTerm;
    }

    public override double ProductOfInertia()
    {
        double centroidX = CentroidX();
        double centroidY = CentroidY();

        double dxE = LargerCircle.CentroidX() - centroidX;
        double dyE = LargerCircle.CentroidY() - centroidY;

        double dxI = SmallerCircle.CentroidX() - centroidX;
        double dyI = SmallerCircle.CentroidY() - centroidY;

        double firstTerm =
            LargerCircle.ProductOfInertia()
            + LargerCircle.Area() * dxE * dyE;

        double secondTerm =
            SmallerCircle.ProductOfInertia()
            + SmallerCircle.Area() * dxI * dyI;

        return firstTerm - secondTerm;
    }
}
