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

        [<TestCase("-Owner", "someValue")>]
        [<TestCase("-O", "otherValue")>]
        let ``Should parse owner from arguments`` flag value =
            let arguments = [flag; value]


            (parseCommandLineRec arguments defaultOptions).RepositoryOwner 
            |> should equal arguments.[1]

        [<TestCase("-Repository", "someValue")>]
        [<TestCase("-R", "otherValue")>]
        let ``Should parse repository from arguments`` flag value =
            let arguments = [flag; value]


            (parseCommandLineRec arguments defaultOptions).RepositoryName 
            |> should equal arguments.[1]

        [<TestCase("-File", "someValue")>]
        [<TestCase("-F", "otherValue")>]
        let ``Should parse file from arguments`` flag value =
            let arguments = [flag; value]


            (parseCommandLineRec arguments defaultOptions).File 
            |> should equal arguments.[1]

        [<Test>]
        [<TestCase("-TemplatePath", "someValue")>]
        [<TestCase("-Template", "otherValue")>]
        let ``Should parse reveal template path from arguments`` flag value =
            let arguments = [flag; value]


            (parseCommandLineRec arguments defaultOptions).RevealTemplatePath 
            |> should equal arguments.[1]

        [<Test>]
        [<TestCase("-OutputPath", "someValue")>]
        [<TestCase("-Out", "otherValue")>]
        let ``Should parse output path from arguments`` flag value =
            let arguments = ["-OutputPath"; ".\\Some\Path"]


            (parseCommandLineRec arguments defaultOptions).OutputPath 
            |> should equal arguments.[1]

        [<Test>]
        [<TestCase("-Language", "someValue")>]
        [<TestCase("-L", "otherValue")>]
        let ``Should parse language from arguments`` flag value =
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
            
            output.ToString() |> should startWith "Option "
