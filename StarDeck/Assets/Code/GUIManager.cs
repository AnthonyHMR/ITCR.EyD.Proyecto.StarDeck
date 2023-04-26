using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    [SerializeField] public GameObject _register;
    [SerializeField] public GameObject _createCard;
    [SerializeField] public TMP_InputField username;
    [SerializeField] public TMP_InputField name;

    public void SwitchScreen ()
    {
        if (_register.activeSelf)
        {
            _register.SetActive(false);
            _createCard.SetActive(true);
        }
        else 
        {
            _createCard.SetActive(false);
            _register.SetActive(true);
        }
    }

    public void PrintUser ()
    {
        Debug.Log(GetInfo());
    }

    public string GetInfo () 
    {
        string output = "{user: "+ username.text + ", name: " + name.text + "}";
        return output;
    }
}
