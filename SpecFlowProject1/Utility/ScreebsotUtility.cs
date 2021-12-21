using ImageMagick;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace SpecFlowProject1.Utility
{
    class ScreebsotUtility:Base
    {

        public String devPath;
        public String qaPath;
        public String resultPath;
        public static String qaFileName;
        public  static String devFileName;
        

        public void TakeScreenshot(String environmentName)
        {
            CreateFolderStructure();
            String fileToSave = "";
            String fileName = "";
            if (environmentName.Equals("QA"))
            {
                fileToSave = qaPath;
                DateTime now = DateTime.Now;
                ScreebsotUtility.qaFileName = now.Hour + "_" + now.Minute + "_" + now.Second + "_" + now.Year + "_" + now.Month + "_" + now.Day;
                fileName = ScreebsotUtility.qaFileName;
            }
            else
            {
                fileToSave = devPath;
                DateTime now = DateTime.Now;
                ScreebsotUtility.devFileName = now.Hour + "_" + now.Minute + "_" + now.Second + "_" + now.Year + "_" + now.Month + "_" + now.Day;
                fileName = ScreebsotUtility.devFileName;
            }

            VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker().RemoveScrollBarsWhileShooting());
            driver.TakeScreenshot(vcd).ToMagickImage().Write(fileToSave+fileName+".png", ImageMagick.MagickFormat.Png);
        }


        public double Compare()
        {
            var screenshot1 = new MagickImage(qaPath+ScreebsotUtility.qaFileName+".png");
            var screenshot2 = new MagickImage(devPath+ScreebsotUtility.devFileName+".png");
            var resultScreenshotErrorMetric = new MagickImage();
            var distortionValue = screenshot1.Compare(screenshot2, ErrorMetric.Absolute, resultScreenshotErrorMetric);
            //var distortionValueSimilarity= screenshot1.Compare(screenshot2, ErrorMetric.StructuralSimilarity, resultScreenshot);
            resultScreenshotErrorMetric.Write(resultPath + GetCurrentTimeFormat() + ".png");
            return distortionValue;
        }




        private void CreateFolderStructure()
        {
            String systemUser = Environment.UserName;
            String mainPath = "C:\\Users\\"+systemUser+"\\Documents\\ImageCompareData";
            CreateDirectory(mainPath);
            String qaFolderPath = mainPath + "\\QA\\";
            String devFolderPath = mainPath + "\\Dev\\";
            String resultsFolderPath = mainPath + "\\results\\";
            CreateDirectory(qaFolderPath);
            CreateDirectory(devFolderPath);
            CreateDirectory(resultsFolderPath);
            this.devPath = devFolderPath;
            this.qaPath = qaFolderPath;
            this.resultPath = resultsFolderPath;
        }

        public void CreateDirectory(String path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private String GetCurrentTimeFormat()
        {
            DateTime now = DateTime.Now;
            return  now.Hour + "_" + now.Minute + "_" + now.Second + "_" + now.Year + "_" + now.Month + "_" + now.Day;
        }



        public void CloseDriver()
        {
            driver.Close();
        }

    }
}
