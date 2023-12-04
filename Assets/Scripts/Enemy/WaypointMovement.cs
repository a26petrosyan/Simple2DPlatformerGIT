using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _enemyPath;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPointIndex;

    private void Start()
    {
        _points = new Transform[_enemyPath.childCount];

        for (int i = 0; i < _enemyPath.childCount; i++)
            _points[i] = _enemyPath.GetChild(i);
    }

    private void Update()
    {
        var target = _points[_currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - target.position.x) < 0.01)
        {
            if (_currentPointIndex == _points.Length - 1)
                _currentPointIndex = 0;
            else
                _currentPointIndex++;

        }
    }
}
