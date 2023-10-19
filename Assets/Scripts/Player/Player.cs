using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private CatWin _cat;

    private Animator _animation;

    public bool Lose { get; private set; }

    private void Awake()
    {
        _animation = GetComponent<Animator>();
    }

    private void Start()
    {
        Alive();
        _cat.gameObject.SetActive(false);
    }

    public void Alive() => Lose = false;

    public void PlayerReady()
    {
        _animation.SetBool("Idle", true);
    }

    public void Defeated()
    {
        Lose = true;
        Dance();
    }

    public void Run()
    {
        _animation.SetBool("Idle", false);
        _animation.SetBool("Run", true);
    }

    public void Idle()
    {
        _animation.SetBool("Idle", true);
        _animation.SetBool("Run", false);
    }

    private void Dance()
    {
        DanceCat();
        _animation.SetBool("Dance", true);
    }

    private void DanceCat()
    {
        float zoneCat = 1.5f;
        float Left = -1.5f;
        float catPositionY = -2.86f;

        if (transform.position.x >= 1.1f)
            zoneCat = Left;

        _cat.transform.position = new Vector3(transform.position.x + zoneCat,
                                              catPositionY);

        _cat.gameObject.SetActive(true);
    }
}
