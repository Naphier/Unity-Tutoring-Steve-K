using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class SphereAnimationControls : MonoBehaviour
{
    private const string BOOLNAME = "move2";
    Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetBool(BOOLNAME, !animator.GetBool(BOOLNAME));
    }
}
