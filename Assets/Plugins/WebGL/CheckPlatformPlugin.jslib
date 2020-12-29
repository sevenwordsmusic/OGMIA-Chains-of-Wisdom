var CheckPlatformPlugin = {
   IsMobile: function()
   {
      return UnityLoader.SystemInfo.mobile;
   }
};  
mergeInto(LibraryManager.library, CheckPlatformPlugin);