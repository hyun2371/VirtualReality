using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{

    AudioSource Audio;
    public AudioClip  ShotSound;
    public AudioClip explosionSound;
    public GameObject  ShotParticle;
    public HealthBar healthBar;
    private float MaxHealth = 50;
    private float CurrentHealth;
    public GameObject guideTmp;


    void Start()
    {
        Audio = GetComponent<AudioSource>();
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    private void Update()
    {
        if (CurrentHealth < 0)
        {
            guideTmp.GetComponent<TMP_Text>().text = "You killed gingerbread man.";
            PlayClip(explosionSound);
            gameObject.SetActive(false);
        }
    }

    void InstantiateParticle(GameObject Particle)
    {
        GameObject Shooter = gameObject;
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 1.4f + Shooter.transform.up * 1.7f;
        Quaternion CloneRot = Shooter.transform.rotation;
        GameObject Clone = Instantiate(Particle, ClonePos, CloneRot);
        // Clone.transform.localScale = Vector3.one * 0.5f;
        Destroy(Clone, 2f);


    }

    void PlayClip(AudioClip clip)
    {
        Audio.clip = clip;
        Audio.Play();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            print("Target hit");
            getShot();
            PlayClip(ShotSound);
            InstantiateParticle(ShotParticle);
            
        }
    }

    public void getShot()
    {
        CurrentHealth--;
        healthBar.SetHealth(CurrentHealth);
    }
}
