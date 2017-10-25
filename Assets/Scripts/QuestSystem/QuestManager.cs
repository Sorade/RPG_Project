using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

namespace QuestSystem
{
    public class QuestManager : MonoBehaviour
    {

        public static QuestManager instance;

        public List<Quest> questList = new List<Quest>(); // Master quest list where all quests are located
        public List<Quest> currentQuestList = new List<Quest>(); // Master quest list where all quests are located

        private void Awake()
        {
            MakeSingleton();
        }

        void MakeSingleton()
        {
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);
            //makes instance of singleton persitent through scenes
            DontDestroyOnLoad(gameObject);
        }

        //REQUEST QUEST
        public void QuestRequest(QuestObject questObject)
        {
            //CHECKING FOR AVAILABLE QUEST
            if (questObject.availableQuestIDs.Count > 0)
            {
                for (int i = 0; i < questList.Count; i++)
                {
                    for (int j = 0; j < questObject.availableQuestIDs.Count; j++)
                    {
                        if (questList[i].id == questObject.availableQuestIDs[j] && questList[i].progress == QuestProgress.AVAILABLE)
                        {
                            Debug.Log("NPC Given Quest ID: " + questObject.availableQuestIDs[j] + " is " + questList[i].progress);
                            //quest UI manager
                            //TESTING
                            AcceptQuest(questObject.availableQuestIDs[j]);
                        }
                    }
                }
            }

            //CHECKING FOR RECEIVABLE QUEST
            for (int i = 0; i < questList.Count; i++)
            {
                for (int j = 0; j < questObject.receivableQuestIDs.Count; j++)
                {
                    if (questList[i].id == questObject.receivableQuestIDs[j]
                        && questList[i].progress == QuestProgress.ACCEPTED
                        || questList[i].progress == QuestProgress.COMPLETE)
                    {
                        Debug.Log("NPC Received Quest ID: " + questObject.receivableQuestIDs[j] + " is " + questList[i].progress);
                        //quest UI manager
                        //TESTING
                        CompleteQuest(questObject.receivableQuestIDs[j]);
                    }
                }
            }
        }
        
        //ACCEPTE QUEST
        public void AcceptQuest(int questID)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                if (questList[i].id ==  questID && questList[i].progress == QuestProgress.AVAILABLE)
                {
                    currentQuestList.Add(questList[i]);
                    questList[i].progress = QuestProgress.ACCEPTED;
                }
            }
        }

        //ABANDON QUEST
        public void AbandonQuest(int questID)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                if (questList[i].id == questID && questList[i].progress == QuestProgress.ACCEPTED)
                {
                    currentQuestList.Remove(questList[i]);
                    questList[i].progress = QuestProgress.AVAILABLE;
                    //reset all quest variables, will need a Abandon() on the quest class
                    questList[i].questObjectiveCount = 0;
                }
            }
        }

        //COMPLETE QUEST
        public void CompleteQuest(int questID)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                if (questList[i].id == questID && questList[i].progress == QuestProgress.COMPLETE)
                {
                    currentQuestList.Remove(questList[i]);
                    questList[i].progress = QuestProgress.DONE;

                    //REWARD
                }
            }
            //Check for chain quests
        }

        //ADD ITEMS
        public void AddQuestItem(string questObjective, int itemAmount)
        {
            for (int i = 0; i < currentQuestList.Count; i++)
            {
                //CHECK FOR QUEST OF INTERFACE COLLECTION HERE AS WELL
                if (currentQuestList[i].objective == questObjective && currentQuestList[i].progress == QuestProgress.ACCEPTED)
                {
                    currentQuestList[i].questObjectiveCount += itemAmount;
                }
                if (currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveCountRequierment && currentQuestList[i].progress == QuestProgress.ACCEPTED)
                {
                    currentQuestList[i].progress = QuestProgress.COMPLETE;
                }
            }
        }

        //REMOVE ITEMS

        //BOOL Methods
        public bool RequestAvailable (int questID)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                if (questList[i].id == questID && questList[i].progress == QuestProgress.AVAILABLE )
                {
                    return true;
                }
            }
            return false;
        }

        public bool RequestAccepted(int questID)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                if (questList[i].id == questID && questList[i].progress == QuestProgress.ACCEPTED)
                {
                    return true;
                }
            }
            return false;
        }

        public bool RequestComplete(int questID)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                if (questList[i].id == questID && questList[i].progress == QuestProgress.COMPLETE)
                {
                    return true;
                }
            }
            return false;
        }        
    }
}
