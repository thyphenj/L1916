using System;

namespace Listener1916
{
    internal class Program
    {
        static SortedSet<Factor> Divisors = new SortedSet<Factor>();

        static void Main()
        {
            // -- Preset list of divisors FOR ALL NUMBERS upto 6 digits

            PopulateDivisors(1000000);

            // ---------------------------------------------------------------------------------------------------------------
            // -- Across

            var poss_A = new AnswerList('A');               //var poss_A = FindDivisors('A', 9, 13);
            var poss_B = FindDivisors('B', 2, 8);
            var poss_C = FindDivisors('C', 6, 14);
            var poss_D = FindDivisors('D', 5, 3);
            var poss_E = FindDivisors('E', 4, 6);
            var poss_F = FindDivisors('F', 3, 20);
            var poss_G = FindDivisors('G', 4, 4);
            var poss_H = FindDivisors('H', 2, 12);
            var poss_J = FindDivisors('J', 3, 6);
            var poss_K = FindDivisors('K', 2, 4);
            var poss_M = FindDivisors('M', 4, 33);
            var poss_N = FindDivisors('N', 3, 5);
            var poss_P = FindDivisors('P', 4, 10);
            var poss_Q = FindDivisors('Q', 5, 6);
            var poss_R = FindDivisors('R', 6, 15);
            var poss_S = FindDivisors('S', 2, 8);
            var poss_T = new AnswerList('T');               //var poss_T = FindDivisors('T', 9, 26);

            // -- Down

            var poss_a = new AnswerList('a');               //var poss_a = FindDivisors('a', 9, 11);
            var poss_b = FindDivisors('b', 2, 10);
            var poss_c = FindDivisors('c', 3, 9);
            var poss_d = FindDivisors('d', 4, 20);
            var poss_e = new AnswerList('e');               //var poss_e = FindDivisors('e', 9, 7);
            var poss_f = FindDivisors('f', 3, 18);
            var poss_g = FindDivisors('g', 3, 9);
            var poss_h = FindDivisors('h', 4, 28);
            var poss_j = FindDivisors('j', 4, 16);
            var poss_k = FindDivisors('k', 3, 20);
            var poss_m = FindDivisors('m', 3, 21);
            var poss_n = FindDivisors('n', 4, 2);
            var poss_p = FindDivisors('p', 4, 35);
            var poss_q = FindDivisors('q', 3, 3);
            var poss_r = FindDivisors('r', 4, 12);
            var poss_s = FindDivisors('s', 3, 10);
            var poss_t = FindDivisors('t', 3, 16);
            var poss_u = FindDivisors('u', 3, 24);
            var poss_v = FindDivisors('v', 2, 3);

            // -- These take FOREVER to calc - so ...

            poss_A.Add(new Factor(244140625, 13));
            poss_a.Add(new Factor(282475249, 11));
            poss_e.Add(new Factor(594823321, 7));
            poss_T.Add(new Factor(914609961, 26));

            // ---------------------------------------------------------------------------------------------------------------
            // -- Nothing can start with a zero - so exclude these out of hand

            poss_B.ExcludeDigitAtPosition(0, 1);
            poss_C.ExcludeDigitAtPosition(0, 1);
            poss_C.ExcludeDigitAtPosition(0, 3);
            poss_C.ExcludeDigitAtPosition(0, 5);
            poss_D.ExcludeDigitAtPosition(0, 2);
            poss_H.ExcludeDigitAtPosition(0, 1);
            poss_M.ExcludeDigitAtPosition(0, 1);
            poss_R.ExcludeDigitAtPosition(0, 5);

            poss_b.ExcludeDigitAtPosition(0, 1);
            poss_f.ExcludeDigitAtPosition(0, 2);
            poss_h.ExcludeDigitAtPosition(0, 1);
            poss_j.ExcludeDigitAtPosition(0, 3);
            poss_n.ExcludeDigitAtPosition(0, 3);
            poss_t.ExcludeDigitAtPosition(0, 2);

            // ---------------------------------------------------------------------------------------------------------------
            // -- We have 5 values that are now fixed - M, N, b, m, p - minimize the crossers

            poss_n.OnlyAllowDigitAtPosition(poss_M.GetDigitsAtPos(0), 1);// -- from M=9216
            poss_r.OnlyAllowDigitAtPosition(poss_M.GetDigitsAtPos(1), 0);// -- from M=9216
            poss_p.OnlyAllowDigitAtPosition(poss_M.GetDigitsAtPos(2), 1);// -- from M=9216
            poss_m.OnlyAllowDigitAtPosition(poss_M.GetDigitsAtPos(3), 2);// -- from M=9216

            poss_s.OnlyAllowDigitAtPosition(poss_N.GetDigitsAtPos(0), 0);// -- from N=625
            poss_q.OnlyAllowDigitAtPosition(poss_N.GetDigitsAtPos(1), 1);// -- from N=625
            poss_t.OnlyAllowDigitAtPosition(poss_N.GetDigitsAtPos(2), 0);// -- from N=625

            poss_C.OnlyAllowDigitAtPosition(poss_b.GetDigitsAtPos(1), 0);// -- from b=48

            poss_G.OnlyAllowDigitAtPosition(poss_m.GetDigitsAtPos(0), 0);// -- from m=576
            poss_J.OnlyAllowDigitAtPosition(poss_m.GetDigitsAtPos(1), 1);// -- from m=576
            poss_M.OnlyAllowDigitAtPosition(poss_m.GetDigitsAtPos(2), 3);// -- from m=576

            poss_J.OnlyAllowDigitAtPosition(poss_p.GetDigitsAtPos(0), 0);// -- from p=5184
            poss_M.OnlyAllowDigitAtPosition(poss_p.GetDigitsAtPos(1), 2);// -- from p=5184
            poss_P.OnlyAllowDigitAtPosition(poss_p.GetDigitsAtPos(2), 3);// -- from p=5184
            poss_R.OnlyAllowDigitAtPosition(poss_p.GetDigitsAtPos(3), 2);// -- from p=5184

            // ---------------------------------------------------------------------------------------------------------------
            // -- Here we go ...

            for (int i = 0; i < 3; i++)
            {
                OnlyAllowCrossDigits(poss_A, 0, poss_a, 0); // - A
                OnlyAllowCrossDigits(poss_A, 2, poss_b, 0);
                OnlyAllowCrossDigits(poss_A, 4, poss_c, 0);
                OnlyAllowCrossDigits(poss_A, 6, poss_d, 0);
                OnlyAllowCrossDigits(poss_A, 8, poss_e, 0);

                OnlyAllowCrossDigits(poss_B, 0, poss_a, 1); // - B
                OnlyAllowCrossDigits(poss_B, 1, poss_f, 0);

                OnlyAllowCrossDigits(poss_C, 0, poss_b, 1); // - C
                OnlyAllowCrossDigits(poss_C, 1, poss_g, 0);
                OnlyAllowCrossDigits(poss_C, 2, poss_c, 1);
                OnlyAllowCrossDigits(poss_C, 3, poss_h, 0);
                OnlyAllowCrossDigits(poss_C, 4, poss_d, 1);
                OnlyAllowCrossDigits(poss_C, 5, poss_j, 0);

                OnlyAllowCrossDigits(poss_D, 0, poss_a, 2); // -- D
                OnlyAllowCrossDigits(poss_D, 1, poss_f, 1);
                OnlyAllowCrossDigits(poss_D, 2, poss_k, 0);
                OnlyAllowCrossDigits(poss_D, 3, poss_g, 1);
                OnlyAllowCrossDigits(poss_D, 4, poss_c, 2);

                OnlyAllowCrossDigits(poss_E, 0, poss_h, 1); // -- E
                OnlyAllowCrossDigits(poss_E, 1, poss_d, 2);
                OnlyAllowCrossDigits(poss_E, 2, poss_j, 1);
                OnlyAllowCrossDigits(poss_E, 3, poss_e, 2);

                OnlyAllowCrossDigits(poss_F, 0, poss_f, 2); // -- F
                OnlyAllowCrossDigits(poss_F, 1, poss_k, 1);
                OnlyAllowCrossDigits(poss_F, 2, poss_g, 2);

                OnlyAllowCrossDigits(poss_G, 0, poss_m, 0); // -- G
                OnlyAllowCrossDigits(poss_G, 1, poss_h, 2);
                OnlyAllowCrossDigits(poss_G, 2, poss_d, 3);
                OnlyAllowCrossDigits(poss_G, 3, poss_j, 2);

                OnlyAllowCrossDigits(poss_H, 0, poss_a, 4); // -- H
                OnlyAllowCrossDigits(poss_H, 1, poss_n, 0);

                OnlyAllowCrossDigits(poss_J, 0, poss_p, 0); // -- J
                OnlyAllowCrossDigits(poss_J, 1, poss_m, 1);
                OnlyAllowCrossDigits(poss_J, 2, poss_h, 3);

                OnlyAllowCrossDigits(poss_K, 0, poss_j, 3); // -- K
                OnlyAllowCrossDigits(poss_K, 1, poss_e, 4);

                OnlyAllowCrossDigits(poss_M, 0, poss_n, 1); // -- M
                OnlyAllowCrossDigits(poss_M, 1, poss_r, 0);
                OnlyAllowCrossDigits(poss_M, 2, poss_p, 1);
                OnlyAllowCrossDigits(poss_M, 3, poss_m, 2);

                OnlyAllowCrossDigits(poss_N, 0, poss_s, 0); // -- N
                OnlyAllowCrossDigits(poss_N, 1, poss_q, 1);
                OnlyAllowCrossDigits(poss_N, 2, poss_t, 0);

                OnlyAllowCrossDigits(poss_P, 0, poss_a, 6); // -- P
                OnlyAllowCrossDigits(poss_P, 1, poss_n, 2);
                OnlyAllowCrossDigits(poss_P, 2, poss_r, 1);
                OnlyAllowCrossDigits(poss_P, 3, poss_p, 2);

                OnlyAllowCrossDigits(poss_Q, 0, poss_u, 0); // -- Q
                OnlyAllowCrossDigits(poss_Q, 1, poss_s, 1);
                OnlyAllowCrossDigits(poss_Q, 2, poss_q, 2);
                OnlyAllowCrossDigits(poss_Q, 3, poss_t, 1);
                OnlyAllowCrossDigits(poss_Q, 4, poss_e, 6);

                OnlyAllowCrossDigits(poss_R, 0, poss_n, 3); // -- R
                OnlyAllowCrossDigits(poss_R, 1, poss_r, 2);
                OnlyAllowCrossDigits(poss_R, 2, poss_p, 3);
                OnlyAllowCrossDigits(poss_R, 3, poss_u, 1);
                OnlyAllowCrossDigits(poss_R, 4, poss_s, 2);
                OnlyAllowCrossDigits(poss_R, 5, poss_v, 0);

                OnlyAllowCrossDigits(poss_S, 0, poss_t, 2); // -- S
                OnlyAllowCrossDigits(poss_S, 1, poss_e, 7);

                OnlyAllowCrossDigits(poss_T, 0, poss_a, 8); // -- T
                OnlyAllowCrossDigits(poss_T, 2, poss_r, 3);
                OnlyAllowCrossDigits(poss_T, 4, poss_u, 2);
                OnlyAllowCrossDigits(poss_T, 6, poss_v, 1);
                OnlyAllowCrossDigits(poss_T, 8, poss_e, 8);

            }

            // ---------------------------------------------------------------------------------------------------------------
            // -- display 

            Console.WriteLine(poss_A);
            Console.WriteLine(poss_B);
            Console.WriteLine(poss_C);
            Console.WriteLine(poss_D);
            Console.WriteLine(poss_E);
            Console.WriteLine(poss_F);
            Console.WriteLine(poss_G);
            Console.WriteLine(poss_H);
            Console.WriteLine(poss_J);
            Console.WriteLine(poss_K);
            Console.WriteLine(poss_M);
            Console.WriteLine(poss_N);
            Console.WriteLine(poss_P);
            Console.WriteLine(poss_Q);
            Console.WriteLine(poss_R);
            Console.WriteLine(poss_S);
            Console.WriteLine(poss_T);
            Console.WriteLine();

            Console.WriteLine(poss_a);
            Console.WriteLine(poss_b);
            Console.WriteLine(poss_c);
            Console.WriteLine(poss_d);
            Console.WriteLine(poss_e);
            Console.WriteLine(poss_f);
            Console.WriteLine(poss_g);
            Console.WriteLine(poss_h);
            Console.WriteLine(poss_j);
            Console.WriteLine(poss_k);
            Console.WriteLine(poss_m);
            Console.WriteLine(poss_n);
            Console.WriteLine(poss_p);
            Console.WriteLine(poss_q);
            Console.WriteLine(poss_r);
            Console.WriteLine(poss_s);
            Console.WriteLine(poss_t);
            Console.WriteLine(poss_u);
            Console.WriteLine(poss_v);


            Console.WriteLine("-------------------");
        }
#if false

