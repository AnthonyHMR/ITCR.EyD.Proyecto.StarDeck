using UnityEngine;
using TMPro;

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

    public void RegisterAccount ()
    {
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
}
