using UnityEngine;

public class WeaponTrade : TradeStrategy
{
    public override void LetsTrade()
    {
        Debug.Log($"Для вас у меня особый выбор");
    }
}
