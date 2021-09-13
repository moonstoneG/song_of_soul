using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AS_2D.DiaInfo
{
    public class DialogueCanvasController : MonoBehaviour
    {
        //public Animator animator;
        public TextMeshProUGUI textMeshProUGUI;

        protected Coroutine m_DeactivationCoroutine;
    
        //protected readonly int m_HashActivePara = Animator.StringToHash ("Active");

        IEnumerator SetAnimatorParameterWithDelay (float delay)
        {
            yield return new WaitForSeconds (delay);
            //animator.SetBool(m_HashActivePara, false);
        }

        /// <summary>
        /// 显示输入的文本内容
        /// </summary>
        /// <param name="text">要显示的文本内容</param>
        public void ActivateCanvasWithText (string text)
        {
            if (m_DeactivationCoroutine != null)
            {
                StopCoroutine (m_DeactivationCoroutine);
                m_DeactivationCoroutine = null;
            }

            gameObject.SetActive (true);
            //animator.SetBool (m_HashActivePara, true);
            textMeshProUGUI.text = text;

        }

        /// <summary>
        /// 事件调用显示文本只用此方法，根据translator内的so物体配置自动显示选择的语言
        /// </summary>
        /// <param name="phraseKey"></param>
        public void ActivateCanvasWithTranslatedText (string phraseKey)
        {

            if (m_DeactivationCoroutine != null)
            {
                StopCoroutine(m_DeactivationCoroutine);
                m_DeactivationCoroutine = null;
            }

            gameObject.SetActive(true);
            //animator.SetBool(m_HashActivePara, true);
            textMeshProUGUI.text = Translator.Instance[phraseKey];

        }

        public void DeactivateCanvasWithDelay (float delay)
        {
            m_DeactivationCoroutine = StartCoroutine (SetAnimatorParameterWithDelay (delay));
        }

    }
}
