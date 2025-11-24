using UnityEngine;

public class Player_Shield : MonoBehaviour
{
    public AudioClip powerUpClip;
    public AudioClip powerDownClip;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && powerUpClip != null)
        {
            audioSource.PlayOneShot(powerUpClip);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Enemy")
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            Instantiate(whatDidIHit.GetComponent<Enemy>().explosionPrefab, whatDidIHit.transform.position, Quaternion.identity);
            gameManager.AddScore(5);
            gameManager.ChangeScoreText(gameManager.score);
            Destroy(whatDidIHit.gameObject);
            if (audioSource != null && powerDownClip != null)
            {
                audioSource.PlayOneShot(powerDownClip);
            }
            Collider2D collider = this.GetComponent<Collider2D>();
            collider.enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject,3);
        }
    }

}
