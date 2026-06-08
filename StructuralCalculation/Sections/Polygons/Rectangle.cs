using StructuralCalculation.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StructuralCalculation.Sections.Polygons;

public class Rectangle : Polygon
{
    private readonly List<Point2D> _vertices;

    protected override IReadOnlyList<Point2D> Vertices => _vertices;

    public double Width { get; }
    public double Height { get; }

    public Rectangle (double width, double height)
    {
        if (width <= 0)
            throw new ArgumentException("Width must be positive.");

        if (height <= 0)
            throw new ArgumentException("Height must be positive.");
        Width = width; 
        Height = height;
        _vertices = new List<Point2D>{ new Point2D (0, 0), new Point2D (width, 0), 
            new Point2D (width, height), new Point2D (0, height),};

    }
}
