using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public Animator animator;

    public string triggerToPlay = "Fly";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger(triggerToPlay);
        }

    }
}
