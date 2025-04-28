namespace ConsoleApp13
{
    internal class Program
    {
        static int totalSum = 0;
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int[] nums = new int[N];
            var rand = new Random();
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = rand.Next(1, 1000);
            }

            Thread[] threads = new Thread[M];

            for (int i = 0; i < threads.Length; i++)
            {
                int range = N / M;
                int endRange = 0;
                int II = i;
                if (i == M - 1)
                {
                    endRange = N;
                }
                else
                {
                    endRange = range * i + range;
                }
                threads[i] = new Thread(() => Sum(nums, II * range, endRange));
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine(totalSum);

        }

        static void Sum(int[] nums, int start, int end)
        {
            int sum = 0;

            for (int i = start; i < end; i++) 
            { 
                sum += nums[i];
            }

            Interlocked.Add(ref totalSum, sum);
        }
    }
}
