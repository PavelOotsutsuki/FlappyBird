using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour, IInitiazable
{
    private TMP_Text _score;

    public void Init()
    {
        _score = GetComponent<TMP_Text>();
    }

    public void ChangeScoreText(int score)
    {
        _score.text = score.ToString();
    }
}
