using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Material
{
    public double ModulusOfElasticity { get; }
    public double PoissonCoefficient { get; }
    public double Density {  get; }
    public double ShearModulus => ModulusOfElasticity / (2.0 * (1.0 + PoissonCoefficient));

    public Material(double modulusOfElasticity, double poissonCoefficient, double density)
    {
        if (modulusOfElasticity <= 0)
            throw new ArgumentException(
                "Elastic modulus must be positive.");

        if (density <= 0)
            throw new ArgumentException(
                "Density must be positive.");

        if (poissonCoefficient <= -1 || poissonCoefficient >= 0.5)
            throw new ArgumentException(
                "Invalid Poisson coefficient.");

        ModulusOfElasticity = modulusOfElasticity;
        PoissonCoefficient = poissonCoefficient;
        Density = density;
        

}

}
