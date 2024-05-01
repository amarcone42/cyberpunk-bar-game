[System.Serializable]
public class Script {
    public Dialogue[] script;

    public Dialogue[] GetScript() { return script; }
    public Message GetMessage(string id, int index)
    {
        return GetDialogue(id).GetMessage(index);
    }
    public Dialogue GetDialogue(string id)
    {
        for (int i = 0; i < script.Length; i++)
        {
            if (script[i].GetId() == id)
            {
                return script[i];
            }
        }
        return null;
    }

    public int GetLength(string id) { return GetDialogue(id).GetLength(); }
}
