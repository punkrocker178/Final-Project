using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 20f;
    public float scrollSpeed = 5;
    public float minY = 10f;
    public float maxY = 80f;
    public float minSpan= -40f;
    public float maxSpan = 60f;
    private bool toggleMovement = true;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            toggleMovement = !toggleMovement;
        }

        if (!toggleMovement)
        {
            return;
        }

        if (Input.GetKey("w") || (Input.mousePosition.y >= Screen.height -panBorderThickness))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            float forward = Mathf.Clamp(transform.position.z, minSpan, maxSpan);
            transform.position = new Vector3(transform.position.x, transform.position.y, forward);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            float backward = Mathf.Clamp(transform.position.z, minSpan, maxSpan);
            transform.position = new Vector3(transform.position.x, transform.position.y, backward);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {

            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            float left = Mathf.Clamp(transform.position.x, minSpan, maxSpan);
            transform.position = new Vector3(left, transform.position.y, transform.position.z);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            float right = Mathf.Clamp(transform.position.x, minSpan, maxSpan);
            transform.position = new Vector3(right, transform.position.y, transform.position.z);
            
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000  * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
