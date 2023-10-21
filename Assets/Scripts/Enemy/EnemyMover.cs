using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _speedMultiplier = 5f;

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * _speedMultiplier * Time.deltaTime);
    }

    public void SetSpeedMultiplier(float speedMultiplier)
    {
        _speedMultiplier = speedMultiplier;
    }
}
