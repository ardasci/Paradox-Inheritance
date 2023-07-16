using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    private GameObject plane;
    private void Start()
    {
        plane = GameObject.FindGameObjectWithTag("plane");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "border")
        {
            Destroy(this.gameObject);
        }
    }
}
