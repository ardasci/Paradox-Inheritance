using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planeCont : MonoBehaviour
{
    public float planeSpeed;
    private Rigidbody2D rb;
    private Vector2 planeDirection;
    public Text score;
    private int coinScore;

    [SerializeField] private AudioSource coinCollection;
    [SerializeField] private AudioSource deathSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        planeDirection = new Vector2(0,directionY).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0,planeDirection.y*planeSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            coinCollection.Play();
            coinScore++;
            score.text = "=" + " " + coinScore.ToString();
            Destroy(collision.gameObject);
            if (PlayerPrefs.HasKey("coin"))
            {
                int coinCount = PlayerPrefs.GetInt("coin");
                coinCount++;
                PlayerPrefs.SetInt("coin",coinCount);
            }
            else if (!PlayerPrefs.HasKey("coin"))
            {
                PlayerPrefs.SetInt("coin",coinScore);
            }
        }
    }
}
