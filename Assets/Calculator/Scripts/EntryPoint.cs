using Calculator.Model;
using Calculator.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint
{
    private UIRootView _uiRoot;
    private CalculatorModel _model;
    private ISaveLoad _saveLoad;
    private Presenter _presenter;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutostartGame()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        new EntryPoint().RunGame();
    }

    private EntryPoint()
    {
        _saveLoad = new SimpleSaveLoadService();
        _presenter = new Presenter();

        var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
        _uiRoot = Object.Instantiate(prefabUIRoot);
        _uiRoot.name = "[UI ROOT]";
        _uiRoot.Init(_presenter);
        Object.DontDestroyOnLoad(_uiRoot);

        _model = new CalculatorModel(_presenter, _saveLoad, new AdditionService());
        _presenter.Init(_uiRoot, _model);
    }

    private void RunGame()
    {
        _model.Init();
    }
}
