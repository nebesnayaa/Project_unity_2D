using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;
    private Rigidbody2D rb2d;
    private ForceScript forceScript;

    [SerializeField]
    private float forceFactor;


    private bool isLaunched = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        forceScript = GameObject
                        .Find("ForceCanvasIndicator")
                        .GetComponent<ForceScript>();
    }

    void Update()
    {
        if (Time.timeScale == 0.0f)  return; 
        
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            if (forceScript != null)
            {
                forceFactor *= forceScript.forceFactor + 0.5f;
            }
            else
            {
                Debug.LogError("forceScript NUll, used default");
            }

            rb2d.AddForce(forceFactor * arrow.right);
            arrow.gameObject.SetActive(false);
            isLaunched = true;
        }
    }
}
