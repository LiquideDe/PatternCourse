using UnityEngine;

public class Buyer : MonoBehaviour
{
    public int Reputation { get; private set; }

    public void SetReputation(int value)
    {
        Reputation = value;
    }
}
