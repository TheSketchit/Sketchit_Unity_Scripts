using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBoundary = 30.0f;
    public float lowerBoundary = -10.0f;
    public float rightBoundary = -26f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBoundary) 
        {
            Destroy(gameObject);
        } 
                else if (transform.position.z < lowerBoundary)
                {
                    Debug.Log("Game Over!");
                    Destroy(gameObject);
                }
    }
}
