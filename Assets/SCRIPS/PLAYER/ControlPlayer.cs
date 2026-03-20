using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class ControlPlayer : MonoBehaviour
{
    public float velocity = 2.0f;
    public Rigidbody2D rigb2d;
    public float forwardVelocity = 2.0f; // Velocidad hacia adelante

    // --- NUEVAS VARIABLES PARA ACELERACIÓN ---
    public float acceleration = 0.05f;
    public float maxForwardVelocity = 10.0f;
    public float decceleration = 0.05f;
    private bool chocandoConObstaculo = false;

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
       
        if (!chocandoConObstaculo && forwardVelocity < maxForwardVelocity)
        {
            forwardVelocity += acceleration * Time.deltaTime;
        }

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
        else if (estaSaltando == false && chocandoConObstaculo == true)
        {
            forwardVelocity =- decceleration * Time.deltaTime;
            Debug.Log("Frena velocidad");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            chocandoConObstaculo = true;
            Debug.Log("choco con el obstaculo");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            chocandoConObstaculo = false;
            Debug.Log("Ya no toca el obstáculo - Acelera de nuevo");
        }
    }
}
