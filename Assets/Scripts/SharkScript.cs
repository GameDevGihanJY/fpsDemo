using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    /*  check for collision
        check for player
        check for E key
        check if player has a coin
    
        if
            remove the coin from the player
            update inventory display
            enable the weapon
            play win sound
        else
            print "Go away"
    */

    [SerializeField]private Collider sharkCollider;

    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        sharkCollider = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider target)
    {
        if(target.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                PlayerScript player = target.GetComponent<PlayerScript>();
                 
                if(player != null)
                {
                    if(player.hasCoin == true)
                    {
                        player.hasCoin = false;

                        UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                        if (uiManager != null)
                        {
                            uiManager.RemoveCoin();
                        }

                        _audioSource.Play();
                    }
                    else
                    {
                        print("Go away...!!");
                    }
                }
            }
        }
    }
}
