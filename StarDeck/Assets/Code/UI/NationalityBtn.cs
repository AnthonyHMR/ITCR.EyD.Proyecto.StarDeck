using UnityEngine;
using UnityEngine.UI;

public class NationalityBtn : MonoBehaviour
{
    [SerializeField] string _nationality;
    [SerializeField] Image _shadow;
    [SerializeField] RegisterUI _registerUi;
    private Color _selectedColor = new Color(70f/255f, 187f/255f, 221f/255f, 1f);
    private Color _defaultColor = new Color(160f/255f, 48f/255f, 105f/255f, 1f);
    private bool _isSelected;

    public void Select ()
    {
        // Select this nationality
        _isSelected = true;
        SetColor();
    }

    public void Deselect ()
    {
        // Deselect this nationality
        _isSelected = false;
        SetColor();
    }

    public void SetColor ()
    {
        if (_isSelected)
            _shadow.color = _selectedColor;
        else 
            _shadow.color = _defaultColor;
    }

    public string GetNationality ()
    {
        return _nationality;
    }
}
