
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Persona : Entity,IPointerEnterHandler, IPointerExitHandler
{
    public Sprite[] Sprite0;
    public Sprite[] Sprite1;
    public Sprite[] Sprite2;
    public GameObject TextShow;
    List<int> Connect;
    public int[] Interface = new int[4];
    bool ShowText;
    public int Done;
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowText=true;        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShowText = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Face == 0) GetComponent<Image>().sprite = Sprite0[PersonaID];
        if (Face == 1) GetComponent<Image>().sprite = Sprite1[PersonaID];
        if (Face == 2) GetComponent<Image>().sprite = Sprite2[PersonaID];
        TextShow.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text[textID];
    }

    // Update is called once per frame
    void Update()
    {       
        if (ShowText) TextShow.GetComponent<CanvasGroup>().alpha += 5*Time.unscaledDeltaTime;
        else TextShow.GetComponent<CanvasGroup>().alpha -= 5*Time.unscaledDeltaTime;        
    }
    public void Achieve()
    {
        int wish = 0;
        Connect =new List<int>();
        for (int i = 0; i < Interface.Length; i++)Connect.Add(Interface[i]);
        Connect.Sort();
        for (int i = 0; i < Connect.Count; i++)
        {
            wish += (int)(Connect[i]* Mathf.Pow(10, i));
        }
        print(wish);
        for (int i = 0; i < Wish.Length; i++)
        {
            if (wish == Wish[i])
            {
                Done = 1; break;
            }
            if (i == Wish.Length - 1) Done = -1;
        }
        if (Done>0)
        {
            textID = 1;
            Face = 1;
        }
        if (Done < 0)
        {
            textID = 2;
            Face = 2;
        }
        if (Face == 0) GetComponent<Image>().sprite = Sprite0[PersonaID];
        if (Face == 1) GetComponent<Image>().sprite = Sprite1[PersonaID];
        if (Face == 2) GetComponent<Image>().sprite = Sprite2[PersonaID];
        TextShow.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text[textID];
    }
}
