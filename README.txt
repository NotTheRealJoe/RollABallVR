Git repository: https://github.com/NotTheRealJoe/RollABallVR

RIGHT joystick only controls ball. It could be set to the left or both.

I was able to implement the ball movements using the "Player" prefab rather than the
"Camera Rig" prefab provided by SteamVR. This made it significantly easier to implement
teleportation, but it probably wasn't worth it because it was so hard to make the
trackpad control the ball. I eventually got the trackpad to control it, but I wasn't able
to successfully take into account the orientation of the player when doing so, so it
moves a bit like a model aircraft (the x and y axes are absolute). You can see some
methods I attempted to use to do this in the commented out code in the TrackPadMover
script, but I didn't have enough time to actually make any of them work.

Also, I tested this throghout on the Oculus, but it should work on the Vive as well.
Sometimes the controllers do not show up when you run the game, as far as I can tell this
is a problem with SteamVR and you just need to try to restart the game making sure the
controllers are in view of the sensors when you do.

Note that there is not really any actual "game" here, there are no collectables and
nothing to really do other than move the ball around.