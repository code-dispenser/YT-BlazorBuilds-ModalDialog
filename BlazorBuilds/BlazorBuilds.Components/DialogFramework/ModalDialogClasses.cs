﻿using BlazorBuilds.Components.Common.Enums;
using BlazorBuilds.Components.Common.Utilities;
using System.Collections;
using System.Linq.Expressions;

namespace BlazorBuilds.Components.DialogFramework;
public class ModalDialogOptions (HorizontalAlignment horizontalAlignment = HorizontalAlignment.Centre, VerticalAlignment verticalAlignment = VerticalAlignment.Centre, int maxWidthPercent = 70)
{
    public string HorizonalPosition { get; } = horizontalAlignment switch { HorizontalAlignment.Left => "flex-start", HorizontalAlignment.Centre => "center", HorizontalAlignment.Right => "flex-end", _ => "center" };
    public string VerticalPosition  { get; } = verticalAlignment switch { VerticalAlignment.Top => "flex-start", VerticalAlignment.Centre => "center", VerticalAlignment.Bottom => "flex-end", _ => "center" };
    public string MaxWidth          { get; } = maxWidthPercent > 90 ? "90%" : maxWidthPercent + "%";

}

public abstract class ModalDialogParameters : IEnumerable<KeyValuePair<string, object>>
{
    Dictionary<string, Object> _parameters = [];
    protected void Add(string key, object value)                     => _parameters.TryAdd(key, value);
    public IEnumerator<KeyValuePair<string, object>> GetEnumerator() =>  _parameters.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()                          =>  GetEnumerator();
}

public class ModalDialogParameters<TDialog> : ModalDialogParameters
{
    public void Add<TData>(Expression<Func<TDialog, object>> dialogParam, TData? data)
    {
        var (paramName, paramType) = GeneralUtilities.GetModalDialogParamType(dialogParam);

        if (paramType != typeof(TData)) new ArgumentException("The data type does not match the component parameter type");

        this.Add(paramName, data!);
    }
}

public class ModalDialogResult
{
    public DialogResultButtons ButtonClicked { get; }
    public object Data       { get; }
    public Type   DataType   { get; }
    public string ButtonText { get; }

    private ModalDialogResult (DialogResultButtons buttonClicked, Type dataType, object data, string buttonText)
    
        => (ButtonClicked, DataType, Data,ButtonText) = (buttonClicked, dataType, data, buttonText);

    public static ModalDialogResult OK<T>(T data)

        => new(DialogResultButtons.Ok, typeof(T), GeneralUtilities.ThrowIfNullEmptyOrWhitespace(data)!, "OK");
    
    public static ModalDialogResult Other<T>(string buttonText, T data)

        => new(DialogResultButtons.Other, typeof(T), GeneralUtilities.ThrowIfNullEmptyOrWhitespace(data)!, buttonText);

    public static ModalDialogResult OK()                     => new(DialogResultButtons.Ok, typeof(NoReturnValue), NoReturnValue.Value, "OK");
    public static ModalDialogResult Cancel()                 => new(DialogResultButtons.Cancel, typeof(NoReturnValue), NoReturnValue.Value, "Cancelled");
    public static ModalDialogResult Other(string buttonText) => new(DialogResultButtons.Other, typeof(NoReturnValue), NoReturnValue.Value, buttonText);

}

public record NoReturnValue
{
    public static readonly NoReturnValue Value = new();
    private NoReturnValue() { }
    public override string ToString() => "Ø";
}
