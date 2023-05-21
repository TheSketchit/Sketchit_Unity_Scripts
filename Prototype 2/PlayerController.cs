using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 15.0f;
    public float xRange = 19.0f;
    public float zRange = 14.0f;

    public GameObject projecticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // sets the player boundary so that they have to stay within this particular range. 
        if(transform.position.x < -xRange)
        {
           transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); 
        }
        if(transform.position.x > xRange)
                {
           transform.position = new Vector3(xRange, transform.position.y, transform.position.z); 
        }

        if(transform.position.z > zRange)
        {
           transform.position = new Vector3(transform.position.x, transform.position.y, zRange); 
        }

        if(transform.position.z < -0.9f)
        {
           transform.position = new Vector3(transform.position.x, transform.position.y, -0.9f); 
        }
        
        // Get's player input from controls, and converts that to player movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed); 

        verticalInput = Input.GetAxis("Vertical");  
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed); 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projecticlePrefab, transform.position, projecticlePrefab.transform.rotation);
        }
    }
}
