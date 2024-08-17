using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public PasswordTrigger passwordTrigger;  // Reference to the PasswordTypeWriter script

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            passwordTrigger.TriggerTypingEffect();
        }
    }
}
