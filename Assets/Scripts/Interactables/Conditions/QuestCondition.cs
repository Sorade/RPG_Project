using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

public class QuestCondition : Condition {
    public int questID;
    public QuestProgress questStatus;

    public override bool Check()
    {
        return QuestManager.instance.RequestProgress(questID, questStatus);
    }
}
