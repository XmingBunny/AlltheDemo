using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageText
{
    static Text Text;

    public static Text messageText
    {
        get
        {
            if (Text == null)
            {
                Text = GameObject.Find("messageText").GetComponent<Text>();
            }
            return Text;
        }
        set
        {
            Text = value;
        }
    }

    public static bool SetMessage(string message)
    {
        messageText.text = message;
        return true;
    }

    public static string GetMessage()
    {
        return messageText.text;
    }
}
