using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public Rigidbody2D rigb2d;
    private Animator animatorPlayer;
    public bool isDead;

    private PlayerControllers controllersPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controllersPlayer = new PlayerControllers();
        animatorPlayer = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        controllersPlayer.Enable();
    }
    private void OnDisable()
    {
        controllersPlayer.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    public void Jump()
    {
        bool estaSaltando = controllersPlayer.Controllers.JUMP.IsPressed();

        if (estaSaltando == true)
        {
            Flap();
        }
    }

    public void Flap()
    {
        rigb2d.linearVelocity = Vector2.zero;
        rigb2d.AddForce(Vector2.up * velocity);
        animatorPlayer.SetTrigger("FLAP");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        animatorPlayer.SetTrigger("DEATH");
    }
}
