using System.Collections;
using UnityEngine;
using System;

public class SpawnerEnemy : MonoBehaviour
{
    private string _nameSpawner;
    private float _delay;
    private EnemyFactory _enemyFactory;

    public void SetParameters(string name, float delay)
    {
        _nameSpawner = name;
        _delay = delay;
    }

    public void SetEnemyFactory(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    public void StartSpawnEnemy()
    {
        StartCoroutine(SpawnCorotuine());
    }

    public void StopSpawnEnemy()
    {
        StopCoroutine(SpawnCorotuine());
    }

    IEnumerator SpawnCorotuine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            Debug.Log($"{_nameSpawner} заспавнил врага");
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        System.Random random = new System.Random();
        int id = random.Next(0, Enum.GetNames(typeof(ClassType)).Length);
        var enemy = _enemyFactory.Get((ClassType)Enum.GetValues(typeof(ClassType)).GetValue(id));
        enemy.Attack();
    }

}
