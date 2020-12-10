using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class CharDialogue
{
    /**SPEAKER ID
     * 
     * 0:Player
     * 1:Scientist 1
     * 2:Scientist 2
     * 3:Scientist 3
     * 4:Exposition
     * 
     * */

    public int speakerID;
    public string speakerName;
    public string Dialogue;

}



[CreateAssetMenu]
public class Dialogue_Script_Scriptable : ScriptableObject
{
    public CharDialogue[] charSpeaker;

    public int getLength()
    {
        return charSpeaker.Length;
    }

    public int getSpeakerID(int index)
    {
        return charSpeaker[index].speakerID;
    }

    public string getSpeakerName(int index)
    {
        return charSpeaker[index].speakerName;
    }

    public string getSpeakerDialogue (int index)
    {
        return charSpeaker[index].Dialogue;
    }


}
