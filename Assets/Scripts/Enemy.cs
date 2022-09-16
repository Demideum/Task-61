using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _pathEnemy;
    [SerializeField] private float _speedEnemy;

    private Transform[] _points;
    private int _currentPoint;
    private int _swivelAngle = -180;

    private void Start()
    {
        _points = new Transform[_pathEnemy.childCount];

        for (int i = 0; i < _pathEnemy.childCount; i++)
        {
            _points[i] = _pathEnemy.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speedEnemy * Time.deltaTime);

        if (transform.position == target.position)
        {
            transform.eulerAngles = new Vector3(0, _swivelAngle, 0);
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.transform.position = player.Die();
        }
    }
}
