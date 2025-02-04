using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace StoreSeleniumProject.Utils;

public class ExtentReporting
{
    private static ExtentReports _extentReports;
    private static ExtentTest _extentTest;

    private static ExtentReports StartReporting()
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"../../../../results/";
        if (_extentReports == null)
        {
            Directory.CreateDirectory(path);

            _extentReports = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(path);

            _extentReports.AttachReporter(htmlReporter);
        }

        return _extentReports;
    }

    public static void CreateTest(string testName)
    {
        _extentTest = StartReporting().CreateTest(testName);
    }

    public static void EndReporting()
    {
        StartReporting().Flush();
    }

    public static void LogInfo(string info)
    {
        _extentTest.Info(info);
    }

    public static void LogPass(string info)
    {
        _extentTest.Pass(info);
    }

    public static void LogFail(string info)
    {
        _extentTest.Fail(info);
    }

    public static void LogScreenshot(string info, string image)
    {
        _extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
    }
}
