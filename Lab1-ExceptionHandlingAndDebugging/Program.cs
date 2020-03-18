using System;

namespace Lab1_ExceptionHandlingAndDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Welcome to my game! Let's do some math!");
                StartSequence();
            }
            catch (Exception ex)
            {
                //Error handling: generic exception letting the user know they did something wrong
                Console.WriteLine("Sorry! It looks like something went wrong! Exception{0}", ex.Message);
            }
            //Add Finally that tells the user the program is complete
            finally
            {
                Console.WriteLine("And finally, we are done!");
            }

        }

        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Please enter a number between 1 and 10 ");
                string answer = Console.ReadLine();
                int arrayLength = Convert.ToInt32(answer);

                //call GetSum method:
                int[] array = new int[arrayLength];

                int[] arr = Populate(array);
                
                int sum = GetSum(array);

                //call GetProduct and pass array and sum
                int product = GetProduct(array, sum);

            //call GetQuotient and pass product
                decimal quotient = GetQuotient(product);

                //put all outgoing messages here (6 total)

            
             //return array to user   
             Console.WriteLine("The sum is {0}", sum);
             Console.WriteLine("The product is {0}", product);
             Console.WriteLine("The quotient is {0}", quotient);
             Console.WriteLine("Thanks for playing, the program is complete!");

            }
            catch (FormatException formatEx)
            {
                Console.WriteLine("Your input is in the wrong format: {0}", formatEx.Message);
            }
            catch (OverflowException overflowEx)
            {
                Console.WriteLine("You have a data overflow: {0}", overflowEx.Message);
            }
        }

        static int[] Populate(int[] arrayLength)
        {
            //build the array with the length chosen by the user
            //int[] array = new int[arrayLength];
            for (int i = 0; i < arrayLength.Length; i++)
            {
                Console.WriteLine("Please select {0} numbers, hitting enter after each.", arrayLength.Length);
                string answer = Console.ReadLine();
                int arrDigit = Convert.ToInt32(answer);
                arrayLength[i] = arrDigit;
            }

            //return array to the user
            for (int j = 0; j < arrayLength.Length; j++)
            {
                Console.WriteLine("You entered {0}", arrayLength[j]);
            }
            return arrayLength;
        }

        static int GetSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            //throw a custom exception statement if sum <20
            if (sum < 20)
            {
                Console.WriteLine("Value of {0} is too low!", sum);
                
            }
            return sum;
        }

        static int GetProduct(int[] array, int sum)
        {
            int product = 0;
            int limit = array.Length;
            try
            {
                Console.WriteLine("Please pick a number between 1 and {0} ", limit);
                string answer = Console.ReadLine();
                int pickedNum = Convert.ToInt32(answer);
         

            product = sum * pickedNum;

            
            }
            catch (Exception IndexOutOfRange)
            {
                Console.WriteLine("Index is out of range: {0}", IndexOutOfRange.Message);
                throw;
            }
            return product;
        }

        static decimal GetQuotient(int product)
        {
            int dividend = 0;
            try
            {
                Console.WriteLine("Please select a number to divide your product {0} by ", product);
                string answer = Console.ReadLine();
                dividend = Convert.ToInt32(answer);
            }
            catch (DivideByZeroException ex)
            {
                if (dividend == 0)
                {
                    Console.WriteLine("You are trying to divide by 0: {0} ", ex.Message);
                }
            }

            decimal quotient = product / dividend;
            

            return quotient;
        }

    }

}
