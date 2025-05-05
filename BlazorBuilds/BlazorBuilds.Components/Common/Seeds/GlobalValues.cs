using BlazorBuilds.Components.Common.Enums;

namespace BlazorBuilds.Components.Common.Seeds;

internal class GlobalValues
{
    public const string Argument_Null_Empty_Exception_Message = "The argument cannot be null or empty.";

    public const string JavaScript_File_Path                  = "./_content/BlazorBuilds.Components/assets/js/modal-Dialog.js";
    public const string JavaScript_Open_Modal_Func            = "openModalDialog";
    public const string JavaScript_Close_Modal_Func           = "closeModalDialog";

    public const string DialogFramework_Class                 = "dialog-framework";
    public const string DialogFramework_Window_Class          = $"{DialogFramework_Class}__window";

}
