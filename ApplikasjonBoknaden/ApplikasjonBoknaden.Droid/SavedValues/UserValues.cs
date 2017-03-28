using System;
using Android.Content;

namespace ApplikasjonBoknaden.Droid.SavedValues
{
    public static class UserValues
    {

        /*Gets and returns Boolean from savedUserPrefs*/
        public static Boolean getBooleanPrefs(String prefName, ISharedPreferences sP)
        {

            return sP.GetBoolean(prefName, false);
        }

        public static String getStringPrefs(String savedPrefName, ISharedPreferences sP)
        {
            return sP.GetString(savedPrefName, "Oslo");
        }

        public static void saveStringPrefs(String prefName, String value, ISharedPreferencesEditor sPEditor)
        {
            sPEditor.PutString(prefName, value);
            sPEditor.Commit();
        }

        public static void saveBooleanPrefs(String prefName, Boolean value, ISharedPreferencesEditor sPEditor)
        {
            sPEditor.PutBoolean(prefName, value);
            sPEditor.Commit();
        }
    }
}