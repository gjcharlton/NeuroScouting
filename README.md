# NeuroScouting
Adding Unity project to git repository

Rules+++++++
-This is a matching game that tests a players reaction time, and scores based on such, assuming a correct match is made.
-The player first selects how many trials they would like, (1-9).
-The player is then prompted to begin and the target appears on screen for an allotted amount of time.
-The target then disappears and it is up to the player to remember what the icone was
-The player must accurately and swiftly strike the swift key when the appropriate icon appears
-The player will then be scored based on said swiftness.

Scoring+++++
-Scoring is based on how long the player takes to press the spacebar, immediately following the icon gaining a minute amount of 
visibility.
-The score starts at 100 and decreases over the duration that the icon is active.

Code++++++++
-Two scripts
-One is used to control my canvas elements.
-Another is used to control the Target, which is essentially what makes the entire game.
-The target is a list of sprites.
-The target randomly chooses which one it wants to be the target sprite to match and essentially begins the process from there.
-Following this, the script will save which was chosen as the target and switch gears into randomly choosing which sprite
will be shown next. The matching sprite could be first, last, anywhere in between, as well as invisible.
-Once the player hits the spacebar, whether a loss or win, the list is reset, a new target is chosen, and there is also a chance
for the target to be invisible during the matching portion.
