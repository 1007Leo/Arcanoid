using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameDataScript gameData;

    public Vector2 ballInitialForce;
    Rigidbody2D rb;
    GameObject playerObject;
    float deltaX;

    AudioSource audioSrc;
    public AudioClip hitSound;
    public AudioClip loseSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameData.sound)
        {
            audioSrc.PlayOneShot(loseSound, 5);
        }
        Destroy(gameObject);
        playerObject.GetComponent<PlayerScript>().BallDestroyed();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameData.sound) 
        {
            audioSrc.PlayOneShot(hitSound, 5);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        deltaX = transform.position.x;
        audioSrc = Camera.main.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (rb.isKinematic) 
        {
            if (Input.GetButtonDown("Fire1"))
            {
                rb.isKinematic = false;
                rb.AddForce(ballInitialForce);
            }
            else
            {
                var pos = transform.position;
                pos.x = playerObject.transform.position.x + deltaX;
                transform.position = pos;
            }
        }
        if (!rb.isKinematic && Input.GetKeyDown(KeyCode.J))
        {
            var v = rb.velocity;
            if (Random.Range(0, 2) == 0)
            {
                v.Set(v.x - 0.1f, v.y + 0.1f);
            }
            else
            {
                v.Set(v.x + 0.1f, v.y - 0.1f);
            }
            rb.velocity = v;
        }
    }
}
