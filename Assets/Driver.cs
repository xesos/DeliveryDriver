using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float fastSpeed = 30f;


    void Start()
    {
        
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;        
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "SpeedTrap") {
            Debug.Log("Speeding Up");
            moveSpeed =  fastSpeed;

        }

        if (other.tag == "Cone") {
            Debug.Log("Slowing down Up");
            float moveAmount = Input.GetAxis("Vertical") * slowSpeed * Time.deltaTime;
            moveSpeed =  slowSpeed;
        }
        
    }
}
