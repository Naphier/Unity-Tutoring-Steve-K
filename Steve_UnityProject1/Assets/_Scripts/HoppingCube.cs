using UnityEngine;
using System.Collections;

public class HoppingCube : MonoBehaviour
{
    public float force = 100f;
    public float rotationSpeed = 0.10f;
    public float moveSpeed = 0.01f;
    Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        if(_rigidbody == null)
        {
            Debug.LogError("Rigidbody not found");
            this.enabled = false;
        }

        StartCoroutine(HopCoroutine());
    }

    void OnGUI()
    {
        //GUI.Label("")
    }

    IEnumerator HopCoroutine()
    {
        while (true)
        {
            _rigidbody.AddForce(force * Vector3.up);
            yield return new WaitForSeconds(1f);
        }
    }
}
