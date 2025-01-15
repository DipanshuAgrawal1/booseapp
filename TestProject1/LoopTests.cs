using BOOSE;
using main;

namespace LoopTests
{
    [TestClass]
    public class LoopTests
    {
        private AppCanvas canvas = null!;

        [TestInitialize]
        public void SetUp()
        {
            canvas = new AppCanvas();
        }

        #region If Tests

        /// <summary>
        /// Test: Simple if-else structure with condition.
        /// </summary>
        [TestMethod]
        public void TestIfElseStructure_ShouldExecuteSuccessfully()
        {
            string command = @"int control = 50
                               if control < 10
                                   if control < 5
                                       pen 255,0,0
                                   else
                                       pen 0,0,255
                                   end if
                                   circle 20
                                   rect 20,20
                               else
                                   pen 0,255,0
                                   circle 100
                                   rect 100,100
                               end if";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Invalid Test: Missing 'end if' for the nested if condition.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestIfElseMissingEndIf_ShouldThrowException()
        {
            string command = @"int control = 50
                               if control < 10
                                   if control < 5
                                       pen 255,0,0
                                   else
                                       pen 0,0,255
                               circle 20
                               rect 20,20
                               else
                                   pen 0,255,0
                                   circle 100
                                   rect 100,100
                               end if";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Invalid Test: Invalid condition in if statement (non-existent variable).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestIfWithUndefinedVariable_ShouldThrowException()
        {
            string command = @"if control < 10
                                   pen 255,0,0
                               end if";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        #endregion

        #region While Tests

        /// <summary>
        /// Test: While loop with decreasing height.
        /// </summary>
        [TestMethod]
        public void TestWhileLoopDecreasingHeight_ShouldExecuteSuccessfully()
        {
            string command = @"moveto 100,100
                               int width = 9
                               int height = 150
                               pen 255,128,128
                               while height > 50
                                   circle height
                                   height = height - 15
                                   if height < 100
                                       pen 0,128,255
                                   end if
                               end while
                               pen 0,255,0
                               moveto 50,50
                               height = 50
                               while height > 10
                                   rect height, height
                                   height = height - 10
                               end while";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Test: While loop that doesn't enter the loop (height <= 50).
        /// </summary>
        [TestMethod]
        public void TestWhileLoopNoExecution_ShouldExecuteSuccessfully()
        {
            string command = @"int height = 40
                               while height > 50
                                   circle height
                                   height = height - 10
                               end while";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Invalid Test: While loop with undefined variable in condition.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.ParserException))]
        public void TestWhileWithUndefinedVariable_ShouldThrowException()
        {
            string command = @"while height > 50
                                   circle height
                                   height = height - 10
                               end while";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Invalid Test: While loop with missing 'end while'.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestWhileMissingEndWhile_ShouldThrowException()
        {
            string command = @"int height = 100
                               while height > 50
                                   circle height
                                   height = height - 10
                               pen 0,255,0
                               moveto 50,50";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        #endregion

        #region For Tests

        /// <summary>
        /// Test: Simple for loop (counting up).
        /// </summary>
        [TestMethod]
        public void TestForLoopCountingUp_ShouldExecuteSuccessfully()
        {
            string command = @"pen 255,0,0
                               moveto 200,200
                               for count = 1 to 20 step 2
                                   circle count * 10
                               end for";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Test: Simple for loop (counting down).
        /// </summary>
        [TestMethod]
        public void TestForLoopCountingDown_ShouldExecuteSuccessfully()
        {
            string command = @"pen 0,255,0
                               moveto 150,150
                               for count = 20 to 1 step -2
                                   circle count * 10
                               end for";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Test: For loop with negative step value.
        /// </summary>
        [TestMethod]
        public void TestForLoopWithNegativeStep_ShouldExecuteSuccessfully()
        {
            string command = @"pen 0,0,255
                               for count2 = 30 to 10 step -1
                                   circle count2 * 20
                               end for";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Invalid Test: For loop with missing 'end for'.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestForMissingEndFor_ShouldThrowException()
        {
            string command = @"pen 255,0,0
                               moveto 200,200
                               for count = 1 to 20 step 2
                                   circle count * 10
                               pen 0,255,0";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Invalid Test: For loop with invalid range (start > end).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestForLoopWithInvalidRange_ShouldThrowException()
        {
            string command = @"for count = 10 to 1 step 2
                                   circle count * 10
                               end for";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        #endregion
    }
}
