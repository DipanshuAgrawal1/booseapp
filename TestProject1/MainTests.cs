using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using main;
using BOOSE;
using System.ComponentModel;

namespace AppCanvasTests
{
    [TestClass]
    public class MainTests
    {
        private AppCanvas canvas = null!;

        #region Initialization Tests
        [TestInitialize]
        public void SetUp()
        {
            canvas = new AppCanvas();
        }

        [TestMethod]
        public void TestInitialization()
        {
            Assert.AreEqual(0, canvas.Xpos);
            Assert.AreEqual(0, canvas.Ypos);
        }
        #endregion

        #region MoveTo Tests
        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestMoveTo_InvalidPosition_ShouldThrowException()
        {
            int invalidX = -50;
            int invalidY = 50;
            canvas.MoveTo(invalidX, invalidY);
        }

        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestMoveTo_InvalidPosition_NegativeY_ShouldThrowException()
        {
            int invalidX = 50;
            int invalidY = -50;
            canvas.MoveTo(invalidX, invalidY);
        }

        [TestMethod]
        public void TestMoveTo_CorrectPositionStoredAfterCommand()
        {
            int moveToX = 50;
            int moveToY = 50;

            canvas.MoveTo(moveToX, moveToY);
            Assert.AreEqual(moveToX, canvas.Xpos);
            Assert.AreEqual(moveToY, canvas.Ypos);
        }
        #endregion

        #region DrawTo Tests
        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestDrawTo_LargeNumbers_ShouldThrowException()
        {
            int startX = 0;
            int startY = 0;
            int largeX = 1000000;
            int largeY = 1000000;

            canvas.SetColour(0, 0, 0);
            canvas.MoveTo(startX, startY);

            canvas.DrawTo(largeX, largeY);
        }

        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestDrawTo_InvalidPosition_ShouldThrowException()
        {
            int invalidX = -50;
            int invalidY = 50;
            canvas.DrawTo(invalidX, invalidY);
        }

        [TestMethod]
        public void TestDrawTo_CorrectPositionStoredAfterCommand()
        {
            int moveToX = 100;
            int moveToY = 100;
            int drawToX = 200;
            int drawToY = 200;

            canvas.SetColour(0, 0, 0);
            canvas.MoveTo(moveToX, moveToY);
            canvas.DrawTo(drawToX, drawToY);

            Assert.AreEqual(drawToX, canvas.Xpos);
            Assert.AreEqual(drawToY, canvas.Ypos);
        }
        #endregion

        #region Colour Tests
        [TestMethod]
        public void TestSetColour_ValidColour_ShouldUpdatePenColour()
        {
            int red = 255;
            int green = 0;
            int blue = 0;

            canvas.SetColour(red, green, blue);
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), canvas.PenColour);
        }

        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestSetColour_InvalidColour_ShouldThrowException()
        {
            int invalidRed = 300;
            int green = 0;
            int blue = 0;

            canvas.SetColour(invalidRed, green, blue);
        }

        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestSetColour_InvalidNegativeColour_ShouldThrowException()
        {
            int negativeRed = -10;
            int green = 0;
            int blue = 0;

            canvas.SetColour(negativeRed, green, blue);
        }

        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestSetColour_InvalidSymbolInColour_ShouldThrowException()
        {
            string invalidGreen = "G";
            int red = 255;
            int blue = 0;

            try
            {
                int green = Convert.ToInt32(invalidGreen);
                canvas.SetColour(red, green, blue);
            }
            catch (FormatException)
            {
                throw new main.CanvasException("Color components must be valid integers.");
            }
        }
        #endregion

        #region Canvas State Tests
        [TestMethod]
        public void TestClear_ShouldClearCanvas()
        {
            canvas.Clear();
            Bitmap bm = (Bitmap)canvas.getBitmap();
            Color pixelColor = bm.GetPixel(0, 0);

            Assert.AreEqual(239, pixelColor.R);
            Assert.AreEqual(216, pixelColor.G);
            Assert.AreEqual(183, pixelColor.B);
            Assert.AreEqual(255, pixelColor.A);
        }

        [TestMethod]
        public void TestReset_ShouldResetPosition()
        {
            int resetX = 100;
            int resetY = 100;

            canvas.MoveTo(resetX, resetY);
            canvas.Reset();
            Assert.AreEqual(0, canvas.Xpos);
            Assert.AreEqual(0, canvas.Ypos);
        }
        #endregion

        #region Multi-line Program Tests
        [TestMethod]
        public void Multiline_Valid_Test()
        {
            string multilinetext = @"moveto 100,100
                                    pen 0,255,0
                                    circle 50, false
                                    pen 255,0,0
                                    moveto 150,50
                                    rect 50,100, false";

            AppCommandFactory Factory = new AppCommandFactory();
            StoredProgram Program = new StoredProgram(canvas);
            Parser Parser = new Parser(Factory, Program);

            Parser.ParseProgram(multilinetext);
            Program.Run();
        }

        [TestMethod]
        [ExpectedException(typeof(BOOSE.ParserException))]
        public void Multiline_Invalid_Test()
        {
            string invalidMultilinetext = @"moveto 100,100
                                    pen 0,255,0
                                    circle 50, true
                                    pen 255,0,0
                                    moveto 150,50
                                    rect 50,100, false
                                    move 200,200";

            AppCommandFactory Factory = new AppCommandFactory();
            StoredProgram Program = new StoredProgram(canvas);
            Parser Parser = new Parser(Factory, Program);

            Parser.ParseProgram(invalidMultilinetext);
        }

        [TestMethod]
        [ExpectedException(typeof(BOOSE.ParserException))]
        public void Multiline_Invalid_UnknownCommand_Test()
        {
            string multilinetextInvalid = @"moveto 100,100
                                            pen 0,255,0
                                            unknowncommand 50, false";

            AppCommandFactory Factory = new AppCommandFactory();
            StoredProgram Program = new StoredProgram(canvas);
            Parser Parser = new Parser(Factory, Program);

            Parser.ParseProgram(multilinetextInvalid);
        }
        #endregion

        #region AppCommandFactory Tests
        [TestMethod]
        public void TestMakeCommand_ValidCommand_ShouldReturnCorrectCommand()
        {
            AppCommandFactory factory = new AppCommandFactory();
            ICommand command = factory.MakeCommand("circle");

            Assert.IsInstanceOfType(command, typeof(AppCircle));
        }

        [TestMethod]
        [ExpectedException(typeof(BOOSE.FactoryException))]
        public void TestMakeCommand_InvalidCommand_ShouldThrowException()
        {
            AppCommandFactory factory = new AppCommandFactory();
            factory.MakeCommand("unknowncommand");
        }
        #endregion

        #region TestCleanup
        [TestCleanup]
        public void TearDown()
        {
            canvas = new AppCanvas();
        }
        #endregion
    }
}
