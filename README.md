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
### Example usage
```
        static void RenderTest()
        {
            while (true)
            {
                Global.Render.DrawRectangle(entity.pos2d.x, entity.pos2d.y, entity.size2d.w, entity.size2d.h, entity.enemy ? Color.Red : Color.Blue);
                Global.Render.FillRectangle(entity.pos2d.x + 1, entity.pos2d.y + 1, entity.size2d.w - 2, entity.size2d.h + 1, Color.Black);
                Global.Render.FillRectangle(entity.pos2d.x + 1, entity.pos2d.y + 1, entity.hp / entity.size2d.w - 1, entity.size2d.h + 1, Color.Green);
            }
        }
```
![](Unknown (4).png)
