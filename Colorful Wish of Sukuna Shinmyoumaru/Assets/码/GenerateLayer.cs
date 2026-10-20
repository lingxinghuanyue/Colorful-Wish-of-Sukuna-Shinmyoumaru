
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class GenerateLayer : MonoBehaviour
{
    public int X;
    public int Y;
    public GameObject Layer;
    public GameObject Row;
    public GameObject Plaid;
    public TMP_InputField ImpactEventX;
    public TMP_InputField ImpactEventY;
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ModifyX(string x)
    {
        if (x != "") X = int.Parse(x);
        else
        {
            X = 1;            
            ImpactEventX.text = 1.ToString();
        }
        Generate();
    }
    public void ModifyY(string y)
    {
        if (y != "") Y = int.Parse(y);
        else
        {
            Y = 1;
            ImpactEventY.text = 1.ToString();
        }
        Generate();
    }
    public void Generate()
    {
        if (Layer.transform.childCount > Y)
        {
            for (int i = Y; i < Layer.transform.childCount; i++)          
            {
                Destroy(Layer.transform.GetChild(i).gameObject);
            }
        }
        if (Layer.transform.childCount < Y)
        {
            for (int i = Layer.transform.childCount; i < Y; i++)
            {
                Instantiate(Row,Layer.transform);
            }
        }
        for (int i = 0; i < Layer.transform.childCount; i++)
        {
            if (Layer.transform.GetChild(i).childCount > X)
            {
                for (int j = X; j < Layer.transform.GetChild(i).childCount; j++)
                {
                    Destroy(Layer.transform.GetChild(i).GetChild(j).gameObject);
                }
            }
            if (Layer.transform.GetChild(i).childCount < X)
            {
                for (int j = Layer.transform.GetChild(i).childCount; j < X; j++)
                {
                    Instantiate(Plaid, Layer.transform.GetChild(i));
                }
            }
        }        
        Layer.GetComponent<RectTransform>().sizeDelta = new Vector2(1,1);
    }
}
