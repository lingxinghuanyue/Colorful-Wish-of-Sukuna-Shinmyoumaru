
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class PersonaEditor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Persona persona;
    public bool Hover;
    public bool Mouseuse;
    public GameObject SolutionSet;
    public GameObject Wish;
    public TMP_InputField Text0;
    public TMP_InputField Text1;
    public GameObject NewWish;
    public Toggle toggle;
    public GameObject WishPanel;
    public GameObject personaPanel;
    public ChoosePersona ChoosePersona;
    private void OnEnable()
    {
        transform.localPosition = new Vector3(3920,0,0);      
        for (int i = 0; i < persona.Wish.Count; i++)
        {
            GameObject wish = Instantiate(Wish, SolutionSet.transform);
            wish.GetComponent<EditWish>().persona = persona;
            wish.GetComponent<Image>().color = Random.ColorHSV(0, 1, 0, 1, 0.5f, 1, 1, 1);           
        }
        Sync();
        ChoosePersona.persona = persona;
        ChoosePersona.Choose(persona.PersonaID);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void newWish()
    {
        persona.Wish.Add(1000);
        persona.text.Add(" ");
        persona.ImpactEvent.Add(0);
        persona.PositiveImpact.Add(false);
        persona.ImpactEventNum.Add(0);
        GameObject wish = Instantiate(Wish, SolutionSet.transform);
        wish.GetComponent<EditWish>().persona = persona;
        wish.GetComponent<Image>().color = Random.ColorHSV(0, 1, 0, 1, 0.5f, 1, 1, 1);
        Sync();
    }
    public void text0(string i)
    {
        if (i != "") persona.text[0] = i;
        Sync();
    }
    public void text1(string i)
    {
        if (i != "") persona.text[1] = i;
        Sync();
    }
    public void Sync()
    {
        Text0.text = persona.text[0];
        Text1.text = persona.text[1];
        NewWish.transform.SetAsLastSibling();
    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition += new Vector3(-3920f * 3f * Time.unscaledDeltaTime, 0, 0);
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, 1920, 3920), transform.localPosition.y, transform.localPosition.z);
        WishPanel.SetActive(toggle.isOn);
        personaPanel.SetActive(!toggle.isOn);
        if (Input.GetMouseButtonUp(0) && Mouseuse)
        {
            Mouseuse = false;
            for (int i = 0; i < SolutionSet.transform.childCount-1; i++)
            {
                Destroy(SolutionSet.transform.GetChild(i).gameObject);
            }
            gameObject.SetActive(false);            
        }
            
        
        if (Input.GetMouseButtonDown(0) && !Hover)
        {
            Mouseuse = true;
        }
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
