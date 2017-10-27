using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideBox : MonoBehaviour {

    private float initialSize;
    private Rigidbody rb;
    public float vitesse { get; set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSize = 9;
        SetScale(initialSize);
    }

    public void SetScale(float f)
    {
        gameObject.transform.localScale = new Vector3(f, f, f);
    }

    public void ChangeScale(float f)
    {
        Vector3 v = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(v.x * f, v.y*f, v.z * f);
    }

    public void LimitSpeed()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, vitesse);
    }

    public void MoveCollideBox(Vector2 v2)
    {
        rb.AddForce(new Vector3(v2.x, 0, v2.y));
    }

    public Vector2 GetColliderPosition()
    {
        return new Vector2(transform.position.x, transform.position.z);
    }

    public float GetColliderScale()
    {
        return transform.localScale.x;
    }

    public void ResetThis()
    {
        SetScale(initialSize);
        rb.velocity = Vector3.zero;
        gameObject.transform.position = Vector3.zero;
    }
}
