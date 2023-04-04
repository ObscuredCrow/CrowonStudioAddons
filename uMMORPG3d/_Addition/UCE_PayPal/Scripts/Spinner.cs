// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

public class Spinner : MonoBehaviour
{
    public Image SpinnerImage;

    // Use this for initialization
    private void Start()
    {
        SpinnerImage.fillAmount = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (SpinnerImage.fillAmount == 1f)
        {
            SpinnerImage.fillAmount = 0f;
        }

        SpinnerImage.fillAmount += Time.deltaTime;
    }
}