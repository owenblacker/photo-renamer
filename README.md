# Photo Renamer

I often take photos at protests and Pride events (for example). These all get named automatically by my phone, so I want to rename them all systematically before [uploading them to Wikimedia Commons](https://commons.wikimedia.org/wiki/Special:ListFiles/OwenBlacker).

This C# console app will take pairs of quoted `find` and `replace` arguments before renaming all files. An optional final parameter can provide a [glob](https://en.wikipedia.org/wiki/Glob_(programming)) instead of the default `IMG*.jpg`. Thus usage is:

```PhotoRenamer (find replace)n [filter]```

Calling with no arguments will output usage details.
