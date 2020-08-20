using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* created by Aubrey Isaacman
 * 
 * following Ardity setup guide
*/

public class MyMessageListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // invoked when a line of data is received from the serial device
    void OnMessageArrived(string msg)
    {
        Debug.Log("Arrived: " + msg);
    }

    // invoked when connect/disconnect even occurs
        // 'success' will be 'true' upon connection,
        //'false' upon disconnection or failure to connect
    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
