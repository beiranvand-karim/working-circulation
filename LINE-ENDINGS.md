# Line endings

This repo enforces line endings through [`.gitattributes`](.gitattributes) so
that diffs never show spurious `LF` ⇄ `CRLF` changes, no matter how each
contributor has `core.autocrlf` configured locally.

## Policy

| Files | Stored in repo | Checked out as | Why |
| --- | --- | --- | --- |
| Everything text (`* text=auto`) | LF | platform default | Normalized baseline |
| `*.ps1`, `*.bat`, `*.cmd` | LF | **CRLF** | Windows-native scripts; the tooling that runs them expects CRLF |
| `*.sh` | LF | **LF** | Must stay LF to remain runnable on Linux/macOS |
| `*.ico`, `*.db` | as-is | as-is | Binary — never normalized or diffed as text |

In short: text is normalized to **LF inside the repository**, and the
working-tree ending is dictated by the rules above rather than by anyone's
personal Git settings.

## Why you might have seen "LF → CRLF" in a diff

Before this file existed there was no `.gitattributes`, so line endings were
left to each machine's `core.autocrlf`. On Windows with `autocrlf=true`, files
stored as LF get checked out as CRLF, and a tool re-saving a file could surface
that difference as a diff. The `.gitattributes` rules make this deterministic
and the warning goes away.

## One-time renormalize

After adding or changing `.gitattributes`, realign already-tracked files with
the new policy:

```sh
git add --renormalize .
git commit -m "Normalize line endings per .gitattributes"
```

This only restages files whose normalized form changed; it does not touch file
contents beyond line endings.

## Verifying a file's endings

```sh
git ls-files --eol path/to/file      # shows i/<index> w/<working-tree> endings
```
