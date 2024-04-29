[System.Serializable]
public class Script {
    public Message[] script;

    public Message[] GetScript() { return script; }
    public Message GetMessage(int index)
    {
        return script[index];
    }

    public int GetLength() { return script.Length; }
}
