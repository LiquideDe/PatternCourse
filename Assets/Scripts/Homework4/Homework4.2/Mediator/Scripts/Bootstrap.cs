using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private Level _level;

    [Inject]
    private void Construct(Level level)
    {
        _level = level;
    }

    private void Awake()
    {
        _level.Start();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _level.OnDefeat();
    }
}