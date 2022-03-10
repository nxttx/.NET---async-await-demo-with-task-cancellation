class Two
{
    // static void Main(string[] args)
    // {
    //     RunMethods();
    //     Console.ReadKey();
    // }

    public static void RunMethods() {
        Method1();
        Method2();
    }

    public static async Task Method1()
    {
        // 1: laten we een cancellationTokenSource maken
        using (CancellationTokenSource cancellationTokenSource = new CancellationTokenSource())
        {
            // 2: laten we van het cancellationTokenSource de token pakken
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            
            // 3: we maken van de await een variable zodat we er later makkelijker naar kunnen refereren.
            var task = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    // 4: laten we checken of het tocken gecanceld is
                    if (cancellationToken.IsCancellationRequested)
                        return;

                    Console.WriteLine(" Method 1");

                    // Do something
                    Task.Delay(1000).Wait();
                }
            });

            // 5: defineer timeout
            int timeout = 5000;
            // 6: When Any returnd de task die als eerste is afgerond. 
            //    Als dat gelijk ligt aan onze task, dan weten we dat de task optijd is afgerond.
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                Console.WriteLine("Task 1 completed in time.");
            }
            else
            {
                // 7: de timeout was eerder klaar dus cancel de cancellationtoken maar.
                cancellationTokenSource.Cancel();
                Console.WriteLine("Task 1 canceld due to timeout");
            }
        }
    }


    public static async Task Method2()
    {
        await Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" Method 2");
                // Do something
                Task.Delay(1000).Wait();
            }
        });
    }
}