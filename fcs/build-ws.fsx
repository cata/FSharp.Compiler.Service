// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"

open Fake
open Fake.Core

let setCommonBuildParams p =
    { p with
        Verbosity = Some MSBuildVerbosity.Minimal
        ToolsVersion = Some "15.0"
        NodeReuse = false
        MaxCpuCount = Some 6 |> Some
        Properties = ["Platform","Any Cpu"; "Configuration","Debug"]
    }

fun  _ -> build setCommonBuildParams "Fcs.WebSharper.sln"
|> Target.Create "Build" 

// start build
Target.RunOrDefault "Build"
