module Utils

open Fable.Core
open Feliz

/// <summary>
/// Converts a ReactElement to a JSX.Element
/// </summary>
let inline toJsx (el : ReactElement) : JSX.Element = unbox el

/// <summary>
/// Converts a JSX.Element to a ReactElement
/// </summary>
let inline toReact (el : JSX.Element) : ReactElement = unbox el

/// <summary>
/// Enables use of Feliz styles within a JSX hole
/// </summary>
let inline toStyle (styles : IStyleAttribute list) : obj =
    JsInterop.createObj (unbox styles)

/// <summary>
/// Converts a list of strings and booleans to a string of classes
/// </summary>
let toClass (classes : (string * bool) list) : string =
    classes
    |> List.choose (fun (c, b) ->
        match c.Trim(), b with
        | "", _
        | _, false -> None
        | c, true -> Some c)
    |> String.concat " "