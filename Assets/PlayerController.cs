using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    float targetX = 0;
    public float speed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Vector3 pos = ray.origin;
        targetX = Mathf.Clamp(pos.x, -5.82f, 5.82f);
        int c = 1;
        if (transform.position.x > targetX)
        {
            c = -1;
        }

        this.transform.position = new Vector3(transform.position.x + c * speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
