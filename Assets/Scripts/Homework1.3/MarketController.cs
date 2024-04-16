using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketController : MonoBehaviour
{
    [SerializeField] Trader trader;
    [SerializeField] Buyer buyer;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI textReputation;
    private const int WeaponLvl = 80;
    private const int FoodLvl = 30;

    public void ChangeSlider()
    {
        buyer.SetReputation((int)slider.value);
        CheckReputation(buyer.Reputation);
        textReputation.text = buyer.Reputation.ToString();
    }

    private void CheckReputation(int reputation)
    {
        if(reputation > WeaponLvl)
        {
            trader.SetStragedy(new WeaponTrade());
        }
        else if(reputation > FoodLvl)
        {
            trader.SetStragedy(new FoodTrade());
        }
        else
        {
            trader.SetStragedy(new NoTrade());
        }
    }

    private void Start()
    {
        buyer.SetReputation(0);
        CheckReputation(buyer.Reputation);
    }

}
