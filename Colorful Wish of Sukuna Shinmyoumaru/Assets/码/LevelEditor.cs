
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    public int Event;
    public GameObject PersonaEditor;
    public GameObject CameraMove;
    public List<Entity> EntityList;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraMove.SetActive(!PersonaEditor.activeSelf);
        for (int i = 0; i < EntityList.Count; i++)
        {
            if (EntityList[i] == null) EntityList.Remove(EntityList[i]);
        }
    }
    [System.Serializable]

    public class LevelData
    {
        [System.Serializable]
        public class GenerateData
        {
            public Vector2 XY;
            public int TriggerEvent;
            public bool Reversible;
        }        
        public List<GenerateData> generateData;
        public List<Entity> EntityList;
    }
}
