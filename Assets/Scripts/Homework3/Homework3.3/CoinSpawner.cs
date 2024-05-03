using System;
using System.Collections.Generic;
using UnityEngine;

/*
 * Я потом только понял, что вы имели ввиду наверное, что в одной точке если монетка есть, то уже не создавать новую,
 * но я уже реализовал спавн по кругу и не хочу от него отказываться)). А чтобы решить проблему просто в точке, то точно так же
 * создаем сферу в точке, проверяем есть ли в коллайдере вхождения вообще, если там что то может находится, то можем конретно 
 * монетки проверить и в зависимости от ответа создавать или нет новую. * 
 */

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject _coinPrefab;
    [SerializeField] Transform[] _startPositions;
    [SerializeField] float _sizeBetweenCoins;
    [SerializeField] int _amountCoinsInFirstLine;
    private List<GameObject> _coins = new List<GameObject>();
    private float _radius;

    private bool _isFindPlaceForCoin = false;
    private int _number;
    private int _numberInLine;
    private int _amountCoinsInLine;
    private int _idPosition = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Spawn();


        if (Input.GetKeyDown(KeyCode.C))
        {
            _idPosition++;
            if (_idPosition >= _startPositions.Length)
                _idPosition = 0;
        }

        if (_isFindPlaceForCoin)
        {
            FindPlaceAtPoint();
        }
    }

    private void Spawn()
    {
        _coins.Add(Instantiate(_coinPrefab));
        _coins[^1].name = $"Coin {_coins.Count}";
        _number = 0;
        _numberInLine = 0;
        _amountCoinsInLine = _amountCoinsInFirstLine;
        _radius = _coinPrefab.transform.localScale.x * _sizeBetweenCoins;
        _isFindPlaceForCoin = true;
    }

    private void FindPlaceAtPoint()
    {
        Collider[] hitColliders = Physics.OverlapSphere(new Vector3(_startPositions[_idPosition].position.x, 0, _startPositions[_idPosition].position.z), _coinPrefab.transform.localScale.x / 2);
        if (hitColliders.Length == 0)
        {
            _isFindPlaceForCoin = false;
            _coins[^1].transform.position = new Vector3(_startPositions[_idPosition].position.x, 0, _startPositions[_idPosition].position.z);
        }
        else
            FindPlaceNear();
    }
    
    private void FindPlaceNear()
    {
        float x = (float)(Math.Cos(2 * Math.PI * _number / _amountCoinsInLine) * _radius) + _startPositions[_idPosition].position.x;
        float y = (float)(Math.Sin(2 * Math.PI * _number / _amountCoinsInLine) * _radius) + _startPositions[_idPosition].position.z;

        //На 2 делим, потому что нужен радиус, а не диаметр, как спрятать это магическое число не знаю
        Collider[] hitColliders = Physics.OverlapSphere(new Vector3(x, 0, y), _coinPrefab.transform.localScale.x / 2);
        if (hitColliders.Length == 0)
        {
            _isFindPlaceForCoin = false;
            _coins[^1].transform.position = new Vector3(x, 0, y);
        }
        else
        {
            _number++;
            _numberInLine++;
            if (_numberInLine == _amountCoinsInLine)
            {
                _radius += _sizeBetweenCoins * _coinPrefab.transform.localScale.x;
                _amountCoinsInLine += _amountCoinsInFirstLine;
                _numberInLine = 0;
            }
        }
    }    
}
