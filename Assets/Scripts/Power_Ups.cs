using UnityEngine;

public class Power_Ups : MonoBehaviour
{
    public GameObject playerShield;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            GameObject player = GameObject.FindWithTag("Player");
            GameObject shieldInstance = Instantiate(playerShield, player.transform.position, Quaternion.identity, player.transform);
            shieldInstance.transform.localPosition = Vector3.zero;
            Destroy(this.gameObject);
        }
    }
}
