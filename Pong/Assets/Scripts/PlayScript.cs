using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
  public GameObject win;
  public GameObject lose;
  void Start()
  {
    if (LogicScript.playerScore == 10)
    {
      win.SetActive(true);
    }
    else
    {
      lose.SetActive(true);
    }
  }

  public void startNewGame()
  {
    SceneManager.LoadScene("Game");
  }
}
