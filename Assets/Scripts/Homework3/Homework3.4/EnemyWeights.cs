using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWeights", menuName = "EnemyWeights")]
public class EnemyWeights : ScriptableObject
{
    [SerializeField] private int elfWeight;
    [SerializeField] private int orkWeight;
    [SerializeField] private int humanWeight;
    [SerializeField] private int robotWeight;

    public int ElfWeight  => elfWeight;
    public int OrkWeight => orkWeight; 
    public int HumanWeight => humanWeight; 
    public int RobotWeight => robotWeight; 
}
