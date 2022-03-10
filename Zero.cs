class Zero
{
    // static void Main(string[] args)
    // {
    //     RunMethods();
    //     Console.ReadKey();
    // }

    public static void RunMethods()
    {
        Method1();
        Method2();
    }

    public static void Method1()
    {
        for (int i = 0; i < 10; i++)
        {

            Console.WriteLine(" Method 1");

            // Do something
            Task.Delay(1000).Wait();
        }
    }


    public static void Method2()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(" Method 2");
            // Do something
            Task.Delay(1000).Wait();
        }
    }
}