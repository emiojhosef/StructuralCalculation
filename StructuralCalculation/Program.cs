using StructuralCalculation.Sections.CompositeSection;

TSection t =
    new TSection(
        20,
        2,
        30,
        2);

Console.WriteLine($"Area = {t.Area()}");
Console.WriteLine($"Cx = {t.CentroidX()}");
Console.WriteLine($"Cy = {t.CentroidY()}");
Console.WriteLine($"Ix = {t.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {t.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {t.ProductOfInertia()}");