using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  public float speed = 5;
  private Rigidbody2D rb;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.W))
    {
      rb.velocity = new Vector2(0.0f, speed);
    }
    else if (Input.GetKey(KeyCode.S))
    {
      rb.velocity = new Vector2(0.0f, -speed);
    }
    else
    {
      rb.velocity = Vector2.zero;
    }
  }
}