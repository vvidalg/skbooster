using System;
using UnityEngine;
using System.Collections.Generic;

public class QuizResultManager : MonoBehaviour
{
    public static QuizResultManager Instance;
    private Dictionary<string, bool> results = new();
    
    public static event Action<string, bool> OnQuizFinished;


    public void SetResult(string quizId, bool passed)
    {
        results[quizId] = passed;
        OnQuizFinished?.Invoke(quizId, passed);
        Debug.Log("[QuizREsultMAnager] SetResult " + quizId+" y " + passed);
    }

}
