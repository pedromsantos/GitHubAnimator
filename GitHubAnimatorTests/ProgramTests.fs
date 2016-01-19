namespace GitHubAnimator

    module ProgramTests = 
        open NUnit.Framework
        open FsUnit
        open Program
        open System
        open System.IO
        open System.Text

        let defaultOptions = { 
                                    RepositoryOwner = ""; 
                                    RepositoryName = ""; 
                                    File = "";
                                    RevealTemplatePath = "";
                                    OutputPath = "";
                                    Language = ""; 
                                }

        [<Test>]
        let ``Should parse owner from arguments``() =
            let arguments = ["-Owner"; "pedromsantos"]


            (parseCommandLineRec arguments defaultOptions).RepositoryOwner 
            |> should equal arguments.[1]

        [<Test>]
        let ``Should parse repository from arguments``() =
            let arguments = ["-Repository"; "SomeRepository"]


            (parseCommandLineRec arguments defaultOptions).RepositoryName 
            |> should equal arguments.[1]

        [<Test>]
        let ``Should parse file from arguments``() =
            let arguments = ["-File"; "SomeFile.txt"]


            (parseCommandLineRec arguments defaultOptions).File 
            |> should equal arguments.[1]

        [<Test>]
        let ``Should parse reveal template path from arguments``() =
            let arguments = ["-TemplatePath"; ".\\Some\Path"]


            (parseCommandLineRec arguments defaultOptions).RevealTemplatePath 
            |> should equal arguments.[1]

        [<Test>]
        let ``Should parse output path from arguments``() =
            let arguments = ["-OutputPath"; ".\\Some\Path"]


            (parseCommandLineRec arguments defaultOptions).OutputPath 
            |> should equal arguments.[1]

        [<Test>]
        let ``Should parse language from arguments``() =
            let arguments = ["-Language"; "language-xxx"]


            (parseCommandLineRec arguments defaultOptions).Language 
            |> should equal arguments.[1]

        [<Test>]
        let ``Should print error for invalid arguments``() =
            let arguments = ["-InvalidFlag"; "irrelevant value"]

            let output = new StringBuilder()
            Console.SetOut(new StringWriter(output))

            parseCommandLineRec arguments defaultOptions
            |> ignore 
            
            output.ToString() |> should startWith "Option '-InvalidFlag' is unrecognized"
