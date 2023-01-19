using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : MonoBehaviour
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    //public Inventory playerInventory;
    private SpriteRenderer doorSprite;
    private BoxCollider2D physicsCollider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    public void Open()
    {

    }

    public void Close()
    {

    }
}
