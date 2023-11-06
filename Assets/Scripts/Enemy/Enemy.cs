using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audio;

    [SerializeField] private Explode _bang;

    private EnemyMover _enemyMover;
    private AudioSource _randomAudio;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _randomAudio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _randomAudio.clip = GetRundomAudio();
    }

    private void OnDisable()
    {
        _randomAudio.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.Defeated();
        }

        Die();
    }

    public void OnPlayMusic(bool isOnMusic)
    {
        if (isOnMusic)
            _randomAudio.Play();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetSpeedMultiplier(float speedMultiplier)
    {
        _enemyMover.SetSpeedMultiplier(speedMultiplier);
    }

    public void Die()
    {
        Instantiate(_bang, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    private AudioClip GetRundomAudio()
    {
        int randomNumber = Random.Range(0, _audio.Length);
        return _audio[randomNumber];
    }
}
