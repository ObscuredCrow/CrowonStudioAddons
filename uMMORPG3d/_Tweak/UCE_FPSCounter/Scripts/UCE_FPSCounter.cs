// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class UCE_FPSCounter : MonoBehaviour
{
    public Text fpsText;

    public float goodThreshold = 90f;
    public float okayThreshold = 60f;

    public Color goodColor = Color.green;
    public Color okayColor = Color.yellow;
    public Color badColor = Color.red;

    protected int fps;

    private float resetTimer = 0.5f;
    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > resetTimer)
        {
            fps = (int)(1f / Time.unscaledDeltaTime);
            
            // change color based on status
            if (fps >= goodThreshold)
                fpsText.color = goodColor;
            else if (fps >= okayThreshold)
                fpsText.color = okayColor;
            else
                fpsText.color = badColor;

            // show latency in milliseconds
            fpsText.text = fps.ToString() + "fps";

            timer = 0;
        }
    }
}