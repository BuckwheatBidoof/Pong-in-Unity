using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
  public Text leftScore;
  public Text rightScore;
  public static int playerScore = 0;
  public static int enemyScore = 0;
  public AudioSource score;
  public GameObject ball;
  private Rigidbody2D rb;
  void Update()
  {
    if (Input.GetKey("escape"))
    {
      Application.Quit();
    }
  }

  public void addScore(int player)
  {
    if (player == 0)
    {
      playerScore++;
      leftScore.text = playerScore.ToString();
    }
    else
    {
      enemyScore++;
      rightScore.text = enemyScore.ToString();
    }
    score.Play();

    rb = ball.GetComponent<Rigidbody2D>();

    rb.velocity = Vector2.zero;

    StartCoroutine(waiter());

    ball.transform.position = new Vector2(0, 0);

    if (playerScore == 10 || enemyScore == 10)
    {
      SceneManager.LoadScene("Game Over");
    }

  }

  IEnumerator waiter()
  {
    yield return new WaitForSeconds(0.5f);
    rb.velocity = Vector2.zero;
    yield return new WaitForSeconds(0.5f);
  }
}
