using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class DialogPhase : MonoBehaviour
    {
        public int phaseID;
        public string nameOfMSB;
        [TextArea(1, 10)]
        public string mainText;

        [Header("Replies")]
        [HideInInspector]
        public Reply[] replies;
        [HideInInspector]
        public Animator animator;    // Reference to the Animator component on this gameobject.
        [HideInInspector]
        public DialogStateBehaviour dialogState;    // Reference to a single StateMachineBehaviour.
        [HideInInspector]
        public Dialog dialog;


        void Awake()
        {
            // Find a reference to the Animator component in Awake since it exists in the scene.
            animator = GetComponentInParent<Animator>();
            replies = GetComponentsInChildren<Reply>();
        }

        public void SetActiveReplies()
        {
            for (int i = 0; i < UIManager.instance.replies.Length; i++)
            {
                //by default sets the reply button text to disabled
                UIManager.instance.replies[i].enabled = false;
                if (i < replies.Length)
                {
                    replies[i].order = i; //sets the order of the reply to its default order
                    if (replies[i].CheckConditions())
                    {
                        // Checks if the previous reply has failed, if it has it displays the text in it,
                        // and changes the order of the reply to the previous reply index          
                        if (i > 1 && !UIManager.instance.replies[i - 1].enabled)
                        {
                            UIManager.instance.replies[i - 1].enabled = true;
                            UIManager.instance.replies[i - 1].text = replies[i].text;
                            replies[i].order = i - 1;
                        }
                        else
                        {
                            UIManager.instance.replies[i].enabled = true;
                            UIManager.instance.replies[i].text = replies[i].text;
                        }
                    }
                    else
                    {
                        UIManager.instance.replies[i].enabled = false;
                        UIManager.instance.replies[i].text = "";
                    }
                }
                else
                {
                    UIManager.instance.replies[i].enabled = false;
                    UIManager.instance.replies[i].text = "";
                }
            }
        }
    }
}
