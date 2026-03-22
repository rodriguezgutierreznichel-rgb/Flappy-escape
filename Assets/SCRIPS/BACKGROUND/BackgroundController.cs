using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Rigidbody2D rig2DBack;

    [SerializeField] private float speed = 2.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig2DBack = GetComponent<Rigidbody2D>();
        rig2DBack.linearVelocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
