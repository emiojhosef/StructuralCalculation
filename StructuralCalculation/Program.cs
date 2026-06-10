using StructuralCalculation.Geometry;
using StructuralCalculation.Sections;
using StructuralCalculation.Sections.CircularSections;
using StructuralCalculation.Sections.Polygons;

SemiCircle semiCircle = new SemiCircle(10);

Console.WriteLine(semiCircle.Area());
Console.WriteLine(semiCircle.CentroidY());
Console.WriteLine(semiCircle.MomentOfInertiaX());
Console.WriteLine(semiCircle.MomentOfInertiaY());
