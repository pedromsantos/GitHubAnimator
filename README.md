# GitHubAnimator
Generate Reveal.js slides from GitHub commits using F# and Octokit

## How Can I Use It?

Start by grabbing the code to GitHubAnimator from [here](https://github.com/pedromsantos/GitHubAnimator)

You should be using a GitHub [Personal access token](https://github.com/settings/tokens). You can use the GitHubAPI as an anonymous user but the request limits are much lower. Make sure you copy the token. Then create an environment variable called githubtoken and set the GitHubToken you got from GitHub as a value. Be careful with the personal access token since it is effectively a replacement for your username and password.

For the time being you need to make a few changes to the code if you want to use GitHubAnimator. I started building a console interface but its still in its infancy. So go to the integration tests module and change this line:

```FSharp
let parameters = { Owner = "pedromsantos"; Repository = "FSharpKatas"; File="Bowling.fs"; Language = "language-fsharp" }
```

Note: Language should be one the the languages prism.js supports and should be in the format language-xxx [Prism languages](http://prismjs.com/#languages-list)

Then go to the last integration test change the hardcoded paths, unignore it and finally execute that test manually. This should generate a Reveal.js presentation in the folder you specified.

The code, as is, is good enough for me :) But if you want to make it friendlier feel free to make a pull request. I make no promises on when, if ever, I'm changing it :)
