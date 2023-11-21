using BlazorTDDTest.Shared;

namespace BlazorTDDTest.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void ShouldDisplayZeroOnLoad()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches("0");
        }
    }
}
