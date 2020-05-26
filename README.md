# FeOverlay
### Explanation
A built from ground up rendering helper/system in C# that uses windows buffering as a source for GDI+ that doesn't require windowed or borderless modes to render, is completely undetected from any anti cheat at the moment and hooks keyboard not using getkeystate or getasynckeystate with performance in mind.
### Benefits of choosing FeOverlay
- Undetected from any modern day anti cheat
- Works with fullscreen enabled and different refresh rates
- A fully undetected keyboard hook
- Simple to initialize
- Fully featured logging system
### Cons of choosing FeOverlay
- Quite flickery
- Issues WILL happen if hooks are disposed as they are in the example
- Does not include driver of any kind, BUT one can be implemented quite easily by using google
- Renders out of game as its using windows.
