public class WeaponSingleShot : WeaponModel
{
    private const int RateOfFire = 1;

    public WeaponSingleShot(int bullets) : base(bullets) { }
    public override int Shoot()
    {
        if(Bullets >= RateOfFire)
        {
            Bullets--;
            return RateOfFire;
        }

        return 0;
    }
}
