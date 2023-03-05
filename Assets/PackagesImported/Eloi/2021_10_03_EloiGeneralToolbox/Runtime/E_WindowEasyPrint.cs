using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace Eloi { 
    public class E_Print 
    {



        public interface IUnityWindowPrinter
        {

            void PrintText(in string text);
            void PrintText(in Eloi.IMetaAbsolutePathFileGet filePath);

            void PrintImage(in Texture2D texture);
            void PrintImage(in Eloi.IMetaAbsolutePathFileGet filePath);

        }


        public static class Window
        {
            static IMetaAbsolutePathDirectoryGet folder = new MetaAbsolutePathDirectory(Application.temporaryCachePath);
            static IMetaFileNameWithExtensionGet fileTxt = new MetaFileNameWithExtension("toprint", "txt");
            static IMetaFileNameWithExtensionGet fileJpg = new MetaFileNameWithExtension("toprint", "jpg");
            static IMetaFileNameWithExtensionGet filePng = new MetaFileNameWithExtension("toprint", "png");

            static public void PrintImage(in Texture2D texture)
            {
                //BEST BUT NOT TOTALY HIDDEN
                //IMetaAbsolutePathFileGet file = E_FileAndFolderUtility.Combine(in folder, in filePng);
                //E_FileAndFolderUtility.CreateFolderIfNotThere(file);
                //byte[] tByte= texture.EncodeToPNG();
                //string p = file.GetPath();
                //File.WriteAllBytes(p,tByte);
                //PrintImage(in file);


                TryPrintingInHiddenMode(texture);


            }
            public static void TryPrintingInHiddenMode(Texture2D texture)
            {
                string mspaintARgs = "/p \"{0}\"";
                IMetaAbsolutePathDirectoryGet folder = new MetaAbsolutePathDirectory(Application.temporaryCachePath);
                IMetaFileNameWithExtensionGet filePng = new MetaFileNameWithExtension("toprint", "jpg");
                IMetaAbsolutePathFileGet file = E_FileAndFolderUtility.Combine(in folder, in filePng);
                E_FileAndFolderUtility.CreateFolderIfNotThere(file);
                byte[] tByte = texture.EncodeToJPG();
                string p = file.GetPath();
                File.WriteAllBytes(p, tByte);
                string arg = string.Format(mspaintARgs, p.Replace("/", "\\"));
                //Should I let it ?
                //Thread.Sleep(500);
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;
                startInfo.FileName = "mspaint.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = arg;
                Process.Start(startInfo);

            }

            public static void TryPrintingHidden(string text)
            {
                IMetaAbsolutePathDirectoryGet folder = new MetaAbsolutePathDirectory(Application.dataPath);
                IMetaFileNameWithExtensionGet fileTxt = new MetaFileNameWithExtension("toprint", "txt");

                IMetaAbsolutePathFileGet file = E_FileAndFolderUtility.Combine(in folder, in fileTxt);
                File.WriteAllText(file.GetPath(), text);
                string arg = string.Format(" /P \"{0}\"", file.GetPath());
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;
                startInfo.FileName = "notepad.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = arg;
                Process.Start(startInfo);
            }


            static public void PrintImage(in IMetaAbsolutePathFileGet filePath)
            {
                if (filePath == null)
                    throw new System.NullReferenceException();
                string path = filePath.GetPath();
                if (!File.Exists(path))
                    throw new System.Exception("File need to exist");

                string cmd = string.Format("mspaint /pt \"{0}\"", path);
                E_LaunchWindowBat.ExecuteCommandHiddenWithReturnInThread( folder, cmd);
            }

            static public void PrintText(in string text)
            {
                PrintTextWithNotepad(in text);
            }

            static public void PrintText(in IMetaAbsolutePathFileGet filePath)
            {
                if (filePath == null)
                    throw new System.NullReferenceException();
                string path = filePath.GetPath();
                if (!File.Exists(path))
                    throw new System.Exception("File need to exist");
               string text = File.ReadAllText(path);
                PrintTextWithNotepad(in text);

            }

            static public void PrintTextWithNotepad(in string text)
            {

                //BEST BUT NOT TOTALY HIDDEN
                //IMetaAbsolutePathFileGet file = E_FileAndFolderUtility.Combine(in folder, in fileTxt);
                //File.WriteAllText(file.GetPath(), text);
                //string cmd = string.Format("notepad /P \"{0}\"", file.GetPath());
                //E_LaunchWindowBat.ExecuteCommandHiddenWithReturnInThread( folder, cmd);

                TryPrintingHidden(text);

            }
          
        }
    }
}
