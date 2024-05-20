# P2_T24

## **Player Controller** <br/>
The Player Controller class serves to define many base functionalities of the alien. <br/>
These functionalities may need to be modified dependent on specific forms, and so all forms <br/>
inherit the PC class so that they can modify on a form specific basis. <br/>


## **Forms** 

### SalmonForm <br/>

The salmonform class presently accomplishes a few things. <br/>
First, it overrides the parents Move and Jump. <br/>
Second, it adds two collision checkers for entering and exiting water. <br/>
Third, it adds a flop. <br/>
Fourth, it changes the gravity to more closely mimic the buoyancy of water. <br/>


The collision checkers work with a layermask and two unity functions called <br/>
OnTriggerEnter2D and OnTriggerExit2D. <br/>
These functions are called anytime the game object interacts with a Collider2D object, on entrance and on exit. <br/>
Specifically in this case, the layermask checks if the layer of the object is water, and toggles the boolean <br/>
inWater.


### SlimeForm. <br/>

### CatForm <br/>

## **FormManager**
The formManager works by initializing/retrieving all of the forms on the player object. It enables/disables them dependent on the form switched to. <br/>


## **Sprite management**
The sprites are all currently saved on the Player Controller component, in the form of an array Sprites[].
This is convenient because in the unity inspector you can drag and drop them in.
Attempting to directly access this array when the playercontroller class is disabled (as it is when a form is active) causes problems. The solution is:
Each form saves their sprite on "awake" 
Then they call the switchsprite method on the saved sprite, overriding the empty function signature in the parent PlayerController class.

## **Camera**
Each frame, grabs the players position and applies a vertical offset to their y coordinate. This means it tracks the player + verticaloffset. 
It smooths this out with a linear interpolation. 
The vertical offset and smooth speed can be changed in the inspector. 
The size can be hardcoded with the variable, but the actual orthographicSize variable is always available in the unity inspector underneath the general camera parameters.






