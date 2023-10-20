using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    [SerializeField] private Transform _leftZone;
    [SerializeField] private Transform _rightZone;

    [SerializeField] private Controller _entry;

    private int _rotationDegree = 180;

    private void OnMouseDrag()
    {
        if (_entry.IsGame)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePosition.x = Mathf.Clamp(mousePosition.x, _leftZone.position.x, _rightZone.position.x);

            Turn(mousePosition);

            _player.transform.position = Vector3.MoveTowards(_player.transform.position,
                new Vector3(mousePosition.x, _player.transform.position.y, _player.transform.position.z),
                _speed * Time.deltaTime);
            
        }
    }

    private void OnMouseUpAsButton()
    {
        _player.Idle();
    }

    private void Turn(Vector3 mousePosition)
    {
        float delta = mousePosition.x - _player.transform.position.x;
        float epsilon = 0.01f;

        if (Mathf.Abs(delta) < epsilon)
            _player.Idle();

        if (delta >= epsilon)
            Turn(0);

        if (delta <= -epsilon)
            Turn(_rotationDegree);
    }

    private void Turn(int degrees)
    {
        _player.transform.rotation = Quaternion.Euler(0, degrees, 0);
        _player.Run();
    }
}
