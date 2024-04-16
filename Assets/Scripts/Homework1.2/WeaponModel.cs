public abstract class WeaponModel
{
    public int Bullets { get; protected set; }
    public WeaponModel(int bullets)
    {
        Bullets = bullets;
    }

    public abstract int Shoot();
}

