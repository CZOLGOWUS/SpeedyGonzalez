using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPrecent());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - transform.localScale.y)
            Destroy(gameObject);
    }
}
