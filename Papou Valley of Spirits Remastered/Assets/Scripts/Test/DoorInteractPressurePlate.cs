using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractPressurePlate : MonoBehaviour
{

    [SerializeField]
    GameObject switchOn;

    [SerializeField]
    GameObject switchOff;

    public DoorAnimated door;
    public float timer;

    public bool isOn = false;

    private void Start()
    {
        //Set the switch to off
        gameObject.GetComponent<SpriteRenderer>().sprite = switchOff.GetComponent<SpriteRenderer>().sprite;

    }


    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                door.CloseDoor();
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = switchOn.GetComponent<SpriteRenderer>().sprite;

        isOn = true;

        
        if(collider.GetComponent<PlayerMovement>() != null || collider.GetComponent<log>() != null || collider.GetComponent<Box>() != null)
        {
            door.OpenDoor();
            
        }
        

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = switchOff.GetComponent<SpriteRenderer>().sprite;

        isOn = false;

        if(isOn == false)
        {
            door.CloseDoor();
        }
    }


}
