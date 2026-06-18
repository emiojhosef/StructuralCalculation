using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructuralCalculation.Sections.Polygons;

namespace StructuralCalculation.Sections.CompositeSection;

public class USection : CompositeSection
{
    public USection(double flangeWidth, double flangeThickness, double webHeight, double webThickness) : base
        (
            new List<Section>
            {
                new Rectangle(webThickness,webHeight,0,flangeThickness),
                new Rectangle(flangeWidth, flangeThickness, 0, 0),
                new Rectangle(webThickness, webHeight, flangeWidth-webThickness, flangeThickness),
            }
        )
    {

    }
}
