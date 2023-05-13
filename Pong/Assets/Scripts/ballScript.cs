using System.Collections;
using UnityEngine;

public class ballScript : MonoBehaviour
{
  public bool startOfRound = true;
  private int startDirection;
  private Vector2 direction = new Vector2(0, 0);
  private Rigidbody2D rb;
  private Rigidbody2D rbl;
  private Rigidbody2D rbr;
  public float speed = 150;
  public AudioSource paddle;
  public AudioSource wall;
  public GameObject logicSystem;
  private LogicScript logic;
  public GameObject leftPaddle;
  public GameObject rightPaddle;
  private float topSpeed = 15;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    rbl = leftPaddle.GetComponent<Rigidbody2D>();
    rbr = rightPaddle.GetComponent<Rigidbody2D>();
    logic = logicSystem.GetComponent<LogicScript>();
  }

  // Update is called once per frame
  void Update()
  {
    StartCoroutine(waiter());

    if (transform.position.x > 9.5)
    {
      logic.addScore(0);
      startOfRound = true;
    }
    else if (transform.position.x < -9.5)
    {
      logic.addScore(1);
      startOfRound = true;
    }

    if (rb.velocity.magnitude > topSpeed)
    {
      rb.velocity = Vector2.ClampMagnitude(rb.velocity, topSpeed);
      speed = 750;
    }

  }

  IEnumerator waiter()
  {
    if (startOfRound)
    {
      startDirection = Random.Range(0, 2);
      startOfRound = false;
      speed = 150;

      yield return new WaitForSeconds(2);

      if (startDirection == 0)
      {
        direction = new Vector2(-speed, 0);
      }
      else if (startDirection == 1)
      {
        direction = new Vector2(speed, 0);
      }

      rb.AddForce(direction);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.layer == 3)
    {
      paddle.Play();
      speed *= 1.5f;
      if (collision.gameObject.tag == "Player")
      {
        direction = new Vector2(speed, rb.velocity.y * rbl.velocity.y * 2);
      }
      else
      {
        direction = new Vector2(-speed, rb.velocity.y * rbr.velocity.y * 2);
      }
      rb.AddForce(direction);
    }
    else if (collision.gameObject.layer == 6)
    {
      wall.Play();
      if (transform.position.y > 0)
      {
        direction = new Vector2(direction.x / 2, -speed);
      }
      else
      {
        direction = new Vector2(direction.x / 2, speed);
      }
      rb.AddForce(direction);
    }
  }
}
