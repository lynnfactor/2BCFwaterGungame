using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* created by Aubrey Isaacman
 *
 * ESC = quit game
 * R = restart level
 */

public class Quit : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            Debug.Log("Quitting game");
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restarting scene");
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
