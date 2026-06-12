using StructuralCalculation.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StructuralCalculation.Sections.Polygons;

public class Triangle : Polygon
{
    private readonly List<Point2D> _vertices;

    protected override IReadOnlyList<Point2D> Vertices => _vertices;

    public double SideA {  get; }
    public double SideB { get; }
    public double SideC {  get; }
    public double OffsetX { get; }
    public double OffsetY { get; }

    public bool ConditionOfExistence()
    {
        bool Condition1 = SideA < SideB + SideC;
        bool Condition2 = SideB < SideA + SideC;
        bool Condition3 = SideC < SideA + SideB;
        bool Condition4 = SideA > 0 && SideB > 0 && SideC > 0;

        if (Condition1 && Condition2 && Condition3 && Condition4)
            return true;
        return false;
    }
    
    public double HeightTriangle()
    {
        double semiperimeter = (SideA + SideB + SideC) / 2;
        double area = Math.Sqrt((semiperimeter)*(semiperimeter-SideA)*(semiperimeter-SideB)*(semiperimeter-SideC));
        return 2 * area / SideA;
    }

    public double OrthogonalProjectionOfB()
    {
        double hypotenuse = SideB;
        double height = HeightTriangle();
        double AdjacentLeg = Math.Sqrt(Math.Pow(hypotenuse, 2) - Math.Pow(height, 2));

        return AdjacentLeg;

    }
    public Triangle(double sideA, double sideB, double sideC, double offsetX, double offsetY)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
        OffsetX = offsetX;
        OffsetY = offsetY;

        if (ConditionOfExistence()==false)
            throw new ArgumentException("The sum of two sides must be greater than the length of the other, or All sides must be positive..");

        _vertices = new List<Point2D>
        {
            new Point2D(offsetX,offsetY),
            new Point2D(SideA+offsetX,offsetY),
            new Point2D(OrthogonalProjectionOfB()+offsetX,HeightTriangle()+offsetY),
        };

    }
}