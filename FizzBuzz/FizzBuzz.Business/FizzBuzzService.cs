using System;
using System.Text;

namespace FizzBuzz.Business
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public const int MinimumFactor = 2;
        public const int MaximumFactor = 10;
        public const int MinimumLastNumber = 1;
        public const int MaximumLastNumber = 250;

        public string GenerateFizzBuzzText(int fizzFactor, int buzzFactor, int lastNumber)
        {
            Validate(fizzFactor, buzzFactor, lastNumber);
            StringBuilder stringBuilder = new StringBuilder();
            for (int count = 1; count <= lastNumber; count++)
            {
                if (count % fizzFactor == 0 && count % buzzFactor == 0)
                {
                    stringBuilder.Append("FizzBuzz");
                }
                else if (count % fizzFactor == 0)
                {
                    stringBuilder.Append("Fizz");
                }
                else if (count % buzzFactor == 0)
                {
                    stringBuilder.Append("Buzz");
                }
                else
                    stringBuilder.Append(count);
                if(count<= lastNumber - 1)
                {
                    stringBuilder.Append(" ");
                }
            }
            return stringBuilder.ToString();
        }

        public void Validate(int fizzFactor, int buzzFactor, int lastNumber)
        {
            if (fizzFactor > MaximumFactor || buzzFactor > MaximumFactor)
            {
                throw new FizzBuzzValidationException("Fizz or Buzz > Maximum");
            }
            else if (fizzFactor < MinimumFactor || buzzFactor < MinimumFactor)
            {
                throw new FizzBuzzValidationException("Fizz or Buzz < Minimum");
            }
            else if (lastNumber < MinimumLastNumber)
            {
                throw new FizzBuzzValidationException("lastnumber too small");
            }
            else if (lastNumber > MaximumLastNumber)
            {
                throw new FizzBuzzValidationException("lastnumber too big");
            }
        }
    }
}