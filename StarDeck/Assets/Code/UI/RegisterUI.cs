using UnityEngine;
using TMPro;
//using Code.Models;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class RegisterUI : MonoBehaviour
{
    // Data fields
    [SerializeField] private TMP_InputField _usernameIF;
    [SerializeField] private TMP_InputField _nameIF;
    [SerializeField] private TMP_InputField _passwordIF;
    [SerializeField] private TMP_InputField _confirmIF;

    // Restrictions variables
    private int[] _nameLimits = {1, 30};
    private NationalityBtn _selectedNationality = new NationalityBtn();
    private int _passwordLength = 8;

    // API
    private bool _checkData = false;
    // URL del api
    private string url = "https://localhost:7098/api/Usuario";

    public void RegisterAccount ()
    {
        Usuario user = new Usuario();
        user.id_usuario = "5";
        user.nombre_usuario = "Anthony";
        user.nombre_completo = "Anthony Montero";
        user.nacionalidad = "Costa Rica";
        user.contrasena = "12345678";
        user.imagen = "imagen";
        user.estado = "activo";
        user.ranking = 20;
        user.monedas = 30;

        var body = JsonUtility.ToJson(user);

        _checkData = true;

        // Username restrictions
        if (_usernameIF.text.Length < _nameLimits[0] || _usernameIF.text.Length > _nameLimits[1])
        {
            Debug.Log("Invalid: Username");
            _checkData = false;
        }

        // Name restrictions
        if (_nameIF.text.Length < _nameLimits[0] || _nameIF.text.Length > _nameLimits[1])
        {
            Debug.Log("Invalid: Name");
            _checkData = false;
        }

        // Nationality restrictions
        if (_selectedNationality.GetNationality() == null)
        {
            Debug.Log("Invalid: Nationality not selected");
            _checkData = false;
        }

        // Password restrictions
        if (_passwordIF.text.Length != _passwordLength)
        {
            Debug.Log("Invalid: Password");
            _checkData = false;
        }

        // Confirm password restrictions
        if (_confirmIF.text.Length == 0)
        {
            Debug.Log("Invalid: Confirm password empty");
            _checkData = false;
        }
        else if (_confirmIF.text != _passwordIF.text)
        {
            Debug.Log("Invalid: Password not confirmed");
            _checkData = false;
        }

        if (_checkData)
        {
            // API call
            Debug.Log("OK");
            //StartCoroutine(GetData());
            StartCoroutine(PostData(body));
        }
    }

    public void SetNationality (NationalityBtn nationality)
    {
        if (_selectedNationality.GetNationality() == nationality.GetNationality())
        {
            nationality.Deselect();
            _selectedNationality = new NationalityBtn();
        }
        else
        {
            if (_selectedNationality.GetNationality() != null)
                _selectedNationality.Deselect();
            nationality.Select();
            _selectedNationality = nationality;
        }
    }

    IEnumerator GetData()
    {
        using(UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                string results = request.downloadHandler.text;

                Debug.Log(results);
            }
        }
    }

    IEnumerator PostData(string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            Debug.Log("Form Uploaded complete!");
        }
    }
}
