using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float speed = 5.0f;
    public float acceleration = 0.2f; // Cuánto aumenta la velocidad por segundo
    public float maxSpeed = 15.0f;    // El tope de velocidad

    void Update()
    {
        
        if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }

        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
