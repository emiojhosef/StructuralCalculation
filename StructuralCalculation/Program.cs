using StructuralCalculation.Geometry;
using StructuralCalculation.Sections;
using StructuralCalculation.Sections.Polygons;

RightTrapezoid trapezoid = new RightTrapezoid(10,6,4, RightTrapezoid.VerticalSidePosition.Left);

Console.WriteLine($"Area = {trapezoid.Area()}");
Console.WriteLine($"Ix = {trapezoid.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {trapezoid.MomentOfInertiaY()}");
Console.WriteLine(trapezoid.CentroidX());
Console.WriteLine(trapezoid.CentroidY());
Console.WriteLine(trapezoid.ProductOfInertia());
