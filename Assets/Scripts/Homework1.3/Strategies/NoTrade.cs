using UnityEngine;

public class NoTrade : TradeStrategy
{
    public override void LetsTrade()
    {
        Debug.Log($"Ќам с вам не о чем говорить и торговать");
    }
}
