using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* created by Aubrey Isaacman
 *
 * This script controls player movement: constantly move up + change direction
 * For now, this works with the keyboard
 * Eventually, it will work with Arduino or Adafruit
*/

public class PlayerMovement : MonoBehaviour
{
    // define what the controls are
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Speed;

    Vector2 moveUp;

    public float speedBoost;
    public float speed;

    // taking damage animation
    public Animation anim;

    // win state text
    public GameObject WinText;

    // how many crystals player has
    public int displayCount = 0;
    // variable for the UI text that shows the crystal count
    public Text countUI;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        // player moves up when they press S
        // player goes faster if they press A
        if(Input.GetKey(Up))
        {
            moveUp = gameObject.transform.position;
            
            if(Input.GetKey(Speed))
            {
                moveUp.y += speedBoost * speed;
            }

            moveUp.y += speed;
            gameObject.transform.position = moveUp;
        }

        // when space is pressed, player will go down
        if(Input.GetKey(Down))
        {
            moveUp.y -= 0.1f;
            gameObject.transform.position = moveUp;

            if(Input.GetKey(Speed))
            {
                moveUp.y -= speedBoost * speed;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Crystal"))
        {
            displayCount++;
            countUI.text = displayCount.ToString(); //write the new score to the UI text
        }
        
        if(other.CompareTag("Enemy"))
        {
            anim.Play("PlayerDamage");
            // make player immune to other enemies while they're flashing red
            // decrease number of crystals they have
            displayCount--;
            countUI.text = displayCount.ToString(); // write new score to UI text
            // make sure they can never have a negative amount of crystals
            if(displayCount < 0)
            {
                displayCount = 0;
                countUI.text = displayCount.ToString();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "GameWon")
        {
            if(displayCount >= 2)
            {
                WinText.SetActive(true);
            }
        }
    }
}
