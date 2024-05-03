using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    public class Spawner: MonoBehaviour, IEnemyDeathNotifier
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private EnemyWeights _enemyWeights;
        [SerializeField] private int _maxWeight;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();

        private Coroutine _spawn;
        private WeightEnemies _weightIncome;
        private WeightEnemies _weightOutcome;
        private bool _isCoroutineWork;

        public event Action<Enemy> Notified;

        public void StartWork()
        {
            if(_weightIncome == null)
            {
                _weightIncome = new WeightEnemies(_enemyWeights);
                _weightOutcome = new WeightEnemies(_enemyWeights);
            }

            StopWork();

            _spawn = StartCoroutine(Spawn());
            _isCoroutineWork = true;
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);

            _isCoroutineWork = false;
        }

        public void KillRandomEnemy()
        {
            if (_spawnedEnemies.Count == 0)
                return;

            _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Kill();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                enemy.Died += OnEnemyDied;
                _spawnedEnemies.Add(enemy);
                _weightIncome.Visit(enemy);

                if (_weightIncome.Weight - _weightOutcome.Weight > _maxWeight)
                    StopWork();
                                
                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            Notified?.Invoke(enemy);
            enemy.Died -= OnEnemyDied;
            _weightOutcome.Visit(enemy);
            _spawnedEnemies.Remove(enemy);

            if (_isCoroutineWork == false)
                if(_weightIncome.Weight - _weightOutcome.Weight < _maxWeight)
                {
                    StartWork();
                }
        }


        private class WeightEnemies : IEnemyVisitor
        {
            private EnemyWeights _enemyWeights;
            public WeightEnemies(EnemyWeights enemyWeights) => _enemyWeights = enemyWeights;            

            public int Weight { get; private set; }

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);

            public void Visit(Elf elf) => Weight += _enemyWeights.ElfWeight;

            public void Visit(Human human) => Weight += _enemyWeights.HumanWeight;

            public void Visit(Ork ork) => Weight += _enemyWeights.OrkWeight;

            public void Visit(Robot robot) => Weight += _enemyWeights.RobotWeight;
        }


    }

    
}
