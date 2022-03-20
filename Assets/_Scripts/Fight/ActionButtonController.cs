using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonController : MonoBehaviour
{
   // public Color[] Colors;
    public ActionButton ActionButtonPrefab;

    public List<FightCommandTypes> PossibleCommands;

    public CombatManager CombatManager;

    private List<GameObject> CurrentButtons;

    private CanvasGroup _canvasGroup;

    //public CubeColor Cube;

    // Start is called before the first frame update
    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    

    internal void ChooseTarget(Entity activeEntity)
    {
        Hide();
    }

    void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
    }

    void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }

    private void Start()
    {
        CurrentButtons = new List<GameObject>();
        MakeButtons();
    }

    private void MakeButtons()
    {
        var commands = CombatManager.EntityManager.ActiveEntity.GetComponent<Fighter>().PossibleCommands;

        foreach (var command in commands)
        {
            MakeNewButton(command);
        }
    }

    private void MakeNewButton(FightCommandTypes command)
    {
        var button = Instantiate(ActionButtonPrefab) as ActionButton;
        button.Init(command, this);
        button.transform.SetParent(transform);
        CurrentButtons.Add(button.gameObject);
    }

    public void UpdateButtons()
    {
        _UpdateButtons();
    }

    private void _UpdateButtons()
    {
        foreach(GameObject button in CurrentButtons)
        {
            Destroy(button);
        }
        CurrentButtons.Clear();

        MakeButtons();
    }

    public void OnButtonPressed(FightCommandTypes fightCommandType)
    {
        CombatManager.DoAction(fightCommandType);
    }
}
