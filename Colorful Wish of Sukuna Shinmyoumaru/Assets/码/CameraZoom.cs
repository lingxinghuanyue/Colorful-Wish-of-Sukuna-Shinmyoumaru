
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1); ;
    }
    void Update()
    {
        if (transform.parent.GetComponent<LevelEditor>() != null && transform.parent.GetComponent<LevelEditor>().PersonaEditor.activeSelf) return;      
        float Scale = -Input.mouseScrollDelta.y * 10f * Time.unscaledDeltaTime;
        transform.localScale -= new Vector3(Scale, Scale, Scale);
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 0.5f, 3f), Mathf.Clamp(transform.localScale.y, 0.5f, 3f), Mathf.Clamp(transform.localScale.z, 0.5f, 3f));
    }
}
