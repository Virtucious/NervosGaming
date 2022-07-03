using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Public Methods
    
    public float panSpeed = 20f;
    public float scrollSpeed = 2f;
    public Vector2 panLimit;
    public float minY;
    public float maxY;
    
    #endregion
    
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= panSpeed *Time.deltaTime;
        }
        if(Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed*100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -12f, -3f);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -56f, -47f);    

        transform.position = pos;

        

    }
}
