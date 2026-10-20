using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePersona : MonoBehaviour
{
    public Persona persona;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Choose(int i)
    {
        transform.GetChild(ID).GetChild(0).gameObject.SetActive(false);
        ID = i;
        persona.PersonaID = ID;
        persona.UpdateSprite();
        transform.GetChild(ID).GetChild(0).gameObject.SetActive(true);
    }
}
