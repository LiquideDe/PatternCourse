using UnityEngine;

public class Trader : MonoBehaviour
{
    private TradeStrategy tradeStrategy;

    public void SetStragedy(TradeStrategy tradeStrategy)
    {
        this.tradeStrategy = tradeStrategy;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Buyer buyer))
        {
            tradeStrategy.LetsTrade();
        }
    }
}
