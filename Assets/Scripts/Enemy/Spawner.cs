using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Enemy[] _enemys;

    [SerializeField] private Transform _leftEght;
    [SerializeField] private Transform _rightEght;

    [SerializeField] private Player _player;

    [SerializeField] private Controller _entry;

    [SerializeField] private float _timeIncrease;
    [SerializeField] private float _startSecondsBetweenSpawn;
    [SerializeField] private float _endSecondsBetweenSpawn;
    [SerializeField] private float _startIncreaseSpeed; 
    [SerializeField] private float _endIncreaseSpeed;

    private float _secondsBetweenSpawn;
    private float _increaseSpeed;

    private float _elapsedTime = 0;

    private void Start()
    {
        SpeedReset();
        Initialize(_enemys);
    }

    private void Update()
    {
        if (_player.Lose)
        {
            SpeedReset();
            return;
        }

        if (_entry.IsGame)
        {
            _increaseSpeed += Multiplier(_startIncreaseSpeed, _endIncreaseSpeed);
            _secondsBetweenSpawn += Multiplier(_startSecondsBetweenSpawn, _endSecondsBetweenSpawn);

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

    private void SpeedReset()
    {
        _secondsBetweenSpawn = _startSecondsBetweenSpawn;
        _increaseSpeed = _startIncreaseSpeed;
    }

    private float GetRandomPosition() =>
        Random.Range(_leftEght.position.x,
                     _rightEght.position.x);

    private float Multiplier(float start, float end)
    {
        float residualPath = end - start;

        return residualPath / _timeIncrease * Time.deltaTime;
    }
}
