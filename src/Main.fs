module Main

open Feliz
open Browser.Dom
open Fable.Core.JsInterop

open App

importSideEffects "./index.css"

let root = ReactDOM.createRoot(document.getElementById "root")
root.render(React.strictMode [App() |> Utils.toReact])
