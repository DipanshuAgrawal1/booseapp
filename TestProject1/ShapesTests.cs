using BOOSE;
using main;

namespace ShapesTests
{
    [TestClass]
    public class ShapesTests
    {
        private AppCanvas canvas = null!;

        /// <summary>
        /// Initializes the test environment by creating a new AppCanvas instance.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            canvas = new AppCanvas();
        }

        #region Rect Tests (Parsed Command Test with AppStoredProgram)

        /// <summary>
        /// Tests a valid rectangle drawing command (non-filled) with correct dimensions.
        /// </summary>
        [TestMethod]
        public void TestRect_ValidDimensions_ShouldNotThrowException()
        {
            string validRectCommand = @"rect 100,50, false";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(validRectCommand);
            program.Run();
        }

        /// <summary>
        /// Tests a valid rectangle drawing command (filled) with correct dimensions.
        /// </summary>
        [TestMethod]
        public void TestRect_ValidFilledDimensions_ShouldNotThrowException()
        {
            string validFilledRectCommand = @"rect 100,50, true";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(validFilledRectCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid rectangle drawing command with a negative width.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestRect_InvalidNegativeWidth_ShouldThrowException()
        {
            string invalidWidthCommand = @"rect -100,50, false";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(invalidWidthCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid rectangle drawing command with a negative height.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestRect_InvalidNegativeHeight_ShouldThrowException()
        {
            string invalidHeightCommand = @"rect 100,-50, false";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(invalidHeightCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid rectangle drawing command with zero width.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestRect_ZeroWidth_ShouldThrowException()
        {
            string zeroWidthCommand = @"rect 0,50, false";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(zeroWidthCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid rectangle drawing command with zero height.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestRect_ZeroHeight_ShouldThrowException()
        {
            string zeroHeightCommand = @"rect 100,0, false";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(zeroHeightCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid rectangle drawing command with a non-numeric symbol in the width.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestRect_InvalidSymbolWidth_ShouldThrowException()
        {
            string invalidSymbolCommand = @"rect #,50, false";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(invalidSymbolCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid rectangle drawing command with a non-numeric string for the width.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestRect_InvalidStringWidth_ShouldThrowException()
        {
            string invalidStringCommand = @"rect hundred,50, false";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(invalidStringCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid rectangle drawing command with extra parameters.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestRect_ExtraParameters_ShouldThrowException()
        {
            string extraParametersCommand = @"rect 100,50, false, extra";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(extraParametersCommand);
            program.Run();
        }

        #endregion

        #region Triangle Tests (Parsed Command Test with AppStoredProgram)

        /// <summary>
        /// Tests a valid triangle drawing command with correct dimensions.
        /// </summary>
        [TestMethod]
        public void TestTri_ValidDimensions_ShouldNotThrowException()
        {
            string validTriCommand = @"tri 100,50";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(validTriCommand);
            program.Run();
        }

        /// <summary>
        /// Tests a valid filled triangle drawing command with correct dimensions.
        /// </summary>
        [TestMethod]
        public void TestTri_ValidFilledDimensions_ShouldNotThrowException()
        {
            string validFilledTriCommand = @"tri 100,50, true";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(validFilledTriCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid triangle drawing command with a negative base width.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestTri_InvalidNegativeBaseWidth_ShouldThrowException()
        {
            string invalidBaseWidthCommand = @"tri -100,50";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(invalidBaseWidthCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid triangle drawing command with a negative height.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestTri_InvalidNegativeHeight_ShouldThrowException()
        {
            string invalidHeightCommand = @"tri 100,-50";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(invalidHeightCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid triangle drawing command with zero base width.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestTri_ZeroBaseWidth_ShouldThrowException()
        {
            string zeroBaseWidthCommand = @"tri 0,50";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(zeroBaseWidthCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid triangle drawing command with zero height.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestTri_ZeroHeight_ShouldThrowException()
        {
            string zeroHeightCommand = @"tri 100,0";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(zeroHeightCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid triangle drawing command with a non-numeric symbol in the base width.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestTri_InvalidSymbolBaseWidth_ShouldThrowException()
        {
            string invalidSymbolCommand = @"tri #,50";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(invalidSymbolCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid triangle drawing command with a non-numeric string for the base width.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestTri_InvalidStringBaseWidth_ShouldThrowException()
        {
            string invalidStringCommand = @"tri hundred,50";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(invalidStringCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid triangle drawing command with extra parameters.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(main.CanvasException))]
        public void TestTri_ExtraParameters_ShouldThrowException()
        {
            string extraParametersCommand = @"tri 100,50, true, extra";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(extraParametersCommand);
            program.Run();
        }

        #endregion

        #region Circle Tests (Parsed Command Test with AppStoredProgram)

        /// <summary>
        /// Tests a valid circle drawing command with correct radius.
        /// </summary>
        [TestMethod]
        public void TestCircle_ValidRadius_ShouldNotThrowException()
        {
            string validCircleCommand = @"circle 50";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(validCircleCommand);
            program.Run();
        }

        /// <summary>
        /// Tests a valid filled circle drawing command with correct radius.
        /// </summary>
        [TestMethod]
        public void TestCircle_ValidFilledRadius_ShouldNotThrowException()
        {
            string validFilledCircleCommand = @"circle 50, true";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(validFilledCircleCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid circle drawing command with a negative radius.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestCircle_InvalidNegativeRadius_ShouldThrowException()
        {
            string invalidRadiusCommand = @"circle -50";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(invalidRadiusCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid circle drawing command with zero radius.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestCircle_ZeroRadius_ShouldThrowException()
        {
            string zeroRadiusCommand = @"circle 0";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(zeroRadiusCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid circle drawing command with a non-numeric symbol for the radius.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestCircle_InvalidSymbolRadius_ShouldThrowException()
        {
            string invalidSymbolCommand = @"circle #";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(invalidSymbolCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid circle drawing command with a non-numeric string for the radius.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestCircle_InvalidStringRadius_ShouldThrowException()
        {
            string invalidStringCommand = @"circle fifty";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(invalidStringCommand);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid circle drawing command with extra parameters.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestCircle_ExtraParameters_ShouldThrowException()
        {
            string extraParametersCommand = @"circle 50, true, extra";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(extraParametersCommand);
            program.Run();
        }

        #endregion
    }
}
