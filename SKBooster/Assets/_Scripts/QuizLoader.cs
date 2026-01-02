using UnityEngine;
using System.IO;

public static class QuizLoader
{
    public static QuizJsonData Load(string quizId)
    {
        string path= Path.Combine(Application.dataPath,"_Scripts/JSON",quizId + ".json");
        if (!File.Exists(path))
        {
            Debug.LogError("No se encontró el archivo JSON: " + path);
            return null;
        }
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<QuizJsonData>(json);
    }
}
