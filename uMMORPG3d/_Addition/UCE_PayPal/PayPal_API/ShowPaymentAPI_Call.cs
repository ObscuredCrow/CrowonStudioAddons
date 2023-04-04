// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPaymentAPI_Call : MonoBehaviour
{
    public string payID;

    public string accessToken;

    //[HideInInspector]
    public PayPalShowPaymentJsonResponse API_SuccessResponse;

    //[HideInInspector]
    public PayPalErrorJsonResponse API_ErrorResponse;

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(MakePayAPIcall());
    }

    private void handleSuccessResponse(string responseText)
    {
        //attempt to parse reponse text
        API_SuccessResponse = JsonUtility.FromJson<PayPalShowPaymentJsonResponse>(responseText);
    }

    private void handleErrorResponse(string responseText, string errorText)
    {
        //attempt to parse error response
        API_ErrorResponse = JsonUtility.FromJson<PayPalErrorJsonResponse>(responseText);
    }

    private IEnumerator MakePayAPIcall()
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();

        headers.Add("Content-Type", "application/json");
        headers.Add("Authorization", "Bearer " + accessToken);

        string baseEndpointURL = StoreProperties.INSTANCE.isUsingSandbox() ?
            "https://api.sandbox.paypal.com/v1/payments/payment/" :
            "https://api.paypal.com/v1/payments/payment/";

        string endpointURL = baseEndpointURL + payID;
#pragma warning disable
        WWW www = new WWW(endpointURL, null, headers);
#pragma warning restore

        yield return www;

        //if ok response
        if (www.error == null)
        {
            handleSuccessResponse(www.text);
        }
        else
        {
            handleErrorResponse(www.text, www.error);
        }
    }
}
