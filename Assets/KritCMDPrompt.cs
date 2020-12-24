using UnityEngine;
using System.Collections;
using KModkit;
using System.Linq;
using System.Text.RegularExpressions;

public class KritCMDPrompt : MonoBehaviour
{
    public KMSelectable buttonY;
    public KMSelectable buttonN;
    public KMSelectable CloseBtn;

    public KMBombInfo BombInfo;

    public TextMesh CommandName;
    public TextMesh FileName;
    public TextMesh ExtensionName;
    public TextMesh ResponseText;

    public MeshRenderer TypingBar;
    public MeshRenderer TypingBlock;

    public KMAudio TypingSFX;

    public KMSelectable[] ProcessTwitchCommand(string Command)
    {
        Command = Command.ToLowerInvariant().Trim();
        if (Regex.IsMatch(Command, "respond y"))
        {
            return new[] { buttonY };
        }
        else if (Regex.IsMatch(Command, "respond n"))
        {
            return new[] { buttonN };
        }
        else
        {
            
        }
        return null;
    }
    private readonly string TwitchHelpMessage = "Type '!{0} respond Y/N' to press the given button";

    public float letterPause = 0.2f;

    static int moduleIdCounter = 1;
    int moduleId;
    int ButtonAns = 0;
    int Command = 0;
    int File = 0;
    int Extension = 0;
    int StageNR = 0;

    bool Active = false;
    bool Typing = false;
    bool ActiveTyping = false;
    bool Exceptions;

    string ButtonName;

    void Awake()
    {
        moduleId = moduleIdCounter++;
        GetComponent<KMNeedyModule>().OnNeedyActivation += OnNeedyActivation;
        GetComponent<KMNeedyModule>().OnNeedyDeactivation += OnNeedyDeactivation;
        buttonY.OnInteract += CommandY;
        buttonN.OnInteract += CommandN;
        CloseBtn.OnInteract += Closing;
        GetComponent<KMNeedyModule>().OnTimerExpired += OnTimerExpired;
    }

