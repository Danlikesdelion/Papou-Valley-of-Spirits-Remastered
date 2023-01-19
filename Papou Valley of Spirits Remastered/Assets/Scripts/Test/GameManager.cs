using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private bool m_ReadyForInput;
    public PlayerMovement m_Player;

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if(moveInput.sqrMagnitude > 0.5)
        {
            if(m_ReadyForInput)
            {
                m_ReadyForInput = false;
                //m_Player.MoveCharacter();
            }
        }
        else
        {
            m_ReadyForInput = true;
        }
    }

}
