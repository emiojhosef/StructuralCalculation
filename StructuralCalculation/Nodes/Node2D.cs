using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructuralCalculation.Supports;

namespace StructuralCalculation.Nodes;


public class Node2D
{
    public double X { get; }
    public double Y { get; }
    public Support? Support { get; }
    public Node2D(double x, double y, Support? support = null)
    {
        X= x;
        Y= y;
        Support = support;
    }
}
