using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class itemPickUpManagement : MonoBehaviour
{
    [SerializeField] GameObject pickGuide;
    public Transform itemContent;
    public GameObject inventoryItem;
    private bool inventoryControl;
    private GameObject collectibleObject;
    private int starCount;
    private int aidCount;
    private int coinCount;
    private int boatCount;
    public item Item;
    void Start()
    {
        collectibleObject = gameObject;
    }

    private void Update()
    {
        pickUp();
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            pickGuide.SetActive(true);
            inventoryControl = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        pickGuide.SetActive(false);
        inventoryControl = false;
    }

    public void pickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && inventoryControl)
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
            singeltonObject.Instance.Item.Add(Item);
            listItems();
            Destroy(collectibleObject);
            pickGuide.SetActive(false);
        }
    }

    public void listItems()
    {
        GameObject obj = Instantiate(inventoryItem);
        obj.transform.SetParent(itemContent.transform);
        var itemIcon = obj.transform.GetChild(0);
        itemIcon.GetComponent<Image>().sprite = Item.itemIcon;
        Debug.Log(singeltonObject.Instance.Item.LastIndexOf(Item));
    }
}
