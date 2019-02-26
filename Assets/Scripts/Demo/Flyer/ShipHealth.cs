using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : Unit
{
    [SerializeField] GameObject explosive;
    [SerializeField] Transform explodepoint;
    [SerializeField] Image HealthBar;

    float initialHealth;

    void Start()
    {
        initialHealth = health;
        HealthBar.fillAmount = 1f;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (health <= 0) return;

        Unit unit = collision.transform.root.gameObject.GetComponent<Unit>();
        if (unit)
        {
            health -= unit.damage;
            //Debug.Log("health: " + health);
            HealthBar.fillAmount = health / initialHealth;
            if (health <= 0)
            {
                Events.TriggerGameOver();
                Debug.Log("Game Over");
                Instantiate(explosive, transform.position, transform.rotation);

                Destroy(gameObject);
            }
        }
    }

    public void IncreaseHealth(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, 100);
        Debug.Log("new Health: " + health);
        HealthBar.fillAmount = health / initialHealth;
    }
}
