namespace DesafioModulo2;

internal abstract class Entidade : ICombate
{
    public string Name { protected set; get; }
    public int BaseHealth { protected set; get; }
    public int Health { protected set; get; }
    public Random r = new();


    public abstract void Attack(ICombate Alvo);
    

    public void ReceiveDamage(int Damage)
    {
        if(Damage > Health) Health = 0; else Health -= Damage;
    }

    public void showLifeBar()
    {
        int healthbarSize = 14;
        int filledHealth = (int)((Double)Health / BaseHealth * healthbarSize);
        Console.Write("  ");
        for (int i = 0; i < filledHealth; i++)
        {
            Console.Write("█");
        }
        for (int i = filledHealth; i < healthbarSize; i++)
        {
            Console.Write("░");
        }

        Console.WriteLine("|");
        Console.WriteLine($"     {Health} / {BaseHealth}");
    }
}
