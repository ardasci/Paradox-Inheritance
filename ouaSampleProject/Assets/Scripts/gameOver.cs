using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    public GameObject panel;
    public Text coinCount;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("plane") == null)
        {
            coinCount.text = PlayerPrefs.GetInt("coin").ToString();
            panel.SetActive(true);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
