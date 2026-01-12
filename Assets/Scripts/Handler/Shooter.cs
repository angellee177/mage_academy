using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; // You need this for the new Input System!

public class Shooter : MonoBehaviour
{
    [Header("Base Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFireRate = 0.2f;

    [Header("AI Variables")]
    [SerializeField] bool useAI;
    [SerializeField] float minimumFireRate = 0.2f;
    [SerializeField] float maximumFireRate = 1f;
    [SerializeField] float fireRateVariance = 0f;

    [HideInInspector] public bool isFiring;
    Coroutine fireCoroutine;
    AudioManager audioManager;

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        if(useAI)
        {
            isFiring = true;
        }
    }

    // --- NEW INPUT LOGIC ---
    // This is the function that handles the touch signal
    public void OnAttack(InputAction.CallbackContext context)
    {
        // When finger touches down
        if (context.started || context.performed)
        {
            isFiring = true;
        }
        // When finger lifts up
        else if (context.canceled)
        {
            isFiring = false;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        } 
        else if(!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            // Simplified instantiation
            GameObject projectile = Instantiate(
                projectilePrefab, 
                transform.position,
                transform.rotation
            );

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            if(projectileRB != null)
            {
                projectileRB.linearVelocity = transform.up * projectileSpeed;
            }

            Destroy(projectile, projectileLifetime);

            float waitTime = Random.Range(
                baseFireRate - fireRateVariance,
                baseFireRate + fireRateVariance
            );
            waitTime = Mathf.Clamp(waitTime, minimumFireRate, maximumFireRate);

            if(audioManager != null) audioManager.PlayShootingSFX();

            yield return new WaitForSeconds(waitTime);
        }
    }
}