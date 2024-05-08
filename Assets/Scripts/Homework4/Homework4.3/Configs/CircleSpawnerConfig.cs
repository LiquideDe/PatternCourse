using UnityEngine;

[CreateAssetMenu(fileName = "CircleSpawnerConfig", menuName = "EnemyConfigs/CircleSpawnerConfig")]
public class CircleSpawnerConfig : ScriptableObject
{
    [SerializeField] int _limitX = 30;
    [SerializeField] int _limitZ = 15;

    public int LimitX => _limitX;

    public int LimitZ => _limitZ;
}
