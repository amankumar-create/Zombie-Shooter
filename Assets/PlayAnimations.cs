using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{
    public void PlayMoveAnimation(Vector2 move)
    {
        if(move!=new Vector2(0, 0))
        GetComponent<Animator>().SetBool("move", true);
        else
        {
            GetComponent<Animator>().SetBool("move", false);

        }
    }
    public void PlaySprintAnimation(bool isSprinting)
    {
        GetComponent<Animator>().SetBool("sprint", isSprinting);
    }

     
}
