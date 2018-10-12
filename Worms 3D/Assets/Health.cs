﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Worked on by:
 * Ryan Madigan 
 * Dean Kennelly
 * Evan Barry 
 * Jack Gammon */

/*How to use this script:    
 Every object that has health has to:
 have a tag explaining what the game object is so it can
 be assigned an appropiate health value. 
 In addition it will also need the healthDriverTest script.
 This script will also destroy game objects once the health has hit 0.
 This script will assign a max health to certain game objects preventing some
 from going above a certain value.
 */

public class Health : MonoBehaviour {

    public int health;
    public int maxHealth;
    FloatingDisplay ourHealthDisplay;

    internal void Iam(WormControl wormControl)
    {
        print("Iam");
        health = 100;
        maxHealth = 200;
        ourHealthDisplay = gameObject.AddComponent<FloatingDisplay>();
        ourHealthDisplay.setDisplay(health.ToString() + " kjkluh" );
  
    }





	// Use this for initialization
	void Start () {

  



        if(gameObject.tag=="Wall")
        {
            health = 500;
        }

      
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) adjustHealth(-5);
		
	}

    public int getHealth()
    {
        return health;
    }

    public void adjustHealth(int hit)
    {
        health += hit;
        print("Damage of " + hit.ToString());

        if(health<=0)
        {
           death();
        }

        if(gameObject.tag=="Player" && health>maxHealth)
        {
            health = 200;
        }

   
        ourHealthDisplay.setDisplay(health.ToString());

    }

    void death()
    {
        Debug.Log("You dead");

        Destroy(gameObject);
    }

    internal void printHello()
    {
        print("Hello" + health.ToString() + "   " + maxHealth.ToString());
    }
}
