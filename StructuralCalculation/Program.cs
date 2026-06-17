using StructuralCalculation.Sections.CompositeSection;
using StructuralCalculation.Sections.HollowSections;
using StructuralCalculation.Sections.Polygons;
CompositeSection section =
    new CompositeSection(
    [
        new Rectangle(10, 10, 0, 0),
        new Rectangle(10, 10, 10, 0)
    ]);

Console.WriteLine(section.Area());
Console.WriteLine(section.CentroidX());
Console.WriteLine(section.CentroidY());
Console.WriteLine(section.MomentOfInertiaX());
Console.WriteLine(section.MomentOfInertiaY());
Console.WriteLine(section.ProductOfInertia());
