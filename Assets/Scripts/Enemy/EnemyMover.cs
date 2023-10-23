using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _speedMultiplier;

    private void Update()
    {
        transform.Translate(Vector3.down * _speedMultiplier * Time.deltaTime);
    }

    public void SetSpeedMultiplier(float speedMultiplier)
    {
        _speedMultiplier = speedMultiplier;
    }
}
