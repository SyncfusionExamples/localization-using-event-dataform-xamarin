﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using DataformXamarin;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DataformXamarin.iOS.Localize))]

namespace DataformXamarin.iOS
{
    public class Localize : ILocalize
    {
        public void SetLocale(System.Globalization.CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fr");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("fr");
        }
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "fr";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];

                netLanguage = iOSToDotnetLanguage(pref);
            }
            // this gets called a lot - try/catch can be expensive so consider caching or something
            System.Globalization.CultureInfo ci = null;
            try
            {
                ci = new System.Globalization.CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {
                // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    Console.WriteLine(netLanguage + " failed, trying " + fallback + " (" + e1.Message + ")");
                    ci = new System.Globalization.CultureInfo(fallback);
                }
                catch (CultureNotFoundException e2)
                {
                    // iOS language not valid .NET culture, falling back to English
                    Console.WriteLine(netLanguage + " couldn't be set, using 'fr' (" + e2.Message + ")");
                    ci = new System.Globalization.CultureInfo("fr");
                }
            }

            return ci;
        }
        string iOSToDotnetLanguage(string iOSLanguage)
        {
            Console.WriteLine("iOS Language:" + iOSLanguage);
            var netLanguage = iOSLanguage;

            //certain languages need to be converted to CultureInfo equivalent
            switch (iOSLanguage)
            {
                case "ms-MY":   // "Malaysian (Malaysia)" not supported .NET culture
                case "ms-SG":   // "Malaysian (Singapore)" not supported .NET culture
                    netLanguage = "ms"; // closest supported
                    break;
                case "gsw-CH":  // "Schwiizertüütsch (Swiss German)" not supported .NET culture
                    netLanguage = "de-CH"; // closest supported
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }

            Console.WriteLine(".NET Language/Locale:" + netLanguage);
            return netLanguage;
        }
        string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            Console.WriteLine(".NET Fallback Language:" + platCulture.LanguageCode);
            var netLanguage = platCulture.LanguageCode; // use the first part of the identifier (two chars, usually);

            switch (platCulture.LanguageCode)
            {
                // 
                case "pt":
                    netLanguage = "pt-PT"; // fallback to Portuguese (Portugal)
                    break;
                case "gsw":
                    netLanguage = "de-CH"; // equivalent to German (Switzerland) for this app
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }
            Console.WriteLine(".NET Fallback Language/Locale:" + netLanguage + " (application-specific)");
            return netLanguage;
        }
    }
}
