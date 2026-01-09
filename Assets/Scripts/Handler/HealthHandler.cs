using System.Xml.Serialization;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int scoreValue = 1;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] bool applyCameraShake;

    ShakeScreen cameraShake;
    AudioManager audioManager;
    ScoreManagerHandler scoreManager;

    void Start()
    {
        cameraShake = Camera.main.GetComponent<ShakeScreen>();
        audioManager = FindFirstObjectByType<AudioManager>();
        scoreManager = FindFirstObjectByType<ScoreManagerHandler>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageHandler damageHandler = other.GetComponent<DamageHandler>();

        if(damageHandler != null)
        {
            // reduce health;
            TakeDamage(damageHandler.GetDamage());
            PlayHitParticles();
            damageHandler.Hit();
            audioManager.PlayDamageSFX();

            if(applyCameraShake)
            {
                cameraShake.Play();
            }
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} has taken damage! Current health: {health}");        
        
        if(health <= 0)
        {   
            Die();
        }
    }

    void Die()
    {
        if(!isPlayer)
        {
            scoreManager.ModifyScore(scoreValue);
        }
        
        Destroy(gameObject);
    }

    void PlayHitParticles()
    {
        if(hitParticles != null)
        {
            ParticleSystem particles = Instantiate(hitParticles, transform.position, Quaternion.identity);
            Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }
}
