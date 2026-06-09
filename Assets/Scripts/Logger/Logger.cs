using UnityEngine;

public class Logger : MonoBehaviour, ILogger
{
    [SerializeField] bool active = true;
    [SerializeField] Color logColor = Color.white;
    [SerializeField] Color warningColor = Color.yellow;
    [SerializeField] Color errorColor = Color.red;

    public void Log(string message)
    {
        if (!active) return;
        Debug.Log("<color=#"+logColor.GetHashCode()+">PlayerLoggerLog: "+message);
    }
    public void LogWarning(string message)
    {
        if (!active) return;
        Debug.LogWarning("<color=#" + warningColor.GetHashCode() + ">PlayerLoggerWarning: " + message);
    }
    public void LogError(string message)
    {
        if (!active) return;
        Debug.LogError("<color=#" + errorColor.GetHashCode() + ">PlayerLoggerError: " + message);
    }
}
