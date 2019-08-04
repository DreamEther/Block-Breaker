using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;   // sound clip played when a block is destroyed 
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] damageLevels;

    //cached reference
    Level level;
    GameSession currentTotalPoints;

    //state variables
    [SerializeField] int timesHit;

    private void Start()
    {
        CountBreakableBlocks(); 
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();   // getting access to Level as a class. 
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = damageLevels.Length + 1;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                playSparklesVFX();
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1; // -1 because the array starts at zero. 
        if (damageLevels[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = damageLevels[spriteIndex]; //SpriteRenderer is a reference to the Inspector tab for Block objects
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name); // this is just to let us know that a block does not have a sprite in it's array.
        }
    }

    private void DestroyBlock() 
    {
        currentTotalPoints = FindObjectOfType<GameSession>();
        currentTotalPoints.addToScore(); 
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);  // sound is coming from the main camera's position
        Destroy(gameObject);
        level.BlockDestroyed();
        playSparklesVFX();
       
    }

    private void playSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation); ;  // creating a copy of the blockSparklesVFX
        Destroy(sparkles, 1f);
    }
}
