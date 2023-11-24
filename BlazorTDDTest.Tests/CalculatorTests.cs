using BlazorTDDTest.Shared;

namespace BlazorTDDTest.Tests
{
    public class CalculatorTests
    {
        TestContext ctx = new TestContext();
        IRenderedComponent<Calculator> cut;
        AngleSharp.Dom.IElement paraElm;

        public CalculatorTests() // Called before each test
        {
            ctx = new TestContext();
            cut = ctx.RenderComponent<Calculator>();
            paraElm = cut.Find("p");
        }

        [Fact]
        public void DisplayZeroOnLoad()
        {
            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 0");
        }

        [Fact]
        public void DisplayBindToCode() 
        {
            // Act
            cut.Find("button#one").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 1");
        }

        [Fact]
        public void DisplayAddToStringIfNonZero()
        {
            // Act
            cut.Find("button#one").Click();
            cut.Find("button#one").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 11");
        }

        [Fact]
        public void ClearButtonClearDisplay()
        {
            // Act
            cut.Find("button#one").Click();
            cut.Find("button#press-clear").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 0");
        }

        [Fact]
        public void AddSingleDigitNumbers()
        {
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
        public void AddMultiDigitNumbers()
        {
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
            // Act
            cut.Find("button#press-add").Click();
            cut.Find("button#two").Click();
            cut.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 2");
        }

        [Fact]
        public void SubtractOneFromFive()
        {
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
        public void SubtractTenFromFive()
        {
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
        public void DivideTenByTwo()
        {
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
        public void DivideByZero()
        {
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
