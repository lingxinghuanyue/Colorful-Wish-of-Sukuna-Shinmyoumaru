
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditWish : MonoBehaviour
{
    public Persona persona;
    public int WishID;
    public GameObject Wish;
    public List<int> WishisOn;
    public TMP_InputField ImpactEvent;
    public Toggle PositiveImpact;
    public TMP_InputField ImpactEventNum;
    public TMP_InputField Text;
    public TextMeshProUGUI textMeshProUGUI;
    public Button delete;
    // Start is called before the first frame update
    void Start()
    {
        Sync();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetChild(WishID).gameObject != gameObject) Sync();
        delete.interactable = transform.parent.childCount > 2;
    }
    public void Delete()
    {
        persona.Wish.Remove(persona.Wish[WishID]);
        persona.text.Remove(persona.text[WishID]);
        persona.ImpactEvent.Remove(persona.ImpactEvent[WishID]);
        persona.PositiveImpact.Remove(persona.PositiveImpact[WishID]);
        persona.ImpactEventNum.Remove(persona.ImpactEventNum[WishID]);
        Destroy(gameObject);
    }
    public void positiveImpact()
    {
        PositiveImpact.isOn = !PositiveImpact.isOn;
        persona.PositiveImpact[WishID] = PositiveImpact.isOn;
        Sync();
    }
    public void Edit(int i)
    {
        Wish.transform.GetChild(i - 1).GetComponent<Toggle>().isOn = !Wish.transform.GetChild(i - 1).GetComponent<Toggle>().isOn;       
        if (Wish.transform.GetChild(i - 1).GetComponent<Toggle>().isOn)
        {
            WishisOn.Add(i);
        }
        else if(WishisOn.Count>1)
        {
            WishisOn.Remove(i);
        }
        if (WishisOn.Count > 4)
        {            
            WishisOn.Remove(WishisOn[0]);
        }   
        int wish = 0;
        List<int> Connect = new List<int>();
        for (int j = 0; j < 4; j++)
        {
            Connect.Add(0);
        }
        for (int j = 0; j < WishisOn.Count; j++)
        {
            Connect[j] = WishisOn[j];
        }          
        Connect.Sort();
        for (int j = 1; j < Connect.Count; j++)
        {
            if (Connect[j] != 0 && Connect[j] == Connect[j - 1])
            {
                Connect[j] = 0;
                Connect.Sort();
                j -= 1;
            }
        }
        for (int j = 0; j < Connect.Count; j++)
        {
            wish += (int)(Connect[j] * Mathf.Pow(10, j));
        }
        persona.Wish[WishID] = wish;
        Sync();
    }
    public void text(string i)
    {
        if (i != "") persona.text[WishID+2] = i;        
        Sync();
    }
    public void impactEvent(string i)
    {
        if(i!="") persona.ImpactEvent[WishID] = int.Parse(i);    
        else persona.ImpactEvent[WishID] = 0;
        Sync();
    }
    public void impactEventNum(string i)
    {
        if (i != "") persona.ImpactEventNum[WishID] = int.Parse(i);
        else persona.ImpactEventNum[WishID] = 0;
        Sync();
    }
    public void Sync()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).gameObject == gameObject)
            {
                WishID = i;
                break;
            }
        }
        textMeshProUGUI.text = "½â" + WishID;
        ImpactEvent.text = persona.ImpactEvent[WishID].ToString();
        PositiveImpact.isOn = persona.PositiveImpact[WishID];
        ImpactEventNum.text = persona.ImpactEventNum[WishID].ToString();
        Text.text = persona.text[WishID+2];
        for (int i = 0; i < Wish.transform.childCount; i++)
        {
            Wish.transform.GetChild(i).GetComponent<Toggle>().isOn = false;
        }       
        string wish = persona.Wish[WishID].ToString();
        for (int i = 0; i < 4; i++)
        {           
            if (int.Parse(wish[i].ToString()) != 0)
            {
                Wish.transform.GetChild(int.Parse(wish[i].ToString()) - 1).GetComponent<Toggle>().isOn = true;
                if (!WishisOn.Contains(int.Parse(wish[i].ToString()))) WishisOn.Add(int.Parse(wish[i].ToString()));
            }
        }
    }
}
