module App

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<Erase>]
type Tauri =
    [<Import("invoke", "@tauri-apps/api/core")>]
    static member invoke(cmd : string, ?invokeParams : obj) : JS.Promise<_> = jsNative

[<JSX.Component>]
let App () : JSX.Element =
    let greetMsg, setGreetMsg = React.useState ""
    let name, setName = React.useState ""
    let counter, setCounter = React.useState 0

    /// Learn more about Tauri commands at https://tauri.app/v1/guides/features/command
    let greet () : unit =
        promise {
            let! (greetMsg : string) =
                Tauri.invoke (
                    "greet",
                    createObj [
                        "name" ==> name
                    ]
                )
            setGreetMsg greetMsg
        }
        |> Promise.start

    let onSubmit (e : Browser.Types.Event) : unit =
        e.preventDefault()
        greet()

    let onChange (e : Browser.Types.Event) : unit =
        let value : string =
            !!e.target?value
        setName value

    let onClickIncrement (_ : Browser.Types.Event) : unit =
        setCounter (counter + 1)

    let onClickDecrement (_ : Browser.Types.Event) : unit =
        setCounter (counter - 1)

    JSX.jsx $"""
    import reactLogo from "./public/react.svg";
    import fableLogo from "./public/fable.svg";
    import viteLogo from "./public/vite.svg";
    import tauriLogo from "./public/tauri.svg";
    <div className="container">
      <h1>Welcome to Tauri!</h1>

      <div className="row">
        <a href="https://vitejs.dev" target="_blank">
          <img src={{viteLogo}} className="logo vite" alt="Vite logo" />
        </a>
        <a href="https://tauri.app" target="_blank">
          <img src={{tauriLogo}} className="logo tauri" alt="Tauri logo" />
        </a>
        <a href="https://reactjs.org" target="_blank">
          <img src={{reactLogo}} className="logo react" alt="React logo" />
        </a>
        <a href="https://fable.io" target="_blank">
          <img src={{fableLogo}} className="logo react" alt="Fable logo" />
        </a>
      </div>

      <p>Click on the logos to learn more.</p>

      <form
        className="row"
        onSubmit={onSubmit}
      >
        <input
          id="greet-input"
          onChange={onChange}
          placeholder="Enter a name..."
        />
        <button type="submit">Greet</button>
      </form>

      <p>{greetMsg}</p>
      
      <div className="row">
        <button onClick={onClickDecrement}>Decrement</button>
        <p className="count-display">Count: {counter}</p>
        <button onClick={onClickIncrement}>Increment</button>
      </div>
    </div>
    """
