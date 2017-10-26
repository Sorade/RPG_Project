using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    [System.Serializable]
    public class Quest : IQuest      
    {
        [SerializeField]
        private string _title;
        [SerializeField]
        private string _objective;
        [SerializeField]
        private int _id;
        [SerializeField]
        private int _questObjectiveCount;
        [SerializeField]
        private int _questObjectiveCountRequierment;
        [SerializeField]
        private int _nextQuest;
        [SerializeField]
        private QuestProgress _progress;

        public QuestProgress progress
        {
            get
            {
                return _progress;
            }

            set
            {
                _progress = value;
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

        public int questObjectiveCountRequierment
        {
            get
            {
                return _questObjectiveCountRequierment;
            }
        }

        public int nextQuest
        {
            get
            {
                return _nextQuest;
            }
        }
    }
}