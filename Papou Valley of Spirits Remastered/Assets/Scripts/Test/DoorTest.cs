using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTest : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    GameObject DoorType;

    int stateOfDoor = 1;

    void Start()
    {
        anim = GetComponent<Animator>();

        if(DoorType.name == "EntryDoor")
        {
            
            OpenDoor();
            anim.SetFloat("DoorState", 3);
        }
        if(DoorType.name == "ExitDoor")
        {
            LockDoor();
        }
    }

    void LockDoor()
    {
        if(DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorState", 1);
            stateOfDoor = 1;
        }
    }

    void UnlockDoor()
    {
        if(DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorState", 2);
            stateOfDoor = 2;
        }
    }

    public void OpenDoor()
    {
        if(DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorState", 3);
            stateOfDoor = 3;
        }
    }

    public void SetDoorState(int state)
    {
        if(state == 1 && DoorType.name == "ExitDoor")
        {
            LockDoor();
        }
        if(state == 2 && DoorType.name == "ExitDoor")
        {
            UnlockDoor();
        }
        if(state == 3 && DoorType.name == "ExitDoor")
        {
            OpenDoor();
        }
    }

    public int GetDoorState()
    {
        return stateOfDoor;
    }
}
