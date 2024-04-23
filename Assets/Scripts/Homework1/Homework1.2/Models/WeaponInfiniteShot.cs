public class WeaponInfiniteShot : WeaponModel
{
    private const int RateOfFire = 1;

    public WeaponInfiniteShot(int bullets) : base(bullets) { }
    public override int Shoot()
    {
        return RateOfFire;
    }
}
