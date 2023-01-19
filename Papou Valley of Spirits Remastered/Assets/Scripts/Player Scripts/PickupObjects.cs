using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instance.coinsPickedInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}
