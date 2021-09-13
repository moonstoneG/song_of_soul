using System;
using System.Collections.Generic;
using UnityEngine;

namespace AS_2D.DiaInfo
{
    
    [CreateAssetMenu(fileName = "OriginalPhrases_SO", menuName = "SO物体配置/源文本_SO", order = 2)]
    public class OriginalPhrases : ScriptableObject
    {
        [Tooltip("该文本语言为")]
        public string language;
        [Tooltip("文本内容key值+value值的集合")]
        public List<Phrase> phrases = new List<Phrase>();

        public string this[string key]
        {
            get
            {
                for (int i = 0; i < phrases.Count; i++)
                {
                    if (phrases[i].key == key)
                        return phrases[i].value;
                }

                return "Key not found.";
            }
        }
    }

    [Serializable]
    public class Phrase
    {
        [Tooltip("文本key值")]
        public string key;
        [Tooltip("文本value值")]
        public string value;
    }
}