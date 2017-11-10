using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestSystem;

public class QuestInteractable : Interactable
{
    //Variables needed by the UIManager to display quest markers
    public GameObject questMarker;
    public Image questMarkerImage;

    public List<int> availableQuestIDs = new List<int>();
    public List<int> receivableQuestIDs = new List<int>();

    private void OnDisable()
    {
        QuestManager.instance.onQuestInteractionCallback -= UpdateQuestMarker;
    }

    private void Start()
    {            
        QuestManager.instance.onQuestInteractionCallback += UpdateQuestMarker;
        UIManager.instance.SetQuestMarker(this);
    }

    // When we interact with the quest: We receive of give back a quest
    public override void Interact()
    {
        print("Interact");
        // quest manager
        QuestManager.instance.QuestRequest(this);
        //reseting the quest marker after the interaction
        UIManager.instance.SetQuestMarker(this);

        if (QuestManager.instance.onQuestInteractionCallback != null)
        {           
            QuestManager.instance.onQuestInteractionCallback.Invoke();
        }
    }

    private void UpdateQuestMarker()
    {
        UIManager.instance.SetQuestMarker(this);
    }
}
