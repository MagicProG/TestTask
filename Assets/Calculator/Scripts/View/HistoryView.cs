using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Calculator.View
{
    public class HistoryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI historyText;
        [SerializeField] private RectTransform contentRT;
        [SerializeField] private RectTransform viewRT;
        [SerializeField] private float MaxViewHeight;

        private void Awake()
        {
            historyText.text = "";

            UpdateSize();
        }

        public void SetHistory(List<string> results)
        {
            if (results.Count > 0)
            {
                var history = "";
                for (int i = results.Count - 1; i > 0; i--)
                {
                    history += results[i] + "\n";
                }
                history += results[0];

                historyText.text = history;
                UpdateSize();
            }
        }

        public void AddResult(string output)
        {
            historyText.text = output + "\n" + historyText.text;
            UpdateSize();
            contentRT.localPosition = Vector2.zero;
        }

        private void UpdateSize()
        {
            var height = historyText.GetPreferredValues().y;

            contentRT.sizeDelta = new Vector2(contentRT.sizeDelta.x, height);
            viewRT.sizeDelta = new Vector2(viewRT.sizeDelta.x, Mathf.Clamp(height, 0, MaxViewHeight));
        }
    }
}
