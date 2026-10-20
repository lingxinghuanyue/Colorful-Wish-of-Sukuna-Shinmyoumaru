
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Persona : Entity,IPointerEnterHandler, IPointerExitHandler
{
    public PlayerControl playerControl;
    public LevelEditor levelEditor;
    public Sprite[] Sprite0;
    public Sprite[] Sprite1;
    public Sprite[] Sprite2;
    public GameObject TextShow;
    List<int> Connect;
    public int[] Interface = new int[4];
    public Line[] Source = new Line[4];
    bool ShowText;
    public int Done;   
    public int wish = 0;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (playerControl != null)
        {
            ShowText = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (playerControl != null)
        {
            ShowText = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (playerControl != null) return;
        if (levelEditor == null)
        {
            levelEditor = transform.parent.parent.parent.parent.GetComponent<LevelEditor>();
            if (levelEditor != null)
            {
                pos = transform.parent.GetComponent<Plaid>().pos;
                levelEditor.EntityList.Add(this);
            }
        }
        if (levelEditor == null) playerControl = transform.parent.parent.parent.parent.GetComponent<PlayerControl>();
        if (playerControl != null)
        {           
            TextShow = transform.parent.GetChild(0).gameObject;
            TextShow.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text[textID];            
            playerControl.EventSource.Add(this);
        }
        UpdateSprite();
    }  
    // Update is called once per frame
    public void UpdateSprite()
    {
        if (Face == 0) GetComponent<Image>().sprite = Sprite0[PersonaID];
        if (Face == 1) GetComponent<Image>().sprite = Sprite1[PersonaID];
        if (Face == 2) GetComponent<Image>().sprite = Sprite2[PersonaID];
    }
    void Update()
    {
        if (playerControl != null)
        {
            if (TriggerEvent != 0 && !playerControl.Event[TriggerEvent])
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.25f);
                return;
            }
            else
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            }
            if (ShowText) TextShow.GetComponent<CanvasGroup>().alpha += 5 * Time.unscaledDeltaTime;
            else TextShow.GetComponent<CanvasGroup>().alpha -= 5 * Time.unscaledDeltaTime;
        }
        if (levelEditor != null)
        {
            if (TriggerEvent != 0)
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.25f);
                return;
            }
            else
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            }
        }
    }
    public void Achieve()
    {
        if (playerControl != null)
        {
            if (TriggerEvent != 0 && !playerControl.Event[TriggerEvent]) return;
            
            if (Source[0] == null || Source[0].Interface[1] != gameObject) Interface[0] = 0;
            if (Source[1] == null || Source[1].Interface[0] != gameObject) Interface[1] = 0;           
            if (Source[2] == null || Source[2].Interface[3] != gameObject) Interface[2] = 0;
            if (Source[3] == null || Source[3].Interface[2] != gameObject) Interface[3] = 0;
            wish = 0;
            Connect = new List<int>();
            for (int i = 0; i < Interface.Length; i++)
            {                                
                Connect.Add(Interface[i]);
            }
            Connect.Sort();
            for (int i = 1; i < Connect.Count; i++)
            {
                if (Connect[i] != 0 && Connect[i] == Connect[i - 1])
                {
                    Connect[i] = 0;
                    Connect.Sort();
                    i -= 1;
                }
            }
            for (int i = 0; i < Connect.Count; i++)
            {
                wish += (int)(Connect[i] * Mathf.Pow(10, i));
            }
            if (wish!=0)
            {
                for (int i = 0; i < Wish.Count; i++)
                {
                    if (wish == Wish[i])
                    {
                        Done = i+2;
                        textID = i+2;
                        break;
                    }
                    if (i == Wish.Count - 1) Done = -1;
                }
            }
            else
            {
                Done = 0;
                textID = 0;
                Face = 0;
            }
            if (Done > 0)
            {                
                Face = 1;
            }
            if (Done < 0)
            {
                textID = 1;
                Face = 2;
            }
            if (Face == 0) GetComponent<Image>().sprite = Sprite0[PersonaID];
            if (Face == 1) GetComponent<Image>().sprite = Sprite1[PersonaID];
            if (Face == 2) GetComponent<Image>().sprite = Sprite2[PersonaID];
            TextShow.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text[textID];
            playerControl.EventUpdate();
        }
    }
    public void Editor()
    {
        if (levelEditor != null)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            levelEditor.PersonaEditor.GetComponent<PersonaEditor>().persona = this;
            levelEditor.PersonaEditor.SetActive(true);           
        }
    }
}
