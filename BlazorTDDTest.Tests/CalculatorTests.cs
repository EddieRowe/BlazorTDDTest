using BlazorTDDTest.Shared;

namespace BlazorTDDTest.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void DisplayShouldShowZeroOnLoad()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 0");
        }

        [Fact]
        public void DisplayShouldBindToCode() {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            //Act
            cut.Find("button#one").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 1");
        }

        [Fact]
        public void DisplayShouldAddToStringIfNonZero()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            //Act
            cut.Find("button#one").Click();
            cut.Find("button#one").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 11");
        }

        [Fact]
        public void ClearButtonShouldClearDisplay()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#one").Click();
            cut.Find("button#clear-display").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 0");
        }
    }
}
