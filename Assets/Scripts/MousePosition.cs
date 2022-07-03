using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    #region Public Variables

    public float speed = 10f;
    public Vector3 targetPos;
    public bool isMoving;
    const int MOUSE = 0;

    #endregion

    #region Private functions
    
    void Start()
    {
        targetPos = transform.position;
        isMoving = false;
    }

    
    void Update()
    {
        if (Input.GetMouseButton(MOUSE))
        {
           
        }
    }

    void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
        {
            targetPos = ray.GetPoint(point);
        }
        isMoving = true;
    }

    void MoveObject()
    {
        transform.LookAt(targetPos);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (transform.position == targetPos)
        {
            isMoving = false;
        }

    }

    #endregion
}
