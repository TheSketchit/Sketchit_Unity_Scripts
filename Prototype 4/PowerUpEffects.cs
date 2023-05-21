using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffects : MonoBehaviour 
{
    public float rotationSpeed = 20f;
    public float hoverAmount = 0.1f;
    public float hoverSpeed = 0.8f;
    private GameObject powerUp;

    void Start()
    {
        powerUp = GameObject.Find("Powerup");

       
    }

    void Update()
    {
        // The powerup should slowly rotate and bob up and down
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad * hoverSpeed) * hoverAmount * Time.deltaTime);
        


  
    }
}

