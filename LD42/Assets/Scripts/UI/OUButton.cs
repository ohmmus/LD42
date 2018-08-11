using UnityEngine.UI;
using UnityEngine;

public class OUButton : MonoBehaviour
{
    public void OnMouseUp()
    {
        TimeAuthority.ToggleTimeFrozen();
    }

    public void OnMouseDown()
    {
    }
}
