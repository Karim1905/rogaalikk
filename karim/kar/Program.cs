using karim;
class Program
{
    static void Main()
    {
        Console.WriteLine("Салам.");
        Console.Write("Ник придумай,да: ");
        string playerName = Console.ReadLine();
        Console.WriteLine("ИУ,игра начинается");


        Player player = new Player(playerName, 100);
        player.HealthKit = new Aid("Осетинский пирог", 10);
        int totalPoints = 0;
        List<Enemy> enemies = new List<Enemy>
    {
            new Enemy("Асхаб", new Random().Next(20, 100), new Weapon("Ханджар", 1, 100)),
            new Enemy("Эльдар", new Random().Next(20, 100), new Weapon("Кума", 10, 100)),
            new Enemy("Ислам", new Random().Next(20, 100), new Weapon("Тюбетейка", 18, 100)),
            new Enemy("Ибрагим", new Random().Next(20, 100), new Weapon("Дубина", 11, 100)),
            new Enemy("Магомед", new Random().Next(20, 100), new Weapon("Шашка", 23, 100))
        };

        List<Weapon> playerWeapons = new List<Weapon>
{
    new Weapon("Кастет", 25, 100),
    new Weapon("Прогиб", 30, 100),
    new Weapon("Розочка", 16, 100),
    new Weapon("Телескопичка", 21, 100),
    new Weapon("ДУХ + КУЛАКИ", 20, 100),
    new Weapon("Нож", 19, 100)
};
        List<Weapon> weapons = new List<Weapon>
{
   new Weapon("Ханджар", 1, 100),
    new Weapon("Кума", 10, 100),
    new Weapon("Тюбетейка", 18, 100),
    new Weapon("Дубина", 11, 100),
    new Weapon("Шашка", 23, 100),
    new Weapon("Дагестанский кинжал", 19, 100),
    new Weapon("позвать братьев", 19, 100)
};
        while (player.CurrentHealth > 0)
        {
            Enemy enemy = enemies[new Random().Next(enemies.Count)];
            Weapon enemyWeapon = weapons[new Random().Next(weapons.Count)];
            player.CurrentWeapon = playerWeapons[new Random().Next(playerWeapons.Count)];
            if (enemyWeapon.Name == "позвать братьев")
            {
                Console.WriteLine("Ты в соло раскидаешь этих лохов");
            }
            else
            {
                Console.WriteLine("Бояться нечего");
            }
            if (player.CurrentWeapon.Name == "ДУХ + КУЛАКИ")
            {
                Console.WriteLine("Ты духом силен брат");
            }
            if (player.CurrentWeapon.Name == "Нож")
            {
                Console.WriteLine("Режь брат");
            }
            if (player.CurrentWeapon.Name == "Прогиб")
            {
                Console.WriteLine("ОДИН ПРОГИБ И ТЫ ПОГИБ(ну почти)");
            }
            enemy.EnemyWeapon = enemyWeapon;
            Console.WriteLine($"Вы встречаете осла {enemy.Name} ({enemy.CurrentHealth}hp), у осла за спиной {enemy.EnemyWeapon.Name} ({enemy.EnemyWeapon.Damage}).");
            while (player.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                Console.WriteLine($"Наше здоровье: {player.CurrentHealth}, Здоровье осла: {enemy.CurrentHealth}");
                Console.WriteLine($"Ваше прозвище: {player.Name}, брат, у тебя: {player.CurrentWeapon.Name}");

                Console.WriteLine("Действие выбери,да");
                Console.WriteLine("1. Ударить");
                Console.WriteLine("2. Позвать братков");
                Console.WriteLine("3. Захавать пирог");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        player.Attack(enemy);
                        Console.WriteLine($"Вы ударили {enemy.Name}!");
                        break;
                    case "2":
                        Console.WriteLine("Такие дела не делай да в следующий раз");
                        Console.WriteLine("Твои братки порешали этого осла");
                        enemy.CurrentHealth = 0;
                        break;
                    case "3":
                        player.Heal();
                        Console.WriteLine($"Вы захавали пирог. Ваше текущее здоровье: {player.CurrentHealth}");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите 1, 2 или 3.");
                        break;
                }


                enemy.Attack(player);
                Console.WriteLine($"{enemy.Name} атакует вас! Ваше текущее здоровье: {player.CurrentHealth}");
            }

            if (player.CurrentHealth <= 0)
            {
                Console.WriteLine($"Игра окончена. {enemy.Name} победил! Ваши общие очки {totalPoints}");
                Console.WriteLine("Жи есть в следующий раз нагнешь");
                break;
            }
            else
            {
                Console.WriteLine($"Вы победили {enemy.Name} и получили очки!");


                player.CurrentHealth += 20;
                Console.WriteLine($"Вы захавали пирог после победы и восстановили  20 хп. Ваше здоровье: {player.CurrentHealth}");
                totalPoints += 10;
                Console.WriteLine($"Ваши текущие очки: {totalPoints}");

                Console.WriteLine("Хотите продолжить игру? (да/Пас)");
                string continueChoice = Console.ReadLine();
                if (continueChoice.ToLower() != "Конечно")
                {
                    Console.WriteLine($"Игра завершена. Ваши общие очки: {totalPoints}");
                    break;
                }
            }
        }
    }
}