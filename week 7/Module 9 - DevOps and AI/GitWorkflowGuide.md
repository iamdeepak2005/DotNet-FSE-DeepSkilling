# Git Workflow Guide

This document outlines the standard Git commands and practices used to manage the repository workflows during full stack development.

## 1. Local Configuration & Clone
Set up your email and identity:
```bash
git config --global user.name "iamdeepak2005"
git config --global user.email "dkag709@gmail.com"
```

Clone the repository:
```bash
git clone https://github.com/iamdeepak2005/DotNet-FSE-DeepSkilling.git
```

## 2. Managing Branches
Create a feature branch and switch to it:
```bash
git checkout -b feature/event-api-refactoring
```

List all local branches:
```bash
git branch
```

## 3. Staging and Committing
Stage modified files and commit with a clean, descriptive message:
```bash
git add .
git commit -m "week 3 framework exercises completed"
```

## 4. Rebase vs Merge
To merge `main` branch changes into your feature branch without introducing unnecessary merge commits (preserving a linear history):
```bash
# Fetch latest main branch
git checkout main
git pull origin main

# Rebase feature branch on top of main
git checkout feature/event-api-refactoring
git rebase main
```

### Resolving Rebase Conflicts
If a conflict occurs, Git will pause:
1. Open the conflicting files and resolve conflicts manually (remove `<<<<<<<`, `=======`, `>>>>>>>`).
2. Stage resolved files:
   ```bash
   git add resolved_file.cs
   ```
3. Continue the rebase:
   ```bash
   git rebase --continue
   ```
4. Push rebased changes (may require force-with-lease):
   ```bash
   git push origin feature/event-api-refactoring --force-with-lease
   ```