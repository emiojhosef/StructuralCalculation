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
    public double OffsetX { get; }
    public double OffsetY { get; }
    public enum VerticalSidePosition
    {
        Left,
        Right
    }

    public RightTrapezoid(double largerBase, double smallerBase, double heighttrapezoid, VerticalSidePosition verticalSidePosition, double offsetX, double offsetY)
    {
        if (largerBase <= 0 || smallerBase <= 0 || heighttrapezoid <= 0)
            throw new ArgumentException("Width must be positive.");
        if (smallerBase > largerBase)
            throw new ArgumentException(
                "Smaller base must be less than or equal to larger base.");
        LargerBase = largerBase;
        SmallerBase = smallerBase;
        HeightTrapezoid = heighttrapezoid;
        OffsetX = offsetX;
        OffsetY = offsetY;

        if (verticalSidePosition == VerticalSidePosition.Right)
            _vertices = new List<Point2D>
            {
                new Point2D(OffsetX, OffsetY),
                new Point2D(OffsetX+LargerBase, OffsetY),
                new Point2D(OffsetX + LargerBase, HeightTrapezoid+OffsetY),
                new Point2D(OffsetX+(LargerBase-SmallerBase), HeightTrapezoid+OffsetY),
            };
        else
            _vertices = new List<Point2D>
            {
                new Point2D(OffsetX, OffsetY),
                new Point2D(OffsetX+LargerBase, OffsetY),
                new Point2D(OffsetX+SmallerBase, HeightTrapezoid+OffsetY),
                new Point2D(OffsetX, HeightTrapezoid+OffsetY),
            };
    }
}
