using Newtonsoft.Json;

namespace Pract8
{
    public class TablicaRekordov
    {
        private static List<User> users = new List<User>();

        public static void Load(string put)
        {
            if (File.Exists(put))
            {
                string json = File.ReadAllText(put);
                var desiarialized = JsonConvert.DeserializeObject<List<User>>(json);
                if (desiarialized != null)
                {
                    users = desiarialized;
                }
            }
        }

        public static void Update(User user)
        {
            User? finded = users.Find(u => u.name == user.name);
            if (finded == null)
            {
                users.Add(user);
            } else
            {
                finded.simvolVMinutu = user.simvolVMinutu;
                finded.simvolVSecundu = user.simvolVSecundu;
            }
        }

        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("Таблица рекордов");
            Console.WriteLine("----------------");
            foreach (User user in users)
            {
                Console.WriteLine($"{user.name} | {user.simvolVMinutu:0} символов в минуту | {user.simvolVSecundu:0.00} символов в секунду");
            }
        }

        public static void Save(string put)
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(put, json);
        }
    }
}
