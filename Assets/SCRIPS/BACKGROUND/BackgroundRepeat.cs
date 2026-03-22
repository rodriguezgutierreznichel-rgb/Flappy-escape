using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private float spriteWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        spriteWidth = boxCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -spriteWidth)
        {
            ResetPosition();
        }
    }
    public void ResetPosition()
    {
        transform.Translate(new Vector3(2 * spriteWidth, 0f, 0f));
    }

    
}
