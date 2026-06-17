using StructuralCalculation.Sections.CompositeSection;

HSection h = new HSection(
    20, // largura mesa
    2,  // espessura mesa
    30, // altura alma
    2   // espessura alma
);

Console.WriteLine($"Area = {h.Area()}");
Console.WriteLine($"Cx = {h.CentroidX()}");
Console.WriteLine($"Cy = {h.CentroidY()}");
Console.WriteLine($"Ix = {h.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {h.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {h.ProductOfInertia()}");