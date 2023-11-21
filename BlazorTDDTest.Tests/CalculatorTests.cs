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
            cut.Find("button#press-clear").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 0");
        }

        [Fact]
        public void AddMethodShouldAddSingleDigitNumbers()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#five").Click();
            cut.Find("button#press-add").Click();
            cut.Find("button#five").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 10");
        }

        [Fact]
        public void AddMethodShouldAddMultiDigitNumbers()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#five").Click();
            cut.Find("button#nine").Click();
            cut.Find("button#zero").Click();
            cut.Find("button#press-add").Click();
            cut.Find("button#two").Click();
            cut.Find("button#two").Click();
            cut.Find("button#three").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 813");
        }

        [Fact]
        public void AddFromNoInput()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#press-add").Click();
            cut.Find("button#two").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 2");
        }

        [Fact]
        public void Subtract1From5()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#five").Click();
            cut.Find("button#press-subtract").Click();
            cut.Find("button#one").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 4");
        }

        [Fact]
        public void Subtract10From5()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#five").Click();
            cut.Find("button#press-subtract").Click();
            cut.Find("button#one").Click();
            cut.Find("button#zero").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": -5");
        }

        [Fact]
        public void PressSubtractMultipleTimes()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#five").Click();
            cut.Find("button#press-subtract").Click();
            cut.Find("button#press-subtract").Click();
            cut.Find("button#one").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 4");
        }

        [Fact]
        public void MultiplyFromNoInput()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#press-multiply").Click();
            cut.Find("button#two").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 0");
        }

        [Fact]
        public void MultiplyByZero()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#five").Click();
            cut.Find("button#press-multiply").Click();
            cut.Find("button#zero").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 0");
        }

        [Fact]
        public void AddToResult()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#five").Click();
            cut.Find("button#press-add").Click();
            cut.Find("button#six").Click();
            cut.Find("button#press-equals").Click();
            cut.Find("button#press-add").Click();
            cut.Find("button#one").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 12");
        }

        [Fact]
        public void Divide10By2()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#one").Click();
            cut.Find("button#zero").Click();
            cut.Find("button#press-divide").Click();
            cut.Find("button#two").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 5");
        }

        [Fact]
        public void DivideBy0()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#one").Click();
            cut.Find("button#press-divide").Click();
            cut.Find("button#zero").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": Cannot / by 0");
        }

        [Fact]
        public void MultiplyAnswersThenNewSum()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#eight").Click();
            cut.Find("button#press-multiply").Click();
            cut.Find("button#eight").Click();
            cut.Find("button#press-equals").Click();
            //64
            cut.Find("button#press-multiply").Click();
            cut.Find("button#eight").Click();
            cut.Find("button#press-equals").Click();
            //512
            cut.Find("button#press-multiply").Click();
            cut.Find("button#eight").Click();
            cut.Find("button#press-equals").Click();
            //4096
            cut.Find("button#one").Click();
            cut.Find("button#press-add").Click();
            cut.Find("button#eight").Click();
            cut.Find("button#press-equals").Click();
            //9

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 9");
        }

        [Fact]
        public void MultiplyAnswersThenNewMultiDigitSum()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#eight").Click();
            cut.Find("button#press-multiply").Click();
            cut.Find("button#eight").Click();
            cut.Find("button#press-equals").Click();
            
            cut.Find("button#one").Click();
            cut.Find("button#one").Click();
            cut.Find("button#press-add").Click();
            cut.Find("button#five").Click();
            cut.Find("button#press-equals").Click();     

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 16");
        }

        [Fact]
        public void PlusEqualsTest()    //Maybe make SubtractEquals, MultiplyEquals & DivideEquals tests?
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#eight").Click();
            cut.Find("button#press-add").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": +");
        }

        [Fact]
        public void ClearButtonClearsOperation()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button#five").Click();
            cut.Find("button#press-divide").Click();
            cut.Find("button#press-clear").Click();

            cut.Find("button#five").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 5");
        }

    }
}
