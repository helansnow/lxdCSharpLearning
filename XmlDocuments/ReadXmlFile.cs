using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace XmlDocuments.CSharpLearning
{
    public class ReadXmlFile
    {
        public static string getCookie(string cookieName)
        {
            //Get the cookie data in the last XML created
            List<Cookie> CookieList = new List<Cookie>();
            try
            {
                //String temporaryInternetFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
                String temporaryInternetFilesPath = @"E:\";
                DirectoryInfo directoryInfo = new DirectoryInfo(temporaryInternetFilesPath);
                DirectoryInfo cookieDirectory = directoryInfo.GetDirectories().First(x => x.Name == "Content.IE5");
                List<FileInfo> xmlList = cookieDirectory.GetFiles().Where(x => x.Extension == ".xml").ToList();
                xmlList.Sort((x, y) => y.CreationTime.CompareTo(x.CreationTime));
                
                XmlDocument xmlDoc = new XmlDocument();
                var fileName = @"E:\Content.IE5\Coo69A8.xml";
                string reader = null;

                try
                {
                    using (var sr = new StreamReader(fileName))
                    {
                        reader = sr.ReadToEnd().Replace("xml:stylesheet", "xml-stylesheet");   
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }

                if (reader != null) 
                    xmlDoc.LoadXml(reader);

                XmlNodeList nodeListCookie = xmlDoc.DocumentElement.SelectNodes("cookie");
                List<XmlNode> cookieStoreIdList = nodeListCookie.Cast<XmlNode>().Where(x => x.ChildNodes[0].InnerText == cookieName).ToList();
                XmlNode cookie = cookieStoreIdList.First(x => x.SelectSingleNode("domain").InnerText.Contains("retailer"));
                CookieList.Add(new Cookie()
                    {
                        Value = cookie.SelectSingleNode("value").InnerText,
                        Expires = DateTime.Parse(cookie.SelectSingleNode("expires").InnerText),
                    });

                CookieList.Sort((x, y) => y.Expires.CompareTo(x.Expires));
                return CookieList[0].Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
