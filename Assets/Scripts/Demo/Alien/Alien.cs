using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Alien : Unit
{
    [SerializeField] int scoreValue = 10;
    [SerializeField] GameObject explosive;
    [SerializeField] Image HealthBar;

    //[SerializeField] AudioSource ExplosionAudio;
    //[SerializeField] AudioSource ThrusterAudio;

    float initialHealth;

    void Start()
    {
        initialHealth = health;
        HealthBar.fillAmount = 1f;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -20);
        rb.rotation = Quaternion.Euler(0, 0, 0);

        //ThrusterAudio.Play();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (health <= 0) return;

        Unit collidedGO = collision.gameObject.GetComponent<Unit>();
        if (collidedGO)
        {
            health -= collidedGO.damage;
            HealthBar.fillAmount = health / initialHealth;

            if (health <= 0)
            {
                //ThrusterAudio.Stop();

                CurrentScore.score += scoreValue;
                Destroy(Instantiate(explosive, transform.position, transform.rotation), 1.5f);
                Destroy(gameObject);

                //ExplosionAudio.Play();
            }
            
        }
    }  
}
 