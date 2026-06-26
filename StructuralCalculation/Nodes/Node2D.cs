using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructuralCalculation.Supports;

namespace StructuralCalculation.Nodes;


public struct Node2D
{
    public double X { get; }
    public double Y { get; }
    public Support Node { get; }
    public Node2D(double x, double y, Support node)
    {
        X= x;
        Y= y;
        Node = node;
    }
}
