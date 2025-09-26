namespace DesafioModulo2
{
    internal class Program
    {
        enum MenuEnum
        {
            Welcome,
            CharacterSelection,
            Fight,
            Turn
        }
        static Hero hero;
        static Enemy orc;
        static Random random = new Random();

        static void Main(string[] args)
        {
            ConsoleKey keyPressed;
            MenuShow(MenuEnum.Welcome);
            do
            {
                keyPressed = Console.ReadKey().Key;
            } while (keyPressed != ConsoleKey.Enter);
            if (keyPressed == ConsoleKey.Enter)
            {
                do
                {
                    MenuShow(MenuEnum.CharacterSelection);
                    keyPressed = Console.ReadKey().Key;
                    switch (keyPressed)
                    {
                        case ConsoleKey.D1:
                            hero = new(8, 100, ClassType.Guerreiro);
                            break;
                        case ConsoleKey.D2:
                            hero = new(9, 70, ClassType.Arqueiro);
                            break;
                        case ConsoleKey.D3:
                            hero = new(12, 55, ClassType.Mago, 5);
                            break;
                        default:
                            break;
                    }
                }
                while (hero.Class == ClassType.None);
                MenuShow(MenuEnum.Fight);
                orc = new(random.Next(7, 13), random.Next(70, 90), "Orc");
                do
                {
                    do
                    {
                        Console.Clear();
                        MenuShow(MenuEnum.Turn);
                        Console.WriteLine("--------- SEU TURNO ---------");
                        Console.WriteLine("Pressione [A] para atacar");
                        Console.WriteLine("Pressione [S] para usar poção");
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("\n\n");
                        keyPressed = Console.ReadKey().Key;
                        switch (keyPressed)
                        {
                            case ConsoleKey.A:
                                Console.Clear();
                                MenuShow(MenuEnum.Turn);
                                hero.Attack(orc);
                                break;
                            case ConsoleKey.S:
                                Console.Clear();
                                MenuShow(MenuEnum.Turn);
                                hero.UsePotion();
                                break;
                            default:
                                break;
                        }

                    } while (keyPressed != ConsoleKey.A && keyPressed != ConsoleKey.S);
                    if (orc.Health == 0) break;
                    MenuShow(MenuEnum.Turn);
                    Thread.Sleep(2000);
                    Console.Clear();
                    MenuShow(MenuEnum.Turn);
                    Console.WriteLine("--------- TURNO DO ORC ---------");
                    orc.Attack(hero);
                    Console.WriteLine("---------------------------------");
                    if (hero.Health <= 0) break;
                    MenuShow(MenuEnum.Turn);
                    Thread.Sleep(2000);

                } while (orc.Health > 0 && hero.Health > 0);
                Console.Clear();
                while (true) {
                    if (hero.Health != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n####################################");
                        Console.WriteLine("           VOCE GANHOU!");
                        Console.WriteLine("####################################");

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n####################################");
                        Console.WriteLine("            VOCE MORREU");
                        Console.WriteLine("####################################");
                    }
                }
                
            }

        }

        internal class Menu
        {
            public string Title { get; set; }
            public string BottomText { get; set; }

            public Menu(string title, string bottomText)
            {
                this.Title = title;
                this.BottomText = bottomText;
            }
        }

        static void MenuShow(MenuEnum menu)
        {
            Menu m;
            switch (menu)
            {
                case MenuEnum.Welcome:
                    Console.Clear();
                    m = new Menu("Bem vindo ao jogo!", "Pressione [Enter] para continuar, ou [Escape] para sair");
                    break;
                case MenuEnum.CharacterSelection:
                    Console.Clear();
                    m = new Menu("Selecione o seu personagem com sabedoria!\n1) Guerreiro     2)Arqueiro     3) Mago", "Escolha seu personagem utilizando as teclas de [1-3]");
                    break;
                case MenuEnum.Fight:
                    m = new Menu("", "");
                    Console.Clear();
                    Console.WriteLine("\n\n Sua aventura começa...");
                    Thread.Sleep(4000);
                    Console.Clear();
                    Console.WriteLine($"\n\nO grande heroi {hero.Class} anda pelas masmorras");
                    Thread.Sleep(3000);
                    Console.WriteLine($"\naté que...");
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.WriteLine("\n\nSe depara com um grande Orc");
                    Thread.Sleep(3000);
                    Console.WriteLine("então a luta se inicia...");
                    break;
                case MenuEnum.Turn:
                    m = new Menu("", "");
                    Console.SetCursorPosition(0, 0);
                    orc.showStatus();

                    Console.SetCursorPosition(0, 15);
                    hero.showStatus();

                    Console.SetCursorPosition(0, 7);
                    break;

                default:
                    Console.Clear();

                    m = new Menu("ERRO!", "ERROOO!");
                    break;
            }
            if (m.Title != "" && m.BottomText != "")
            {
                string spacer = "";
                foreach (char c in m.Title.Split('\n')[0])
                {
                    spacer += "#";
                }
                Console.WriteLine(spacer);
                Console.WriteLine(m.Title);
                Console.WriteLine(spacer);
                Console.WriteLine("\n\n\n");
                Console.WriteLine(m.BottomText);
            }

        }


    }
}
