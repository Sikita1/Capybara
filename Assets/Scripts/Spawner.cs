using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Enemy[] _enemys;
    [SerializeField] private float _secondsBetweenSpawn;

    [SerializeField] private Transform _leftEght;
    [SerializeField] private Transform _rightEght;

    [SerializeField] private Player _player;

    [SerializeField] private EntryPoint _entry;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_enemys);
    }

    private void Update()
    {
        if (_entry.IsGame)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _secondsBetweenSpawn)
            {
                if (TryGetRandomObject(out Enemy enemy))
                {
                    _elapsedTime = 0;

                    if (_player.Lose == false)
                        SetEnemy(enemy, new Vector3(GetRandomPosition(),
                                                    _leftEght.position.y,
                                                    _leftEght.position.z));
                }
            }
        }
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private float GetRandomPosition() =>
        Random.Range(_leftEght.position.x,
                     _rightEght.position.x);
}
