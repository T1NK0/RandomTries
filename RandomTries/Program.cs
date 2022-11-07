// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Security.Cryptography;

Console.WriteLine("RandomNumberGenerator numbers \n");

Stopwatch timer = new Stopwatch();

using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
{
    byte[] buffer = new byte[4];

    Console.WriteLine("RandomNumberGenerator");
    // 3 rounds
    for (int i = 0; i < 3; i++)
    {
        timer.Start();
        Console.WriteLine("Iteration: " + i);
        // Generate 20 numbers each round
        for (int j = 0; j < 20; j++)
        {
            //fill buffer
            rng.GetBytes(buffer);

            //Convert to int
            int value = BitConverter.ToInt32(buffer, 0);

            //Print our value
            Console.WriteLine(j + ". "+ value);
        }
        Console.WriteLine('\n');
    }
        timer.Stop();

    TimeSpan ts = timer.Elapsed;
    Console.WriteLine("Total Milliseconds for 3 iterations: " + ts.TotalMilliseconds);
}

timer.Reset();

Random random = new Random();
 
Console.WriteLine("Random");
for (int i = 0; i < 3; i++)
{
    timer.Start();
    Console.WriteLine("Iteration: " + i);
    for (int j = 0; j < 20; j++)
    {
        Console.WriteLine(j+ ". " + random.Next());
    }
    Console.WriteLine('\n');
}
timer.Stop();

TimeSpan tst = timer.Elapsed;
Console.WriteLine("Total Milliseconds for 3 iterations: " + tst.TotalMilliseconds);

Console.WriteLine("Done generating numbers.");
Console.ReadKey();