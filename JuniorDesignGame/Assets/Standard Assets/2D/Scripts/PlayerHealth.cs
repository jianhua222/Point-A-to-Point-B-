using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider HealthSlider;                                 // Reference to the UI's health bar.
    //public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    //public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public int maxHealth;

    Animator anim;                                              // Reference to the Animator component.
    //AudioSource playerAudio;                                    // Reference to the AudioSource component.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.

    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;
    public Image Fill;

    float timeRemaining;


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();

        // Set the initial health of the player.
        currentHealth = GameControl.control.health;
        maxHealth = GameControl.control.maxHealth;
        Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)currentHealth / maxHealth);
        HealthSlider.maxValue = GameControl.control.maxHealth;
        HealthSlider.value = GameControl.control.health;
    }


    void Update()
    {
        if (Time.time >= timeRemaining)
        {
            damaged = false;
        }
    }

    public void updateSlider()
    {
        Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)currentHealth / maxHealth);
    }


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;
        //Debug.Log("Current HealthSlider value: " + HealthSlider.value);
        //Debug.Log("Current HealthSlider maxValue: " + HealthSlider.maxValue);
        //timeRemaining = Time.time + 2;
        // Reduce the current health by the damage amount.
        currentHealth = currentHealth - amount < HealthSlider.maxValue ? currentHealth - amount : (int)HealthSlider.maxValue;
        // Set the health bar's value to the current health.
        HealthSlider.value = currentHealth < HealthSlider.maxValue? currentHealth : HealthSlider.maxValue;
        GameControl.control.health = currentHealth;
        GameControl.control.maxHealth = (int)HealthSlider.maxValue;
        Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)GameControl.control.health / GameControl.control.maxHealth);
        timeRemaining = Time.time + 1.0f;
        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        
        if (currentHealth <= 0 && !isDead)
        {
            currentHealth = 0;

            new WaitForSeconds(1);
            //GameControl.control.health = maxHealth;
            SceneManager.LoadScene("Scene3");
        }


    }



    public void increaseHealth(int amount)
    {
        maxHealth += amount;
        HealthSlider.maxValue = maxHealth;
        currentHealth = maxHealth;
        HealthSlider.value = currentHealth;
        GameControl.control.health = currentHealth;
        GameControl.control.maxHealth = maxHealth;
        updateSlider();
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public bool getDamaged()
    {
        return damaged;
    }

}

