using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* created by Aubrey Isaacman
 *
 * Following the EnemeySpawner script since I made that first
 *
 * This will spawn crystals randomly at the spawn points on the screen
 * these will spawn much slower than enemies
 * I'm keeping the two spawner scripts different specifically so I can change the min/max delay values since they should be different
*/

public class CrystalSpawner : MonoBehaviour
{
    // variables to establish random range of delay for spawning enemies
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 50f;

    [SerializeField] GameObject crystalPrefab;

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
            SpawnCrystal();
        }
    }

    // spawn the sparkley bois
    private void SpawnCrystal()
    {
        Instantiate(crystalPrefab, transform.position /*where we currently are*/, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
