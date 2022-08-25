using System;
namespace Listener1916
{
    public class Answer
    {
        public int Factors { get; set; }
        public int Length { get; set; }
        public List<long> Lights { get; set; }

        public Answer(int factors, int length)
        {
            Factors = factors;
            Length = length;
            Lights = new List<long>();
        }
    }
}

