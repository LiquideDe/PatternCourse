using UnityEngine;

public interface IBallonView 
{
    public delegate void CheckCollider(Collider collider);
    public void RegDelegate(CheckCollider checkCollider);
    public void ShowGameWin();
    public void ShowGameLoose();
    public void GenerateBallons(int red, int green, int white);
}
