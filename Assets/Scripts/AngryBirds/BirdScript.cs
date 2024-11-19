using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;
    [SerializeField]
    private float forceFactor;
    [SerializeField]
    private float shotTimeout;

    private Rigidbody2D rb2d;
    private ForceScript forceScript;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private float shotTime;
    private bool isShot = false;
    

    void Start()
    {
        shotTime = 0.0f;
        isShot = false;
        startPosition = this.transform.position;
        startRotation = this.transform.rotation;
        rb2d = GetComponent<Rigidbody2D>();
        forceScript = 
            GameObject
            .Find("ForceCanvasIndicator")
            .GetComponent<ForceScript>();
    }

    void Update()
    {
        if (Time.timeScale == 0.0f)  return; 
        
        if (Input.GetKeyDown(KeyCode.Space) && !isShot)
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
            isShot = true;
            shotTime = shotTimeout;
            forceFactor /= forceScript.forceFactor + 0.5f;
        }
        if (isShot)
        {
            shotTime -= Time.deltaTime;
            if (shotTime < 0.0f)
            {
                TriesCountScript.triesCount -= 1;
                if(TriesCountScript.triesCount <= 0)
                {
                    TriesCountScript.triesCount = 0;
                    GameState.isLevelFailed = true;
                    ModalScript.ShowModal("ПРОГРАШ", "Вичерпано кількість спроб", "Перезапустити");
                }
                else
                {
                    isShot = false;

                    this.transform.position = startPosition; // Start position
                    this.transform.rotation = startRotation;
                    rb2d.linearVelocity = Vector2.zero;      // Stop
                    rb2d.angularVelocity = 0.0f;

                    arrow.gameObject.SetActive(true);
                }
                
            }
        }
        

    }
}
