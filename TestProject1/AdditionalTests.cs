//using BOOSE;
//using main;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace AdditionalTests
//{
//    [TestClass]
//    public class AdditionalTests
//    {
//        private AppCanvas canvas = null!;

//        [TestInitialize]
//        public void SetUp()
//        {
//            canvas = new AppCanvas();
//        }

//        #region Method Tests

//        /// <summary>
//        /// Valid Test: Defining and calling a method with parameters.
//        /// </summary>
//        [TestMethod]
//        public void TestMethodWithParameters_ShouldExecuteSuccessfully()
//        {
//            string command = @"method int testMethod int one, int two
//                                  testMethod = one * two
//                                end method
//                                int global = 55
//                                call testMethod 10 15
//                                moveto 200,200
//                                write testMethod
//                                circle testMethod
//                                rect global, global";

//            AppCommandFactory factory = new AppCommandFactory();
//            AppStoredProgram program = new AppStoredProgram(canvas);
//            Parser parser = new Parser(factory, program);

//            parser.ParseProgram(command);
//            program.Run();
//        }

//        #endregion

//        #region Invalid Method Tests

//        /// <summary>
//        /// Invalid Test: Calling a method without defining it.
//        /// Expecting an exception because 'testMethod' is not defined.
//        /// </summary>
//        [TestMethod]
//        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
//        public void TestCallWithoutMethodDefinition_ShouldThrowException()
//        {
//            string command = @"
//                               call testMethod 10 15
//                               moveto 200,200
//                               write testMethod";

//            AppCommandFactory factory = new AppCommandFactory();
//            AppStoredProgram program = new AppStoredProgram(canvas);
//            Parser parser = new Parser(factory, program);

//            parser.ParseProgram(command);
//            program.Run();
//        }

//        /// <summary>
//        /// Invalid Test: Missing input parameters when calling a method.
//        /// Expecting an exception due to missing input parameters.
//        /// </summary>
//        [TestMethod]
//        [ExpectedException(typeof(BOOSE.ParserException))]
//        public void TestMethodCallWithMissingParameters_ShouldThrowException()
//        {
//            string command = @"method testMethod int one, int two
//                                   testMethod = one * two
//                               end method
//                               call testMethod 10
//                               moveto 200,200
//                               write testMethod";

//            AppCommandFactory factory = new AppCommandFactory();
//            AppStoredProgram program = new AppStoredProgram(canvas);
//            Parser parser = new Parser(factory, program);

//            parser.ParseProgram(command);
//            program.Run();
//        }

//        /// <summary>
//        /// Invalid Test: Incorrect variable type used in method.
//        /// Expecting an exception due to incorrect variable type ('string' instead of 'real').
//        /// </summary>
//        [TestMethod]
//        [ExpectedException(typeof(BOOSE.ParserException))]
//        public void TestMethodWithIncorrectParameterType_ShouldThrowException()
//        {
//            string command = @"method testMethod int one, real two
//                                   testMethod = one * two
//                               end method
//                               call testMethod 10 'string'
//                               moveto 200,200
//                               write testMethod";

//            AppCommandFactory factory = new AppCommandFactory();
//            AppStoredProgram program = new AppStoredProgram(canvas);
//            Parser parser = new Parser(factory, program);

//            parser.ParseProgram(command);
//            program.Run();
//        }

//        /// <summary>
//        /// Invalid Test: Method with mismatched parameter count.
//        /// Expecting an exception because parameter count doesn't match.
//        /// </summary>
//        [TestMethod]
//        [ExpectedException(typeof(BOOSE.ParserException))]
//        public void TestMethodWithMismatchedParameterCount_ShouldThrowException()
//        {
//            string command = @"method testMethod int one, int two
//                                   testMethod = one * two
//                               end method
//                               call testMethod 10 15 20
//                               moveto 200,200
//                               write testMethod";

//            AppCommandFactory factory = new AppCommandFactory();
//            AppStoredProgram program = new AppStoredProgram(canvas);
//            Parser parser = new Parser(factory, program);

//            parser.ParseProgram(command);
//            program.Run();
//        }

//        /// <summary>
//        /// Invalid Test: Method with missing 'end method' keyword.
//        /// Expecting an exception due to missing 'end method'.
//        /// </summary>
//        [TestMethod]
//        [ExpectedException(typeof(BOOSE.ParserException))]
//        public void TestMethodWithMissingEndMethod_ShouldThrowException()
//        {
//            string command = @"method testMethod int one, int two
//                                   testMethod = one * two
//                               // Missing 'end method'
//                               call testMethod 10 15
//                               moveto 200,200
//                               write testMethod";

//            AppCommandFactory factory = new AppCommandFactory();
//            AppStoredProgram program = new AppStoredProgram(canvas);
//            Parser parser = new Parser(factory, program);

//            parser.ParseProgram(command);
//            program.Run();
//        }

//        #endregion
//    }
//}
