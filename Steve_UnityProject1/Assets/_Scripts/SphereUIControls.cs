using UnityEngine;
using System.Collections;

public class SphereUIControls : MonoBehaviour
{
    public Animator animator;

    void Start()
    {

    }

    void Update()
    {

    }

    public void PlaybackSpeed(float playbackSpeed)
    {
        animator.speed = playbackSpeed;
    }

    public void Switch()
    {
        animator.SetBool("hop", !animator.GetBool("hop"));
    }
}
