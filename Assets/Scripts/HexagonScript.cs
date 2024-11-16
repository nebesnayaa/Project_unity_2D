using UnityEngine;

public class HexagonScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    float torqueAmount = 10f; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb2d.AddForce(Vector2.left * 300);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2d.AddForce(Vector2.right * 300);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        { 
            rb2d.AddForce(Vector2.up * 300); 
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb2d.AddTorque(torqueAmount);
            rb2d.AddForce(Vector2.down * 300);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            rb2d.linearVelocity = Vector2.zero;

            rb2d.angularVelocity = 0f;
        }
    }
}
