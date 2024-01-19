namespace Exam12._1._5
{
    internal class Work
    {
        private string _login;
        private List<User> _users;
        public Work()
        {
            GetLogin();
        }

        private void GetLogin()
        {
            Console.WriteLine("login: ");
            _login = Console.ReadLine();
            if(string.IsNullOrEmpty(_login))
            {
                Console.WriteLine("login is empty");
                GetLogin();
                return;
            }
            GetUsers();
            Authorize(_login);
        }

        private void GetUsers()
        {
            _users =
            [
                new User{ Login = "admin", IsPremium = true, Name = "Администратор" },
                new User{ Login = "user", IsPremium = false, Name = "Иванов Иван"}
            ];
        }

        private void Authorize(string? login)
        {
            var user = _users.FirstOrDefault(a => a.Login.Equals(login));
            if(user is null)
            {
                Console.WriteLine($"{login} is not registered.");
                GetLogin();
                return;
            }
            if(user.IsPremium)
            {
                Console.WriteLine($"Welcome dear {user.Name}!");
            }
            else
            {
                ShowAds();
                Console.WriteLine($"Welcome dear {user.Name}!");
            }
        }
        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }
    }
}
