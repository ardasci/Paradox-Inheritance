using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManagement : MonoBehaviour
{
    [SerializeField] GameObject canvasInventory;

    [SerializeField] Text starText;
    [SerializeField] Text coinText;
    [SerializeField] Text boatText;
    [SerializeField] Text aidText;
    private int starCount;
    private int aidCount;
    private int coinCount;
    private int boatCount;
    private void Update()
    {
        showInventory();
        if (Input.GetKeyDown(KeyCode.G))
        {
            deleteData();
        }
    }
    

    public void showInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !canvasInventory.activeSelf)
        {
            canvasInventory.SetActive(true);
            if (PlayerPrefs.HasKey("star"))
            {
                starCount = PlayerPrefs.GetInt("star");
                starText.text = "Star:" + starCount;
            }
            else
            {
                starText.text = "Star: 0";
            }

            if (PlayerPrefs.HasKey("coin"))
            {
                coinCount = PlayerPrefs.GetInt("coin");
                coinText.text = "Coin:" + coinCount;
            }
            else
            {
                coinText.text = "Coin: 0";
            }

            if (PlayerPrefs.HasKey("aid"))
            {
                aidCount = PlayerPrefs.GetInt("aid");
                aidText.text = "Aid:" + aidCount;
            }
            else
            {
                aidText.text = "Aid: 0";
            }

            if (PlayerPrefs.HasKey("boat"))
            {
                boatCount = PlayerPrefs.GetInt("boat");
                boatText.text = "Boat:" + boatCount;
            }
            else
            {
                boatText.text = "Boat: 0";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && canvasInventory.activeSelf)
        {
            canvasInventory.SetActive(false);
        }
    }

    public void deleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
