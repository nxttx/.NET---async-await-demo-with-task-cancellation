class one
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

    // Void -> Task
    public static async Task Method1()
    {
        //voeg Task run toe zodat we de forloop uitvoeren in async land
        await Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" Method 1");
                // Do something
                Task.Delay(1000).Wait();
            }
        });
    }

    // Void -> Task
    public static async Task Method2()
    {
        //voeg Task run toe zodat we de forloop uitvoeren in async land
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