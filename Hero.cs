namespace DesafioModulo2
{
    internal class Hero : Entidade
    {
        public ClassType Class = ClassType.None;

        public int Strength;

        public static int BasePotionAmount { protected set; get; }

        public static int PotionAmount { protected set; get; }
        public override void Attack(ICombate Target)
        {
            Target.ReceiveDamage(Strength);
            Console.WriteLine($"{Class} ataca com {Strength} de dano!");
        }

        public void UsePotion()
        {
            int healing = r.Next(10, 18);
            Health += healing;
            if (Health > BaseHealth) { Health = BaseHealth; }
            Console.WriteLine($"{Class} usa a poção, que o cura {healing} de vida");
            PotionAmount -= 1;
        }

        public void UsePotion(int HealAmount)
        {
            Health += HealAmount;
            Console.WriteLine($"{Class} usa a poção, que o cura {HealAmount} de vida");
            PotionAmount -= 1;

        }
        public Hero(int strength, int health, ClassType heroClass, int potionAmount = 3)
        {
            Strength = strength;
            Health = health;
            BaseHealth = health;
            Class = heroClass;
            PotionAmount = potionAmount;
            BasePotionAmount = potionAmount;
        }

        static string PotionsDisplay()
        {
            string display = "";
            for (int i = 0; i < PotionAmount; i++)
            {
                display += "O ";
            }
            for (int i = PotionAmount; i < BasePotionAmount; i++)
            {
                display += "X ";
            }
            return display;
        }
        
        public void showStatus()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"--- Heroi: {Class} ---\n");
            Console.WriteLine($"  Poções: {PotionsDisplay()}");
            Console.WriteLine($"  Força: {Strength}\n");

            this.showLifeBar();
            Console.ResetColor();
        }
    }
}
