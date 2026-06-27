using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructuralCalculation.Supports;
using StructuralCalculation.Sections;
using StructuralCalculation.Nodes;
using StructuralCalculation.Materials;

namespace StructuralCalculation.Elements;

public abstract class Element2D
{
    public Node2D InicialNode { get; }
    public Node2D FinalNode { get; }

    public Section Section { get; }

    public Material Material { get; }
    public double Length => Math.Sqrt(Math.Pow(InicialNode.X-FinalNode.X,2)+Math.Pow(InicialNode.Y - FinalNode.Y, 2));

    public Element2D(Node2D inicialNode, Node2D finalNode, Section section, Material material)
    {
        InicialNode = inicialNode;
        FinalNode = finalNode;
        Section = section;
        Material = material;

        if (Length <= 0)
            throw new ArgumentException(
                "Element length must be greater than zero.");

    }

    public abstract double[,] LocalStiffnessMatrix();
}