    void Init()
    {
        Command = Random.Range(1, 7);
        File = Random.Range(1, 6);
        Extension = Random.Range(1, 6);

        Typing = true;
        StageNR++;

        //ButtonAns 1 = y, ButtonAns 2 = n
        if (Command == 1)
        {
            CommandName.text = "E x e c u t e";
            if (File == 1)
            {
                ButtonAns = 1;
                FileName.text = "A u t o E x e c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //AutoExec
            if (File == 2)
            {
                ButtonAns = 2;
                FileName.text = "M a n u a l D e t";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ManualDet
            if (File == 3)
            {
                Exception4();
                Exceptions = true;
                FileName.text = "R u n I n d c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //RunIndc
            if (File == 4)
            {
                ButtonAns = 2;
                FileName.text = "ButtonMasher";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ButtonMasher
            if (File == 5)
            {
                ButtonAns = 1;
                FileName.text = "FileNotFound";
                ExtensionName.text = "?";
            } //FileNotFound
        } //Execute
        else if (Command == 2)
        {
            CommandName.text = "O p e n";
            if (File == 1)
            {
                Exception2();
                Exceptions = true;
                FileName.text = "A u t o E x e c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //AutoExec
            if (File == 2)
            {
                ButtonAns = 2;
                FileName.text = "M a n u a l D e t";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ManualDet
            if (File == 3)
            {
                ButtonAns = 1;
                FileName.text = "R u n I n d c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //RunIndc
            if (File == 4)
            {
                Exception3();
                Exceptions = true;
                FileName.text = "ButtonMasher";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ButtonMasher
            if (File == 5)
            {
                ButtonAns = 2;
                FileName.text = "FileNotFound";
                ExtensionName.text = "?";
            } //FileNotFound
        } //Open
        else if (Command == 3)
        {
            CommandName.text = "R u n";
            if (File == 1)
            {
                Exception1();
                Exceptions = true;
                FileName.text = "A u t o E x e c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //AutoExec
            if (File == 2)
            {
                ButtonAns = 1;
                FileName.text = "M a n u a l D e t";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ManualDet
            if (File == 3)
            {
                Exception4();
                Exceptions = true;
                FileName.text = "R u n I n d c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //RunIndc
            if (File == 4)
            {
                ButtonAns = 2;
                FileName.text = "ButtonMasher";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ButtonMasher
            if (File == 5)
            {
                ButtonAns = 2;
                FileName.text = "FileNotFound";
                ExtensionName.text = "?";
            } //FileNotFound
        } //Run
        else if (Command == 4)
        {
            CommandName.text = "A b o r t";
            if (File == 1)
            {
                Exception3();
                Exceptions = true;
                FileName.text = "A u t o E x e c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //AutoExec
            if (File == 2)
            {
                ButtonAns = 2;
                FileName.text = "M a n u a l D e t";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ManualDet
            if (File == 3)
            {
                ButtonAns = 1;
                FileName.text = "R u n I n d c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //RunIndc
            if (File == 4)
            {
                Exception2();
                Exceptions = true;
                FileName.text = "ButtonMasher";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ButtonMasher
            if (File == 5)
            {
                ButtonAns = 1;
                FileName.text = "FileNotFound";
                ExtensionName.text = "?";
            } //FileNotFound
        } //Abort
        else if (Command == 5)
        {
            CommandName.text = "T e r m i n a t e";
            if (File == 1)
            {
                ButtonAns = 1;
                FileName.text = "A u t o E x e c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //AutoExec
            if (File == 2)
            {
                Exception4();
                Exceptions = true;
                FileName.text = "M a n u a l D e t";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ManualDet
            if (File == 3)
            {
                ButtonAns = 2;
                FileName.text = "R u n I n d c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //RunIndc
            if (File == 4)
            {
                ButtonAns = 1;
                FileName.text = "ButtonMasher";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ButtonMasher
            if (File == 5)
            {
                ButtonAns = 2;
                FileName.text = "FileNotFound";
                ExtensionName.text = "?";
            } //FileNotFound
        } //Terminate
        else if (Command == 6)
        {
            CommandName.text = "S t o p";
            if (File == 1)
            {
                Exception2();
                Exceptions = true;
                FileName.text = "A u t o E x e c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //AutoExec
            if (File == 2)
            {
                ButtonAns = 1;
                FileName.text = "M a n u a l D e t";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ManualDet
            if (File == 3)
            {
                Exception3();
                Exceptions = true;
                FileName.text = "R u n I n d c";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //RunIndc
            if (File == 4)
            {
                ButtonAns = 2;
                FileName.text = "ButtonMasher";
                if (Extension == 1)
                {
                    ExtensionName.text = ".exe?";
                } //Exe
                if (Extension == 2)
                {
                    ExtensionName.text = ".bat?";
                } //Bat
                if (Extension == 3)
                {
                    ExtensionName.text = ".dll?";
                } //Dll
                if (Extension == 4)
                {
                    ExtensionName.text = ".cmd?";
                } //Cmd
                if (Extension == 5)
                {
                    ExtensionName.text = ".sys?";
                } //Sys
            } //ButtonMasher
            if (File == 5)
            {
                ButtonAns = 1;
                FileName.text = "FileNotFound";
                ExtensionName.text = "?";
            } //FileNotFound
        } //Stop
        ButtonNaming();
    }

    void Exception1()
    {
        if (Extension == 1 || Extension == 4)
        {
            ButtonAns = 1;
        }
        else
        {
            ButtonAns = 2;
        }
        ButtonNaming();
    }
    void Exception2()
    {
        if (Extension == 3 || Extension == 5)
        {
            ButtonAns = 1;
        }
        else
        {
            ButtonAns = 2;
        }
        ButtonNaming();
    }
    void Exception3()
    {
        if (Extension == 2 || Extension == 1)
        {
            ButtonAns = 2;
        }
        else
        {
            ButtonAns = 1;
        }
        ButtonNaming();
    }
    void Exception4()
    {
        if (BombInfo.GetSerialNumberLetters().Any("AEIOU".Contains))
        {
            ButtonAns = 2;
        }
        else
        {
            ButtonAns = 1;
        }
        ButtonNaming();
    }

    void ButtonNaming()
    {
        if (ButtonAns == 1)
        {
            ButtonName = "YES";
        }
        else if (ButtonAns == 2)
        {
            ButtonName = "NO";
        }
        LogAnswer();
    }

    void LogAnswer()
    {
        Debug.LogFormat("[Command Prompt #{0}] Button that must be pressed for stage {1}: {2}", moduleId, StageNR, ButtonName);
    }

    private IEnumerator TypeTextY()
    {
        for (int i = 0; i <= 5; i++)
        {
            if (i == 0 && Active == true && Typing == true)
            {
                Typing = false;
                ActiveTyping = true;
                ResponseText.text = "Y";
                TypingSFX.PlaySoundAtTransform("CharacterTick", transform);
                TypingBlock.material.color = new Color(0, 0, 0);
            }
            else if (i == 1 && ActiveTyping == true)
            {
                ResponseText.text += "E";
                TypingSFX.PlaySoundAtTransform("CharacterTick", transform);
                TypingBlock.material.color = new Color(0, 0, 0);
            }
            else if (i == 2 && ActiveTyping == true)
            {
                ResponseText.text += "S";
                TypingSFX.PlaySoundAtTransform("CharacterTick", transform);
                TypingBlock.material.color = new Color(0, 0, 0);
            }
            else if (i == 5 && ActiveTyping == true)
            {
                ActiveTyping = false;
                ResponseText.text = "";
                TypingBlock.material.color = new Color(255, 255, 255);
                StopCoroutine("TypeTextN");
                CommandName.color = Color.white;
                ExtensionName.color = Color.white;
                FileName.color = Color.white;
                CommandName.text = "A w a i t i n g";
                FileName.text = "Server input";
                ExtensionName.text = ". . .";
            }
            else
            {

            }
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }

    private IEnumerator TypeTextN()
    {
        for (int i = 0; i <= 5; i++)
        {
            if (i == 0 && Active == true && Typing == true)
            {
                ActiveTyping = true;
                Typing = false;
                TypingSFX.PlaySoundAtTransform("CharacterTick", transform);
                ResponseText.text = "N";
                TypingBlock.material.color = new Color(0, 0, 0);
            }
            else if (i == 1 && ActiveTyping == true)
            {
                ResponseText.text += "O";
                TypingSFX.PlaySoundAtTransform("CharacterTick", transform);
                TypingBlock.material.color = new Color(0, 0, 0);
            }
            else if (i == 5 && ActiveTyping == true)
            {
                ActiveTyping = false;
                ResponseText.text = "";
                TypingBlock.material.color = new Color(255, 255, 255);
                StopCoroutine("TypeTextN");

                CommandName.color = Color.white;
                ExtensionName.color = Color.white;
                FileName.color = Color.white;
                CommandName.text = "A w a i t i n g";
                FileName.text = "Server input";
                ExtensionName.text = ". . .";
            }
            else
            {

            }
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }

    protected bool CommandY()
    {
        StartCoroutine("TypeTextY");
        GetComponent<KMSelectable>().AddInteractionPunch();
        if (ButtonAns == 1 && Active == true)
        {
            Active = false;
            GetComponent<KMNeedyModule>().HandlePass();
            Debug.LogFormat("[Command Prompt #{0}] Button pressed in stage {1}: Button Y", moduleId, StageNR);
            Debug.LogFormat("[Command Prompt #{0}] Which was correct! Passed.", moduleId);
            CommandName.color = Color.green;
            ExtensionName.color = Color.green;
            FileName.color = Color.green;
        }
        else if (ButtonAns == 2 && Active == true)
        {
            GetComponent<KMNeedyModule>().HandleStrike();
            Debug.LogFormat("[Command Prompt #{0}] Button pressed in stage {1}: Button Y", moduleId, StageNR);
            Debug.LogFormat("[Command Prompt #{0}] Incorrect button! Strike handed.", moduleId);
            CommandName.color = Color.red;
            ExtensionName.color = Color.red;
            FileName.color = Color.red;
            Active = false;
            GetComponent<KMNeedyModule>().HandlePass();
        }
        else if (ButtonAns == 2 && Active == false)
        {
            return false;
        }
        else
        {

        }
        if (Active == true)
        {
            TypingSFX.PlaySoundAtTransform("CharacterTick", transform);
        }
        return false;
    }
    protected bool CommandN()
    {
        StartCoroutine("TypeTextN");
        GetComponent<KMSelectable>().AddInteractionPunch();
        if (ButtonAns == 2 && Active == true)
        {
            Active = false;
            Debug.LogFormat("[Command Prompt #{0}] Button pressed in stage {1}: Button N", moduleId, StageNR);
            Debug.LogFormat("[Command Prompt #{0}] Which was correct! Passed.", moduleId);
            GetComponent<KMNeedyModule>().HandlePass();

            CommandName.color = Color.green;
            ExtensionName.color = Color.green;
            FileName.color = Color.green;


        }
        else if (ButtonAns == 1 && Active == false)
        {

        }
        else if (ButtonAns == 1 && Active == true)
        {
            GetComponent<KMNeedyModule>().HandleStrike();
            Debug.LogFormat("[Command Prompt #{0}] Button pressed in stage {1}: Button N", moduleId, StageNR);
            Debug.LogFormat("[Command Prompt #{0}] Incorrect button! Strike handed.", moduleId);
            CommandName.color = Color.red;
            ExtensionName.color = Color.red;
            FileName.color = Color.red;
            Active = false;
            GetComponent<KMNeedyModule>().HandlePass();
        }
        else if (ButtonAns == 1 && Active == false)
        {
            return false;
        }
        else
        {

        }
        if (Active == true)
        {
            TypingSFX.PlaySoundAtTransform("CharacterTick", transform);
        }


        return false;
    }

    protected void OnNeedyActivation()
    {
        Active = true;
        Init();
    }

    protected void OnNeedyDeactivation()
    {

    }

    protected void OnTimerExpired()
    {
        GetComponent<KMNeedyModule>().OnStrike();
        Active = false;
    }

    protected bool Closing()
    {
        GetComponent<KMSelectable>().AddInteractionPunch();
        GetComponent<KMNeedyModule>().HandleStrike();
        Debug.LogFormat("[Command Prompt #{0}] Attempted to close BombCMD.cmd! Strike handed", moduleId);
        return false;
    }
}

/* A list of possible Commands, Files or Extensions

Commands: Execute (1), Open (2), Run (3), Abort (4), Terminate (5), Stop (6)
Files: AutoExec (1), ManualDet (2), RunIndc (3), ButtonMasher (4), FileNotFound (5)
Extensions: Exe (1), Bat (2), Dll (3), Cmd (4), Sys (5)

 */
