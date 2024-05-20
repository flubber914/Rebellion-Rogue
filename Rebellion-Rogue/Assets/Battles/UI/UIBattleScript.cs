using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIBattleScript : MonoBehaviour
{
    //AllPins
    public List<VisualElement> PinList = new List<VisualElement>();
    //Pin1
    public VisualElement Pin1;
    //Pin2
    public VisualElement Pin2;

    public int PinSelected;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Pin1 = root.Q<VisualElement>("Pin1");
        Pin1.AddManipulator(new PinDragger());
        PinList.Add(Pin1);
        Pin2 = root.Q<VisualElement>("Pin2");
        Pin2.AddManipulator(new PinDragger());
        PinList.Add(Pin2);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < PinList.Count; i++)
        {
        }
    }

    void OnPointerDown(MouseDownEvent evt)
    {
        print("yes?");
    }

    void clicked()
    {
        print("?");
    }

}
