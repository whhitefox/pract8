namespace Pract8
{
    class Program
    {
        static void Main(string[] args)
        {
            string put = "D:\\TablicaRecordov.json";
            TablicaRekordov.Load(put);
            string text = "Повседневная практика показывает, что постоянное информационно-пропагандистское обеспечение нашей деятельности представляет собой интересный эксперимент проверки новых предложений. Задача организации, в особенности же постоянный количественный рост и сфера нашей активности в значительной степени обуславливает создание систем массового участия. Повседневная практика показывает, что рамки и место обучения кадров играет важную роль в формировании направлений прогрессивного развития.";
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите имя для таблицы рекордов:");
                string? name = Console.ReadLine();
                while (name == null || name.Length == 0)
                {
                    Console.SetCursorPosition(0, 1);
                    name = Console.ReadLine();
                }
                User user = new User(name, 0, 0);
                Nabor nabor = new Nabor(user, text, ConsoleColor.Red);
                nabor.Start();
                TablicaRekordov.Update(user);
                TablicaRekordov.Save(put);
                TablicaRekordov.Show();
                Console.WriteLine();
                Console.WriteLine("Чтобы попробовать еще раз, нажмите Enter");
                key = Console.ReadKey(true);
            } while (key.Key == ConsoleKey.Enter);
        }
    }
}