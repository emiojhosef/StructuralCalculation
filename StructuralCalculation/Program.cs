using StructuralCalculation.Sections.CompositeSection;

USection u =
    new USection(
        20,
        2,
        30,
        2);

Console.WriteLine($"Area = {u.Area()}");
Console.WriteLine($"Cx = {u.CentroidX()}");
Console.WriteLine($"Cy = {u.CentroidY()}");
Console.WriteLine($"Ix = {u.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {u.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {u.ProductOfInertia()}");