using BOOSE;
using main;

namespace VariableTests
{
    [TestClass]
    public class VariableTests
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

        #region Int Tests

        /// <summary>
        /// Tests a simple integer variable assignment and usage.
        /// </summary>
        [TestMethod]
        public void TestIntVariableAssignment_ShouldExecuteSuccessfully()
        {
            string command = @"int radius = 50
                               int width
                               width = 2 * radius
                               pen 255,0,0
                               moveto 100,100
                               circle radius
                               rect width, 100";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();  // Should execute without exceptions
        }

        /// <summary>
        /// Tests invalid integer operation, such as referencing an uninitialized variable.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestUninitializedIntVariable_ShouldThrowException()
        {
            string command = @"int width
                               pen 255,0,0
                               moveto 100,100
                               circle width";  // 'width' is uninitialized

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();  // Expecting exception
        }

        #endregion

        #region Real Tests

        /// <summary>
        /// Tests simple real variable assignment and usage.
        /// </summary>
        [TestMethod]
        public void TestRealVariableAssignment_ShouldExecuteSuccessfully()
        {
            string command = @"real length = 15.5
                               real width = 10.0
                               real pi = 3.14159
                               real radius = 27.7
                               real circ = 2 * pi * radius
                               pen 0,0,255
                               moveto 100,100
                               write length * width
                               moveto 100,125
                               write circ";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();  // Should execute without exceptions
        }
        #endregion

        #region Array Tests

        /// <summary>
        /// Tests simple array assignment and usage.
        /// </summary>
        [TestMethod]
        public void TestArrayAssignment_ShouldExecuteSuccessfully()
        {
            string command = @"array int nums 10
                               poke nums 5 = 99
                               int x
                               peek x = nums 5
                               circle x";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();  // Should execute without exceptions
        }

        /// <summary>
        /// Tests array out-of-bounds access, expecting an exception due to invalid index.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestArrayOutOfBounds_ShouldThrowException()
        {
            string command = @"array int nums 10
                               poke nums 5 = 99
                               int x
                               peek x = nums 15";  // Index 15 is out of bounds for the array

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();  // Expecting exception
        }

        /// <summary>
        /// Tests an array with an invalid data type (assigning a real value to an int array).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestArrayTypeMismatch_ShouldThrowException()
        {
            string command = @"array int nums 10
                               poke nums 5 = 99.99";  // Attempt to store a real value in an int array

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();  // Expecting exception
        }

        #endregion
    }
}
