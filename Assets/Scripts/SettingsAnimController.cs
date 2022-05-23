
using UnityEngine;

public class SettingsAnimController : MonoBehaviour
{
    public Animation settingsAnim;
    public GameObject vib;
    public GameObject sound;
    private bool isSettingsOpen = false;

    public void Toggle()
    {
        if (isSettingsOpen == true)
        {

            //settingsAnim["SettingsClose"].speed = 1.0f;
            settingsAnim.Play("SettingsClose");
            isSettingsOpen = false;
            vib.SetActive(false);
            sound.SetActive(false);

        }
        else if (isSettingsOpen == false)
        {

            //settingsAnim["Settings"].speed = 1.0f;
            settingsAnim.Play("Settings");
            isSettingsOpen = true;
            vib.SetActive(true);
            sound.SetActive(true);
        }

    }
}
