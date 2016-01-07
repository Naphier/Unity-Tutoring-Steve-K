using UnityEngine;
using System.Collections;


public class SphereAnimationControls : MonoBehaviour
{
    public Animator animator;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("hop", !animator.GetBool("hop"));
        }
        
    }

    public void Switch()
    {
        animator.SetBool("hop", !animator.GetBool("hop"));
    }

    public void PlaybackSpeed(float playbackSpeed)
    {
        animator.speed = playbackSpeed;
    }
}
