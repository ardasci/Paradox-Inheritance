using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{
    public Text coinCount;
    public GameObject levelsPanel;
    public GameObject level2Button;
    public GameObject level2ButtonLocked;
    public GameObject level3Button;
    public GameObject level3ButtonLocked;
    void Start()
    {
        if (PlayerPrefs.HasKey("coin"))
        {
            coinCount.text = PlayerPrefs.GetInt("coin").ToString();
        }
    }

    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void loadLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void loadLevel3()
    {
        SceneManager.LoadScene(3);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void levelsShow()
    {
        levelsPanel.SetActive(true);
        levelsPanel.GetComponent<Animator>().Play("levelsAnim");
        if (PlayerPrefs.HasKey("coin"))
        {
            if(PlayerPrefs.GetInt("coin") >= 50)
            {
                level2Button.SetActive(true);
                level2ButtonLocked.SetActive(false);
            }
            if(PlayerPrefs.GetInt("coin") >= 100)
            {
                level2Button.SetActive(true);
                level2ButtonLocked.SetActive(false);
                level3Button.SetActive(true);
                level3ButtonLocked.SetActive(false);
            }
        }
    }

    public void levelsDisappear()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        levelsPanel.GetComponent<Animator>().Play("levelsAnimBack");
        yield return  new WaitForSeconds(0.5f);
        levelsPanel.SetActive(false);
    }

    public void resetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
