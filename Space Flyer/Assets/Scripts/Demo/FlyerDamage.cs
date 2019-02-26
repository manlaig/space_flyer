using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace VRStandardAssets.Flyer
{
    public class FlyerDamage : MonoBehaviour
    {
        [SerializeField] private float StartingHealth = 100f;         // The amount of health the flyer starts with.


        [SerializeField] private GameObject explosive;     // A prefab of the flyer exploded into parts.
        [SerializeField] private GameObject Flyer;


        [SerializeField] private Image HealthBar;                     // Reference to the image used as a health bar.


        [SerializeField] private AudioSource ExplosionAudio;          // Reference to the audio source used to play the explosion sound.
        [SerializeField] private AudioSource ThrusterAudio;           // Reference to the audio source used to play the sound of the flyer engines.


        

        private float CurrentHealth;                                  // How much health the flyer currently has.
        private bool destroyed;                                          // Whether the flyer is currently dead.


        

        public bool IsDead { get { return destroyed; } }


        public void StartGame ()
        {
            // The flyer is not dead and it's health is reset.
            destroyed = false;
            CurrentHealth = StartingHealth;
            HealthBar.fillAmount = 1f;

            // Play the thrusters if the flyer is being turned on and stop them if not.
            
                ThrusterAudio.Play();
            
                
        }


        public void TakeDamage(int damage)
        {
            // If the flyer is already dead no need to do anything.
            if (destroyed)
                return;

            // Decrement the current health by the damage but make sure it stays between the min and max.
            CurrentHealth -= damage;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, StartingHealth);

            // Set the health bar to show the normalised health amount.
            HealthBar.fillAmount = CurrentHealth / StartingHealth;

            // If the current health is approximately equal to zero the flyer is dead so destroy it.
            if (Mathf.Abs(CurrentHealth) < float.Epsilon)
            {
                ThrusterAudio.Stop();
                destroyed = true;
                Destroy(Flyer);

                Instantiate(explosive, transform.position, Quaternion.identity);

                // Play the explosion audio.
                ExplosionAudio.Play();
            }
        }
    }
}