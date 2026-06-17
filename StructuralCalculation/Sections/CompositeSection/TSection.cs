using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructuralCalculation.Sections.Polygons;

namespace StructuralCalculation.Sections.CompositeSection;

public class TSection : CompositeSection
{
    public TSection(double flangeWidth, double flangeThickness, double webHeight, double webThickness) : base
        (
            new List<Section>
            {
                new Rectangle(flangeWidth, flangeThickness, 0, webHeight),
                new Rectangle(webThickness,webHeight,(flangeWidth - webThickness) / 2.0,0)
            }
        )
    {

    }
}
