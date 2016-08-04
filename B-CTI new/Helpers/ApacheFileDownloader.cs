using BCTI.DialogBoxes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace BCTI
{
    class ApacheFileDownloader
    {
        /// <summary>
        /// Credentials
        /// </summary>
        private string UserName;
        private string PassWord = string.Empty;
        private string Domain = string.Empty;
        public string Url = string.Empty;
        public string GetDirectoryListingRegexForUrl()
        {
            return "<a href=\".*\">(?<name>.*)</a>";
        }
        public ApacheFileDownloader()
        {

        }
        public ApacheFileDownloader(string _username, string _pass)
        {
            UserName = _username;
            PassWord = _pass;
        }
        /// <summary>
        /// Получение списка страниц с сервера
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public List<string> GetFolderList(string uri)
        {
            string url = uri;
            List<string> files = new List<string>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (string.IsNullOrEmpty(UserName))
            {
                request.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            }
            else
            {
                request.Credentials = new NetworkCredential(UserName, PassWord);
            }
            try
            {

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string html = reader.ReadToEnd();
                        Regex regex = new Regex(GetDirectoryListingRegexForUrl());
                        MatchCollection matches = regex.Matches(html);
                        if (matches.Count > 0)
                        {
                            foreach (Match match in matches)
                            {
                                if (match.Success)
                                    files.Add(match.Groups["name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BMessageBox.Show(ex.Message);
            }
            return files;
        }
        /// <summary>
        /// Скачивание файла с сервера и сохранение в appdata
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="filename"></param>
        public void DownloadFile(string uri, string filename)
        {
            EventLogs.WriteLog(uri);
            WebClient webCl = new WebClient();
            if (!string.IsNullOrEmpty(UserName))
            {
                webCl.Credentials = new NetworkCredential(UserName, PassWord);
            }
            else
            {
                webCl.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            }
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\Playback"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\Playback");
            }
            webCl.DownloadFile(uri+filename, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\Playback\\" + filename);
        }
    }
}
