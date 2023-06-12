using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickUpManagement : MonoBehaviour
{
    [SerializeField] GameObject pickGuide;
    private GameObject collectibleObject;
    private int starCount;
    private int aidCount;
    private int coinCount;
    private int boatCount;
    void Start()
    {
        collectibleObject = gameObject;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            pickGuide.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (collectibleObject.tag)
                {
                    case "star":
                        if (PlayerPrefs.HasKey("star"))
                        {
                            starCount = PlayerPrefs.GetInt("star");
                            starCount++;
                            PlayerPrefs.SetInt("star", starCount);
                        }
                        else
                        {
                            starCount++;
                            PlayerPrefs.SetInt("star", starCount);
                        }
                        break;
                    case "coin":
                        if (PlayerPrefs.HasKey("coin"))
                        {
                            coinCount = PlayerPrefs.GetInt("coin");
                            coinCount++;
                            PlayerPrefs.SetInt("coin", coinCount);
                        }
                        else
                        {
                            coinCount++;
                            PlayerPrefs.SetInt("coin", coinCount);
                        }
                        break;
                    case "boat":
                        if (PlayerPrefs.HasKey("boat"))
                        {
                            boatCount = PlayerPrefs.GetInt("boat");
                            boatCount++;
                            PlayerPrefs.SetInt("boat", boatCount);
                        }
                        else
                        {
                            boatCount++;
                            PlayerPrefs.SetInt("boat", boatCount);
                        }
                        break;
                    case "aidKit":
                        if (PlayerPrefs.HasKey("aid"))
                        {
                            aidCount = PlayerPrefs.GetInt("aid");
                            aidCount++;
                            PlayerPrefs.SetInt("aid", aidCount);
                        }
                        else
                        {
                            aidCount++;
                            PlayerPrefs.SetInt("aid", aidCount);
                        }
                        break;
                }
                Destroy(collectibleObject);
                pickGuide.SetActive(false);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        pickGuide.SetActive(false);
    }
}
