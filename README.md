# StructuralCalculation

StructuralCalculation is a C# library focused on Civil Engineering structural calculations.

## Current Features

### Geometric Properties

* Area
* Centroid (X and Y)
* Moment of Inertia (Ix)
* Moment of Inertia (Iy)
* Product of Inertia (Ixy)
* Radius of Gyration

### Implemented Sections

* Rectangle
* Triangle
* Generic Polygon Base Class

## Project Structure

```text
Section
│
└── Polygon
    ├── Rectangle
    └── Triangle
```

## Example

```csharp
Rectangle rectangle = new Rectangle(10, 5);

Console.WriteLine($"Area = {rectangle.Area()}");
Console.WriteLine($"Ix = {rectangle.MomentOfInertiaX()}");
Console.WriteLine($"Iy = {rectangle.MomentOfInertiaY()}");
```

## Future Development

* Isostatic Structures
* Hyperstatic Structures
* Reinforced Concrete Design
* Steel Structure Design
* Composite Sections
* Structural Analysis Tools

## Objective

The goal of this project is to build a comprehensive structural analysis and design library for Civil Engineering applications using C#.
