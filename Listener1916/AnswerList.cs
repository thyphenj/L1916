using System;
namespace Listener1916
{
    public class AnswerList
    {
        public char Clue { get; set; }
        public List<Factor> Answers { get; set; }

        public AnswerList(char ch)
        {
            Clue = ch;
            Answers = new List<Factor>();
        }

        public void Add(Factor factor)
        {
            Answers.Add(factor);
        }

        public long? Result()
        {
            if (Answers.Count == 1)
                return Answers[0].Number;
            else
                return null;
        }

        public void OnlyKeep (HashSet<long> keepThese)
        {
            var nxt = new List<Factor>();

            foreach ( var num in keepThese)
            {
                nxt.Add(new Factor(num));
            }
            Answers = nxt;
        }

        internal void OnlyAllowDigitAtPosition(int digit, int pos)
        {
            var nxt = new List<Factor>();
            foreach (var a in Answers)
            {
                if (DigitAtPosition(a.Number, pos) == digit)
                    nxt.Add(a);
            }
            Answers = nxt;
        }

        public override string ToString()
        {
            if (Answers.Count == 1)
                return $"{Clue} = {Answers[0].Number,6}";
            else if (Answers.Count < 15)
            {
                string s = $"{Clue}          ";
                foreach (var a in Answers)
                    s += $"({a.Number}) ";
                return s;
            }
            else
                return $"{Clue}                 ====> {Answers.Count,4} possible answers";
        }

        internal void OnlyAllowDigitAtPosition(int[] digits, int pos)
        {
            var nxt = new List<Factor>();
            foreach (var a in Answers)
            {
                if (digits.Contains(DigitAtPosition(a.Number, pos)))
                    nxt.Add(a);
            }
            Answers = nxt;

        }

        internal void ExcludeDigitAtPosition(int digit, int pos)
        {
            var nxt = new List<Factor>();
            foreach (var a in Answers)
            {
                if (DigitAtPosition(a.Number, pos) != digit)
                    nxt.Add(a);
            }
            Answers = nxt;
        }

        private int DigitAtPosition(long num, int pos)
        {
            return int.Parse(num.ToString()[pos].ToString());
        }

        internal int[] GetDigitsAtPos(int pos)
        {
            var lis = new HashSet<int>();

            foreach (var a in Answers)
                lis.Add(DigitAtPosition(a.Number, pos));

            return lis.ToArray<int>();
        }
    }
}

