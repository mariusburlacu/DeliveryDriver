using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool isPicked = false;

    [SerializeField] float destroyDelay = 0.5f;

    [SerializeField] Color32 hasPackageColor = new Color32(50,133,52,255);

    [SerializeField] Color32 noPackageColor = new Color32(200,78,71,255);

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
 
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Opal accident");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // if (the thing we trigger is the package)
        // then print "package picked up"

        if (other.tag.Equals("Package") && !isPicked) {
            Debug.Log("Package picked up");
            isPicked = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        } else {
            Debug.Log("You cannot pick more than one package!");
        }

        if (other.tag.Equals("Customer")) {
            if (isPicked) { 
                Debug.Log("Package delivered!");
                isPicked = false;
                spriteRenderer.color = noPackageColor;
            } else {
                Debug.Log("Package not picked! Please pick up the package");
            }
        }
    }
}
