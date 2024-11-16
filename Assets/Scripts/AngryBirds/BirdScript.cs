using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;
    private Rigidbody2D rb2d;
    private bool isLaunched = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            rb2d.AddForce(1000 * arrow.right);
            arrow.gameObject.SetActive(false);
            isLaunched = true;
        }
    }
}
