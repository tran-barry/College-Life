﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour

{
    public bool hasDied;
    public int playerHealth = 3;
    public bool isTangible = true;
    public float secondsInvulnerable = 0.1f;
    private Animator anim;

    private Color originalColor;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        hasDied = false;
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;

        if (GameData.Instance.TookMelatonin)
            playerHealth = 4;
    }

    // Update is called once per frame
    void Update()
    { 
		if (transform.position.y < -20)
        {
            PlayerDies();
        }
    }

    public void PlayerDies()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Doesn't have to reset scene. Can do take damage -> invuln

        GameObject.Find("GameController").GetComponent<GameController>().WakeUp(false);
    }

    public void PlayerHit()
    {
        playerHealth--;
        HeartsController.instance.UpdateHearts(playerHealth);
        PlayerInvulnerabilityStart();
        if (playerHealth < 1)
        {
            PlayerDies();
        }
    }

    public void PlayerInvulnerabilityStart()
    {
        isTangible = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        anim.SetTrigger("GotHit");
        Invoke("ResetInvulnerability", secondsInvulnerable);
    }

    void ResetInvulnerability()
    {
        isTangible = true;
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }
}





