using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

/* created by Aubrey Isaacman
 *
 * This script does the same thing as the normal PlayerMovement script BUT
 * this one controls player movement with Circuit Playground Express (CPX)
 */

public class PlayerMovementAltCtrl : MonoBehaviour
{

    // for CPX input
    public SerialController serialController;

    // define what the controls are
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Speed;

    Vector2 moveUp;

    public float speedBoost;
    public float speed = 5f;
    
    public bool buttonPressed = false;

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
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();

        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        // receive data
        string message = serialController.ReadSerialMessage();
        if (message == null)
        {
            return;
        }

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + message);


        // player moves up on left button press on CPX
        
        if(message == "Decoded Unknown(0): Value:0 Adrs:0 (0 bits) ")
        {
            moveUp = gameObject.transform.position;

            moveUp.y += moveUp.y * -speed * Time.deltaTime;
            gameObject.transform.position = moveUp;

        }

        // players moves down on right button press on CPX
        if(message == "Decoded NECx(7): Value:E0E040BF Adrs:0 (32 bits)")
        {
            moveUp.y += moveUp.y * speed * Time.deltaTime;
            gameObject.transform.position = moveUp;
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
