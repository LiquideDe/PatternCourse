using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class WeaponFireController : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] WeaponView weaponView;
    private WeaponPresenter weaponPresenter;
    private WeaponModel[] weaponModels;

    public void ChangeRateFire()
    {
        weaponPresenter.SetModel(weaponModels[dropdown.value]);
    }
    // Start is called before the first frame update
    void Start()
    {
        weaponModels = new WeaponModel[3] {new WeaponSingleShot(15), new WeaponInfiniteShot(15), new WeaponTripleShot(15) };
        List<string> nameModels = new List<string>() {"Одиночный выстрел", "Бесконечные патроны", "Тройной залп" };
        dropdown.ClearOptions();
        dropdown.AddOptions(nameModels);
        dropdown.onValueChanged.AddListener(delegate { ChangeRateFire(); });
        weaponPresenter = new WeaponPresenter(weaponModels[0], weaponView);
    }
}
