using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float health = 1.0f;
    private float eggDamage = 0.2f;
    private float numOfEggCollisions = 0;
    private float alphaValue = 1.0f;
    private SpriteRenderer spriteRenderer = null;
    private SpawnManager spawnManager = null;

    // Start is called before the first frame update
    void Start()
    {
        // Get SpriteRenderer in order to manipulate color
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get SpawnManager in order to call EnemyDestroyed and keep track of deaths.
        spawnManager = FindFirstObjectByType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Change alpha to reflect remaining health.
        Color currentColor = spriteRenderer.color;
        spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, alphaValue);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // If player hits plane then just destroy entirely.
        if (other.name == "Player") {
            spawnManager.EnemyDestroyed();
            Destroy(gameObject);

        // Else if an egg hits the plane then decrement health and alpha.
        } else if (other.name == "Egg(Clone)")
        {
            health = health - eggDamage;
            numOfEggCollisions++;
            alphaValue = alphaValue * 0.8f;

            // If four or more eggs hit the plane then destroy.
            if (numOfEggCollisions >= 4)
            {
                spawnManager.EnemyDestroyed();
                Destroy(gameObject);
            }
        }
    }
}
