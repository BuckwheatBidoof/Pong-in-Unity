using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    public bool startOfRound = true;
    private int startDirection;
    private Vector2 direction = new Vector2(0, 0);
    private Rigidbody2D rb;
    public int speed = 150;
    public AudioSource paddle;
    public AudioSource wall;
    public GameObject logicSystem;
    private LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        logic = logicSystem.GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waiter());
        
        if(transform.position.x > 10) {
            logic.addScore(0);
            startOfRound = true;
        } else if(transform.position.x < -10) {
            logic.addScore(1);
            startOfRound = true;
        }
        
    }

    IEnumerator waiter() {
        if(startOfRound) {
            startDirection = Random.Range(0, 2);
            startOfRound = false;

            yield return new WaitForSeconds(2);

            if(startDirection == 0) {
                direction = new Vector2(-speed,0);
            } else if(startDirection == 1) {
                direction = new Vector2(speed,0);
            }

            rb.AddForce(direction);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 3) {
            paddle.Play();
            direction = new Vector2(-direction.x, Random.Range(-speed, speed));
            rb.AddForce(direction);
        }else if(collision.gameObject.layer == 6) {
            wall.Play();
            direction = new Vector2(direction.x, -direction.y);
            rb.AddForce(direction);
        }
    }
}
