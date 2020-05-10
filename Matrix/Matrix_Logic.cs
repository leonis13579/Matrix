using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Matrix
{
    public class Matrix_Logic
    {
        public static List<int> LenghtLong { get; } = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static List<int> LenghtShort { get; } = new List<int>() { 2, 3 };

        public static bool IsDigit(string inp)
        {
            return int.TryParse(inp, out _);
        }

        public static List<int> Summ(List<int> S1, List<int> S2)
        {
            List<int> answ = new List<int>();

            for (int i = 0; i < S1.Count; i++)
            {
                answ.Add(S1[i] + S2[i]);
            }

            return answ;
        }

        public static List<int> Div(List<int> S1, List<int> S2)
        {
            List<int> answ = new List<int>();

            for (int i = 0; i < S1.Count; i++)
            {
                answ.Add(S1[i] - S2[i]);
            }

            return answ;
        }

        public static List<int> MultNum(List<int> S1, int num2)
        {
            List<int> answ = new List<int>();

            for (int i = 0; i < S1.Count; i++)
            {
                answ.Add(S1[i] * num2);
            }

            return answ;
        }

        public static List<int> Trasp (List<int> matrix, int n, int m)
        {
            List<int> answer = new List<int>();

            int m1 = m;
            int k = 0;
            int j = 0;
            while (m1 != 0)
            {
                for (int i = j; i < n * m; i += m)
                {
                    answer.Insert(k, matrix[i]);
                    k++;
                }
                j++;
                m1--;
            }

            return answer;
        }

        public static List<int> Mult(List<int> M1, List<int> M2, int n1, int m1, int n2, int m2)
        {
            List<int> answer = new List<int>();
            for (int i = 0; i < n1 * m2; i++) { answer.Add(0); }

            int x = n1;

            int j = 0;
            int k = 0;
            int t = 0;
            int c = 0;

            while (x != 0)
            {
                c++;

                for (int i = j; i < n2 * m2; i += m2)
                {
                    answer[k] = answer[k] + M1[t] * M2[i];
                    t++;
                }

                k++;

                if (c % m2 == 0)
                {
                    x--;

                    j = j - m2 + 1;
                }
                else
                {
                    t = t - m1;
                    j++;
                }
            }

            return answer;
        }

        public static int opred(List<int> matrix, int n)
        {
            if (n == 2)
            {
                return matrix[0] * matrix[3] - matrix[1] * matrix[2];
            }
            else if (n == 3)
            {
                return matrix[0] * matrix[4] * matrix[8] +
                    matrix[3] * matrix[7] * matrix[2] +
                    matrix[1] * matrix[5] * matrix[6] -
                    matrix[2] * matrix[4] * matrix[6] -
                    matrix[0] * matrix[5] * matrix[7] -
                    matrix[3] * matrix[1] * matrix[8];
            }
            else
            {
                return 0;
            }
        }

        public static List<double> Back(List<int> matrix, int n, int opr)
        {
            List<double> Arev = new List<double>();
            for (int i = 0; i < n*n; i++) { Arev.Add(0); }

            if (n == 2)
            {
                Arev[0] = (double)( matrix[3]) / (double)(opr);
                Arev[1] = (double)(-matrix[1]) / (double)(opr);
                Arev[2] = (double)(-matrix[2]) / (double)(opr);
                Arev[3] = (double)( matrix[0]) / (double)(opr);
            }
            if (n == 3)
            {
                Arev[0] =  (double)((matrix[4]) * (double)(matrix[8]) - (double)(matrix[7]) * (double)(matrix[5])) / (double)(opr);
                Arev[1] = -(double)((matrix[1]) * (double)(matrix[8]) - (double)(matrix[2]) * (double)(matrix[7])) / (double)(opr);
                Arev[2] =  (double)((matrix[3]) * (double)(matrix[7]) - (double)(matrix[6]) * (double)(matrix[4])) / (double)(opr);
                Arev[3] = -(double)((matrix[3]) * (double)(matrix[8]) - (double)(matrix[6]) * (double)(matrix[5])) / (double)(opr);
                Arev[4] =  (double)((matrix[0]) * (double)(matrix[8]) - (double)(matrix[2]) * (double)(matrix[6])) / (double)(opr);
                Arev[5] = -(double)((matrix[0]) * (double)(matrix[5]) - (double)(matrix[3]) * (double)(matrix[2])) / (double)(opr);
                Arev[6] =  (double)((matrix[1]) * (double)(matrix[5]) - (double)(matrix[2]) * (double)(matrix[4])) / (double)(opr);
                Arev[7] = -(double)((matrix[0]) * (double)(matrix[7]) - (double)(matrix[6]) * (double)(matrix[1])) / (double)(opr);
                Arev[8] =  (double)((matrix[0]) * (double)(matrix[4]) - (double)(matrix[1]) * (double)(matrix[3])) / (double)(opr);
            }

            for (int i = 0; i < n * n; i++) { if (Math.Abs(Arev[i]) == 0) { Arev[i] = 0; } }

            return Arev;
        }
    }
}
