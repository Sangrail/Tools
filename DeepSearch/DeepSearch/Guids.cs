// Guids.cs
// MUST match guids.h
using System;

namespace deadcode.DeepSearch
{
    static class GuidList
    {
        public const string guidDeepSearchPkgString = "82929af9-ccf4-403b-8148-6918c9da00d8";
        public const string guidDeepSearchCmdSetString = "ee0161c7-bc70-45e1-b76f-e961395c81e2";
        public const string guidToolWindowPersistanceString = "f362e01e-6579-47ea-873d-518de1f4fc3c";
        public const string guidDeepSearchEditorFactoryString = "3b266595-e70f-436f-89bf-72cf6f9e47ce";

        public static readonly Guid guidDeepSearchCmdSet = new Guid(guidDeepSearchCmdSetString);
        public static readonly Guid guidDeepSearchEditorFactory = new Guid(guidDeepSearchEditorFactoryString);
    };
}