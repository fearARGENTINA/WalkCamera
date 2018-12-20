using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSWalk : MonoBehaviour
{

    private float playerVelocity = 0.1f;
    private float playerJumpforce = 20.0f;
    private Rigidbody mRigidbody = null;
    private Collider mCollider = null;
    private float distToGround;
    // Use this for initialization
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        mCollider = GetComponent<Collider>();

        distToGround = mCollider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * playerVelocity;
        float zAxisValue = Input.GetAxis("Vertical") * playerVelocity;

        transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));

        if (mRigidbody != null && mCollider != null && IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            mRigidbody.AddForce(Vector3.up * playerJumpforce);
        }
    }

    private bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
