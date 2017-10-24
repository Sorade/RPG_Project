using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class QuestManager : MonoBehaviour
    {

        public static QuestManager instance;

        public List<IQuest> questList = new List<IQuest>(); // Master quest list where all quests are located
        public List<IQuest> currentQuestList = new List<IQuest>(); // Master quest list where all quests are located

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

        //ADD ITEMS
        public void AddQuestItem(string questObjective, int itemAmount)
        {
            for (int i = 0; i < currentQuestList.Count; i++)
            {
                //CHECK FOR QUEST OF INTERFACE COLLECTION HERE AS WELL
                if (currentQuestList[i].objective == questObjective && currentQuestList[i].progress == QuestProgress.ACCEPTED)
                {
                    currentQuestList[i].questObjectiveCount += 1;
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
