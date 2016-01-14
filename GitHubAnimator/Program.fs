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
                            }

    [<EntryPoint>]
    let main argv = 

        let commandLineOptions = { 
                                    RepositoryOwner = "pedromsantos"; 
                                    RepositoryName = "FSharpKatas"; 
                                    File="Bowling.fs";
                                    RevealTemplatePath = ".\\reveal.js";
                                    OutputPath = ".\\Presentation"
                                }

        let parameters = {
                            Owner = commandLineOptions.RepositoryOwner;
                            Repository = commandLineOptions.RepositoryName;
                            File =  commandLineOptions.File;
                            }


        createClient
            |> createPresentation parameters
            |> savePresentation 
                commandLineOptions.RevealTemplatePath 
                commandLineOptions.OutputPath

        0