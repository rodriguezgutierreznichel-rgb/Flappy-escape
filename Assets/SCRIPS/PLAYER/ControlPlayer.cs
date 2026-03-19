using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class ControlPlayer : MonoBehaviour
{
    public float velocity = 2.0f;
    public Rigidbody2D rigb2d;
    public float forwardVelocity = 2.0f; // Velocidad hacia adelante

    private PlayerControllers controllersPlayer;
    private void Awake()
    {
        controllersPlayer = new PlayerControllers();
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
            rigb2d.linearVelocity = Vector2.up * velocity;
            rigb2d.linearVelocity = new Vector2(forwardVelocity, rigb2d.linearVelocity.y);
        }
    }
}
