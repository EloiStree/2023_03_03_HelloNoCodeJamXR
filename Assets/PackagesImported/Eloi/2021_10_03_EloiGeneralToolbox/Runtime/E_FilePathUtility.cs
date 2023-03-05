using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Eloi
{
    public class E_FilePathUnityUtility
    {

        /// <summary>
        /// This methode will take the root path and the subfolder path. Remove the border / and \\ then join then with / together as a meltpath
        /// </summary>
        /// <param name="metlPath"></param>
        /// <param name="rootFolderPath"></param>
        /// <param name="subFolders"></param>
        public static void MeltPathTogether(out string metlPath, in string rootFolderPath, params string[] subFolders)
        {
            List<string> cleanPart = new List<string>();
            TrimAtEndSlashAndBackSlashIfThereAre(in rootFolderPath, out string rootPathTrimmed);
            cleanPart.Add(rootPathTrimmed);
            for (int i = 0; i < subFolders.Length; i++)
            {
                TrimSlashAndBackSlashIfThereAre(in subFolders[i], out string trimmed);
                cleanPart.Add(trimmed);

            }
            metlPath = string.Join("/", cleanPart);
            Eloi.E_CodeTag.QualityAssurance.RequestTestingInTheFuture();
        }

        public static void TrimSlashAndBackSlashIfThereAre(in string rootPath, out string triRootPath)
        {
            TrimAtStartSlashAndBackSlashIfThereAre(in rootPath, out string trimmedAtStart);
            TrimAtEndSlashAndBackSlashIfThereAre(in trimmedAtStart, out triRootPath);
        }

        public static string RemoveFileExtension(string path)
        {
            int dotIndex = path.LastIndexOf('.');
            if (dotIndex < 0)
                return path;
            int slashIndex = path.Replace("\\","/").LastIndexOf('/');
            if (dotIndex <= slashIndex)
                return path;
            Eloi.E_StringUtility.SplitInTwo(in path, dotIndex, out string left, out string right);
            return left;
        }

        public static void TrimAtEndSlashAndBackSlashIfThereAre(in string rootPath, out string trimRootPath)
        {
            trimRootPath = rootPath;
            if (rootPath == null || rootPath.Length <= 0)
            {
                return;
            }

            char c = rootPath[rootPath.Length - 1];
            if (c == '/' || c == '\\')
            {
                trimRootPath = rootPath.Substring(0, rootPath.Length - 1);
            }
        }

        public static void TrimAtStartSlashAndBackSlashIfThereAre(in string rootPath, out string trimRootPath)
        {
            trimRootPath = rootPath;
            if (rootPath == null || rootPath.Length <= 0)
            {
                return;
            }
            if (rootPath[0] == '/' || rootPath[0] == '\\')
                trimRootPath = rootPath.Substring(1);
        }

        //public static void GetEditorWindowAssetsFolderPath(out string path)
        //{
        //    throw new System.NotImplementedException("Yo");
        //}
        //public static void GetEditorWindowRootFolderPath(out string path)
        //{
        //    throw new System.NotImplementedException("Yo");
        //}

        //public static void GetRuntimeWindowExeFolderPath(out string path)
        //{
        //    throw new System.NotImplementedException("Yo");
        //}
        //public static void GetEditorWindowDataFolderPath(out string path)
        //{
        //    throw new System.NotImplementedException("Yo");
        //}
        //public static void GetRuntimeWindowDataFolderPath(out string path)
        //{
        //    throw new System.NotImplementedException("Yo");
        //}

        public static void AllBackslash(in string source, out string result)
        {
            result = source.Replace("/", "\\");

        }
        public static void AllSlash(in string source, out string result)
        {
            result = source.Replace("\\", "/");
        }

        public static void GetJustDirectoryName(in string directoryPath, out string name)
        {
            name = new DirectoryInfo(directoryPath).Name;
            //string under = Directory.GetParent(directoryPath).FullName;

            //name = directoryPath.Replace(under, "");
            //name = name.Replace("/", "");
            //name = name.Replace("\\", "");

        }
        public static void GetDirectoryPathOf(in string directoryPath, out string path)
        {
            path = System.IO.Path.GetDirectoryName(directoryPath);
        }

        
    }

    [System.Serializable]
    public class MetaFileExtension
    {
        [SerializeField] string m_extensionNameWithoutDot = "";

        public MetaFileExtension(string extensionNameWithoutDot)
        {
            this.m_extensionNameWithoutDot = extensionNameWithoutDot;
        }

        public void SetExtension(in string fileExtensionWithoutDot)
        {
            m_extensionNameWithoutDot = fileExtensionWithoutDot;
        }
        public void GetExtensionWithoutDot(out string extension) => extension = m_extensionNameWithoutDot;
        public void GetExtensionWithDot(out string extension) => extension = "." + m_extensionNameWithoutDot;
    }

    public interface IMetaPathSet
    {
        void GetPath(out string path);
        void SetPath(string path);
        string GetPath();
    }
    public interface IMetaPathGet
    {
        void GetPath(out string path);
        string GetPath();
    }

    [System.Serializable]
    public class MetaPath : IMetaPathSet, IMetaPathGet
    {
        [SerializeField] string m_path = "";
        public void GetPath(out string path) => path = m_path;
        public void SetPath(string path) => m_path = path;
        public string GetPath()
        {
            return m_path;
        }
        public MetaPath()
        {
        }

        public MetaPath(string path)
        {
            this.m_path = path;
        }
        [ContextMenu("Open Target")]
        public void OpenTargetWithUnity() { Application.OpenURL(GetPath()); }
        [ContextMenu("Open Directory")]
        public void OpenTargetDirectoryWithUnity()
        {
            Eloi.E_FilePathUnityUtility.GetDirectoryPathOf(GetPath(), out string dirPath);
            Application.OpenURL(dirPath);
        }
    }

    public interface IMetaFileNameWithoutExtensionGet
    {
        void GetName(out string fileName);
    }
    [System.Serializable]
    public class MetaFileNameWithoutExtension : IMetaFileNameWithoutExtensionGet
    {
        [SerializeField] string m_fileName = "";

        public MetaFileNameWithoutExtension()
        {
        }

        public MetaFileNameWithoutExtension(string fileName)
        {
            this.m_fileName = fileName;
        }

        public void GetName(out string fileName) => fileName = m_fileName;
        public void SetPath(string fileName) => m_fileName = fileName;
    }


    public interface IMetaFileNameWithExtensionGet
    {
        void GetExtensionWithoutDot(out string extension);
        void GetExtensionWithDot(out string extension);
        void GetFileNameWithoutExtension(out string fileName);
        void GetFileNameWithExtension(out string fileName);

    }
    [System.Serializable]
    public class MetaFileNameWithExtension : IMetaFileNameWithExtensionGet
    {
        [SerializeField] string m_fileName = "";
        [SerializeField] string m_extensionNameWithoutDot = "";

        public MetaFileNameWithExtension(string fileName, string extensionNameWithoutDot)
        {
            this.m_fileName = fileName;
            this.m_extensionNameWithoutDot = extensionNameWithoutDot;
        }
        public MetaFileNameWithExtension(string textToSplitWithDot)
        {
            SetFileFromStringSplitAtLastDot(textToSplitWithDot);
        }
        public void SetFileFromStringSplitAtLastDot(in string text)
        {
            int indexLastDot = text.LastIndexOf(".");
            if (indexLastDot < 0)
            {
                m_fileName = text;
                m_extensionNameWithoutDot = "";
            }
            else {
                Eloi.E_StringUtility.SplitInTwo(in text, in indexLastDot, out m_fileName,out m_extensionNameWithoutDot);
            }
        }
        public void SetFileName(in string fileName, in string fileExtensionWithoutDot) {
            m_fileName = fileName;
            m_extensionNameWithoutDot = fileExtensionWithoutDot;
        }
        public void GetExtensionWithoutDot(out string extension) => extension = m_extensionNameWithoutDot;
        public void GetExtensionWithDot(out string extension) => extension = "." + m_extensionNameWithoutDot;
        public void GetFileNameWithoutExtension(out string fileName) { fileName = m_fileName; }
        public void GetFileNameWithExtension(out string fileName) { fileName = m_fileName + "." + m_extensionNameWithoutDot; }

        public bool IsEmpty()
        {
            return m_fileName.Trim().Length <= 0 && m_extensionNameWithoutDot.Trim().Length <= 0;
        }
    }

    public interface IMetaAbsolutePathFileGet : IMetaPathGet
    {
    }
    [System.Serializable]
    public class MetaAbsolutePathFile : MetaPath, IMetaAbsolutePathFileGet
    {
        public MetaAbsolutePathFile(string path) : base(path)
        {
        }

       
    }

    public abstract class AbstractMetaPathMono : MonoBehaviour
    {

        public abstract void GetPath(out string path);
        public abstract string GetPath();

        [ContextMenu("Open Target")]
        public void OpenTargetWithUnity() { Application.OpenURL(GetPath()); }
        [ContextMenu("Open Directory")]
        public void OpenTargetDirectoryWithUnity()
        {
            Eloi.E_FilePathUnityUtility.GetDirectoryPathOf(GetPath(), out string dirPath);
            Application.OpenURL(dirPath);
        }

       

        public void CreateDirectory() {
            Directory.CreateDirectory(GetPath());
        }
    }

    public abstract class AbstractMetaRelativePathFileMono : AbstractMetaPathMono, IMetaRelativePathFileGet
    {
    }
    public abstract class AbstractMetaAbsolutePathFileMono : AbstractMetaPathMono, IMetaAbsolutePathFileGet
    {
        [ContextMenu("Create Empty")]
        public void CreateEmpty()
        {
            File.WriteAllText(GetPath(), "") ;
        }
        [ContextMenu("Delete Directory")]
        public void Delete()
        {

            if (File.Exists(GetPath()))
                File.Delete(GetPath());
        }
    }
    public abstract class AbstractMetaRelativePathDirectoryMono : AbstractMetaPathMono, IMetaRelativePathDirectoryGet
    {
    }
    public abstract class AbstractMetaAbsolutePathDirectoryMono : AbstractMetaPathMono, IMetaAbsolutePathDirectoryGet
    {
        [ContextMenu("Create Empty")]
        public void CreateEmpty()
        {
            Directory.CreateDirectory(GetPath());
        }
        [ContextMenu("Delete Directory")]
        public void Delete()
        {

            if (Directory.Exists(GetPath()))
                Directory.Delete(GetPath());
        }
    }

    public interface IMetaRelativePathFileGet : IMetaPathGet
    {
    }
    [System.Serializable]
    public class MetaRelativePathFile : MetaPath, IMetaRelativePathFileGet
    {
        public MetaRelativePathFile(string path) : base(path)
        {
        }
    }
    public interface IMetaAbsolutePathDirectoryGet : IMetaPathGet
    {
    }
    [System.Serializable]
    public class MetaAbsolutePathDirectory : MetaPath, IMetaAbsolutePathDirectoryGet
    {
        public MetaAbsolutePathDirectory(string path) : base(path)
        {
        }

        public bool IsEmpty()
        {
            GetPath(out string p);
            return p.Trim().Length <= 0;
        }
    }
    public interface IMetaRelativePathDirectoryGet : IMetaPathGet
    {
    }
    [System.Serializable]
    public class MetaRelativePathDirectory : MetaPath, IMetaRelativePathDirectoryGet
    {
        public MetaRelativePathDirectory(string path) : base(path)
        {
        }
    }


    public class E_FileAndFolderUtility
    {
        public static void CreateFolderIfNotThere(in string path)
        {
            if (E_StringUtility.IsFilled(in path) && !Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        public static void CreateFolderIfNotThere(in IMetaAbsolutePathFileGet filepath)
        {
            string path = Path.GetDirectoryName(filepath.GetPath());
            if (E_StringUtility.IsFilled(in path) && !Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        public static void CreateFolderIfNotThere(in IMetaAbsolutePathDirectoryGet directoryPath)
        {
            string path = (directoryPath.GetPath());
            if (E_StringUtility.IsFilled(in path) && !Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        public static void CreateTextFileIfNotThere(in string path, in string text)
        {
            if (!File.Exists(path)) {
                string dirPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);
                File.WriteAllText(path, text);
            }
        }
        public static void LoadTexture2DFromFile(in IMetaAbsolutePathFileGet path, out Texture2D texture, bool mipmap = true, bool linear = false)
        {
            if (path == null) { 
                texture = null;
                return;
            }
            path.GetPath(out string p);
            LoadTexture2DFromFile(p, out texture);
        }

        public static void LoadTexture2DFromFile(in string path, out Texture2D texture, bool mipmap=true, bool linear=false) {

            if (Exists(in path))
            {
                byte[] buffer = File.ReadAllBytes(path);
                texture = new Texture2D(1, 1, TextureFormat.RGBA32, mipmap, linear);
                texture.LoadImage(buffer);
                texture.Apply();
            }
            else texture = null;

        }
        public static bool Exists(in IMetaAbsolutePathFileGet path)
        {
            return File.Exists(path.GetPath());
        }
        public static bool Exists(in IMetaAbsolutePathDirectoryGet path)
        {
            return Directory.Exists(path.GetPath());
        }
        public static bool DontExists(in IMetaAbsolutePathFileGet path)
        {
            return !File.Exists(path.GetPath());
        }
        public static bool DontExists(in IMetaAbsolutePathDirectoryGet path)
        {
            return !Directory.Exists(path.GetPath());
        }
        public static bool Exists(in string path)
        {
            return File.Exists(path);
        }
        public static bool DontExists(in string path)
        {
            return !File.Exists(path);
        }
       
        public static void OverrideFilePNG(in IMetaAbsolutePathFileGet path, in Texture2D texture, out bool succced)
        {
            OverrideFilePNG(path.GetPath(), in texture, out succced);
        }
        public static void OverrideFilePNG(in string path, in Texture2D texture, out bool succced)
        {
            MetaAbsolutePathFile f = new MetaAbsolutePathFile(path);
            E_FileAndFolderUtility.CreateFolderIfNotThere(f);

            succced = false;
            try
            {
                File.WriteAllBytes(path, texture.EncodeToPNG());
                succced = true;
            }
            catch {      }
        }
        public static void OverrideFileJPEG(in IMetaAbsolutePathFileGet path, in Texture2D texture, out bool succced)
        {
            OverrideFileJPEG(path.GetPath(), in texture, out succced);
        }
        public static void OverrideFileJPEG(in string path, in Texture2D texture, out bool succced)
        {
            succced = false;
            try
            {
                File.WriteAllBytes(path, texture.EncodeToJPG());
                succced = true;
            }
            catch { }
        }
        public static IMetaAbsolutePathDirectoryGet Combine(in IMetaAbsolutePathDirectoryGet root, in IMetaRelativePathDirectoryGet subfolders)
        {
            E_FilePathUnityUtility.MeltPathTogether(out string pathfolder, root.GetPath(), subfolders.GetPath());
            return new MetaAbsolutePathDirectory(pathfolder);
        }
       
        public static IMetaAbsolutePathFileGet Combine(in IMetaAbsolutePathDirectoryGet root, in IMetaRelativePathDirectoryGet subfolders, in IMetaFileNameWithExtensionGet file)
        {
            E_FilePathUnityUtility.MeltPathTogether(out string pathfolder, root.GetPath(), subfolders.GetPath());
            file.GetFileNameWithExtension(out string fileNameWExt);
            E_FilePathUnityUtility.MeltPathTogether(out string path, pathfolder, fileNameWExt);
            return new MetaAbsolutePathFile(path);
        }
        public static string[] emptyStringArray = new string[0];
        public static IMetaRelativePathDirectoryGet[] emptyDirectoryStringArray = new IMetaRelativePathDirectoryGet[0];
        
            public static IMetaAbsolutePathFileGet Combine(in IMetaAbsolutePathDirectoryGet root, in IMetaRelativePathDirectoryGet[] subfolders, in IMetaFileNameWithExtensionGet file)
        {
            string[] paths = subfolders.Select(k => k.GetPath()).ToArray();
            E_FilePathUnityUtility.MeltPathTogether(out string pathfolder, root.GetPath(), paths);
            file.GetFileNameWithExtension(out string fileNameWExt);
            E_FilePathUnityUtility.MeltPathTogether(out string path, pathfolder, fileNameWExt);
            return new MetaAbsolutePathFile(path);
        }
        public static IMetaAbsolutePathDirectoryGet Combine(in IMetaAbsolutePathDirectoryGet root, params IMetaRelativePathDirectoryGet[] subfolders)
        {
            string[] paths = subfolders.Select(k => k.GetPath()).ToArray();
            E_FilePathUnityUtility.MeltPathTogether(out string path, root.GetPath(), paths);
            return new MetaAbsolutePathDirectory(path);
        }
        public static IMetaAbsolutePathFileGet Combine(in IMetaAbsolutePathDirectoryGet root, in IMetaFileNameWithExtensionGet fileName)
        {
            fileName.GetFileNameWithExtension(out string fileExt);
            E_FilePathUnityUtility.MeltPathTogether(out string path, root.GetPath(), fileExt);
            return new MetaAbsolutePathFile(path);
        }
        public static IMetaAbsolutePathFileGet Combine(in IMetaAbsolutePathDirectoryGet root, in IMetaFileNameWithoutExtensionGet fileName)
        {
            fileName.GetName(out string fileNameAsString);
            E_FilePathUnityUtility.MeltPathTogether(out string path, root.GetPath(), fileNameAsString);
            return new MetaAbsolutePathFile(path);
        }

        public static void MoveOverride(in IMetaAbsolutePathFileGet from, in IMetaAbsolutePathFileGet to, out bool succedTransfert)
        {
            succedTransfert = false;
            string sfrom = from.GetPath(), sto = to.GetPath();

            if (Exists(in sto))
            {
                try
                {
                    File.Delete(sto);
                }
                catch { }
            }

            if (Exists(in sfrom) && Eloi.E_StringUtility.IsFilled(sto)) {
                try
                {
                    File.Move(sfrom, sto);
                    succedTransfert = true;
                }
                catch { }
            }

        }

        public static void GetFilesPathsIn(out string[] paths, IMetaFileNameWithExtensionGet fileOverwatch, IMetaAbsolutePathDirectoryGet directory, bool lookInChildren=true)
        {
            string dPath = directory.GetPath();
            if (E_StringUtility.IsFilled(in dPath) && Directory.Exists(dPath))
            {
                fileOverwatch.GetExtensionWithDot(out string fileExt);
                paths = Directory.GetFiles(dPath, "*" + fileExt, lookInChildren ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            }
            else {
                paths = new string[0];
            }
        }

        public static void MoveOverride(in IMetaAbsolutePathFileGet filePath, in IMetaAbsolutePathDirectoryGet receivedDirectory, out bool succedToMove)
        {
            ExtractFileWithExtension(filePath, out IMetaFileNameWithExtensionGet fileName);
            IMetaAbsolutePathFileGet destination= Combine( in receivedDirectory, in fileName);
            MoveOverride(filePath, destination, out succedToMove);

        }

        public static void ExtractFileWithExtension(in IMetaAbsolutePathFileGet filePath, out IMetaFileNameWithExtensionGet fileName)
        {
            string path = filePath.GetPath();
            string name=Path.GetFileNameWithoutExtension(path),
                extension = Path.GetExtension(path);
            if (E_StringUtility.IsFilled(extension) && extension[0] == '.')
                extension = extension.Substring(1);
            fileName = new MetaFileNameWithExtension(name, extension);
        }

        public static IMetaAbsolutePathFileGet GetParent(in IMetaAbsolutePathFileGet path)
        {
            string p = System.IO.Directory.GetParent(path.GetPath()).FullName;
            return new MetaAbsolutePathFile(p);
        }
        public static IMetaAbsolutePathDirectoryGet GetParent(in IMetaAbsolutePathDirectoryGet path)
        {
            string p = System.IO.Directory.GetParent(path.GetPath()).FullName;
            return new MetaAbsolutePathDirectory(p);
        }


      


        public delegate void AccessTextDefaultIfNeeded(out string textToUse);
        public static void ImportOrCreateThenImport(out string imported, in IMetaAbsolutePathFileGet fileTarget, AccessTextDefaultIfNeeded defaultTextToStore)
        {
            string p = fileTarget.GetPath();
            if (File.Exists(p))
            {
                imported = File.ReadAllText(p);
            }
            else
            {
                E_FileAndFolderUtility.CreateFolderIfNotThere(fileTarget);
                defaultTextToStore(out string textToUse);
                imported = textToUse;
                File.WriteAllText(p,textToUse);
            }
        }
        public static void ImportOrCreateThenImportIn<T>(ref T jsonableTarget, in IMetaAbsolutePathFileGet fileTarget)
        {
            string p = fileTarget.GetPath();
            if (File.Exists(p))
            {
                string imported = File.ReadAllText(p);
                jsonableTarget = JsonUtility.FromJson<T>(imported);
            }
            else
            {
                string textToExport = JsonUtility.ToJson(jsonableTarget);
                E_FileAndFolderUtility.CreateFolderIfNotThere(fileTarget);
                File.WriteAllText(p, textToExport);
            }
        }


        public static void ExportOrCreateThenImportIn<T>(ref T jsonableTarget, in IMetaAbsolutePathFileGet fileTarget, bool overrideIfExisting=true)
        {
            string p = fileTarget.GetPath();
            E_FileAndFolderUtility.CreateFolderIfNotThere(fileTarget);
            string textToExport = JsonUtility.ToJson(jsonableTarget);

            if (!File.Exists(p)|| (File.Exists(p) && overrideIfExisting))
            {
                File.WriteAllText(p, textToExport);
            }
            ImportOrCreateThenImportIn(ref jsonableTarget, fileTarget);
        }

        public static void ImportTexture(IMetaAbsolutePathFileGet filePath, out Texture2D texture)
        {
            filePath.GetPath(out string path);
            if (File.Exists(path)) {
               byte [] bytes= File.ReadAllBytes(path);
                texture = new Texture2D(2, 2, TextureFormat.ARGB32, true);
                texture.LoadImage(bytes);
                //Color[] pix = texture.GetPixels(); 
                //for (int i = 0; i < pix.Length; i++)
                //    pix[i].a = pix[i].grayscale; 
                //texture.SetPixels(pix); 
                //texture.Apply();

            }
            else texture = null;

        }
        public static void ExportTexture(in IMetaAbsolutePathFileGet filePath, Texture2D texture)
        {
            CreateFolderIfNotThere(in filePath);
            E_FileAndFolderUtility.SplitInfoAsString(in filePath, 
                out string dir,
                out string fileName, out string fileExtension);
            fileExtension = fileExtension.Trim().ToLower();
            if (fileExtension == "png")
                ExportTextureAsPNG(in filePath, texture, true, false);
            if (fileExtension == "tag")
                ExportTextureAsTGA(in filePath, texture, true, false);
            if (fileExtension == "jpg" ||
                fileExtension == "jpeg")
                ExportTextureAsJPEG(in filePath, texture, true, false);
        }
        public static void ExportTextureAsJPEG(in IMetaAbsolutePathFileGet filePath, Texture2D t,
           bool mipmap, bool linear)
        {
            CreateFolderIfNotThere(in filePath);
            byte[] _bytes = t.EncodeToJPG();
            System.IO.File.WriteAllBytes(filePath.GetPath(), _bytes);
            //Debug.Log(_bytes.Length / 1024 + "Kb was saved as: " + filePath.GetPath());

        }

        public static void ExportTextureAsPNG(in IMetaAbsolutePathFileGet filePath, Texture2D t,
            bool mipmap, bool linear)
        {
           
            CreateFolderIfNotThere(in filePath);

            //if (t.format != TextureFormat.ARGB32) {
            //    byte[] pixelsR8 = t.GetRawTextureData();
            //    Color32[] pixelsRGBA32 = new Color32[pixelsR8.Length];
            //    for (int i = pixelsR8.Length - 1; i != -1; i--)
            //    {
            //        byte value = pixelsR8[i];
            //        pixelsRGBA32[i] = new Color32(value, value, value, 255);//simplest R8 to RGBA32 conversion
            //    }
            //    t.SetPixels32(pixelsRGBA32);//updates textureRGBA32 data in CPU memory
            //    t.Apply();
            //}
            byte[] _bytes = t.EncodeToPNG();
            System.IO.File.WriteAllBytes(filePath.GetPath(), _bytes);
            //Debug.Log(_bytes.Length / 1024 + "Kb was saved as: " + filePath.GetPath());

        }
        public static void ExportTextureAsTGA(in IMetaAbsolutePathFileGet filePath, Texture2D t,
           bool mipmap, bool linear)
        {
           
            CreateFolderIfNotThere(in filePath);
            byte[] _bytes = t.EncodeToTGA();
            System.IO.File.WriteAllBytes(filePath.GetPath(), _bytes);
            //Debug.Log(_bytes.Length / 1024 + "Kb was saved as: " + filePath.GetPath());

        }

        public static void ExportByOverriding(in IMetaAbsolutePathFileGet file, string text)
        {
            CreateFolderIfNotThere(in file);
            File.WriteAllText(file.GetPath(), text);
        }
        public static void ExportByOverridingAsJson<T>(in IMetaAbsolutePathFileGet file, T givenSerializable)
        {
            CreateFolderIfNotThere(in file);
            string json = JsonUtility.ToJson(givenSerializable);
            File.WriteAllText(file.GetPath(), json);
        }
        public static void ImportFromJson<T>(in IMetaAbsolutePathFileGet file, out T returnSerializable)
        {
            CreateFolderIfNotThere(in file);
            string json = File.ReadAllText(file.GetPath());
            returnSerializable = JsonUtility.FromJson<T>(json);
        }
        public static void ImportFromJson<T>(in IMetaAbsolutePathFileGet file, out T returnSerializable, T defaultErrorHappenOrNotThere)
        {
            try
            {
                CreateFolderIfNotThere(in file);
                string json = File.ReadAllText(file.GetPath());
                returnSerializable = JsonUtility.FromJson<T>(json);
            }
            catch (Exception e) {
                returnSerializable = defaultErrorHappenOrNotThere;
            }
        }

        public static void MoveFile(IMetaAbsolutePathFileGet file, IMetaAbsolutePathDirectoryGet directory)
        {
            string p = file.GetPath();
            if (File.Exists(p)) {
                MetaFileNameWithoutExtension filename = new MetaFileNameWithoutExtension(Path.GetFileName(p));
                CreateFolderIfNotThere(directory);
                IMetaAbsolutePathFileGet newFile = Combine(in directory, filename);
                File.Move(p, newFile.GetPath());
            }
        }



        public static bool IsExisting(in IMetaAbsolutePathFileGet fileToLoad)
        {
            return File.Exists(fileToLoad.GetPath());
        }

        public static void CreateFile(IMetaAbsolutePathFileGet fileToLoad, string text)
        {
            CreateFolderIfNotThere(fileToLoad);
            File.WriteAllText(fileToLoad.GetPath(), text);
        }

        public static void ImportFileAsText(IMetaAbsolutePathFileGet fileToLoad, out string text, string defaultValue="")
        {
            if (IsExisting(fileToLoad))
                text = File.ReadAllText(fileToLoad.GetPath());
            else 
                text = defaultValue;
        }

        public static void GetExecutableOrProjectRoot(out string rootpath)
        {

            rootpath = Application.dataPath;

#if PLATFORM_STANDALONE_WIN
            rootpath = Path.Combine( Application.dataPath,"../");
#endif
#if UNITY_EDITOR
            rootpath = Path.Combine(Application.dataPath, "../");
#endif
        }

        public static void GetAllfilesInAndInChildren(IMetaAbsolutePathDirectoryGet m_targetDirectory, out string[] files)
        {
            string directoryPath = m_targetDirectory.GetPath();
            if (Directory.Exists(directoryPath))
                files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
            else files = new string[0];
        }

        public static void GetAllfilesInAndOnlyInFolder(IMetaAbsolutePathDirectoryGet m_targetDirectory, out string[] files)
        {
            string directoryPath = m_targetDirectory.GetPath();
            if(Directory.Exists(directoryPath))
            files = Directory.GetFiles(directoryPath, "*", SearchOption.TopDirectoryOnly);
            else files = new string[0];
        }

        public static void FilterWithSize(in string[] files,
            out List<MetaAbsolutePathFile> filesFound,
            in long minimumFileSize,
            in long maxFileSize)
        {
            filesFound = new List<MetaAbsolutePathFile>();
            if (files == null)
            {
                return;
            }
            for (int i = 0; i < files.Length; i++)
            {
                if (File.Exists(files[i]))
                {
                    FileInfo fi = new System.IO.FileInfo(files[i]);
                    if (fi.Length >= minimumFileSize && fi.Length <= maxFileSize)
                    {
                        filesFound.Add(new MetaAbsolutePathFile(files[i]));
                    }
                }
            }
        }

        public static void CreateOrOverrideFile(IMetaAbsolutePathDirectoryGet whereToSTore, string text, string fileNameWithoutExt, string extentionWithoutDot)
        {
            CreateOrOverrideFile(whereToSTore, text, new MetaFileNameWithExtension(fileNameWithoutExt, extentionWithoutDot));
        }
        public static void CreateOrOverrideFile(IMetaAbsolutePathDirectoryGet whereToSTore, string text, IMetaFileNameWithExtensionGet fileName)
        {
            IMetaAbsolutePathFileGet path = Combine(whereToSTore, fileName);
            CreateFolderIfNotThere(path);
            File.WriteAllText(path.GetPath(), text);
        }

        public static void GetFileInfoFromPath(in IMetaAbsolutePathFileGet filePath,
            out IMetaFileNameWithExtensionGet fileName)
        {
           fileName = new MetaFileNameWithExtension(Path.GetFileName(filePath.GetPath()));
        }

        public static void GetDirectoryPathFromPath(in IMetaAbsolutePathFileGet file,
            out IMetaAbsolutePathDirectoryGet directory)
        {
            directory= new MetaAbsolutePathDirectory( Path.GetDirectoryName(file.GetPath()));
        }

        public static void GetFileNameFrom(in IMetaAbsolutePathFileGet file, out IMetaFileNameWithExtensionGet fileName)
        {

            fileName = new MetaFileNameWithExtension(Path.GetFileName(file.GetPath()));
        }

      
        public static IEnumerator LoadFileWithCoroutine(IMetaAbsolutePathFileGet file, Action<string> pushTextAsLine)
        {

            string path = file.GetPath();
            if (File.Exists(path))
            {

                using (var www = new UnityWebRequest("file:///" + path))
                {
                    www.downloadHandler = new DownloadHandlerBuffer();
                    yield return www.SendWebRequest();
                    pushTextAsLine.Invoke(www.downloadHandler.text);
                }
            }
        }

        public static void SplitInfo(in IMetaAbsolutePathFileGet file, out IMetaAbsolutePathDirectoryGet directoryFound, out IMetaFileNameWithExtensionGet fileFound)
        {
            GetDirectoryPathFromPath(in file, out directoryFound);
            GetFileInfoFromPath(in file, out fileFound);
        }

        public static void SplitInfoAsString(in IMetaAbsolutePathFileGet file, out string directoryPathOfFile, out string fileName, out string fileExtension)
        {
            if (file == null)
            {
                directoryPathOfFile = "";
                fileName = "";
                fileExtension = "";
                return;
            }
            GetDirectoryPathFromPath(in file, out IMetaAbsolutePathDirectoryGet directoryFound);
            GetFileInfoFromPath(in file, out IMetaFileNameWithExtensionGet fileFound);

            directoryFound.GetPath(out directoryPathOfFile);
            fileFound.GetFileNameWithoutExtension(out fileName);
            fileFound.GetExtensionWithoutDot(out fileExtension);


        }

        public static void DeleteFile(in IMetaAbsolutePathFileGet toDeleteFile)
        {
            if (toDeleteFile == null)
                return;
            toDeleteFile.GetPath(out string p);
            if (File.Exists(p))
                File.Delete(p);
        }

        public static void Move(IMetaAbsolutePathDirectoryGet from
            , IMetaAbsolutePathDirectoryGet to, bool overrideFile)
        {
            throw new NotImplementedException();
        }

        public static bool IsNotLock(IMetaAbsolutePathFileGet m_destinationImage)
        {
            if (m_destinationImage == null)
                return false;
            m_destinationImage.GetPath(out string p);
            if (!File.Exists(p))
                return false;

            FileInfo fi = new FileInfo(p);
            return !IsFileLocked(fi);
        }
        public static bool IsLock(IMetaAbsolutePathFileGet m_destinationImage)
        {
            if (m_destinationImage == null)
                return false;
            m_destinationImage.GetPath(out string p);
            if (!File.Exists(p))
                return false;

            FileInfo fi = new FileInfo(p);
            return IsFileLocked(fi);
        }
        public static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        public static void GetAllDirectoriesInAndInChildren(IMetaAbsolutePathDirectoryGet targetDirectory, out string[] directories)
        {
            directories=Directory.GetDirectories(targetDirectory.GetPath(), "*", SearchOption.AllDirectories);
        }

        public static void GetAllDirectoriesInAndOnlyInFolder(IMetaAbsolutePathDirectoryGet targetDirectory, out string[] directories)
        {
            directories= Directory.GetDirectories(targetDirectory.GetPath(), "*", SearchOption.TopDirectoryOnly);
        }

        public static void GetRelativePathFrom(in IMetaAbsolutePathDirectoryGet root, in IMetaAbsolutePathFileGet selection,
            out IMetaRelativePathFileGet relativePath)
        {
            GetRealPathOfExistingDirectory(root, out IMetaAbsolutePathDirectoryGet rootRealPath);
            GetRealPathOfExistingFile(selection, out IMetaAbsolutePathFileGet selectionRealPath);
            string relative = SubstractRootPath(rootRealPath.GetPath(), selectionRealPath.GetPath());
            relativePath = new MetaRelativePathFile(relative);
        }
        public static void GetRelativePathFrom(in IMetaAbsolutePathDirectoryGet root, in IMetaAbsolutePathDirectoryGet selection,
           out IMetaRelativePathDirectoryGet relativePath)
        {
            GetRealPathOfExistingDirectory(root, out IMetaAbsolutePathDirectoryGet rootRealPath);
            GetRealPathOfExistingDirectory(selection, out IMetaAbsolutePathDirectoryGet selectionRealPath);
            string relative = SubstractRootPath(rootRealPath.GetPath(), selectionRealPath.GetPath());
            relativePath = new MetaRelativePathDirectory(relative);
        }

        public static void GetRealPathOfExistingFile(IMetaAbsolutePathFileGet file, out IMetaAbsolutePathFileGet newFilePath)
        {
            if (file == null || !File.Exists(file.GetPath()))
            {
                newFilePath = file;
                return;
            }
            newFilePath = new MetaAbsolutePathFile((new FileInfo(file.GetPath())).FullName);
        }
        public static void GetRealPathOfExistingDirectory(IMetaAbsolutePathDirectoryGet file, out IMetaAbsolutePathDirectoryGet newDirectoryPath)
        {
            if (file == null || !Directory.Exists(file.GetPath()))
            {
                newDirectoryPath = file;
                return;
            }
            newDirectoryPath = new MetaAbsolutePathDirectory((new DirectoryInfo(file.GetPath())).FullName);
        }

        private static string SubstractRootPath(string root, string selection)
        {
            Eloi.E_FilePathUnityUtility.AllSlash(root, out root);
            Eloi.E_FilePathUnityUtility.AllSlash(selection, out selection);
            //Debug.Log("root:" + root + "\nselect:" + selection);
            string relative = selection.Replace(root, "");
            if (relative.Length > 0 && ( relative[0] == '\\' || relative[0] == '/') )
                relative = relative.Substring(1);
            return relative;
        }

        public static void AppendTextAtStart(IMetaAbsolutePathFileGet target, string textToAppend)
        {
            if (!Exists(target)) {
                ExportByOverriding(target, textToAppend);
            }
            else {
                ImportFileAsText(target, out string text, "");
                ExportByOverriding(target, textToAppend + text);
            }
        }
        public static void AppendTextAtEnd(IMetaAbsolutePathFileGet target, string textToAppend)
        {
            if (!Exists(target))
            {
                ExportByOverriding(target, textToAppend);
            }
            else {
                ImportFileAsText(target, out string text, "");
                ExportByOverriding(target,  text+ textToAppend);
            }
        }
        public static void IsContentAreNotEquals(IMetaAbsolutePathFileGet a, IMetaAbsolutePathFileGet b, out bool areNotEqual, bool ignoreCase = false, bool useTrim = true)
        {
            IsContentAreEquals(a, b,out bool areEqualsValue, ignoreCase, useTrim);
            areNotEqual = !areEqualsValue;
        }
            public static void IsContentAreEquals(IMetaAbsolutePathFileGet a, IMetaAbsolutePathFileGet b, out bool areEquals, bool ignoreCase=false, bool useTrim=true)
        {
            if (a==null || b==null ||  DontExists(a) || DontExists(b))
            {
                areEquals = false;
                return;
            }
            ImportFileAsText(a, out string textA);
            ImportFileAsText(b, out string textB);
            areEquals = Eloi.E_StringUtility.AreEquals(textA, textB, ignoreCase, useTrim);
        }

        public static void IsFileNameAndSizeAreEquals(AbstractMetaAbsolutePathFileMono m_readOnlyFileStorageLocker, AbstractMetaAbsolutePathFileMono m_readOnlyFileStorageLockerDouble, out bool areEquals)
        {
            throw new NotImplementedException();
        }


        //public class CoroutinePourcentState {
        //    public float m_pourcentProcessing;
        //    public bool m_finished;
        //    public bool m_processing;
        //    public bool m_errorHappened;

        //    public void SetPourcentDone(float pourcentDone) {
        //        pourcentDone = Mathf.Clamp01(pourcentDone);
        //        m_pourcentProcessing = pourcentDone;
        //    }
        //    public void SetAsFinishedSuccessfully() { m_errorHappened = false; m_processing = false; m_finished = true; }
        //    public void SetAsHadError() { m_errorHappened = true; m_processing = false; m_finished = false; }
        //}
        //public static IEnumerator FilterWithSize( string[] files,
        //   List<MetaAbsolutePathFile> filesFound,
        //   CoroutinePourcentState pourcentDoneRef,
        //   long minimumFileSize,
        //   long maxFileSize
        //   )
        //{
        //    if(pourcentDoneRef ==null)
        //    pourcentDoneRef = new CoroutinePourcentState();
        //    filesFound = new List<MetaAbsolutePathFile>();
        //    if (files == null)
        //    {
        //        pourcentDoneRef.SetAsFinishedSuccessfully();
        //        yield return null;
        //    }
        //    for (int i = 0; i < files.Length; i++)
        //    {
        //        if (File.Exists(files[i]))
        //        {
        //            FileInfo fi = new System.IO.FileInfo(files[i]);
        //            if (fi.Length >= minimumFileSize && fi.Length <= maxFileSize)
        //            {
        //                filesFound.Add(new MetaAbsolutePathFile(files[i]));
        //            }
        //        }
        //        pourcentDoneRef.SetPourcentDone(i / (float)files.Length);
        //       // yield return;
        //    }

        //    pourcentDoneRef.SetAsFinishedSuccessfully();
        //}
    }
}