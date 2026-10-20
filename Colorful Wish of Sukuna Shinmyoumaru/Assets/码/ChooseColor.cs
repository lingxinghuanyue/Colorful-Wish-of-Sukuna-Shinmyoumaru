using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{  
    bool Hover;

    private void OnEnable()
    {
        transform.localScale = new Vector3(0, 1, 1);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(20f * Time.unscaledDeltaTime, 0, 0);
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 0, 1), Mathf.Clamp(transform.localScale.y, 0, 1), Mathf.Clamp(transform.localScale.z, 0, 1));
        if (!Hover && Input.GetMouseButton(0)) gameObject.SetActive(false);
    }
    public void Choose(int i)
    {
        transform.parent.GetComponent<Entity>().Color = i;
        if (transform.parent.GetComponent<MiracleMallet>()) transform.parent.GetComponent<MiracleMallet>().Start();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hover = false;
    }
}