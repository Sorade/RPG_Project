using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class Quest : MonoBehaviour, IQuest      
    {
        private string _title;
        private string _objective;

        private int _id;
        private int _questObjectiveCount;
        private QuestProgress _progress;

        public QuestProgress progress
        {
            get
            {
                return _progress;
            }
        }

        public string title
        {
            get
            {
               return _title;
            }
        }

        public int id
        {
            get
            {
                return _id;
            }
        }

        public string objective
        {
            get
            {
                return _objective;
            }
        }

        public int questObjectiveCount
        {
            get
            {
                return _questObjectiveCount;
            }

            set
            {
                _questObjectiveCount = value;
            }
        }
    }
}