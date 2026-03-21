using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float upForce;
    public Rigidbody2D rigb2d;
    
    public bool isDead;

    private PlayerControllers controllersPlayer;

    private Animator PlayerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controllersPlayer = new PlayerControllers();
        PlayerAnimator = GetComponent<Animator>();
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
        // Cambia IsPressed por wasPressedThisFrame (si usas el nuevo Input System)
        // O mejor aún, usa el callback de "Started"
        bool estaSaltando = controllersPlayer.Controllers.JUMP.WasPressedThisFrame();

        if (estaSaltando)
        {
            Flap();
        }
    }

    public void Flap()
    {
        rigb2d.linearVelocity = Vector2.zero;
        rigb2d.AddForce(Vector2.up * upForce);
        PlayerAnimator.SetTrigger("FLAP");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        PlayerAnimator.SetTrigger("DEAD");
    }
}
