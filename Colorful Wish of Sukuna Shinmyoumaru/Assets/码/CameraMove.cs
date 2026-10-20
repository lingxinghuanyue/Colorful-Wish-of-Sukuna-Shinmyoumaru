
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Scene;    
    public bool Enable;
    public bool X;
    public bool Y;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Enable =true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Enable =false;
    }
    // Start is called before the first frame update
    void Update()
    {
        if (Enable) Scene.transform.position += new Vector3(X? (Y?1000:-1000) * Time.unscaledDeltaTime : 0, !X ? (Y ? 1000 : -1000) * Time.unscaledDeltaTime : 0, 0);
    }
   
}