using StructuralCalculation.Sections.HollowSections;

TriangularTube tube =
    new TriangularTube(
        10, 10, 10, 0, 0,
        5, 5, 5,
        2.5, 1.4433756729740645);

Console.WriteLine($"Area = {tube.Area()}");
Console.WriteLine($"Cx = {tube.CentroidX()}");
Console.WriteLine($"Cy = {tube.CentroidY()}");
Console.WriteLine($"Ix = {tube.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {tube.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {tube.ProductOfInertia()}");
