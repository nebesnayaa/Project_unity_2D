using UnityEngine;

public class CloudScript : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        this.transform.Translate(Vector2.right * 
            //0.0001f
            Time.deltaTime / 10);

        if(this.transform.position.x > 10f)
        {
            this.transform.position = new Vector3(-10f, this.transform.position.y);
        }
    }
}
