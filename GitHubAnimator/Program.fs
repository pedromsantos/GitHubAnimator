namespace GitHubAnimator

module Program =
    open Animator

    type CommandLineOption = 
                            {
                                RepositoryOwner:string;
                                RepositoryName:string;
                                File:string;
                                Language:string;
                                RevealTemplatePath:string;
                                OutputPath:string;
                            }

    let rec parseCommandLineRec args optionsSoFar = 
        match args with 
        | [] -> 
            optionsSoFar
        | (arg:string)::tail ->
            match arg.ToLower() with
            | "-owner" | "-o" ->
               let newOptions = { optionsSoFar with RepositoryOwner = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | "-repository" | "-r" ->
               let newOptions = { optionsSoFar with RepositoryName = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | "-file" | "-f"->
               let newOptions = { optionsSoFar with File = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | "-templatepath" | "-template" ->
               let newOptions = { optionsSoFar with RevealTemplatePath = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | "-outputpath" | "-out" ->
               let newOptions = { optionsSoFar with OutputPath = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | "-language" | "-l" ->
               let newOptions = { optionsSoFar with Language = tail.Head }
               parseCommandLineRec tail.Tail newOptions
            | unrecognizedArgument -> 
               printf "Option '%s' is unrecognized\\n" unrecognizedArgument
               printf "usage: GitHubAnimator [-o[wner] repositoryOwner] [-r[epository] repositoryName] [-f[ile] fileName] [-out[putpath] outputPath] [-template[path] revealTemplatePath] [-l[anguage] language]"
               optionsSoFar 

    
    let animatorParametersFromCommandLineOptions options =
        {
            Owner = options.RepositoryOwner;
            Repository = options.RepositoryName;
            File =  options.File;
            Language = options.Language;
         } 

    [<EntryPoint>]
    let main argv = 
        let options =
            { 
                RepositoryOwner = ""; 
                RepositoryName = ""; 
                File = "";
                Language = "";
                RevealTemplatePath = ".\\reveal.js";
                OutputPath = ".\\Presentation";
            }
            |> parseCommandLineRec (argv |> List.ofArray)

        createClient
            |> createPresentation (animatorParametersFromCommandLineOptions options)
            |> savePresentation 
                options.RevealTemplatePath 
                options.OutputPath

        0