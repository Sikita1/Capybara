using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Explode _bang;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.Defeated();
        }

        Die();
    }

    private void Die()
    {
        Instantiate(_bang, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
