using BlazorTDDTest.Shared;

namespace BlazorTDDTest.Tests
{
    public class CalculatorTests
    {
        TestContext context = new TestContext();
        IRenderedComponent<Calculator> calc;
        AngleSharp.Dom.IElement paraElm;

        public CalculatorTests() // Called before each test
        {
            context = new TestContext();
            calc = context.RenderComponent<Calculator>();
            paraElm = calc.Find("p");
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
            calc.Find("button#one").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 1");
        }

        [Fact]
        public void DisplayAddToStringIfNonZero()
        {
            // Act
            calc.Find("button#one").Click();
            calc.Find("button#one").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 11");
        }

        [Fact]
        public void ClearButtonClearDisplay()
        {
            // Act
            calc.Find("button#one").Click();
            calc.Find("button#press-clear").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 0");
        }

        [Fact]
        public void AddSingleDigitNumbers()
        {
            // Act
            calc.Find("button#five").Click();
            calc.Find("button#press-add").Click();
            calc.Find("button#five").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 10");
        }

        [Fact]
        public void AddMultiDigitNumbers()
        {
            // Act
            calc.Find("button#five").Click();
            calc.Find("button#nine").Click();
            calc.Find("button#zero").Click();
            calc.Find("button#press-add").Click();
            calc.Find("button#two").Click();
            calc.Find("button#two").Click();
            calc.Find("button#three").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 813");
        }

        [Fact]
        public void AddFromNoInput()
        {
            // Act
            calc.Find("button#press-add").Click();
            calc.Find("button#two").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 2");
        }

        [Fact]
        public void SubtractOneFromFive()
        {
            // Act
            calc.Find("button#five").Click();
            calc.Find("button#press-subtract").Click();
            calc.Find("button#one").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 4");
        }

        [Fact]
        public void SubtractTenFromFive()
        {
            // Act
            calc.Find("button#five").Click();
            calc.Find("button#press-subtract").Click();
            calc.Find("button#one").Click();
            calc.Find("button#zero").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": -5");
        }

        [Fact]
        public void PressSubtractMultipleTimes()
        {
            // Act
            calc.Find("button#five").Click();
            calc.Find("button#press-subtract").Click();
            calc.Find("button#press-subtract").Click();
            calc.Find("button#one").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 4");
        }

        [Fact]
        public void MultiplyFromNoInput()
        {
            // Act
            calc.Find("button#press-multiply").Click();
            calc.Find("button#two").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 0");
        }

        [Fact]
        public void MultiplyByZero()
        {
            // Act
            calc.Find("button#five").Click();
            calc.Find("button#press-multiply").Click();
            calc.Find("button#zero").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 0");
        }

        [Fact]
        public void AddToResult()
        {
            // Act
            calc.Find("button#five").Click();
            calc.Find("button#press-add").Click();
            calc.Find("button#six").Click();
            calc.Find("button#press-equals").Click();
            calc.Find("button#press-add").Click();
            calc.Find("button#one").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 12");
        }

        [Fact]
        public void DivideTenByTwo()
        {
            // Act
            calc.Find("button#one").Click();
            calc.Find("button#zero").Click();
            calc.Find("button#press-divide").Click();
            calc.Find("button#two").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 5");
        }

        [Fact]
        public void DivideByZero()
        {
            // Act
            calc.Find("button#one").Click();
            calc.Find("button#press-divide").Click();
            calc.Find("button#zero").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": Cannot / by 0");
        }

        [Fact]
        public void MultiplyAnswersThenNewSum()
        {
            // Act
            calc.Find("button#eight").Click();
            calc.Find("button#press-multiply").Click();
            calc.Find("button#eight").Click();
            calc.Find("button#press-equals").Click();
            //64
            calc.Find("button#press-multiply").Click();
            calc.Find("button#eight").Click();
            calc.Find("button#press-equals").Click();
            //512
            calc.Find("button#press-multiply").Click();
            calc.Find("button#eight").Click();
            calc.Find("button#press-equals").Click();
            //4096
            calc.Find("button#one").Click();
            calc.Find("button#press-add").Click();
            calc.Find("button#eight").Click();
            calc.Find("button#press-equals").Click();
            //9

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 9");
        }

        [Fact]
        public void MultiplyAnswersThenNewMultiDigitSum()
        {
            // Act
            calc.Find("button#eight").Click();
            calc.Find("button#press-multiply").Click();
            calc.Find("button#eight").Click();
            calc.Find("button#press-equals").Click();
            
            calc.Find("button#one").Click();
            calc.Find("button#one").Click();
            calc.Find("button#press-add").Click();
            calc.Find("button#five").Click();
            calc.Find("button#press-equals").Click();     

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 16");
        }

        [Fact]
        public void PlusEqualsTest()    //Maybe make SubtractEquals, MultiplyEquals & DivideEquals tests?
        {
            // Act
            calc.Find("button#eight").Click();
            calc.Find("button#press-add").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": +");
        }

        [Fact]
        public void ClearButtonClearsOperation()
        {
            // Act
            calc.Find("button#five").Click();
            calc.Find("button#press-divide").Click();
            calc.Find("button#press-clear").Click();

            calc.Find("button#five").Click();
            calc.Find("button#press-equals").Click();

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches(": 5");
        }

    }
}
