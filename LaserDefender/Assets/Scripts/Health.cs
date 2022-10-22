using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] int score = 50;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.GetComponent<Damage>();
        if(damage != null)
        {
            TakeDame(damage.GetDamage());
            PlayHit();
            audioPlayer.DamageClip();
            CameraShake();
            damage.Hit();
        }
    }

    void TakeDame(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    void PlayHit()
    {
        if (hitEffect != null)
        {
            ParticleSystem intance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(intance.gameObject, intance.main.duration + intance.main.startLifetime.constantMax);
        }
    }

    void CameraShake()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(score);           
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
        
    }
    
}
