using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralCalculation.Sections.Polygons;
using StructuralCalculation.Geometry;

public class RightTrapezoid : Polygon
{
    private readonly List<Point2D> _vertices;
    protected override IReadOnlyList<Point2D> Vertices => _vertices;

    public double LargerBase { get; }
    public double SmallerBase { get; }
    public double HeightTrapezoid { get; }

    public RightTrapezoid(double largerBase, double smallerBase, double heighttrapezoid)
    {
        if (largerBase <= 0 || smallerBase <= 0 || heighttrapezoid <= 0)
            throw new ArgumentException("Width must be positive.");
        LargerBase = largerBase;
        SmallerBase = smallerBase;
        HeightTrapezoid = heighttrapezoid;

        _vertices = new List<Point2D>
        {
            new Point2D(0, 0),
            new Point2D(LargerBase, 0),
            new Point2D(LargerBase, HeightTrapezoid),
            new Point2D((LargerBase-SmallerBase), HeightTrapezoid),
        };

    }
}
