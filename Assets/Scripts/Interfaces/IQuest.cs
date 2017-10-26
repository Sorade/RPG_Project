using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public enum QuestProgress
    {
        NOT_AVAILABLE,
        AVAILABLE,
        ACCEPTED,
        COMPLETE,
        DONE
    }
    public interface IQuest
    {
        string title { get; }
        string objective { get; }
        int id { get; }
        int questObjectiveCount { get; set; }
        int questObjectiveCountRequierment { get; }
        int nextQuest { get; }
        QuestProgress progress { get; set; }

    }
}
