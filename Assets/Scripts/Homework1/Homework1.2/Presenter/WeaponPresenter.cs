public class WeaponPresenter
{
    private WeaponModel weaponModel;
    private IWeaponView weaponView;

    public WeaponPresenter(WeaponModel weaponModel, IWeaponView weaponView)
    {
        this.weaponModel = weaponModel;
        this.weaponView = weaponView;
        this.weaponView.RegDelegate(Fire);
    }

    public void SetModel(WeaponModel weaponModel)
    {
        this.weaponModel = weaponModel;
        weaponView.UpdateTextBullets(this.weaponModel.Bullets);
    }

    private void Fire()
    {
        weaponView.DrawFire(weaponModel.Shoot());
        weaponView.UpdateTextBullets(weaponModel.Bullets);
    }
}
