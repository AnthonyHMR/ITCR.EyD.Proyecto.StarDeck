using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    // Data fields
    [SerializeField] private TMP_InputField _usernameIF;
    [SerializeField] private TMP_InputField _passwordIF;
    [SerializeField] private UIManager _uiManager;

    // Restrictions variables
    private int[] _nameLimits = {1, 30};
    private int _passwordLength = 8;

    // API
    private bool _checkData = false;

    public void LoginUser ()
    {
        _checkData = true;

        // Username restrictions
        if (_usernameIF.text.Length < _nameLimits[0] || _usernameIF.text.Length > _nameLimits[1])
        {
            Debug.Log("Invalid: Username");
            _checkData = false;
        }
        // Password restrictions
        if (_passwordIF.text.Length != _passwordLength)
        {
            Debug.Log("Invalid: Password");
            _checkData = false;
        }

        if (_checkData)
        {
            // API call
            Debug.Log("OK");

            _uiManager.SwitchTo(2);
        }
    }
}
