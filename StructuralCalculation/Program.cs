using StructuralCalculation.Sections.HollowSections;

CircularTube tube =
    new CircularTube(
        10,
        5,
        0,
        0,
        0,
        0);

Console.WriteLine($"Area = {tube.Area()}");
Console.WriteLine($"Cx = {tube.CentroidX()}");
Console.WriteLine($"Cy = {tube.CentroidY()}");
Console.WriteLine($"Ix = {tube.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {tube.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {tube.ProductOfInertia()}");