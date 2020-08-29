using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Vector2 screenHalfSizeWorldUnits;
    public GameObject fallingBlockPrefab;

    float nextSpawnTime;

    public Vector2 spawnScale = new Vector2(0.5f,2.5f);
    float randomScale;
    //skalowanie moj sposób
    Vector3 randomScaleVec3;

    public float angleMax = 10f;
    float spawnAngle;

    //dificulty
    //moje
    //public float speedOfFallingBlocksMax = 15f;
    //public int dificulty = 1;

    //tutorial
    public Vector2 secondsBetwenSpawnsMinMax;


    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            //skalowanie moj sposób
            randomScale = Random.Range(spawnScale.x, spawnScale.y);

            //tutorial
            spawnAngle = Random.Range(-angleMax, angleMax);

            float secondsBetwenSpawns = Mathf.Lerp(secondsBetwenSpawnsMinMax.y,secondsBetwenSpawnsMinMax.x,Difficulty.GetDifficultyPrecent());
            nextSpawnTime = Time.time + secondsBetwenSpawns;

            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + randomScale);
            
            //moj sposób
            //Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(0f,0f, Random.Range(-angleMax, angleMax)));
            
            //tutorial
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward*spawnAngle));
            newBlock.transform.localScale = new Vector3( randomScale,randomScale,4.5f);

        }

    }

}