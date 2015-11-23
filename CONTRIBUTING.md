If you are interested in contributing to Journaley, please first contact the project owners via [email](mailto:journaleyapp@gmail.com).

This page contains many git commands that you can run from your console. Please feel free to use a GUI git client that you are comfortable with to perform the equivalent operations. (yyoon uses [SourceTree](https://www.sourcetreeapp.com/), and it works great on Windows.)


## Preparation steps

The following steps should be followed only once, when you first start contributing to Journaley.

1.  Fork Journaley into your own GitHub account.
2.  Clone your fork to your local machine.
3.  Add the original Journaley repo as "upstream" by:  
    ```
    git remote add upstream https://github.com/yyoon/Journaley.git
    ```

The concept of `origin` and `upstream` remotes are well explained in [here](http://stackoverflow.com/a/9257901/922135).


## Building the project

It is recommended to use Visual Studio 2013 Community Edition to build the project, which is free for open-source projects.
If you have VS 2012 installed, it should work fine, too.
You can download it from [here](https://www.visualstudio.com/en-us/news/vs2013-community-vs.aspx).

Open the Journaley.sln file at the repository root, and build the solution.
The necessary dependencies will automatically be installed via Nuget Package Manager.


## Branching model

Journaley follows [Vincent Driessen's git-flow model](http://nvie.com/posts/a-successful-git-branching-model/).
Please read his article before moving on.

As a contributor, you only need to care about how to create a new feature branch.
All the other steps (closing a feature, releasing, ...) will be directly handled by the project owners.


## Starting a new feature branch

Whenever you work on a new feature or a bug-fix, create a new feature branch off of `develop`.
You can use the following command to create a feature branch.

    git checkout -b feature/<feature_name> develop

You can make as many commits as you want on the feature branch.


## Creating a pull request

When you think you are done with the feature implementation,
create a pull request from your feature branch.

1.  Pull the up-to-date changes from upstream, and rebase your feature branch onto the new develop.  
    (See the sections below for more details)
2.  Push your feature branch to origin  
    ```
    git push origin feature/<feature_name>
    ```
3.  Create a new pull request from `<your_fork>:feature/<feature_name>` to `yyoon:develop`.  
    (GitHub Help: [Creating a pull request](https://help.github.com/articles/creating-a-pull-request/))
4.  Once the pull request has been submitted, the code will be reviewed by the project owners.
    If the code changes look good, the branch will be merged into `yyoon:develop` branch.  
    (Once this is done, the feature branch is closed, and you are fine to delete your feature branch at this point.)
5.  Otherwise, you will get some comments about what needs to be improved.
    Make sure that you address all the comments in your next commits.
    You can simply make more commits to your feature branch, and then push them to `origin` when you're ready again.  
    (NOTE: if you have rebased your feature branch after the last push, you have to add `--force` parameter to your push command: `git push --force origin feature/<feature_name>`)  
    The new changes will automatically appear in the pull request, and you need not create a new pull request.
5.  Repeat Step 4 until your feature branch gets merged in.


## Updating the changes from upstream

When you want to update all the new changes made in the upstream repository to your local repository (including when your pull request has been just merged), run the following command on your develop branch.

    git checkout develop      # run this only if you are not currently on the develop branch
    git pull upstream develop

Run this command often so that your repository is in sync with the upstream repository as much as possible.


## Rebasing 

After pulling the upstream changes, you might want to rebase your feature branch onto the new develop branch. You can do this by:

    git checkout feature/<feature_name>
    git rebase develop

The concept of rebasing and the details of resolving conflicts is out of scope of this document.
