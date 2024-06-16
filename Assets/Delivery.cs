using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] int delay = 1;
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);

    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("OUUUUUUCHHH!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        //if the thing we trigger is package then print package pick up to the console
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("GOT THE PACKAGE");
            hasPackage = true;
            Destroy(other.gameObject,delay);
            spriteRenderer.color = hasPackageColor;
        }

        if (other.tag == "Client" && hasPackage) {
            Debug.Log("Delivered THE PACKAGE");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
