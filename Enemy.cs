using System.Security.Claims;

namespace DesafioModulo2
{
    internal class Enemy : Entidade
    {
        int BaseDmg;
        public override void Attack(ICombate Alvo)
        {
            int dmg = r.Next(BaseDmg - 1, BaseDmg + 1);
            Alvo.ReceiveDamage(dmg);
            Console.WriteLine($"O inimigo ataca com {dmg} de dano");
        }

        public Enemy(int baseDmg, int health, string name)
        {
            BaseDmg = baseDmg;
            BaseHealth = health;
            Health = health;
            Name = name;
        }
        
        public void showStatus()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"--- Inimigo: {Name} ---");
            this.showLifeBar();
            Console.ResetColor();
        }
    }
}
