using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float speed = 5.0f;
    public float acceleration = 0.2f; // Cuánto aumenta la velocidad por segundo
    public float maxSpeed = 15.0f;    // El tope de velocidad

    public Animator EnemyAnimator;

    public CameraController CameraController;
    public GameObject presion;

    public float timer = 0;

    public void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        presion.SetActive(false);
    }
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }

        
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (timer >= 8f)
        {
            temblarCamara();
        }
        
    }

    public void temblarCamara()
    {
        StartCoroutine(CameraController.Shake());
        presion.SetActive(true);
    }
}
