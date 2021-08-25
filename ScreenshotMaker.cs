using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace msloo.Utilities
{
    public class ScreenshotMaker : MonoBehaviour
    {
        [SerializeField] private KeyCode keyCode = KeyCode.F12;
        [SerializeField] private string folderName = "Screenshots";

        private string path;

        private void Awake()
        {
            path = Path.Combine(Application.persistentDataPath, folderName);

            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
        }

        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
                MakeScreenshot();
        }

        private void MakeScreenshot()
        {
            string fileName = "Screenshot_" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png";
            ScreenCapture.CaptureScreenshot(Path.Combine(path, fileName));
            Debug.Log($"Screenshot with name {fileName} saved!");
        }
    }
}
