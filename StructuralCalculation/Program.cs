using StructuralCalculation.Geometry;
using StructuralCalculation.Sections;
using StructuralCalculation.Sections.Polygons;

Rectangle rectangle = new Rectangle(10, 5);

Console.WriteLine($"Area = {rectangle.Area()}");
Console.WriteLine($"Ix = {rectangle.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {rectangle.MomentOfInertiaY()}");
Console.WriteLine(rectangle.CentroidX());
Console.WriteLine(rectangle.CentroidY());
Console.WriteLine(rectangle.ProductOfInertia());
