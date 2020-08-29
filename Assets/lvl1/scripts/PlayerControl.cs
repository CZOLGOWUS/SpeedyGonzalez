using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    //Components
    Rigidbody2D myRigidBody;

    //movement
    Vector2 input;
    public float speed = 10f;

    //wrap
    Vector2 screenSizeVec2;

    //Events
    public event Action OnPlayerDeath;



    // Start is called before the first frame update
    void Start()
    {
        //float halfPlayerWidth = transform.localScale.x / 2f;
        screenSizeVec2 = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //transform.Translate(input.normalized * speed * Time.deltaTime);
        
        if (transform.position.x < -screenSizeVec2.x - transform.localScale.x * 1.33f)
            transform.position = new Vector2(screenSizeVec2.x + transform.localScale.x * 1.33f, transform.position.y);

        if (transform.position.x > screenSizeVec2.x + transform.localScale.x * 1.33f)
            transform.position = new Vector2(-screenSizeVec2.x - transform.localScale.x * 1.33f, transform.position.y);

        if (transform.position.y < -screenSizeVec2.y)
            transform.position = new Vector2(transform.position.x, -screenSizeVec2.y);

        if (transform.position.y > screenSizeVec2.y)
            transform.position = new Vector2(transform.position.x, screenSizeVec2.y);
    }

    private void FixedUpdate()
    {
        //input.Set(input.normalized.x * speed * 130f * Time.deltaTime, input.normalized.y * speed * 70f * Time.deltaTime);
        input.Set(input.normalized.x * speed * 130f * Time.deltaTime, input.normalized.y * speed * 20f * Time.fixedDeltaTime);
        
        myRigidBody.AddRelativeForce(new Vector2(input.x,0));
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, input.y);
    }

    //tutorial
    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "FallingBlock")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        } 
    }

}
