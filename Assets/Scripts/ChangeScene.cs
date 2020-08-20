using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* created by Aubrey Isaacman
 *
 * following this forum post: https://answers.unity.com/questions/1291944/button-that-change-scene-on-click.html
 * following this youtube tutorial: https://www.youtube.com/watch?v=7KR5IKi8m8g&feature=youtu.be
 *
 * This script lets you change the scene by clicking on a button
 * I made this specifically for the main menu
*/

public class ChangeScene : MonoBehaviour
{

    public void ChangeMenuScene(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
