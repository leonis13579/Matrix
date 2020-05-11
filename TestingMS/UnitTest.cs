using Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestingMS
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void InputTest()
        {
            Console.WriteLine("Ввод: 12\n Ожидаемый результат: true\t Полученный результат: " + Matrix_Logic.IsDigit("12") + "\n");
            Assert.AreEqual(Matrix_Logic.IsDigit("12"), true);

            Console.WriteLine("Ввод: 0\n Ожидаемый результат: true\t Полученный результат: " + Matrix_Logic.IsDigit("0") + "\n");
            Assert.AreEqual(Matrix_Logic.IsDigit("0"), true);

            Console.WriteLine("Ввод: -6\n Ожидаемый результат: true\t Полученный результат: " + Matrix_Logic.IsDigit("-6") + "\n");
            Assert.AreEqual(Matrix_Logic.IsDigit("-6"), true);

            Console.WriteLine("Ввод: abc\n Ожидаемый результат: false\t Полученный результат: " + Matrix_Logic.IsDigit("abc") + "\n");
            Assert.AreEqual(Matrix_Logic.IsDigit("abc"), false);

            Console.WriteLine("Ввод: 4f2s3w\n Ожидаемый результат: false\t Полученный результат: " + Matrix_Logic.IsDigit("4f2s3w") + "\n");
            Assert.AreEqual(Matrix_Logic.IsDigit("4f2s3w"), false);
        }

        [TestMethod]
        public void SumTest()
        {
            Console.WriteLine("Ввод: { 1, 0, 0, 1 } и { -1, 0, 0, -1 }\n Ожидаемый результат: { 0, 0, 0, 0 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Summ(new List<int> { 1, 0, 0, 1 }, new List<int> { -1, 0, 0, -1 })) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Summ(new List<int>{ 1, 0, 0, 1 }, new List<int> { -1, 0, 0, -1 }), new List<int> { 0, 0, 0, 0 });

            Console.WriteLine("Ввод: { 1, 2, 3, 4, 5, 6, 7, 8, 9 } и { 9, 8, 7, 6, 5, 4, 3, 2, 1 }\n Ожидаемый результат: { 10, 10, 10, 10, 10, 10, 10, 10, 10 }\t Полученный результат: " + 
                "{ " + string.Join(", ", Matrix_Logic.Summ(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new List<int> { 9, 8, 7, 6, 5, 4, 3, 2, 1 })) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Summ(new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new List<int> { 9, 8, 7, 6, 5, 4, 3, 2, 1 }), new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10 });

            Console.WriteLine("Ввод: { 11, 12, 13, 14, 15 } и { 15, 16, 17, 18, 19 }\n Ожидаемый результат: { 26, 28, 30, 32, 34 }\t Полученный результат: " + 
                "{ " + string.Join(", ", Matrix_Logic.Summ(new List<int> { 11, 12, 13, 14, 15 }, new List<int> { 15, 16, 17, 18, 19 })) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Summ(new List<int>{ 11, 12, 13, 14, 15 }, new List<int> { 15, 16, 17, 18, 19 }), new List<int> { 26, 28, 30, 32, 34 });

            Console.WriteLine("Ввод: { 11111, 22222, 33333, 44444, 55555, 66666, 77777, 88888, 99999 } и { -11110, -22221, -33332, -44443, -55554, -66665, -77776, -88887, -99998 }\n Ожидаемый результат: { 1, 1, 1, 1, 1, 1, 1, 1, 1 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Summ(new List<int> { 11111, 22222, 33333, 44444, 55555, 66666, 77777, 88888, 99999 }, new List<int> { -11110, -22221, -33332, -44443, -55554, -66665, -77776, -88887, -99998 })) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Summ(new List<int>{ 11111, 22222, 33333, 44444, 55555, 66666, 77777, 88888, 99999}, new 
                List<int> { -11110, -22221, -33332, -44443, -55554, -66665, -77776, -88887, -99998 }), new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1 });

            Console.WriteLine("Ввод: { 123456789 } и { 987654321 }\n Ожидаемый результат: { 1111111110‬ }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Summ(new List<int> { 123456789 }, new List<int> { 987654321 })) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Summ(new List<int>{ 123456789 }, new List<int> { 987654321 }), new List<int> { 1111111110 });
        }

        [TestMethod]
        public void DivTest()
        {
            Console.WriteLine("Ввод: { 1, 0, 0, 1 } и { -1, 0, 0, -1 }\n Ожидаемый результат: {2, 0, 0, 2} \t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Div(new List<int> { 1, 0, 0, 1 }, new List<int> { -1, 0, 0, -1 })) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Div(new List<int> { 1, 0, 0, 1 }, new List<int> { -1, 0, 0, -1 }), new List<int> { 2, 0, 0, 2 });

            Console.WriteLine("Ввод: { 9, 8, 7, 6, 5, 4, 3, 2, 1 } и { 1, 2, 3, 4, 5, 6, 7, 8, 9 }\n Ожидаемый результат: { 8, 6, 4, 2, 0, -2, -4, -6, -8 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Div(new List<int> { 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 })) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Div(new List<int> { 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }), new List<int> { 8, 6, 4, 2, 0, -2, -4, -6, -8 });

            Console.WriteLine("Ввод: { 11, 22, 33, 44, 55 } и { 1, 2, 3, 4, 5 }\n Ожидаемый результат: { 10, 20, 30, 40, 50 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Div(new List<int> { 11, 22, 33, 44, 55 }, new List<int> { 1, 2, 3, 4, 5 })) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Div(new List<int> { 11, 22, 33, 44, 55 }, new List<int> { 1, 2, 3, 4, 5 }), new List<int> { 10, 20, 30, 40, 50 });

            Console.WriteLine("Ввод: { 40, 50, 60, 70, 80, 90 } и { 140, 150, 160, 170, 180, 190 }\n Ожидаемый результат: { -100, -100, -100, -100, -100, -100 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Div(new List<int> { 40, 50, 60, 70, 80, 90 }, new List<int> { 140, 150, 160, 170, 180, 190 })) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Div(new List<int> { 40, 50, 60, 70, 80, 90 }, new List<int> { 140, 150, 160, 170, 180, 190 }), new List<int> { -100, -100, -100, -100, -100, -100 });

            Console.WriteLine("Ввод: { 987654321 } и { 123456789 }\n Ожидаемый результат: { 864197532 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Div(new List<int> { 987654321 }, new List<int> { 123456789 })) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Div(new List<int> { 987654321 }, new List<int> { 123456789 }), new List<int> { 864197532 });
        }

        [TestMethod]
        public void NumMultTest()
        {
            Console.WriteLine("Ввод: { 1, 0, 0, 1 } и 2147483647\n Ожидаемый результат: { 2147483647, 0, 0, 2147483647 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.MultNum(new List<int> { 1, 0, 0, 1 }, 2147483647)) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.MultNum(new List<int> { 1, 0, 0, 1 }, 2147483647), new List<int> { 2147483647, 0, 0, 2147483647 });

            Console.WriteLine("Ввод: { 2, 2, 2, 2 } и 16\n Ожидаемый результат: { 32, 32, 32, 32 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.MultNum(new List<int> { 2, 2, 2, 2 }, 16)) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.MultNum(new List<int> { 2, 2, 2, 2 }, 16), new List<int> { 32, 32, 32, 32 });

            Console.WriteLine("Ввод: { 11, 12, 13, 14, 15, 16, 17, 18, 19 } и 0\n Ожидаемый результат: { 0, 0, 0, 0, 0, 0, 0, 0, 0 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.MultNum(new List<int> { 11, 12, 13, 14, 15, 16, 17, 18, 19 }, 0)) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.MultNum(new List<int> { 11, 12, 13, 14, 15, 16, 17, 18, 19 }, 0), new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        }

        [TestMethod]
        public void TransTest()
        {
            Console.WriteLine("Ввод: { 1, 0, 0, 0, 1, 0, 0, 0, 1 } \n Ожидаемый результат: { 1, 0, 0, 0, 1, 0, 0, 0, 1 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Trasp(new List<int> { 1, 0, 0, 0, 1, 0, 0, 0, 1 }, 3, 3)) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Trasp(new List<int> { 1, 0, 0, 0, 1, 0, 0, 0, 1 }, 3, 3), new List<int> { 1, 0, 0, 0, 1, 0, 0, 0, 1 });

            Console.WriteLine("Ввод: { 1, 2, 3, 4, 5, 6 }\n Ожидаемый результат: { 1, 3, 5, 2, 4, 6 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Trasp(new List<int> { 1, 2, 3, 4, 5, 6 }, 3, 2)) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Trasp(new List<int> { 1, 2, 3, 4, 5, 6 }, 3, 2), new List<int> { 1, 3, 5, 2, 4, 6 });

            Console.WriteLine("Ввод: { 9, 8, 7, 6, 5, 4 }\n Ожидаемый результат: { 9, 6, 8, 5, 7, 4 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Trasp(new List<int> { 9, 8, 7, 6, 5, 4 }, 2, 3)) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Trasp(new List<int> { 9, 8, 7, 6, 5, 4 }, 2, 3), new List<int> { 9, 6, 8, 5, 7, 4});

            Console.WriteLine("Ввод: { 11, 12, 13, 14, 15, 16, 17, 18, 19 }\n Ожидаемый результат: { 11, 14, 17, 12, 15, 18, 13, 16, 19 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Trasp(new List<int> { 11, 12, 13, 14, 15, 16, 17, 18, 19 }, 3, 3)) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Trasp(new List<int> { 11, 12, 13, 14, 15, 16, 17, 18, 19 }, 3, 3), new List<int> { 11, 14, 17, 12, 15, 18, 13, 16, 19 });
        }

        [TestMethod]
        public void MultTest()
        {
            Console.WriteLine("Ввод: { 1, 2, 3, 4 } и { 5, 6, 7, 8 }\n Ожидаемый результат: { 19, 22, 43, 50 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Mult(new List<int> { 1, 2, 3, 4 }, new List<int> { 5, 6, 7, 8 }, 2, 2, 2, 2)) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Mult(new List<int> { 1, 2, 3, 4 }, new List<int> { 5, 6, 7, 8 }, 2, 2, 2, 2), new List<int> { 19, 22, 43, 50 });

            Console.WriteLine("Ввод: { 1, 2, 3, 4, 5, 6, 7, 8, 9 } и { 1, 0, 0, 0, 1, 0, 0, 0, 1 }\n Ожидаемый результат: { 1, 2, 3, 4, 5, 6, 7, 8, 9 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Mult(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new List<int> { 1, 0, 0, 0, 1, 0, 0, 0, 1 }, 3, 3, 3, 3)) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Mult(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new List<int> { 1, 0, 0, 0, 1, 0, 0, 0, 1 }, 3, 3, 3, 3), new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            Console.WriteLine("Ввод: { 11, 12, 13, 14, 15, 16 } и { 1, 2, 3, 4, 5, 6, 7, 8, 9 }\n Ожидаемый результат: { 150, 186, 222, 186, 231, 276 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.Mult(new List<int> { 11, 12, 13, 14, 15, 16 }, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 3, 3, 3)) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.Mult(new List<int> { 11, 12, 13, 14, 15, 16 }, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 3, 3, 3), new List<int> { 150, 186, 222, 186, 231, 276 });
        }

        [TestMethod]
        public void OprTest()
        {
            Console.WriteLine("Ввод: { 1, 0, 0, 1 }\n Ожидаемый результат: 1\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.opred(new List<int> { 1, 0, 0, 1 }, 2)) + " }\n");
            Assert.AreEqual(Matrix_Logic.opred(new List<int> { 1, 0, 0, 1 }, 2), 1);

            Console.WriteLine("Ввод: { 1, 2, 3, 4 }\n Ожидаемый результат: -2\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.opred(new List<int> { 1, 2, 3, 4 }, 2)) + " }\n");
            Assert.AreEqual(Matrix_Logic.opred(new List<int> { 1, 2, 3, 4 }, 2), -2);

            Console.WriteLine("Ввод: { 1, 2, 3, 4, 5, 6, 7, 8, 9 }\n Ожидаемый результат: 0\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.opred(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3)) + " }\n");
            Assert.AreEqual(Matrix_Logic.opred(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3), 0);

            Console.WriteLine("Ввод: { 5, 6, 7, 8 }\n Ожидаемый результат: -2\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.opred(new List<int> { 5, 6, 7, 8 }, 2)) + " }\n");
            Assert.AreEqual(Matrix_Logic.opred(new List<int> { 5, 6, 7, 8 }, 2), -2);
        }

        [TestMethod]
        public void BackTest()
        {
            List<int> inp = new List<int> { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
            Console.WriteLine("Ввод: { 1, 0, 0, 0, 1, 0, 0, 0, 1 } \n Ожидаемый результат: { 1, 0, 0, 0, 1, 0, 0, 0, 1 }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.opred(inp, 3) != 0 ? Matrix_Logic.Back(inp, 3, Matrix_Logic.opred(inp, 3)) : new List<double>()) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.opred(inp, 3) != 0 ? Matrix_Logic.Back(inp, 3, Matrix_Logic.opred(inp, 3)) : new List<double>(), new List<double> { 1, 0, 0, 0, 1, 0, 0, 0, 1 });

            inp = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9};
            Console.WriteLine("Ввод: { 1, 2, 3, 4, 5, 6, 7, 8, 9 }\n Ожидаемый результат: { }\t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.opred(inp, 3) != 0 ? Matrix_Logic.Back(inp, 3, Matrix_Logic.opred(inp, 3)) : new List<double>()) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.opred(inp, 3) != 0 ? Matrix_Logic.Back(inp, 3, Matrix_Logic.opred(inp, 3)) : new List<double>(), new List<double>());

            inp = new List<int> { 1, 2, 3, 4 };
            Console.WriteLine("Ввод: { 1, 2, 3, 4 } \n Ожидаемый результат: { -2, 1, 1.5, -0.5 } \t Полученный результат: " +
                "{ " + string.Join(", ", Matrix_Logic.opred(inp, 2) != 0 ? Matrix_Logic.Back(inp, 2, Matrix_Logic.opred(inp, 2)) : new List<double>()) + " }\n");
            CollectionAssert.AreEqual(Matrix_Logic.opred(inp, 2) != 0 ? Matrix_Logic.Back(inp, 2, Matrix_Logic.opred(inp, 2)) : new List<double>(), new List<double> { -2, 1, 1.5, -0.5 });
        }
    }
}
