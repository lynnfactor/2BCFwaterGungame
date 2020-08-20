using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* created by Aubrey Isaacman
 *
 * Following the Udemy Complete C# Unity Game Developer 2D course
 **** Glitch Garden 132. Spawn Attackers Using Coroutine
 *
 * This will spawn enemies randomly at the spawn points on the screen
 *
*/

public class EnemySpawner : MonoBehaviour
{
    // variables to establish random range of delay for spawning enemies
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    [SerializeField] GameObject enemyPrefab;

    // track if the spawner is on
        // starts as true
        // false when level ends
    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay)); // do this first to START with randomness
            SpawnAttacker();
        }
    }

    // actually spawn da bois
    private void SpawnAttacker()
    {
        Instantiate(enemyPrefab, transform.position /*where we currently are*/, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