            // ---------------------------------------------------------------------------------------------------------------
            // -- have a go at e(7)

            int[] from_E = poss_E.GetDigitsAtPos(3);
            int[] from_K = poss_K.GetDigitsAtPos(1);
            int[] from_Q = poss_Q.GetDigitsAtPos(4);
            int[] from_S = poss_S.GetDigitsAtPos(1);

            for (int i = 10; i < 100; i++)
                for (int k = 0; k < 10; k++)
                    for (int l = 0; l < 10; l++)
                        for (int m = 0; m < 10; m++)
                        {
                            long root
                                = i * 10000000
                                + k * 100000
                                + l * 1000
                                + m;

                            foreach (var E in from_E)
                                foreach (var K in from_K)
                                    foreach (var Q in from_Q)
                                        foreach (var S in from_S)
                                        {
                                            long theNum = root
                                                + E * 1000000
                                                + K * 10000
                                                + Q * 100
                                                + S * 10;
                                            if (m == 0) Console.Write($"{root} {theNum}\r");

                                            var f = new Factor(theNum);
                                            if (f.FactorCount == 7)
                                                Console.WriteLine($"{root} {theNum}   =>  {f}");
                                        }
                        }
                        
            // ---------------------------------------------------------------------------------------------------------------
            // -- have a go at A(13)

