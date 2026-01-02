using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class QuizJsonData
{
    public string quizId;
    public string title;
    public List<ContentJson> contents;
    public List<QuestionJson> questions;
}