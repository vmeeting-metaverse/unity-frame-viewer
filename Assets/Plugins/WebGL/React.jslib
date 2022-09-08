mergeInto(LibraryManager.library, {
  VmeetingRequest: function(status){
    window.dispatchReactUnityEvent("VmeetingRequest", UTF8ToString(status));
  }
});