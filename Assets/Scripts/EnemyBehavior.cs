using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* created by Aubrey Isaacman
 *
 * Following the Udemy Complete C# Unity Game Developer 2D course
 **** Glitch Garden 131. Move Using transform.Translate
 *
 * This will tell enemies how to behave: move, attack, animation, etc.
 *
*/

public class EnemyBehavior : MonoBehaviour
{
    /* tell enemy how fast to fly
        // creates a slider for speed in the inspector
        // this is great for if you want to define a SPECIFIC speed
    [Range (0f, 10f)]
    [SerializeField] float flySpeed = 1f;
    */

    // I'm using this so the speed is random for each enemy spawned
    public float minSpeed = 1f;
    public float maxSpeed = 10f;

    public bool flyRight = true;

    // Update is called once per frame
    void Update()
    {
        // because flyRight is true, the enemy will fly to the right
            // if flyRight is set to false in the inspector, enemy will fly left
            // simply to make this easier on whoever wants to edit the level
        if(flyRight)
        {
            transform.Translate(Vector2.right * Random.Range(minSpeed, maxSpeed) * Time.deltaTime);
        }
        else 
        {
            transform.Translate(Vector2.left * Random.Range(minSpeed, maxSpeed) * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bounds")
        {
            Destroy(this.gameObject);
        }
    }
}
