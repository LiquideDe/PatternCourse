using UnityEngine;

public abstract class BattleCharacter
{
    public abstract void Attack();
    protected void ShowAttack(string text)
    {
        Debug.Log(text);
    }
}
