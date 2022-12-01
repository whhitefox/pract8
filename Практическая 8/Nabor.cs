using System.Diagnostics;

namespace Pract8
{
    public class Nabor
    {
        private string text;
        private int current;
        private ConsoleColor color;
        private User user;
        
        public Nabor(User userParam, string textParam, ConsoleColor colorParam)
        {
            user = userParam;
            text = textParam;
            current = 0;
            color = colorParam;
        }

        public void Start()
        {
            Stopwatch stopwatch = new Stopwatch();
            Thread timerThread = new Thread(_ => StartTimer(stopwatch));

            Console.Clear();
            Console.WriteLine(text);
            Console.WriteLine("-----------------------");
            Console.WriteLine("Когда будете готовы, нажмите Enter");
            Console.SetCursorPosition(0, 0);

            ConsoleKeyInfo startKey = Console.ReadKey(true);
            while (startKey.Key != ConsoleKey.Enter)
            {
                startKey = Console.ReadKey(true);
            }

            timerThread.Start();
            while (current != text.Length && timerThread.IsAlive)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.KeyChar == text[current])
                {
                    current++;
                    Console.ForegroundColor = color;
                    Console.Write(key.KeyChar);
                    Console.ResetColor();
                }
            }
            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            user.simvolVMinutu = current / time.TotalMinutes;
            user.simvolVSecundu = current / time.TotalSeconds;
        }

        private void StartTimer(Stopwatch stopwatch)
        {
            stopwatch.Start();
            TimeSpan timeSpan;
            TimeSpan maxTime = new TimeSpan(0, 1, 0);
            do
            {
                timeSpan = stopwatch.Elapsed;
                var ostalos = maxTime - timeSpan;

                int left = Console.CursorLeft;
                int top = Console.CursorTop;
                Console.SetCursorPosition(0, 10);
                Console.WriteLine($"{ostalos.Minutes:00}:{ostalos.Seconds:00}");
                Console.SetCursorPosition(left, top);

                Thread.Sleep(1000);
            } while (timeSpan < maxTime && stopwatch.IsRunning);
            stopwatch.Stop();
        }
    }
}