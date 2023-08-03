using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSound;

    private void OnTriggerStay(Collider target)
    {
        if(target.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerScript player = target.GetComponent<PlayerScript>();//we can get player details from target
                

                if (player != null)
                {
                    player.hasCoin = true;
                    AudioSource.PlayClipAtPoint(_coinSound, transform.position, 0.5f);
                    
                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                    if (uiManager != null)
                    {
                        uiManager.UpdateCoin();
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
