using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AS_2D.DiaInfo
{
    
    [CreateAssetMenu(fileName = "TranslatedPhrases_SO", menuName = "SO物体配置/翻译文本_SO", order = 3)]
    public class TranslatedPhrases : OriginalPhrases
    {
        [Tooltip("对应源语言文本的SO物体")]
        public OriginalPhrases originalPhrases;
    }
}