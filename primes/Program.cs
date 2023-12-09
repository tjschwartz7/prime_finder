
//#define PRINT_PRIMES

using System.Diagnostics;

class MainBuild
{


    static void Main(string[] args)
    {
        // Display the number of command line arguments.
        //Console.WriteLine(args.Length);
        int search_for_primality = 10000000;

        bool td = true, sieve = true;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        //O(N^2)
        if(td)
        {
            for (int i = 0; i < search_for_primality; i++)
            {
                bool isPrime = (PrimeFunction.TrialDivision(i));
                #if PRINT_PRIMES
                switch (isPrime)
                {
                    case true:
                        Console.WriteLine(i);
                        break;
                }
                #endif
            }
        }
        stopwatch.Stop();
        Console.WriteLine("Trial division took " + (stopwatch.Elapsed) + "s");

        stopwatch.Restart();
        if (sieve)
        {
            PrimeFunction.SieveEratosthenes(search_for_primality);
        }
        stopwatch.Stop();
        Console.WriteLine("Sieve of Eratosthenes took " + (stopwatch.Elapsed) + "s");

    }
}





class PrimeFunction
{

    //This is the slowest of the bunch - O(N) in any case
    //It will check one integer for primality
    public static bool TrialDivision(int potentialPrime)
    {
        //Allow for an extra number in case of rounding error
        int secondRoot = (int)Math.Sqrt(potentialPrime) + 2; //Adds an extra one so we can use less than 
        for (int i = 2; i < secondRoot; i++) 
        {
            //If potentialPrime modulo i == 0
            //  Then it can't be prime
            if (potentialPrime % i == 0) return false;
        }
        return true;
    }

    //This algorithm is designed to search for prime numbers up to some max number
    //It will print a list of all the primes it finds
    public static void SieveEratosthenes(int checkUpTo)
    {
        //This algorithm is pretty fast, but the fact it makes an array of checkUpTo bools is not great
        //Its also subject to many cache misses since it's not always dealing with adjacent integers
        //This algorithm cannot be used for checkUpTo sizes beyond the limits of our heap


        //Generate a list of integers from 2 to N
        //Use array indices as integer marker
        //Bool represents isPrime relation
        bool[] intIsNotPrime = new bool[checkUpTo];
       int p = 2, sqrtN = (int)(Math.Sqrt(checkUpTo)) + 1;

        while( p < sqrtN ) 
        {
            int iter = p;

            //Since we add first, we'll iterate up to checkUpTo - p
            while( iter < checkUpTo - p) 
            {
                //iter+= p
                iter += p;
                //Mark off as NOT prime
                intIsNotPrime[iter] = true;
            }
            do
            {
                p++;
            } while (intIsNotPrime[p]); //Iterate p until it's prime
        }

        #if PRINT_PRIMES
        for (int i = 0; i < checkUpTo; i++)
        {
            if (!intIsNotPrime[i])
                Console.WriteLine(i);
        }
        #endif
    }



    //Executes the Elliptical Curve Primary Proving algorithm and displays the results
    public static bool ECPP(int potentialPrime)
    {
        //This one looks hard to implement. Do others first then decide if its feasible

        return false;
    }

}