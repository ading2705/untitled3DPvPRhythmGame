using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInput : MonoBehaviour
{
    [SerializeField] private float speed;
    // Update is called once per frame
    void Update()
    {
        float currentRotation = this.gameObject.transform.rotation.z;
        if (Input.GetKey(KeyCode.Q))
        {
            currentRotation += speed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            currentRotation -= speed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Attack");
        }
        this.gameObject.transform.Rotate(new Vector3(0, 0, currentRotation) * Time.deltaTime);
    }
}
