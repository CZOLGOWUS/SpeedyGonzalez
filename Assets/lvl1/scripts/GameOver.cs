using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //addon
using UnityEngine.SceneManagement; //addon

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;
    public Text secondsSurvivedUi;
    bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerControl>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvivedUi.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        isGameOver = true;
    }

}
