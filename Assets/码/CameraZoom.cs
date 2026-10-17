
using UnityEngine;

public class CameraZoom : MonoBehaviour
{   
    // Update is called once per frame
    void Update()
    {
        float Scale = -Input.mouseScrollDelta.y * 10f * Time.unscaledDeltaTime;
        transform.localScale -= new Vector3(Scale, Scale, Scale);
    }
}
