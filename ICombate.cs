namespace DesafioModulo2
{
    internal interface ICombate
    {
        string Name { get; }
        int Health { get; }

        void Attack(ICombate Target);

        void ReceiveDamage(int Damage);
    }
}
