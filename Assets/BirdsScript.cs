using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }


        float clampedY = Mathf.Clamp(transform.position.y, -17, 17); // Clamp the bird's position
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        if (transform.position.y >= 17 || transform.position.y <= -17)
        {
            if (birdIsAlive)
            {
                logic.gameOver();
                birdIsAlive = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
