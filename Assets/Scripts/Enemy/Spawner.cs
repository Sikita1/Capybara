using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Enemy[] _enemys;

    [SerializeField] private Transform _leftEght;
    [SerializeField] private Transform _rightEght;

    [SerializeField] private Player _player;

    [SerializeField] private Controller _entry;

    [SerializeField] private float _timeIncrease;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _minSecondsBetweenSpawn;
    [SerializeField] private float _increaseSpeed;
    [SerializeField] private float _maxIncreaseSpeed;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_enemys);
    }

    private void Update()
    {
        if (_player.Lose)
            return;

        if (_entry.IsGame)
        {
            _increaseSpeed = Multiplier(_increaseSpeed, _maxIncreaseSpeed);
            _secondsBetweenSpawn = Multiplier(_secondsBetweenSpawn, _minSecondsBetweenSpawn);

            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _secondsBetweenSpawn &&
                TryGetRandomObject(out Enemy enemy))
            {
                _elapsedTime = 0;

                enemy.Enable();
                enemy.SetPosition(new Vector3(GetRandomPosition(),
                                                _leftEght.position.y,
                                                _leftEght.position.z));
                enemy.SetSpeedMultiplier(_increaseSpeed);
            }
        }
    }

    private float GetRandomPosition() =>
        Random.Range(_leftEght.position.x,
                     _rightEght.position.x);

    private float Multiplier(float current, float target)
    {
        if (current != target)
            //float l = target - current;
            current = (((target - current)* Time.deltaTime) / _timeIncrease);
            //current = Mathf.MoveTowards(current, target, l);


        return current;
    }
}
