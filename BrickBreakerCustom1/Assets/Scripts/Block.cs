using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached Reveracne

    Level level;

    //state variables
    [SerializeField] int timesHit; // todo only serialized for debug
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
        
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {

            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("block sprite is missing fomr a array");
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1 ;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else 
        {
            ShowNextHitSprites();
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDeestroyed();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject Sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(Sparkles, 1f);
    }
    

}
