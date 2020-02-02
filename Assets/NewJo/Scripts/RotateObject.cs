using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    Vector3 mPrevPosition = Vector3.zero;
    Vector3 mCurPosition = Vector3.zero;

    public GameObject self;

    private float zoom = 80f;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0))
        {
            mCurPosition = Input.mousePosition - mPrevPosition;

            if (Vector3.Dot(transform.up, Vector3.up) >=0)  //it stops right and left from inverting if object rotated upsidedown
            {
                self.transform.Rotate(transform.up, -Vector3.Dot(mCurPosition, Camera.main.transform.right), Space.World);  //rotates around Y axis (right/left); Space.World - Rotate object in world space
            }

            else
            {
                self.transform.Rotate(transform.up, Vector3.Dot(mCurPosition, Camera.main.transform.right), Space.World);  //rotates around Y axis (right/left)
            }

            self.transform.Rotate(Camera.main.transform.right, Vector3.Dot(mCurPosition, Camera.main.transform.up), Space.World);  //rotates around up/down
        }

        mPrevPosition = Input.mousePosition;
    }
}
