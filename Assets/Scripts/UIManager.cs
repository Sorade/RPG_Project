using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestSystem;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    // Quest UI variables
    #region
    public Sprite questAvailableSprite; //exclamation point
    public Sprite questReceivableSprite; //interrogation point
    #endregion
    // Dialog UI variables
    #region
    [SerializeField]
    GameObject DialogBox;
    public Text mainText;
    public Text[] replies;
    public bool[] selectedReply;
    #endregion

    private void OnEnable()
    {
        EventManager.StartListening(SimpleEvent.DIALOG_STARTED, InvertDialogPanelState);
        EventManager.StartListening(SimpleEvent.DIALOG_ENDED, InvertDialogPanelState);

    }


    private void OnDisable()
    {
        EventManager.StopListening(SimpleEvent.DIALOG_STARTED, InvertDialogPanelState);
        EventManager.StopListening(SimpleEvent.DIALOG_ENDED, InvertDialogPanelState);

    }

    private void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        selectedReply = new bool[4];
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

    // Quest UIs
    #region
    public bool CheckAvailableQuests(QuestObject questObject)
    {
        for (int i = 0; i < QuestManager.instance.questList.Count; i++)
        {
            for (int j= 0; j < questObject.availableQuestIDs.Count; j++)
            {
                if (QuestManager.instance.questList[i].id == questObject.availableQuestIDs[j] && QuestManager.instance.questList[i].progress == QuestProgress.AVAILABLE)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckAcceptedQuests(QuestObject questObject)
    {
        for (int i = 0; i < QuestManager.instance.questList.Count; i++)
        {
            for (int j = 0; j < questObject.receivableQuestIDs.Count; j++)
            {
                if (QuestManager.instance.questList[i].id == questObject.receivableQuestIDs[j] && QuestManager.instance.questList[i].progress == QuestProgress.ACCEPTED)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckCompletedQuests(QuestObject questObject)
    {
        for (int i = 0; i < QuestManager.instance.questList.Count; i++)
        {
            for (int j = 0; j < questObject.receivableQuestIDs.Count; j++)
            {
                if (QuestManager.instance.questList[i].id == questObject.receivableQuestIDs[j] && QuestManager.instance.questList[i].progress == QuestProgress.COMPLETE)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void SetQuestMarker(QuestObject questObject)
    {
        if (CheckCompletedQuests(questObject))
        {
            questObject.questMarker.SetActive(true);
            questObject.questMarkerImage.sprite = questReceivableSprite;
            questObject.questMarkerImage.color = Color.yellow;
        }
        else if (CheckAvailableQuests(questObject))
        {
            questObject.questMarker.SetActive(true);
            questObject.questMarkerImage.sprite = questAvailableSprite;
            questObject.questMarkerImage.color = Color.red;
        }
        else if (CheckAcceptedQuests(questObject))
        {
            questObject.questMarker.SetActive(true);
            questObject.questMarkerImage.sprite = questAvailableSprite;
            questObject.questMarkerImage.color = Color.grey;
        }
        else
        {
            questObject.questMarker.SetActive(false);
        }
    }
    #endregion //QuestUI

    //Dialog UI
    #region
    public void SetSelectedReply(int replyID)
    {
        //makes sure all other replies are false by resseting them all
        //for (int i = 0; i < selectedReply.Length; i++) { selectedReply[i] = false; }
        //sets the wanted reply to true
        selectedReply[replyID] = true;
    }

    void InvertDialogPanelState()
    {
        DialogBox.SetActive(!DialogBox.activeSelf);
    }
    #endregion
}
