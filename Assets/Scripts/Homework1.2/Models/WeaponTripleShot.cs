public class WeaponTripleShot : WeaponModel
{
    private const int RateOfFire = 3;
    public WeaponTripleShot(int bullets) : base(bullets) { }
    public override int Shoot()
    {
        if(Bullets >= RateOfFire)
        {
            Bullets -= RateOfFire;
            return RateOfFire;
        }

        return 0;
    }
}
