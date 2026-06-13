using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StructuralCalculation.Sections.Polygons;
using StructuralCalculation.Sections.CircularSections;
using System.Net.Http.Headers;
using System.Linq.Expressions;
using StructuralCalculation.Geometry;
namespace StructuralCalculation.Sections.HollowSections;

public class TriangularTube : Section
{
    public double LargerSideA { get; }
    public double LargerSideB { get; }
    public double LargerSideC { get; }
    public double LargerOffsetX { get; }
    public double LargerOffsetY { get; }

    public double SmallerSideA { get; }
    public double SmallerSideB { get; }
    public double SmallerSideC { get; }
    public double SmallerOffsetX { get; }
    public double SmallerOffsetY { get; }

    public Triangle LargerTriangle { get; }
    public Triangle SmallerTriangle { get; }

    private static double AreaDeterminantSarrus(Point2D a, Point2D b, Point2D c)
    {
        double area = (a.X * b.Y + a.Y * c.X + b.X * c.Y - (c.X * b.Y + c.Y * a.X + b.X * a.Y)) / 2.0;
        return Math.Abs(area);
    }

    public TriangularTube (double largerSideA, double largerSideB, double largerSideC, double largerOffsetX, double largerOffsetY, double smallerSideA, double smallerSideB, double smallerSideC, double smallerOffsetX, double smallerOffsetY)
    {
        LargerSideA = largerSideA;
        LargerSideB = largerSideB;
        LargerSideC = largerSideC;
        LargerOffsetX = largerOffsetX;
        LargerOffsetY = largerOffsetY;

        SmallerSideA = smallerSideA;
        SmallerSideB = smallerSideB;
        SmallerSideC = smallerSideC;
        SmallerOffsetX = smallerOffsetX;
        SmallerOffsetY = smallerOffsetY;
      

        LargerTriangle = new Triangle(LargerSideA, LargerSideB, LargerSideC, LargerOffsetX, LargerOffsetY);
        SmallerTriangle = new Triangle(SmallerSideA, SmallerSideB, SmallerSideC, SmallerOffsetX, SmallerOffsetY);

        var verticesLargerTriangle = LargerTriangle.VertexList;

        var verticesSmallerTriangle = SmallerTriangle.VertexList;

        if (SmallerTriangle.Area() >= LargerTriangle.Area())
        {
            throw new ArgumentException(
                "Inner triangle must be smaller than outer triangle.");
        }

        Point2D A = verticesLargerTriangle[0];
        Point2D B = verticesLargerTriangle[1];
        Point2D C = verticesLargerTriangle[2];

        double areaABC = LargerTriangle.Area();

        for (int i =0; i<verticesSmallerTriangle.Count; i++)
        {
            var P = verticesSmallerTriangle[i];
            double area1 = AreaDeterminantSarrus(P, A, B);
            double area2 = AreaDeterminantSarrus(P, B, C);
            double area3 = AreaDeterminantSarrus(P, C, A);

            double areaSum = area1 + area2 + area3;

            double tolerance = areaABC * 1e-10;
            if (Math.Abs(areaSum - areaABC) > tolerance)
                throw new ArgumentException(
                    "The inner triangle must be inside the outer triangle.");
        }
    }
    public override double Area()
    {
        return LargerTriangle.Area() - SmallerTriangle.Area();
    }
    public override double CentroidX()
    {
        return (LargerTriangle.CentroidX() * LargerTriangle.Area() - SmallerTriangle.CentroidX() * SmallerTriangle.Area()) / (LargerTriangle.Area() - SmallerTriangle.Area());
    }

    public override double CentroidY()
    {
        return (LargerTriangle.CentroidY() * LargerTriangle.Area() - SmallerTriangle.CentroidY() * SmallerTriangle.Area()) / (LargerTriangle.Area() - SmallerTriangle.Area());
    }

    public override double MomentOfInertiaX()
    {
        double centroidY = CentroidY();
        double centroitYLargerTriangle = LargerTriangle.CentroidY();
        double centroidYSmallerTriangle = SmallerTriangle.CentroidY();
        double dE = centroitYLargerTriangle - centroidY;
        double dI = centroidYSmallerTriangle - centroidY;

        double firstTerm = LargerTriangle.MomentOfInertiaX() + LargerTriangle.Area() * dE * dE;
        double secondTerm = SmallerTriangle.MomentOfInertiaX() + SmallerTriangle.Area() * dI * dI;
        return firstTerm - secondTerm;
    }
    public override double MomentOfInertiaY()
    {
        double centroidX = CentroidX();
        double centroitXLargerTriangle = LargerTriangle.CentroidX();
        double centroidXSmallerTriangle = SmallerTriangle.CentroidX();
        double dE = centroitXLargerTriangle - centroidX;
        double dI = centroidXSmallerTriangle - centroidX;

        double firstTerm = LargerTriangle.MomentOfInertiaY() + LargerTriangle.Area() * dE * dE;
        double secondTerm = SmallerTriangle.MomentOfInertiaY() + SmallerTriangle.Area() * dI * dI;
        return firstTerm - secondTerm;
    }

    public override double ProductOfInertia()
    {
        double centroidX = CentroidX();
        double centroidY = CentroidY();

        double dxE = LargerTriangle.CentroidX() - centroidX;
        double dyE = LargerTriangle.CentroidY() - centroidY;

        double dxI = SmallerTriangle.CentroidX() - centroidX;
        double dyI = SmallerTriangle.CentroidY() - centroidY;

        double firstTerm =
            LargerTriangle.ProductOfInertia()
            + LargerTriangle.Area() * dxE * dyE;

        double secondTerm =
            SmallerTriangle.ProductOfInertia()
            + SmallerTriangle.Area() * dxI * dyI;

        return firstTerm - secondTerm;
    }
}
