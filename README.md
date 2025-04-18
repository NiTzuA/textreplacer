![image](https://github.com/user-attachments/assets/728bc936-7621-42c7-9d39-24c55b41412f)

<p>This is a simple program that uses low level keyboard hooks to detect if a certain set of characters was typed and replaces it with a user-defined new set of words. 
  It aims to mimic the "Replace With" feature that document editors like notepad or word have, but it does this in real-time.</p>

<p>The following are the current feature of this small program</p>
<ol>
  <li>Replaces a target text with a user specificed one</li>
  <li>Takes into consideration backspaces when replacing text (100 character history)</li>
  <li>Performce decently well? (I'm not sure about this part)</li>
</ol>

<p>However, this was just a program I made out of boredom, so the following problems and limitations are present</p>
<ol>
  <li>It overrides you clipboard. (I made the text replacement faster to avoid users accidentally interrupting the sendkey operation by doing SetClipboard then SendKeys.Keys("^v")</li>
  <li>While the current backspace operation is fast since it uses ^{BACKSPACE}, fast typers can still accidentally override this.</li>
</ol>

![ezgif-761ceceaed5e0a](https://github.com/user-attachments/assets/5a18d3d7-6cd2-4b1b-b5b7-41b8c58e585a)
