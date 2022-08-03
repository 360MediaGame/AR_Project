using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject _hint;

    private GameObject NT;
    private RectTransform NT_rt;
    private TextMeshProUGUI _result;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        NT = Instantiate(_hint, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        NT_rt = NT.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        NT_rt.localPosition = new Vector3(0, 0, 0);
        _result = NT.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        _result.text = "Ã£Àº ÈùÆ® : ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add_Hint(string _text)
    {
        _result.text += _text;
    }
}
