using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    private GameObject plane;
    [SerializeField] private AudioSource deathSound;
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
        else if (collision.tag == "plane")
        {
            deathSound.Play();
            Destroy(plane.gameObject);
            
        }
    }
}
