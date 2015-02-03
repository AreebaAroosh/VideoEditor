using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;


class Methods
{

    public static string strGetVideoDuration(string strVideo)
    {
        string strDuration;



        return 
    }



    /// <summary>
    /// Runs command and then gets the info it spits out
    /// </summary>
    /// <param name="program"></param>
    /// <param name="arguments"></param>
    /// <param name="strWorkingDirectory"></param>
    /// <returns></returns>
    public static string RunCommandGetOutput(string program, string arguments, string strWorkingDirectory)
    {
        string output = "";

        Process p = new Process();
        ProcessStartInfo info;
        StreamReader errors;

        // set the process up to look in the correct directory for the working file and
        // VERY IMPORTANT - UseShellExecute = false because .NET looks in a different
        // location (?!?!) if it is set to true (which is default)
        info = new ProcessStartInfo(program);
        info.UseShellExecute = false;
        info.WorkingDirectory = strWorkingDirectory;

        info.Arguments = arguments;

        info.WindowStyle = ProcessWindowStyle.Hidden;
        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        p.StartInfo = info;

        // Start the process, wait for it to end
        p.StartInfo.Verb = "runas";
        p.Start();
        p.BeginOutputReadLine();

        // Read the standard error from the application, write it to console, and log it
        errors = p.StandardError;
        output += errors.ReadToEnd();
        p.WaitForExit();
        return output;
    }

    public static void CreateWorkingDir
    {
        Directory.
    }
}

