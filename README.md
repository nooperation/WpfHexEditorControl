![example](Logo.png?raw=true)

## Wpf HexEditor control       (Developped in C# 7.0 / Framework 4.5)
A fast, fully customisable Wpf user control for editing file or stream as hexadecimal.


Sample with standard ASCII character table
![example](Sample8-NOTBL.png?raw=true)

Sample with Thingy character table on SNES Final Fantasy II US
![example](Sample8-TBL.png?raw=true)

## NUGET  Last version : 2017-09 (v1.2.1)
https://www.nuget.org/packages/WPFHexaEditor/

## Somes features
- Localized in English, French, Russian and Chinese
- Include HexBox, an Hexadecimal TextBox with spinner
- Modify and Delete bytes
- Save changes
- Fill selection (or another array) with byte.
- Replace byte by another one.
- Support Brush for customize background, selection, highlight and more 
- Support of common key in window like CTRL+C, CTRL+V, CTRL+Z, CTRL+A, ESC...
- Copy to clipboard as code like C#, VB.Net, C, Java, F# ... 
- Support TBL character table file insted of default ASCII.
- Choose color set of TBL string via dependency property
- Selection with mouse/keyboard or property
- Choose the number of byte per line to show 
- Unlimited Undo (no redo for now)
- Move in file with mouse wheel / or keyboard
- Finds methods (FindFirst, FindNext, FindAll, FindLast, FindSelection) and overload for (string, byte[])
- Highlight byte with somes find methods
- Scollbar marker for selection start and byte finded
- Set Bookmark
- Group byte in block 
- Show data as hexadecimal or decimal
- ...

## How to use
Add a reference to `WPFHexaEditor.Control.dll` from your project, then add the following namespace to your XAML:

```xaml
xmlns:Control="clr-namespace:WPFHexaEditor.Control;assembly=WPFHexaEditor.Control"
```

Insert the control like this:

```xaml
<Control:HexaEditor/>
<Control:HexaEditor Width="NaN" Height="NaN"/>
<Control:HexaEditor Width="Auto" Height="Auto"/>
<Control:HexaEditor FileName={Binding FileNamePath} Width="Auto" Height="Auto"/>
```
