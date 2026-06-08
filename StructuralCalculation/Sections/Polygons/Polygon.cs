using StructuralCalculation.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralCalculation.Sections.Polygons;

public abstract class Polygon : Section
{
    protected abstract IReadOnlyList<Point2D> Vertices { get; }

    protected double MatrixDeterminant(Point2D a, Point2D b)
    {
        return a.X * b.Y - a.Y * b.X;
    }

    protected double ProductOfAbscissas(Point2D a, Point2D b)
    {
        return a.X * a.X + a.X * b.X + b.X * b.X;
    }
    protected double ProductOfOrdinates(Point2D a, Point2D b)
    {
        return a.Y * a.Y + a.Y * b.Y + b.Y * b.Y;
    }

    protected double SumOfDeterminants()
    {
        double solution = 0;

        for (int i = 0; i < Vertices.Count; i++)
        {
            int j = (i + 1) % Vertices.Count;
            double matrixdeterminat = MatrixDeterminant(Vertices[i], Vertices[j]);

            solution += matrixdeterminat;
        }

        return solution;
    }
    public override double Area()
    {

        return Math.Abs(SumOfDeterminants() / 2.0);
    }

    protected double SignedArea()
    {
        double area = SumOfDeterminants() / 2.0;

        if (Math.Abs(area) < 1e-12)
            throw new InvalidOperationException(
                "Polygon area is zero.");

        return area;
    }
    public override double CentroidX()
    {
        double solution = 0;

        for (int i = 0; i < Vertices.Count; i++)
        {
            int j = (i + 1) % Vertices.Count;
            double matrixdeterminat = MatrixDeterminant(Vertices[i], Vertices[j]);

            solution += matrixdeterminat * (Vertices[i].X + Vertices[j].X);
        }

        return solution / (6.0 * SignedArea());
    }

    public override double CentroidY()
    {
        double solution = 0;

        for (int i = 0; i < Vertices.Count; i++)
        {
            int j = (i + 1) % Vertices.Count;
            double matrixdeterminant = MatrixDeterminant(Vertices[i], Vertices[j]);

            solution += matrixdeterminant * (Vertices[i].Y + Vertices[j].Y);
        }

        return solution / (6.0 * SignedArea());
    }

    public override double MomentOfInertiaX()
    {
        double solution = 0;
        for (int i = 0; i < Vertices.Count; i++)
        {
            int j = (i + 1) % Vertices.Count;
            double matrixdeterminat = MatrixDeterminant(Vertices[i], Vertices[j]);
            double productofordinate = ProductOfOrdinates(Vertices[i], Vertices[j]);
            solution += matrixdeterminat * productofordinate;
        }
        double inertiaX = (solution) / 12.0;
        double area = SignedArea();
        double centroidY = CentroidY();

        return inertiaX - area * centroidY * centroidY;
    }

    public override double MomentOfInertiaY()
    {
        double solution = 0;
        for (int i = 0; i < Vertices.Count; i++)
        {
            int j = (i + 1) % Vertices.Count;
            double matrixdeterminat = MatrixDeterminant(Vertices[i], Vertices[j]);
            double productofabscissas = ProductOfAbscissas(Vertices[i], Vertices[j]);
            solution += matrixdeterminat * productofabscissas;
        }
        double inertiaY = (solution) / 12.0;
        double area = SignedArea();
        double centroidX = CentroidX();

        return inertiaY - area * centroidX * centroidX;
    }

    protected double ProductOfInertiaTerm(Point2D a, Point2D b)
    {
        return
            a.X * b.Y +
            2 * a.X * a.Y +
            2 * b.X * b.Y +
            b.X * a.Y;
    }
    public override double ProductOfInertia()
    {
        double sum = 0;

        for (int i = 0; i < Vertices.Count; i++)
        {
            int j = (i + 1) % Vertices.Count;

            double determinant =
                MatrixDeterminant(Vertices[i], Vertices[j]);

            sum += determinant *
                   ProductOfInertiaTerm(Vertices[i], Vertices[j]);
        }

        double ixyOrigin = sum / 24.0;

        double area = SignedArea();
        double centroidX = CentroidX();
        double centroidY = CentroidY();

        return ixyOrigin - area * centroidX * centroidY;
    }
}
