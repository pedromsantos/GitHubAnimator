namespace GitHubAnimator

module Program =

    open Animator

    type CommandLineOption = 
                            {
                                RepositoryOwner:string;
                                RepositoryName:string;
                                File:string;
                                RevealTemplatePath:string;
                                OutputPath:string;
                                Language:string;
                            }

    let rec parseCommandLineRec args optionsSoFar = 
        match args with 
        | [] -> 
            optionsSoFar
        | arg::tail ->
            match arg with
            | "-Owner" | "-owner" ->
               let newOptions = { optionsSoFar with RepositoryOwner = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | "-Repository" | "-repository" ->
               let newOptions = { optionsSoFar with RepositoryName = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | "-File" | "-file" ->
               let newOptions = { optionsSoFar with File = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | "-TemplatePath" | "-templatepath" ->
               let newOptions = { optionsSoFar with RevealTemplatePath = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | "-OutputPath" | "-outputpath" ->
               let newOptions = { optionsSoFar with OutputPath = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | "-Language" | "-language" ->
               let newOptions = { optionsSoFar with Language = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | unrecognizedArgument -> 
               printf "Option '%s' is unrecognized\\n" unrecognizedArgument
               printf "usage: GitHubAnimator [-owner repositoryOwner] [-repository repositoryName] [-file fileName] [-templatepath revealTemplatePath] [-outputpath outputPath]"
               optionsSoFar 

    [<EntryPoint>]
    let main argv = 

        let defaultOptions = { 
                                    RepositoryOwner = "pedromsantos"; 
                                    RepositoryName = "FSharpKatas"; 
                                    File = "Bowling.fs";
                                    RevealTemplatePath = ".\\reveal.js";
                                    OutputPath = ".\\Presentation";
                                    Language = "language-fsharp" 
                                }

        let args = argv |> List.ofArray
        let options = parseCommandLineRec args defaultOptions

        let parameters = {
                            Owner = options.RepositoryOwner;
                            Repository = options.RepositoryName;
                            File =  options.File;
                            Language = options.Language;
                            }


        createClient
            |> createPresentation parameters
            |> savePresentation 
                options.RevealTemplatePath 
                options.OutputPath

        0