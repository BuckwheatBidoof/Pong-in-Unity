using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
  public Text leftScore;
  public Text rightScore;
  private int playerScore = 0;
  private int enemyScore = 0;
  public AudioSource score;
  public GameObject ball;
  private Rigidbody2D rb;
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

    if (playerScore == 10)
    {

    }
    else if (enemyScore == 10)
    {

    }

  }

  IEnumerator waiter()
  {
    yield return new WaitForSeconds(0.5f);
    rb.velocity = Vector2.zero;
    yield return new WaitForSeconds(0.5f);
  }
}
