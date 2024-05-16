using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIBattleScript : MonoBehaviour
{
    //AllPins
    List<VisualElement> PinList = new List<VisualElement>();
    //Pin1
    public VisualElement Pin1;

    public int PinSelected;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Pin1 = root.Q<VisualElement>("Pin1");
        Pin1.AddManipulator(new PinDragger());
        PinList.Add(Pin1);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < PinList.Count; i++)
        {
            print(PinList[i].worldTransform.GetPosition().x);
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