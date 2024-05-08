using UnityEngine;

[CreateAssetMenu(fileName = "CircleConfig", menuName = "EnemyConfigs/CircleConfig")]
public class CircleConfig : ScriptableObject
{

    [SerializeField] TypeCircle _typeCircle;

    [SerializeField] CircleMonobehavior _circlePrefab;


    public TypeCircle TypeCircle => _typeCircle;

    public CircleMonobehavior CirclePrefab => _circlePrefab;
}
