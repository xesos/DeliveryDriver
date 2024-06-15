using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("OUUUUUUCHHH!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        //if the thing we trigger is package then print package pick up to the console
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("GOT THE PACKAGE");
            hasPackage = true;
        }

        if (other.tag == "Client" && hasPackage) {
            Debug.Log("Delivered THE PACKAGE");
            hasPackage = false;
        }
    }
}
