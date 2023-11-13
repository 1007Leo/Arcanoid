using UnityEngine;
using UnityEngine.UI;

public class BonusBase : MonoBehaviour
{
    //public GameObject textObject;
    //Text textComponent;

    public Vector2 bonusObjectInitialForce;
    Rigidbody2D rb;
    GameObject playerObject;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BonusActivate();
            Destroy(gameObject);
        }
    }

    public virtual void BonusActivate()
    {
        PlayerScript playerScript = playerObject.gameObject.GetComponent<PlayerScript>();
        playerScript.gameData.points += 100;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        rb.isKinematic = false;
    }

    void Update()
    {
        rb.velocity = new Vector2(0, -2);
    }
}
