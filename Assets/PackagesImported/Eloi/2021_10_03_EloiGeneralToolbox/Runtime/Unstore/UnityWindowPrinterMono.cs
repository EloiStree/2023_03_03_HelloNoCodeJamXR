using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbstractUnityWindowPrinterMono : MonoBehaviour, Eloi.E_Print.IUnityWindowPrinter
{
    public abstract void PrintImage(in Texture2D texture);
    public abstract void PrintImage(in IMetaAbsolutePathFileGet filePath);
    public abstract void PrintText(in string text);
    public abstract void PrintText(in IMetaAbsolutePathFileGet filePath);
}

public class UnityWindowPrinterMono : AbstractUnityWindowPrinterMono
{

    public bool m_enablePrinting=true;
    public void SetPrinterEnable(bool setAsEnable) {
        m_enablePrinting = setAsEnable;
    }
    public override void PrintImage(in Texture2D texture)
    {
        if(m_enablePrinting)
        Eloi.E_Print.Window.PrintImage(in texture);
    }

    public override void PrintImage(in IMetaAbsolutePathFileGet filePath)
    {
        if (m_enablePrinting)
            Eloi.E_Print.Window.PrintImage(in filePath);
    }

    public override void PrintText(in string text)
    {
        if (m_enablePrinting)
            Eloi.E_Print.Window.PrintText(in text);
    }

    public override void PrintText(in IMetaAbsolutePathFileGet filePath)
    {
        if (m_enablePrinting)
            Eloi.E_Print.Window.PrintText(in filePath);
    }

    [ContextMenu("Print Hello World")]
    public  void PrintTextHelloWorld()
    {
        PrintText("\n\n\nHello World !\n\n\n");
    }

}