            int from_b = poss_b.GetDigitsAtPos(0)[0];
            int from_c = poss_c.GetDigitsAtPos(0)[0];
            int from_e = poss_e.GetDigitsAtPos(0)[0];
            int[] from_d = poss_d.GetDigitsAtPos(0);

            for (int i = 10; i < 100; i++)
                for (int j = 0; j < 10; j++)
                    for ( int k = 0; k < 10; k++)
                        for ( int l = 0; l < 10; l++)
                        {
                            long root
                                = i * 10000000
                                + j * 100000
                                + k * 1000
                                + l * 10;
                            root = root
                                + from_b * 1000000
                                + from_c * 10000
                                + from_e;
                            foreach ( var d in from_d)
                            {
                                long theNum = root + d* 100 ;

                                if (k == 0) Console.Write($"{root} {theNum}\r");

                                var f = new Factor(theNum);
                                if (f.FactorCount == 13)
                                    Console.WriteLine($"{root} {theNum}   =>  {f}");
                            }    
                        }

            // ---------------------------------------------------------------------------------------------------------------
            // -- have a go at a(11)
            Console.WriteLine("-- a(11)\n");

            int from_A = poss_A.GetDigitsAtPos(0)[0];
            int[] from_B = poss_B.GetDigitsAtPos(0);
            int from_D = poss_D.GetDigitsAtPos(0)[0];
            int[] from_H = poss_H.GetDigitsAtPos(0);
            int[] from_P = poss_P.GetDigitsAtPos(0);

