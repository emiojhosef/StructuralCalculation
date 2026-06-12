using StructuralCalculation.Sections.CircularSections;
using StructuralCalculation.Sections.Polygons;

Console.WriteLine("=== RECTANGLE ===");
Rectangle rectangle = new Rectangle(10, 4, 0, 0);

Console.WriteLine($"Area = {rectangle.Area()}");
Console.WriteLine($"Cx = {rectangle.CentroidX()}");
Console.WriteLine($"Cy = {rectangle.CentroidY()}");
Console.WriteLine($"Ix = {rectangle.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {rectangle.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {rectangle.ProductOfInertia()}");

Console.WriteLine("\n=== TRIANGLE ===");
Triangle triangle = new Triangle(6, 5, 5, 0, 0);

Console.WriteLine($"Area = {triangle.Area()}");
Console.WriteLine($"Cx = {triangle.CentroidX()}");
Console.WriteLine($"Cy = {triangle.CentroidY()}");
Console.WriteLine($"Ix = {triangle.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {triangle.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {triangle.ProductOfInertia()}");

Console.WriteLine("\n=== ISOSCELES TRAPEZOID ===");
IsoscelesTrapezoid isoTrap =
    new IsoscelesTrapezoid(10, 6, 4, 0, 0);

Console.WriteLine($"Area = {isoTrap.Area()}");
Console.WriteLine($"Cx = {isoTrap.CentroidX()}");
Console.WriteLine($"Cy = {isoTrap.CentroidY()}");
Console.WriteLine($"Ix = {isoTrap.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {isoTrap.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {isoTrap.ProductOfInertia()}");

Console.WriteLine("\n=== RIGHT TRAPEZOID (RIGHT) ===");
RightTrapezoid rightTrap =
    new RightTrapezoid(
        10,
        6,
        4,
        RightTrapezoid.VerticalSidePosition.Right,
        0,
        0);

Console.WriteLine($"Area = {rightTrap.Area()}");
Console.WriteLine($"Cx = {rightTrap.CentroidX()}");
Console.WriteLine($"Cy = {rightTrap.CentroidY()}");
Console.WriteLine($"Ix = {rightTrap.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {rightTrap.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {rightTrap.ProductOfInertia()}");

Console.WriteLine("\n=== RIGHT TRAPEZOID (LEFT) ===");
RightTrapezoid leftTrap =
    new RightTrapezoid(
        10,
        6,
        4,
        RightTrapezoid.VerticalSidePosition.Left,
        0,
        0);

Console.WriteLine($"Area = {leftTrap.Area()}");
Console.WriteLine($"Cx = {leftTrap.CentroidX()}");
Console.WriteLine($"Cy = {leftTrap.CentroidY()}");
Console.WriteLine($"Ix = {leftTrap.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {leftTrap.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {leftTrap.ProductOfInertia()}");

Console.WriteLine("\n=== CIRCLE ===");
Circle circle = new Circle(10, 0, 0);

Console.WriteLine($"Area = {circle.Area()}");
Console.WriteLine($"Cx = {circle.CentroidX()}");
Console.WriteLine($"Cy = {circle.CentroidY()}");
Console.WriteLine($"Ix = {circle.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {circle.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {circle.ProductOfInertia()}");

Console.WriteLine("\n=== SEMICIRCLE ===");
SemiCircle semiCircle = new SemiCircle(10, 0, 0);

Console.WriteLine($"Area = {semiCircle.Area()}");
Console.WriteLine($"Cx = {semiCircle.CentroidX()}");
Console.WriteLine($"Cy = {semiCircle.CentroidY()}");
Console.WriteLine($"Ix = {semiCircle.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {semiCircle.MomentOfInertiaY()}");
Console.WriteLine($"Ixy = {semiCircle.ProductOfInertia()}");