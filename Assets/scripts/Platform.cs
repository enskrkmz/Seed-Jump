using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float bounceSpeed;
    private float distance = 5.2f;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }
    void Update()
    {
        float rnd = Random.Range(-2.1f,2.1f);
        if (mainCam.transform.position.y - transform.position.y >= distance)
        {
            transform.position = new Vector2(rnd, transform.position.y + 18);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.relativeVelocity.y <= 0)
        {
            playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceSpeed);
            if (CompareTag("woodPlatform"))
            {
                StartCoroutine(timer());
            }
        }
    }
    IEnumerator timer()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}

