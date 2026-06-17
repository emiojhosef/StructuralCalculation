using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructuralCalculation.Geometry;

namespace StructuralCalculation.Sections.CompositeSection;

public class CompositeSection : Section
{
    public IReadOnlyList<Section> Sections { get; }

    public CompositeSection(List<Section> sections)
    {
        Sections = sections;
    }


    public override double Area()
    {
        double area = 0;
        foreach (Section section in Sections)
        {
            area = area + section.Area();
        }
        return area;

    }

    public override double CentroidX()
    {
        double centroidX;
        double sumXA = 0;
        double sumA = 0;

        foreach (Section section in Sections) 
        { 
            sumXA = sumXA + section.CentroidX()*section.Area();
            sumA = sumA + section.Area();
        }
        centroidX = sumXA/sumA;
        return centroidX;
    }

    public override double CentroidY()
    {
        double centroidY;
        double sumYA = 0;
        double sumA = 0;

        foreach (Section section in Sections)
        {
            sumYA = sumYA + section.CentroidY() * section.Area();
            sumA = sumA + section.Area();
        }
        centroidY = sumYA / sumA;
        return centroidY;
    }

    public override double MomentOfInertiaX()
    {
        double momentOfInertiaX = 0;
        double centroidCompositeSectionY = CentroidY();
        foreach (Section section in Sections)
        {
            double centroidY = section.CentroidY();
            double dE = centroidY - centroidCompositeSectionY;
            momentOfInertiaX = momentOfInertiaX + section.MomentOfInertiaX() + section.Area() * dE * dE;
        }
        return momentOfInertiaX;
    }

    public override double MomentOfInertiaY()
    {
        double momentOfInertiaY = 0;
        double centroidCompositeSectionX = CentroidX();
        foreach (Section section in Sections)
        {
            double centroidX = section.CentroidX();
            double dE = centroidX - centroidCompositeSectionX;
            momentOfInertiaY = momentOfInertiaY + section.MomentOfInertiaY() + section.Area() * dE * dE;
        }
        return momentOfInertiaY;
    }

    public override double ProductOfInertia()
    {
        double productOfInertia = 0;

        double centroidX = CentroidX();
        double centroidY = CentroidY();

        foreach (Section section in Sections)
        {
            double dx = section.CentroidX() - centroidX;
            double dy = section.CentroidY() - centroidY;

            productOfInertia +=
                section.ProductOfInertia()
                + section.Area() * dx * dy;
        }

        return productOfInertia;
    }
}
