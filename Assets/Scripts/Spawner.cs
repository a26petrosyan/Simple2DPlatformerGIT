using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private float _respawnTime;

    private float _elapsedTime;

    private void Start()
    {
        _elapsedTime = _respawnTime;
    }

    private void Update()
    {
        _elapsedTime-= Time.deltaTime;

        if (_elapsedTime <= 0)
        {
            foreach (Transform orange in _spawner)
            {
                orange.gameObject.SetActive(true);
            }

            _elapsedTime = _respawnTime;
        }
    }
}
