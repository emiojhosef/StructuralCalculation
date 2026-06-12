using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StructuralCalculation.Sections.Polygons;
using StructuralCalculation.Sections.CircularSections;
namespace StructuralCalculation.Sections.HollowSections;

public class RectangularTube:Section
{
    public double LargerWidth { get; }
    public double LargerHeight { get; }
    public double OffsetXLargerWidth { get; }
    public double OffsetYLargerHeight { get; }
    public double SmallerWidth {  get; }
    public double SmallerHeight { get; }
    public double OffsetXSmallerWidth { get; }
    public double OffsetYSmallerHeight { get; }
    public Rectangle LargerRectangle { get; }
    public Rectangle SmallerRectangle { get; }

    public RectangularTube (double largerWidth, double largerHeight, double largerOffsetX, double largerOffsetY, double smallerWidth, double smallerHeight, double smallerOffsetX, double smallerOffsetY)
    {
        if (largerWidth <= 0 || largerHeight <= 0 || smallerWidth <= 0 || smallerHeight<=0)
            throw new ArgumentException("All valors must be positive.");
        if (smallerWidth >= largerWidth)
            throw new ArgumentException(
                "Inner width must be smaller than outer width.");
        if (smallerHeight >= largerHeight)
            throw new ArgumentException(
                "Inner height must be smaller than outer height.");
        LargerWidth = largerWidth;
        LargerHeight = largerHeight;
        OffsetXLargerWidth = largerOffsetX;
        OffsetYLargerHeight = largerOffsetY;
        SmallerWidth = smallerWidth;
        SmallerHeight = smallerHeight;
        OffsetXSmallerWidth = smallerOffsetX;
        OffsetYSmallerHeight = smallerOffsetY;
        LargerRectangle = new Rectangle(LargerWidth, LargerHeight, OffsetXLargerWidth, OffsetYLargerHeight);
        SmallerRectangle = new Rectangle(SmallerWidth, SmallerHeight, OffsetXSmallerWidth, OffsetYSmallerHeight);

    }

    public override double Area()
    {
        return LargerRectangle.Area() - SmallerRectangle.Area();
    }
    public override double CentroidX()
    {
        return (LargerRectangle.CentroidX()* LargerRectangle.Area() - SmallerRectangle.CentroidX()* SmallerRectangle.Area()) /(LargerRectangle.Area() - SmallerRectangle.Area());
    }

    public override double CentroidY()
    {
        return (LargerRectangle.CentroidY() * LargerRectangle.Area() - SmallerRectangle.CentroidY() * SmallerRectangle.Area()) / (LargerRectangle.Area() - SmallerRectangle.Area());
    }

    public override double MomentOfInertiaX()
    {
        double centroidY = CentroidY();
        double centroitYLargerRectangle = LargerRectangle.CentroidY();
        double centroidYSmallerRectangle = SmallerRectangle.CentroidY();
        double dE = centroitYLargerRectangle - centroidY;
        double dI = centroidYSmallerRectangle - centroidY;

        double firstTerm = LargerRectangle.MomentOfInertiaX() + LargerRectangle.Area() * dE * dE;
        double secondTerm = SmallerRectangle.MomentOfInertiaX() + SmallerRectangle.Area() * dI * dI;
        return firstTerm - secondTerm;
    }
    public override double MomentOfInertiaY()
    {
        double centroidX = CentroidX();
        double centroitXLargerRectangle = LargerRectangle.CentroidX();
        double centroidXSmallerRectangle = SmallerRectangle.CentroidX();
        double dE = centroitXLargerRectangle - centroidX;
        double dI = centroidXSmallerRectangle - centroidX;

        double firstTerm = LargerRectangle.MomentOfInertiaY() + LargerRectangle.Area() * dE * dE;
        double secondTerm = SmallerRectangle.MomentOfInertiaY() + SmallerRectangle.Area() * dI * dI;
        return firstTerm - secondTerm;
    }

    public override double ProductOfInertia()
    {
        double centroidX = CentroidX();
        double centroidY = CentroidY();

        double dxE = LargerRectangle.CentroidX() - centroidX;
        double dyE = LargerRectangle.CentroidY() - centroidY;

        double dxI = SmallerRectangle.CentroidX() - centroidX;
        double dyI = SmallerRectangle.CentroidY() - centroidY;

        double firstTerm =
            LargerRectangle.ProductOfInertia()
            + LargerRectangle.Area() * dxE * dyE;

        double secondTerm =
            SmallerRectangle.ProductOfInertia()
            + SmallerRectangle.Area() * dxI * dyI;

        return firstTerm - secondTerm;
    }
}
