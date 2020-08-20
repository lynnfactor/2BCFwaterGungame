# 2BCFwaterGungame
This is a digital spin on the class carnival game, water gun race. Use two Adafruit Circuit Playground Expresses to control your character! This game also has the option to use keyboard buttons as controls if needed.

![Image of 2BCF](https://lamakerspace.org/wp-content/uploads/2019/06/2BCF-Logo-circle-364x345-2516.png)

# Alt Controller Setup Guide
Written by Aubrey Isaacman

## Setup
1. Install the [Ardity Unity asset](https://ardity.dwilches.com/) to communicate between the [Adafruit Circuit Playground
Express](https://www.adafruit.com/product/3333), aka CPX, and Unity. Follow the directions of their setup guide first. It can be
found in the install package and will show up in the “Ardity” folder in your “Assets folder”
after you install it.
2. You will need **two** CPX. One will need a battery pack on it; this one will be the player’s.
The other one will be the target, which will be connected to the computer USB port. It will
read input from the player and send that data to Unity via Ardity.
3. Follow [this tutorial](https://learn.adafruit.com/adafruit-circuit-playground-express/set-up-arduino-ide) by Adafruit to set up your Arduino IDE with CPX.
4. Connect the CPX that will be used by the player to your computer USB port and upload
the following code. It can also be found by going to File -> Examples -> Adafruit Circuit
Playground -> Infrared Demos
![Image of IR read code](https://i.imgur.com/O6OCXnl.png)
5. Disconnect this CPX and plug it into a battery pack. Then, plug in the other CPX (the
target) and upload the following code to it. This code can be found in the same place as
the previous code. This CPX will remain plugged into your computer.
![Image of IR send code](https://i.imgur.com/mMrnSru.png)
6. Open the Serial Monitor under the “Tools” menu. Turn on the battery pack and aim the
player’s CPX at the target CPX. Press the left button, then press the right button. It
should look something like this.
![Image of Serial Monitor](https://i.imgur.com/77JLRAv.png)
7. Open your Unity project and open the “PlayerMovementAltCtrl” script. Scroll down to the
Update function
![Image of PlayerMovementAltCtrl script](https://i.imgur.com/SOe7Ye0.png)
8. Go to your Serial Monitor in Arduino and copy the message that printed when you
pressed the left button. Paste that into the if statement on line 72. Then, go back to your
Serial Monitor and copy the message that printed when you pressed the right button.
Paste that into the if statement on line 81.
9. Now, hit play and test your controller!

## To Do

* Add sound effects
* Add background music
* Replace temporary sprites and backgrounds
* General polish/clean up


## Attributes

* All sprites are from flaticon.com
* All background photos are Adobe Stock Images


## Resources

* [Adafruit, Infrared Receive and Send](https://learn.adafruit.com/infrared-ir-receive-transmit-circuit-playground-express-circuit-python?view=all)
* [Adafruit, Infrared Transmit and Receive](https://cdn-learn.adafruit.com/downloads/pdf/infrared-transmit-and-receive-on-circuit-playground-express-in-c-plus-plus-2.pdf)
