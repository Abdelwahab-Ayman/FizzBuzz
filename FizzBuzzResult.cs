using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzzResult
    {
        public FizzBuzzResult(string output,int count)
        {
            Output = output;
            Count = count;
        }
        public string Output { get;}
        public int Count { get; set;}

        public override string ToString()
        {
            return $"Output: {Output}, Count: {Count}";
        }

    }
}
