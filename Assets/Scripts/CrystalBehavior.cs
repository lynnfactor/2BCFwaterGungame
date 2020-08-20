using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* created by Aubrey Isaacman
 * following Brackeys POWER UPS in Unity tutorial https://www.youtube.com/watch?v=CLSiRf_OrBk&list=PLlvhrv8NNgVEArGZaI2HtMTI3bj0GlhDe&index=92&t=0s
 *
 * The player needs to collect 5 crystals before they can escape on their time machine
 * This script will make crystals collectible by the player
*/

public class CrystalBehavior : MonoBehaviour
{
    // particle system!
    public GameObject crystalEffect;
    // for how long you want power up effect
    public float duration = 4f;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // assign this to "player" in Pickup method
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        // spawn a cool effect
        Instantiate(crystalEffect, transform.position, transform.rotation);

        // this will let you make the crystal invisible before you can destroy it
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        
        // Add crystal counter here

        yield return new WaitForSeconds(duration);
        

        // remove crystal object
        Destroy(gameObject);
    }
}
