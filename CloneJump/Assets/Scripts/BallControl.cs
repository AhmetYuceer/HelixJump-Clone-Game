using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallControl : MonoBehaviour
{
    //lvl
    LevelManager levelManager;

    //power
    public bool powerMod {get;set;}
    private float defaultPowerCount = 0;
    private float _powerCount;
    private float powerLimit = 3;
    //////
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;

    [Header("Graphics")]
    [SerializeField] private GameObject splashMaterial;
    [SerializeField] private Material buffMaterial;
    [SerializeField] private Material mainMaterial;
    [SerializeField] private ParticleSystem buffParticle;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipRemove;
    [SerializeField] private AudioClip audioClipBall;

    private void Start() 
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update() 
    {
        if (powerMod)
        {
            this.GetComponent<MeshRenderer>().material = buffMaterial;
            buffParticle.Play();
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = mainMaterial;
            buffParticle.Stop();
        }
    }
    private void FixedUpdate()
    {
        Vector3 velocity = rb.velocity;
        velocity.y = Mathf.Clamp(velocity.y , -speed , speed);
        rb.velocity = velocity;
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.name == "Buff")
        {
            levelManager.AddXP();
            power();   
            other.gameObject.transform.parent.GetComponent<Pieces>().remove();
            audioSource.PlayOneShot(audioClipRemove);
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (powerMod)
        {
            if (other.collider.gameObject.CompareTag("end"))
            {
                levelManager.SaveGame();
                UIManager.endPanelisOpen = true;
                Time.timeScale = 0f;
                SplashEffect(other);
            }
            else
            {
                other.gameObject.transform.parent.GetComponent<Pieces>().remove();
            }
            restCount();        
        }    
        else
        {
            if (other.collider.gameObject.CompareTag("end") || other.collider.gameObject.CompareTag("finish"))
            {
                UIManager.endPanelisOpen = true;
                Time.timeScale = 0f;
            }
            SplashEffect(other);
            restCount();        
        }
        audioSource.PlayOneShot(audioClipBall);
    }

    private void SplashEffect(Collision other)
    {
        Instantiate(splashMaterial, transform.position - new Vector3(0,0.3f,0) , Quaternion.Euler(90,0,0),other.collider.gameObject.transform);
    }
    public void power()
    {
        if (_powerCount < powerLimit)
        {
            powerMod = false;
            _powerCount += 1;            
        }   
        else if (_powerCount >= powerLimit)
        {
            powerMod = true;
        }
    }
    public void restCount()
    {
        _powerCount = defaultPowerCount;
        powerMod = false;
    }
}
