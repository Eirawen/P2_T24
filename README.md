# P2_T24


Broad Overview of Project Architecture.


Forms inherit the parent PlayerController class. This allows forms to access all of the public
or protected properties of the class and seemed to me the most intuitive way of making changes between forms.

The slime class does not have very many things in it, so we will talk about the SalmonForm class.

The salmonform class presently accomplishes a few things. First, it overrides the parents Move and Jump.
Second, it adds two collision checkers for entering and exiting water.
Third, it adds a flop.
Fourth, it changes the gravity to more closely mimic the buoyancy of water.




The salmonform movement override (protected override void MovePlayer() ) checks if the character is in water,
permits them to move if they are, or else they flop.

The jump override scales the jumpForce with salmonJumpScale, a float that is just used to tweak how powerful the jump should be.

The collision checkers work with a layermask and two unity functions called
OnTriggerEnter2D and OnTriggerExit2D. These are called anytime the game object interacts with a Collider2D object.
Specifically in this case, the layermask checks if the layer of the object is water, and the flips the boolean
inWater depending on if it's exiting or entering.

Flopping is a bit weird. It checks if the player is moving, if they're not, it applies a tiny amount of force
horizontally and vertically. The strange thing is that I do not know why the vertical force is not consistent,
sometimes the salmon goes rather high, sometimes it goes rather low. I dont know why! It should be the same no
matter what. But it sort of mimics proper flopping so im happy to leave it as is.



The most annoying thing was actually the formManager.
Right now, the formManager works by initializing/getting all of the form components currently on the game object. Then it disables/enables them dependent on the form switched to.
This was not my first idea on how to accomplish this task!
After an unfortunately long amoun of time fiddling with it, I settled that we would just have all the forms be components on the player, which enabled and disabled themselves, rather than destroying and creating them over and over again.

As for sprite management,
The sprites are all currently saved on the playerController component, in the form of an array Sprites[].
This is convenient because then in the unity inspector, you can just drag and drop them in, and it'll stay saved, rather than having to navigate file paths.
The current rendition of sprite switching was also not my original plan, but there were a whole bunch of errors when directly accessing the Sprites[] depending on whether or not the PlayerController existed, and so now we have an SwitchSprite method in each of the forms, overriding the empty function signature in the parent PlayerController class.




As for the Camera,
Every frame, it grabs the players position, applies a vertical offset to their y coordinate (so they aren't in the dead center of the screen), and follows them around. It smooths this out with a linear interpolation. The vertical offset and smooth speed can be changed in the inspector. The size can be hardcoded with the variable, but the actual orthographicSize variable is always available in the inspector underneath the general camera parameters.


As for SlimeForm,
slimeform currently does nothing but permit you to use base movement controls and switch the sprite to slime.