            for (int i = 1; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    for (int k = 0; k < 100; k++)
                    {
                        long root
                            = i * 100000
                            + j * 1000
                            + k ;
                        root = root
                            + from_A * 100000000
                            + from_D * 1000000;

                        foreach (var B in from_B)
                            foreach (var H in from_H)
                                foreach (var P in from_P)
                                {
                                    long theNum = root
                                            + B * 10000000
                                            + H * 10000
                                            + P * 100;

                                if (k == 0) Console.Write($"{root} {theNum}\r");

                                    var f = new Factor(theNum);
                                    if (f.FactorCount == 11)
                                        Console.WriteLine($"{root} {theNum}   =>  {f}");
                                }
                    }
        
            Console.WriteLine("------ T");
            int from_a = poss_a.GetDigitsAtPos(8)[0];
            int from_r = poss_r.GetDigitsAtPos(3)[0];
            int from_u = poss_u.GetDigitsAtPos(2)[0];
            int from_v = poss_v.GetDigitsAtPos(1)[0];
            int from_e = poss_e.GetDigitsAtPos(8)[0];

            long root
                = from_a * 100000000
                + from_r * 1000000
                + from_u * 10000
                + from_v * 100
                + from_e;

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    for (int k = 0; k < 10; k++)
                        for (int l = 0; l < 10; l++)
                        {
                            long theNum = root
                                + l * 10
                                + k * 1000
                                + j * 100000
                                + i * 10000000;

                            var f = new Factor(theNum);
                            if (f.FactorCount == 26)
                                Console.WriteLine($"{root} {theNum}   =>  {f}");
                        }




#endif

        // ---------------------------------------------------------------------------------------------------------------

        static void PopulateDivisors(long maxValue)
        {
            for (long prod = 10; prod < maxValue; prod++)
                Divisors.Add(new Factor(prod));
        }

        static AnswerList FindDivisors(char clue, Func<Factor, bool> predicate)
        {
            var poss = new AnswerList(clue);
            foreach (var ans in Divisors.Where(predicate))
                poss.Add(ans);

            return poss;
        }

        static AnswerList FindDivisors(char clue, int len, int facCnt)
        {
            var poss = new AnswerList(clue);
            foreach (var ans in Divisors.Where(x => x.NumLength == len && x.FactorCount == facCnt))
                poss.Add(ans);

            return poss;
        }

        private static void OnlyAllowCrossDigits(AnswerList poss_A, int position_A, AnswerList poss_B, int position_B)
        {
            HashSet<int> matches = new HashSet<int>();

            var digits_A = poss_A.GetDigitsAtPos(position_A);
            var digits_B = poss_B.GetDigitsAtPos(position_B);

            foreach (var b in digits_B)
                if (digits_A.Contains(b))
                    matches.Add(b);

            poss_A.OnlyAllowDigitAtPosition(matches.ToArray<int>(), position_A);
            poss_B.OnlyAllowDigitAtPosition(matches.ToArray<int>(), position_B);
        }

        private static int DigitAtPosition(long num, int pos)
        {
            return int.Parse(num.ToString()[pos].ToString());
        }


    }
}