using StructuralCalculation.Sections.Polygons;
namespace StructuralCalculation.Tests
{
    public class RectangleTests
    {
        [Fact]
        public void CentroidX_Must()
        {
            Rectangle rectangle = new Rectangle(20, 30, 10, 5);
            Assert.Equal(20.0, rectangle.CentroidX(), 10);
        }

        [Fact]
        public void CentroidY_Must()
        {
            Rectangle rectangle = new Rectangle(20, 30, 10, 5);
            Assert.Equal(20.0, rectangle.CentroidY(), 10);
        }

        [Fact]
        public void Area_Must()
        {
            Rectangle rectangle = new Rectangle(20, 30, 10, 5);
            Assert.Equal(600.0, rectangle.Area(), 10);
        }
        [Fact]
        public void InertiaX_Must()
        {
            Rectangle rectangle = new Rectangle(20, 30, 10, 5);
            Assert.Equal(45000.0, rectangle.MomentOfInertiaX(), 10);
        }
        [Fact]
        public void InertiaY_Must()
        {
            Rectangle rectangle = new Rectangle(20, 30, 10, 5);
            Assert.Equal(20000.0, rectangle.MomentOfInertiaY(), 10);
        }

        [Fact]
        public void ProductOfInertia_Must()
        {
            Rectangle rectangle = new Rectangle(20, 30, 10, 5);

            Assert.Equal(0.0, rectangle.ProductOfInertia(), 10);
        }
    }
}
