using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace VRStandardAssets.Flyer
{
    // This class controls each asteroid in the flyer scene.
    public class BlackHole : MonoBehaviour
    {
        public event Action<Asteroid> OnAsteroidRemovalDistance;    // This event is triggered when it is far enough behind the camera to be removed.
        public event Action<Asteroid> OnAsteroidHit;                // This event is triggered when the asteroid is hit either the ship or a laser. 


        [SerializeField] private float AsteroidMinSize = 20f;     // The minimum amount an asteroid can be scaled up.
        [SerializeField] private float AsteroidMaxSize = 20f;     // The maximum amount an asteroid can be scaled up.
        [SerializeField] private float MinSpeed = 5f;             // The minimum speed the asteroid will move towards the camera.
        [SerializeField] private float MaxSpeed = 8f;            // The maximum speed the asteroid will move towards the camera.
        [SerializeField] private float MinRotationSpeed = 0f;   // The minimum speed the asteroid will rotate at.
        [SerializeField] private float MaxRotationSpeed = 0f;   // The maximum speed the asteroid will rotate at.
        [SerializeField] private int PlayerDamage = 2000;           // The amount of damage the asteroid will do to the ship if it hits.
        [SerializeField] private int pointScore = 0;                  // The amount added to the score when the asteroid hits either the ship or a laser.


        private Rigidbody rb;                              // Reference to the asteroid's rigidbody, used to move and rotate it.
        private FlyerDamage fd;      // Reference to the flyer's health script, used to damage it.
        private GameObject Flyer;                                 // Reference to the flyer itself, used to determine what was hit.
        public Transform Cam;                                    // Reference to the camera so this can be destroyed when it's behind the camera.
        private float Speed;                                      // How fast asteroid will move towards the camera.
        private Vector3 RotationAxis;                             // The axis around which the asteroid will rotate.
        private float RotationSpeed = 0;                              // How fast the asteroid will rotate.


        private const float k_RemovalDistance = 50f;                // How far behind the camera the asteroid must be before it is removed.


        public int Score { get { return pointScore; } }
        

        private void Awake ()
        {
            rb = GetComponent<Rigidbody>();
            
            fd = FindObjectOfType<FlyerDamage>();
            Flyer = fd.gameObject;

           
        }


        private void Start()
        {
            // Set a random scale for the asteroid.
            float scaleMultiplier = Random.Range(AsteroidMinSize, AsteroidMaxSize);
            transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, scaleMultiplier);

            

            // Set a random speed for the asteroid.
            Speed = Random.Range(MinSpeed, MaxSpeed);

            
        }


        private void Update()
        {
            // Move and rotate the asteroid given the previously set up parameters.
            rb.MoveRotation (rb.rotation * Quaternion.AngleAxis (RotationSpeed * Time.deltaTime, RotationAxis));
            rb.MovePosition (rb.position - Vector3.forward * Speed * Time.deltaTime);

           
        }


        private void OnTriggerEnter(Collider other)
        {
            // Only continue if the asteroid has hit the flyer.
            if (other.gameObject != Flyer)
                return;

            // Damage the flyer.
            fd.TakeDamage(PlayerDamage);

           
              
        }


       


        
    }
}