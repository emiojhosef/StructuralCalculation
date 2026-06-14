using StructuralCalculation.Sections.HollowSections;
using StructuralCalculation.Sections.Polygons;
Rectangle rectangle = new Rectangle(20, 30, 10, 5);

Console.WriteLine(rectangle.MomentOfInertiaX());
Console.WriteLine(rectangle.CentroidY());
