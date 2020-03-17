using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //variables that controlls spawnning wave
    [Header("Wave Settings")]
    public GameObject hazard; //what we are spawnning
    public Vector2 spawnValue; //where we are spawnning
    public int hazardCount; // howmany are we spawning per wave

    [Header("Wave Time Settings")]
    public float startWait; // how long until the first wave
    public float spawnWait; //how long between each wave in a wave
    public float waveWait; // how long between each wave

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Corroutien to spawn wave of hazzard

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        //Start spawning the wave
        while (true)
        {
            //Spawn some hazzards
            for (int i = 0; i < hazardCount; i++)
            {
                //spawn single hazard use to Sapwn ufo replace random.range
                Vector2 spawnPossion = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));

                Instantiate(hazard, spawnPossion, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait); // wait for the next hazard stargers asteroids
            }

            yield return new WaitForSeconds(waveWait); // Wait for the next wave hazard
        }
    }
}
