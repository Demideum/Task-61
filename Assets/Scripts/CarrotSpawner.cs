using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawner : MonoBehaviour
{
    [SerializeField] private Carrot _carrotPrefab;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private int _countCarrot;
    [SerializeField] private float _delaySpawnCarrots;

    private Transform[] _points;
    private int _currentPoint;
    private int _currentCountCarrots;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitSeconds = new WaitForSeconds(_delaySpawnCarrots);

        while (_countCarrot > _currentCountCarrots)
        {
            Instantiate(_carrotPrefab, _points[_currentPoint].position, Quaternion.identity);
            _currentCountCarrots++;
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }

            yield return waitSeconds;
        }
    }
}
