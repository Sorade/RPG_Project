using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class QuestObject : Interactable
    {
        public List<int> availableQuestIDs = new List<int>();
        public List<int> receivableQuestIDs = new List<int>();

        // When we interact with the quest: We receive of give back a quest
        public override void Interact()
        {
            print("Interact");
            // quest manager
            QuestManager.instance.QuestRequest(this);
        }
    }
}
