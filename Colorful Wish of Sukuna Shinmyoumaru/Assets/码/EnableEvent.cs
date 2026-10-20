
using UnityEngine;
using UnityEngine.EventSystems;

public class EnableEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool Hover;

    private void OnEnable()
    {
        transform.localScale = new Vector3(1, 0, 1);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0, 20f * Time.unscaledDeltaTime, 0);
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 0, 1), Mathf.Clamp(transform.localScale.y, 0, 1), Mathf.Clamp(transform.localScale.z, 0, 1));
        if (!Hover && Input.GetMouseButton(0)) gameObject.SetActive(false);
    }
    public void Choose(string i)
    {
        transform.parent.GetComponent<Entity>().TriggerEvent = int.Parse(i);
        if (transform.parent.parent.parent.parent.parent.GetComponent<LevelEditor>().Event < int.Parse(i)) transform.parent.parent.parent.parent.parent.GetComponent<LevelEditor>().Event = int.Parse(i);
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