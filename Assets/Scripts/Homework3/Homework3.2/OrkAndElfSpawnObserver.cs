using UnityEngine;

public class OrkAndElfSpawnObserver : MonoBehaviour
{
    [SerializeField] private string _nameFirstSpawner, _nameSecondSpawner;
    [SerializeField] private float _delaySpawnFirstSpawner, _delaySpawnSecondSpawner;
    private bool isFirstSpawnElf;
    private SpawnerEnemy _firstSpawner, _secondSpawner;
    
    void Start()
    {
        _firstSpawner = CreateNewSpawner(_nameFirstSpawner, _delaySpawnFirstSpawner);
        _firstSpawner.SetEnemyFactory(new OrkFactory());

        _secondSpawner = CreateNewSpawner(_nameSecondSpawner, _delaySpawnSecondSpawner);
        _secondSpawner.SetEnemyFactory(new ElfFactory());

        _firstSpawner.StartSpawnEnemy();
        _secondSpawner.StartSpawnEnemy();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _firstSpawner.StopSpawnEnemy();
            _secondSpawner.StopSpawnEnemy();

            if (isFirstSpawnElf)
            {
                isFirstSpawnElf = false;
                _firstSpawner.SetEnemyFactory(new OrkFactory());
                _secondSpawner.SetEnemyFactory(new ElfFactory());
            }

            else
            {
                isFirstSpawnElf = true;
                _firstSpawner.SetEnemyFactory(new ElfFactory());
                _secondSpawner.SetEnemyFactory(new OrkFactory());
            }

            _firstSpawner.StartSpawnEnemy();
            _secondSpawner.StartSpawnEnemy();
        }
    }

    private SpawnerEnemy CreateNewSpawner(string name, float delay)
    {
        GameObject spawnerGameObject = new GameObject();
        spawnerGameObject.name = name;
        SpawnerEnemy spawner = spawnerGameObject.AddComponent<SpawnerEnemy>();
        spawner.SetParameters(name, delay);

        return spawner;
    }
}
