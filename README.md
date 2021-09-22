# AUBPTrepo
Compiled programs for the Alcohol Use Behavioral Processing Tasks

# File descriptions
Bart-psychopy.zip – folder containing psychopy materials for the Balloon Analogue Risk Task. Contains an exported python file called bart.py that is used in Beeware.

Helloworld.zip – contains project space for sample Beeware application (currently blank). Main python files can be found by going to src/helloworld. Run on the mac by going to macOS/app/Hello World.

bartBeewareImplementation.zip – our attempt at translating the psychopy BART task into the Beeware framework. Main modifications are done in app.py.

# Coding Issues Description
I am a part of the AUBPT data subteam that is in the process of creating a mobile app containing various RDoc tasks. Currently, we have various tasks operational on PsychoPy, a software that is used to create behavioral experiments and export them to Python or Javascript code. Our next step is to compile these tasks together on a software called Beeware, which can translate a python script into applications that can be opened on Windows, Mac, and mobile devices. Beeware can be set up using this tutorial (https://docs.beeware.org/en/latest/tutorial/tutorial-0.html) and is run by a series of commands on cmd/terminal to create these apps.

To compile python code into an application shell, Beeware creates 3 python files: __init___py, __main.py__, and app.py. The most relevant file is app.py, which contains a main() loop that creates an instance of a class, within which the app’s main code is run through a startup(self) function (example here: https://docs.beeware.org/en/latest/tutorial/tutorial-2.html).

As previously mentioned, PsychoPy can export projects as folders containing python files (along with any images, sounds, data, etc). We need to figure out a general framework for implementing this code into the Beeware framework on app.py to make it functional there. Here are some of the main modifications that I have come up with so far:

Moving images, sounds, etc into resources folder and updating file paths on python script
Handling import statements
Combining toga window scripts with psychopy window scripts

I am more equipped to handle the first two tasks but am less familiar with window graphics and how they may differ across the two platforms. Furthermore, once these points have been addressed, more issues may arise within the code upon running. I have attached 2 files to illustrate the problem. Bart.py is our first functional task on PsychoPy, exported as a python file. App.py is the code skeleton for Beeware. I hope that the code team can help with this issue. Our next step after that will be adding multiple tasks to the same app.py file.
