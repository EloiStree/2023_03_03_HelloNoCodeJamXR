using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using UnityEngine;

public class E_LaunchWindowBat 
{

    //public void ExecuteCommand(in string whereToExecute,in string whatToExecute, in ProcessWindowStyle windowStyle = ProcessWindowStyle.Maximized) {

    //    Process process = new Process();
    //    process.StartInfo.FileName = "whatToExecute";
    //    process.StartInfo.Arguments = "-n";
    //    process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
    //    process.StartInfo.WorkingDirectory = whereToExecute;
    //    process.Start();
    //    process.WaitForExit();
    //}

    // public static void CreateAndExecuteBatFileInThread(in IMetaAbsolutePathDirectoryGet whereToCreate,
        // in IMetaFileNameWithoutExtensionGet batName, in bool deleteAfterRunning,
        // params string[] whatToExecute)
    // {
        // IMetaAbsolutePathDirectoryGet w=whereToCreate;
        // IMetaFileNameWithoutExtensionGet b =batName;
            // bool d= deleteAfterRunning;
         // string[] p=whatToExecute;
        // new Thread(() => CreateAndExecuteBatFile( w ,  b , d , p)).Start();
    // }


    public static void CreateAndExecuteBatFile(in IMetaAbsolutePathDirectoryGet whereToCreate, 
        in MetaFileNameWithoutExtension batName,in bool deleteAfterRunning,
        params string[] whatToExecute)
    {
        batName.GetName(out string batNameWithoutExt);
        whereToCreate.GetPath(out string where);
        E_FilePathUnityUtility.MeltPathTogether(out string path , where, batNameWithoutExt + ".bat");
        File.WriteAllText(path, string.Join("\n", whatToExecute));

        UnityEngine.Debug.Log("-0:" + path);
        UnityEngine.Debug.Log("-1:" + File.ReadAllText(path));
       

        ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/C start \"\" \"" + path+ "\"");
        //processStartInfo.UseShellExecute = true;
       // processStartInfo.CreateNoWindow = true;
        processStartInfo.WorkingDirectory = where;
        processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
        Process p = new Process();
        p.StartInfo = processStartInfo;
        p.Start();
        p.WaitForExit();
        if(deleteAfterRunning)
            File.Delete(path);
    }

    public static void JustLaunchTarget(in IMetaAbsolutePathFileGet batch)
    {

        Eloi.E_FilePathUnityUtility.GetDirectoryPathOf(batch.GetPath(), out string pathDir);
        ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + batch);
        processStartInfo.UseShellExecute = true;
        processStartInfo.CreateNoWindow = false;
        processStartInfo.WorkingDirectory = pathDir;
        processStartInfo.WindowStyle = ProcessWindowStyle.Normal;

        Process p = new Process();
        p.StartInfo = processStartInfo;
        p.Start();
        p.WaitForExit();
    }

    public static void CreateAndExecuteBatFileInThread(in IMetaAbsolutePathDirectoryGet whereToCreate,
     in IMetaFileNameWithoutExtensionGet batName, in bool deleteAfterRunning,
     params string[] whatToExecute)
    {
        IMetaAbsolutePathDirectoryGet w = whereToCreate;
        IMetaFileNameWithoutExtensionGet b = batName;
        bool d = deleteAfterRunning;
        string[] p = whatToExecute;
        new Thread(() => CreateAndExecuteBatFile(w, b, d, p)).Start();
    }

    private static void CreateAndExecuteBatFile(
        IMetaAbsolutePathDirectoryGet whereToCreate,
        IMetaFileNameWithoutExtensionGet batName, 
        bool deleteAfterRunning,
        string[] whatToExecute)
    {
        batName.GetName(out string name);
        MetaFileNameWithExtension file = new MetaFileNameWithExtension(name, "bat");
        IMetaAbsolutePathFileGet filePath = Eloi.E_FileAndFolderUtility.Combine(whereToCreate, file);
        string rawPath = filePath.GetPath();
        Eloi.E_FileAndFolderUtility.CreateFolderIfNotThere(filePath);
        File.WriteAllText(rawPath, string.Join("\n", whatToExecute));
        JustLaunchTarget(filePath);
        if (deleteAfterRunning && File.Exists(rawPath))
        {
            try
            {
                File.Delete(rawPath);
            }
            catch (Exception) {
                Eloi.E_CodeTag.DirtyCode.Info("Shit code but to ill in real life for the moment to think about it.")
              ;  //Humm;
            }
        }

    }

    public static void CreateAndLaunchBatFile(in IMetaAbsolutePathDirectoryGet whereToCreate, in IMetaFileNameWithoutExtensionGet batName, params string[] whatToExecute)
    {
        Eloi.E_CodeTag.ToCodeLater.Info("Git Merge: Should I code that ?");
    }
    public static void ExecuteCommandHiddenWithReturn(in IMetaAbsolutePathDirectoryGet whereToCreate,in string command, out string output, out string error, out int exitCode)
    {
        ProcessStartInfo ProcessInfo;
        Process process;
        ProcessInfo = new ProcessStartInfo("cmd.exe", $"/c {command}");
        ProcessInfo.CreateNoWindow = true;
        ProcessInfo.UseShellExecute = false;
        ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
        ProcessInfo.WorkingDirectory = whereToCreate.GetPath();
        // *** Redirect the output ***
        ProcessInfo.RedirectStandardError = true;
        ProcessInfo.RedirectStandardOutput = true;
        process = Process.Start(ProcessInfo);
        process.WaitForExit();
        // *** Read the streams ***
        output = process.StandardOutput.ReadToEnd();
        error = process.StandardError.ReadToEnd();
        exitCode = process.ExitCode;
        process.Close();
    }



  
public static void ExecuteCommandHiddenWithReturnInThread( IMetaAbsolutePathDirectoryGet whereToCreate,  string command)

    {
        string o, e;
        int ex;
        new Thread(() => ExecuteCommandHiddenWithReturn(  whereToCreate,  command, out o, out e, out ex)).Start();
    }

    //public static void ExecuteMultipleCommandsHidden(MetaAbsolutePathDirectory whereToCreate, params string[] command)
    //{
    //    const string strCmdText = "/C command1&command2";
    //    Process.Start("CMD.exe", strCmdText);
    //    Eloi.E_ThrowException.ThrowNotImplemented();
       
    //}
    

    public static void ExecuteMultipleCommandsHidden(IMetaAbsolutePathDirectoryGet whereToCreate, params string [] command) {
        //static void RunCommands(List<string> cmds, string workingDirectory = "")
        //{
        //    var process = new Process();
        //    var psi = new ProcessStartInfo();
        //    psi.FileName = "cmd.exe";
        //    psi.RedirectStandardInput = true;
        //    psi.RedirectStandardOutput = true;
        //    psi.RedirectStandardError = true;
        //    psi.UseShellExecute = false;
        //    psi.WorkingDirectory = workingDirectory;
        //    process.StartInfo = psi;
        //    process.Start();
        //    process.OutputDataReceived += (sender, e) => { Console.WriteLine(e.Data); };
        //    process.ErrorDataReceived += (sender, e) => { Console.WriteLine(e.Data); };
        //    process.BeginOutputReadLine();
        //    process.BeginErrorReadLine();
        //    using (StreamWriter sw = process.StandardInput)
        //    {
        //        foreach (var cmd in cmds)
        //        {
        //            sw.WriteLine(cmd);
        //        }
        //    }
        //    process.WaitForExit();
        //}
    }



}
