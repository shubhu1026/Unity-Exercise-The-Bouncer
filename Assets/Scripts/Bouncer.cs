using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bouncer : MonoBehaviour
{
    [SerializeField]
    GameObject bouncerPrefab;
    [SerializeField]
    TextMeshProUGUI tmp;

    Rigidbody2D rb2d;

    float force = 2f;
    float scorePerBounce = 10;
    int health;

    float score = 0;

    Color spriteColor;

    const int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        tmp.text = "Score: 0";

        rb2d = GetComponent<Rigidbody2D>();
        health = 100;

        spriteColor = GetComponent<SpriteRenderer>().color;

        Vector2 moveDirection = new Vector2((Random.Range(0, 360) * Mathf.Deg2Rad), (Random.Range(0, 360) * Mathf.Deg2Rad));
        rb2d.AddForce(force * moveDirection, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        tmp.text = "Score: " + score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health > 0)
        {
            health -= damage;
            score+= scorePerBounce;
        }

        spriteColor.a -= 0.1f;

        GetComponent<SpriteRenderer>().color = spriteColor;
    }
}
