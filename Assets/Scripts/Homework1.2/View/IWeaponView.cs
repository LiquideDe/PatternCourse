using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponView
{
    public delegate void FirePressed();
    public void RegDelegate(FirePressed firePressed);
    public void UpdateTextBullets(int bullets);
    public void DrawFire(int bullets);
}
