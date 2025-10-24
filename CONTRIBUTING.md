# Contributing Guidelines

Thank you for your interest in contributing to **GroceryApp_Sprint6_Studenten**! This document describes how we organize work using *Gitflow*, how to set up your branches, submit contributions, and ensure code quality. Please follow these steps to help maintain clarity, consistency, and a stable development process.

---

## Gitflow Workflow

We use the standard Gitflow branching model to structure development. This helps us:

- keep the `main` branch always in a releasable/production-ready state  
- use `develop` for integrating features before release  
- allow hotfixes/releases in a controlled way

Here are the branches we use:

| Branch | Purpose |
|--------|---------|
| `main` | Production‑ready code. Merges only from `release/*` and `hotfix/*`. |
| `develop` | Ongoing development. All feature branches are merged here. When ready, a release branch is cut from this. |
| `feature/<name>` | New features, enhancements, or tasks (e.g. implementing UC05, adding new service, etc.). Branch off from `develop`. |
| `hotfix/<description>` | For urgent fixes when the code in `main` fails in production. Branch off `main`. |
| `docs/<description>` | Documentation updates. Branch off `develop`. |
| `release/<version>` | Prepares a new production release. Branch off `develop`. |

Check for more kinds of branches on [Conventional Branches](https://conventional-branch.github.io/)

### Branch Naming Conventions

- Feature branches: `feature/<short‑description>`  
  *Examples:* `feature/uc05-add-product-to-list`, `feature/login‐authentication`
- Hotfix branches: `hotfix/<issue>`, e.g. `hotfix/login-bug`

### Commit Message Conventions
Use a consistent style for commit messages to improve clarity. A common format is:

```
<type>[optional scope]: <description>

[optional body]

[optional footer(s)]
```

Where `<type>` is one of:
- `feat` — a new feature
- `fix` — a bug fix
- `docs` — documentation only changes
- `style` — formatting, missing semicolons, etc; no code change
- `refactor` — code change that neither fixes a bug nor adds a feature
- `test` — adding missing tests or correcting existing tests
- `chore` — changes to the build process or auxiliary tools and libraries such as documentation

*Examples:*
- `feat(Core.Data): implement GetAvailableProducts logic`
- `fix: uncomment login route in AppShell`

See [Conventional Commits](https://www.conventionalcommits.org/) for more details.

---

## Contribution Process

1. **Fork** the repository and clone to your local machine.  
   ```bash
   git clone <your‑fork‑url>
   cd OOSDD_GroceryApp_Sprint6_Studenten
   git checkout develop
   ```

2. **Sync** your fork regularly with upstream (the original repo) to keep `develop` up to date.

3. **Create a feature branch** off `develop`:  
   ```bash
   git checkout -b feature/<your-feature-name> develop
   ```

4. **Make your changes**, commit often with meaningful messages.

5. **Push your feature branch** to your fork:  
   ```bash
   git push origin feature/<your-feature-name>
   ```

6. **Open a Pull Request (PR)** from your feature branch → `develop` (unless hotfix → `main`). Provide a clear description of what you changed, referencing relevant UC (Use Case) if applicable. Request reviews.

7. **Code review & merge:**  
   - Make sure tests pass, code compiles, UI works.  
   - Fix review feedback.  
   - Squash or clean up minor commits in the PR so history is clear.  
   - When merging features, merge into `develop`.  

---

## Release & Hotfix Process

- **Release Branch**  
  1. Once enough features are implemented and tested (e.g. for a sprint release), create `release/<version>` from `develop`.  
  2. Update version number(s), update documentation, run final integration tests.  
  3. Merge release branch into `main`.  
  4. Create release in GitHub and tag the release. 
  5. Make descriptive release notes.
  6. Publish the release.

- **Hotfix Branch**  
  1. If there is a critical bug in `main`, branch: `hotfix/<description>` from `main`.  
  2. Fix, test.  
  3. Merge hotfix into `main` and `develop`.  
  4. Tag the fix on `main`.  

---

## Additional Guidelines

- Always update **documentation** when needed  
- Ensure consistency in naming, file structure, and project layering (UI / Core / Data).  
- Try to write or maintain tests if possible. Even basic ones help.  
- Use descriptive commit messages; avoid “fixed stuff” or “changes” without context.

---

## Resources

- [Conventional Branches](https://conventional-branch.github.io/) 
- [Conventional Commits](https://www.conventionalcommits.org/)  