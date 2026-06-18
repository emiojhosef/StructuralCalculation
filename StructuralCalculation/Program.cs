using StructuralCalculation.Sections.CompositeSection;

LSection l = new LSection(
    20, // flangeWidth
    2,  // flangeThickness
    30, // webHeight
    2); // webThickness

Console.WriteLine($"Area = {l.Area()}");
Console.WriteLine($"Cx = {l.CentroidX()}");
Console.WriteLine($"Cy = {l.CentroidY()}");
Console.WriteLine($"Ix = {l.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {l.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {l.ProductOfInertia()}");