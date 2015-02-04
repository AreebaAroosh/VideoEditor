using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Video_Editor
{

    class Methods
    {

        public static string strGetVideoDuration(string strVideo)
        {
            // get the ffmpeg output of the video
            string strDuration;
            strDuration = RunCommandGetOutput(Defines.strFFMPEGDir, " -i " + strVideo);

            // get just the duration string
            strDuration = GetDuartionLine(strDuration);

            //substring the duration out
            strDuration = strDuration.Substring(12, strDuration.Length - 12);

            return strDuration;
        }



        /// <summary>
        /// Runs command and then gets the info it spits out
        /// </summary>
        /// <param name="program"></param>
        /// <param name="arguments"></param>
        /// <param name="strWorkingDirectory"></param>
        /// <returns></returns>
        public static string RunCommandGetOutput(string program, string arguments)
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
            info.WorkingDirectory = Defines.strWorkingDirectory;

            info.Arguments = arguments;

            info.WindowStyle = ProcessWindowStyle.Minimized;
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

        /// <summary>
        /// Cycles through ffmpeg info to get duration
        /// </summary>
        /// <param name="strLongString"></param>
        /// <returns></returns>
        public static string GetDuartionLine(string strLongString)
        {
            string strShortString = "";

            string[] strLines = strLongString.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            // loop through them
            foreach (string strArray in strLines)
            {
                if (strArray.Contains("Duration"))
                {
                    strShortString = strArray;

                    string[] strCommaSplitter = strShortString.Split(new string[] { "," }, StringSplitOptions.None);
 
                    foreach (string strSecondArray in strCommaSplitter)
                    {
                        if (strSecondArray.Contains("Duration"))
                        {
                            strShortString = strSecondArray;
                        }
                    }

                }
            }

            // return our final string
            return strShortString;
        }
    }
}

